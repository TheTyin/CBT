Imports System.IO

Module moduleMaps
    Sub loadMap()
        Try
            FormMain.MapList.Items.Add("< none >")

            For Each map As String In My.Computer.FileSystem.GetFiles(Base.dirMaps, FileIO.SearchOption.SearchTopLevelOnly, "*.bsp")
                FormMain.MapList.Items.Add(IO.Path.GetFileNameWithoutExtension(map))
            Next

            FormMain.MapList.SelectedIndex = 0
        Catch ex As Exception
            FormMain.labelProcess.Text = "Launcher can't generate list of maps."
        End Try
    End Sub

    Sub loadMapThumb()
        Try
            Dim mapImage As String() = {Application.StartupPath & "\platform\launcher\maps\" & FormMain.MapList.SelectedItem.ToString & "_cso.png",
                                        Application.StartupPath & "\platform\launcher\maps\random_cso.png"}

            If File.Exists(mapImage(0)) Then
                FormMain.MapThumb.Image = Image.FromFile(mapImage(0))
            ElseIf File.Exists(mapImage(1)) Then
                FormMain.MapThumb.Image = Image.FromFile(mapImage(1))
            End If
        Catch ex As Exception
            FormMain.labelProcess.Text = "Launcher can't show thumbnails of maps."
        End Try
    End Sub

    Sub LoadMapBG()
        Try
            For Each mapBG As String In My.Computer.FileSystem.GetFiles(Base.dirLoadBG, FileIO.SearchOption.SearchTopLevelOnly, "*_loading.tga")
                File.Delete(mapBG)
            Next

            If Directory.Exists(Base.dirGFXMaps & FormMain.MapList.SelectedItem.ToString) Then
                File.Copy(Base.dirGFXMaps & FormMain.MapList.SelectedItem.ToString & "\1024_1_a_loading.tga", Base.dirLoadBG & "1024_1_a_loading.tga")
                File.Copy(Base.dirGFXMaps & FormMain.MapList.SelectedItem.ToString & "\1024_1_b_loading.tga", Base.dirLoadBG & "1024_1_b_loading.tga")
                File.Copy(Base.dirGFXMaps & FormMain.MapList.SelectedItem.ToString & "\1024_1_c_loading.tga", Base.dirLoadBG & "1024_1_c_loading.tga")
                File.Copy(Base.dirGFXMaps & FormMain.MapList.SelectedItem.ToString & "\1024_1_d_loading.tga", Base.dirLoadBG & "1024_1_d_loading.tga")

                File.Copy(Base.dirGFXMaps & FormMain.MapList.SelectedItem.ToString & "\1024_2_a_loading.tga", Base.dirLoadBG & "1024_2_a_loading.tga")
                File.Copy(Base.dirGFXMaps & FormMain.MapList.SelectedItem.ToString & "\1024_2_b_loading.tga", Base.dirLoadBG & "1024_2_b_loading.tga")
                File.Copy(Base.dirGFXMaps & FormMain.MapList.SelectedItem.ToString & "\1024_2_c_loading.tga", Base.dirLoadBG & "1024_2_c_loading.tga")
                File.Copy(Base.dirGFXMaps & FormMain.MapList.SelectedItem.ToString & "\1024_2_d_loading.tga", Base.dirLoadBG & "1024_2_d_loading.tga")

                File.Copy(Base.dirGFXMaps & FormMain.MapList.SelectedItem.ToString & "\1024_3_a_loading.tga", Base.dirLoadBG & "1024_3_a_loading.tga")
                File.Copy(Base.dirGFXMaps & FormMain.MapList.SelectedItem.ToString & "\1024_3_b_loading.tga", Base.dirLoadBG & "1024_3_b_loading.tga")
                File.Copy(Base.dirGFXMaps & FormMain.MapList.SelectedItem.ToString & "\1024_3_c_loading.tga", Base.dirLoadBG & "1024_3_c_loading.tga")
                File.Copy(Base.dirGFXMaps & FormMain.MapList.SelectedItem.ToString & "\1024_3_d_loading.tga", Base.dirLoadBG & "1024_3_d_loading.tga")
            Else
                File.Copy(Base.dirGFXMaps & "none\1024_1_a_loading.tga", Base.dirLoadBG & "1024_1_a_loading.tga")
                File.Copy(Base.dirGFXMaps & "none\1024_1_b_loading.tga", Base.dirLoadBG & "1024_1_b_loading.tga")
                File.Copy(Base.dirGFXMaps & "none\1024_1_c_loading.tga", Base.dirLoadBG & "1024_1_c_loading.tga")
                File.Copy(Base.dirGFXMaps & "none\1024_1_d_loading.tga", Base.dirLoadBG & "1024_1_d_loading.tga")

                File.Copy(Base.dirGFXMaps & "none\1024_2_a_loading.tga", Base.dirLoadBG & "1024_2_a_loading.tga")
                File.Copy(Base.dirGFXMaps & "none\1024_2_b_loading.tga", Base.dirLoadBG & "1024_2_b_loading.tga")
                File.Copy(Base.dirGFXMaps & "none\1024_2_c_loading.tga", Base.dirLoadBG & "1024_2_c_loading.tga")
                File.Copy(Base.dirGFXMaps & "none\1024_2_d_loading.tga", Base.dirLoadBG & "1024_2_d_loading.tga")

                File.Copy(Base.dirGFXMaps & "none\1024_3_a_loading.tga", Base.dirLoadBG & "1024_3_a_loading.tga")
                File.Copy(Base.dirGFXMaps & "none\1024_3_b_loading.tga", Base.dirLoadBG & "1024_3_b_loading.tga")
                File.Copy(Base.dirGFXMaps & "none\1024_3_c_loading.tga", Base.dirLoadBG & "1024_3_c_loading.tga")
                File.Copy(Base.dirGFXMaps & "none\1024_3_d_loading.tga", Base.dirLoadBG & "1024_3_d_loading.tga")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Module
