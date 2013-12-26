Imports System.IO
Imports LibraryOwl.DataBase
Imports System.Text

Public Class FormMain

    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadBar.Value = 0
        labelProcess.Text = "Loading..."

        ' Starting background music
        If File.Exists(Application.StartupPath & "\cstrike\media\GameStartUp.mp3") Then
            Dim bgMusic As New AudioFile(Application.StartupPath & "\cstrike\media\GameStartUp.mp3")
            bgMusic.Play()
        End If

        LoadBar.Value = 10
        labelProcess.Text = "Loading settings..."

        ' Read launcher settings
        Dim LauncherCFG As String = Application.StartupPath & "\platform\launcher\config.ini"

        cvarHostName.Text = ReadIni(LauncherCFG, "Settings", "HOSTNAME", "")
        cvarMaxSlots.Text = ReadIni(LauncherCFG, "Settings", "MAXSLOTS", "")
        cvarBotQuota.Text = ReadIni(LauncherCFG, "Settings", "BOTQUOTA", "")
        cvarMaxRound.Text = ReadIni(LauncherCFG, "Settings", "MAXROUND", "")
        cvarMapLimit.Text = ReadIni(LauncherCFG, "Settings", "MAPLIMIT", "")
        cvarRoundTim.Text = ReadIni(LauncherCFG, "Settings", "ROUNDTIM", "")
        cvarFrezTime.Text = ReadIni(LauncherCFG, "Settings", "FREZTIME", "")
        cvarBuyTimer.Text = ReadIni(LauncherCFG, "Settings", "BUYTIMER", "")
        cvarStartMon.Text = ReadIni(LauncherCFG, "Settings", "STARTMON", "")

        LoadBar.Value = 20
        labelProcess.Text = "Loading maps..."

        ' Load maps
        loadMap()
        loadMapThumb()
        LoadMapBG()

        LoadBar.Value = 80
        labelProcess.Text = "Loading modes..."

        ' Load game mode
        Dim Data As New Data
        Dim Grid As New DataGridView
        Dim LineToReplace() As String = {";", "[id]", "[name]", "[file]"}

        If File.Exists(Base.ModeINI) Then
            Controls.Add(Grid)
            Data.CallData(Grid, LineToReplace, Base.ModeINI)

            For Each row As DataGridViewRow In Grid.Rows
                If (Not row.Cells(0).Value = Nothing) Then
                    Dim changer As New CSOModeChanger

                    changer.Size = New Size(135, 75)
                    changer.GameMode = row.Cells(0).Value
                    changer.Text = row.Cells(1).Value
                    changer.Tag = row.Cells(2).Value

                    modePanel.Controls.Add(changer)

                    AddHandler changer.CheckedChanged, AddressOf Changer_Checked
                End If
            Next

            labelProcess.Text = "Please select mode."
        Else
            MessageBox.Show(Base.ModeINI & " is missing!")
        End If

    End Sub

    Private Sub Changer_Checked(ByVal sender As Object)
        Dim changer As CSOModeChanger = CType(sender, CSOModeChanger)

        If (changer.Checked) Then
            Try
                For Each enabledMode As String In My.Computer.FileSystem.GetFiles(Base.dirAmxCFG, FileIO.SearchOption.SearchTopLevelOnly, "plugins-*.ini")
                    File.Delete(enabledMode)
                Next

                Try
                    File.Delete(Base.dirLoadBG & "mode1.tga")
                    File.Delete(Base.dirLoadBG & "mode2.tga")
                    File.Delete(Base.dirLoadBG & "mode3.tga")
                    File.Delete(Base.dirLoadBG & "mode4.tga")

                    File.Copy(Base.dirGFXMode & changer.Tag & "\mode1.tga", Base.dirLoadBG & "mode1.tga")
                    File.Copy(Base.dirGFXMode & changer.Tag & "\mode2.tga", Base.dirLoadBG & "mode2.tga")
                    File.Copy(Base.dirGFXMode & changer.Tag & "\mode3.tga", Base.dirLoadBG & "mode3.tga")
                    File.Copy(Base.dirGFXMode & changer.Tag & "\mode4.tga", Base.dirLoadBG & "mode4.tga")
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try

                If File.Exists(Base.dirGameModes & "mode_" & changer.Tag & ".ini") Then
                    File.Copy(Base.dirGameModes & "mode_" & changer.Tag & ".ini", Base.dirAmxCFG & "plugins-" & changer.Tag & ".ini")

                    labelProcess.Text = String.Format("{0} is ready to play!", changer.Tag)
                    LoadBar.Value = 100
                Else
                    labelProcess.Text = String.Format("You cannot play {0}!", changer.Tag)
                    LoadBar.Value = 100
                End If

            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub mainNews_Click(sender As Object, e As EventArgs) Handles mainNews.Click
        Process.Start("http://csbte.pixub.com")
    End Sub

    Private Sub mainQuit_Click(sender As Object, e As EventArgs) Handles mainQuit.Click
        FormQuit.Show()

        If FormQuit.Enabled = True Then Me.Enabled = False
    End Sub

    Private Sub gameStart_Click(sender As Object, e As EventArgs) Handles gameStart.Click
        Dim LauncherCFG As String = Application.StartupPath & "\platform\launcher\config.ini"

        writeIni(LauncherCFG, "Settings", "HOSTNAME", cvarHostName.Text)
        writeIni(LauncherCFG, "Settings", "MAXSLOTS", cvarMaxSlots.Text)
        writeIni(LauncherCFG, "Settings", "BOTQUOTA", cvarBotQuota.Text)
        writeIni(LauncherCFG, "Settings", "MAXROUND", cvarMaxRound.Text)
        writeIni(LauncherCFG, "Settings", "MAPLIMIT", cvarMapLimit.Text)
        writeIni(LauncherCFG, "Settings", "ROUNDTIM", cvarRoundTim.Text)
        writeIni(LauncherCFG, "Settings", "FREZTIME", cvarFrezTime.Text)
        writeIni(LauncherCFG, "Settings", "BUYTIMER", cvarBuyTimer.Text)
        writeIni(LauncherCFG, "Settings", "STARTMON", cvarStartMon.Text)

        Dim sb As New StringBuilder()

        Using sr As New StreamWriter(Base.launcherCFG)
            sb.AppendLine("// Config generated by BTE Launcher")
            sb.AppendLine("hostname " & """" & cvarHostName.Text & """")
            sb.AppendLine("bot_quota " & """" & cvarBotQuota.Text & """")
            sb.AppendLine("mp_maxrounds " & """" & cvarMaxRound.Text & """")
            sb.AppendLine("mp_timelimit " & """" & cvarMapLimit.Text & """")
            sb.AppendLine("mp_roundtime " & """" & cvarRoundTim.Text & """")
            sb.AppendLine("mp_freezetime " & """" & cvarFrezTime.Text & """")
            sb.AppendLine("mp_buytime " & """" & cvarBuyTimer.Text & """")
            sb.AppendLine("mp_startmoney " & """" & cvarStartMon.Text & """")
        End Using

        Using outfile As New StreamWriter(Base.launcherCFG)
            outfile.Write(sb.ToString())
        End Using

        Dim CustomParm As String = ReadIni(LauncherCFG, "Launcher", "PARAMETARS", "")

        If File.Exists(Application.StartupPath & "\cstrike.exe") Then
            Process.Start("cstrike.exe", CustomParm & " +map " & MapList.SelectedItem.ToString & ";maxplayers " & cvarMaxSlots.Text)
            Application.Exit()
        Else
            labelProcess.Text = "Game executable is missing or launcher isn't in right directory."
        End If
    End Sub

    Private Sub MapList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles MapList.SelectedIndexChanged
        loadMapThumb()
        LoadMapBG()
    End Sub
End Class
