<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMain))
        Me.CsoMain1 = New Counter_Strike_BreakThrough_3.CSOMain()
        Me.mainNews = New Counter_Strike_BreakThrough_3.CSOMainButton()
        Me.mainQuit = New Counter_Strike_BreakThrough_3.CSOMainButton()
        Me.CsoGroupBox2 = New Counter_Strike_BreakThrough_3.CSOGroupBox()
        Me.labelProcess = New System.Windows.Forms.Label()
        Me.LoadBar = New Counter_Strike_BreakThrough_3.CSOProgressBar()
        Me.gameStart = New Counter_Strike_BreakThrough_3.CSOButton()
        Me.CsoSeperator1 = New Counter_Strike_BreakThrough_3.CSOSeperator()
        Me.modePanel = New System.Windows.Forms.FlowLayoutPanel()
        Me.CsoGroupBox1 = New Counter_Strike_BreakThrough_3.CSOGroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cvarStartMon = New Counter_Strike_BreakThrough_3.CSOTextBox()
        Me.cvarBuyTimer = New Counter_Strike_BreakThrough_3.CSOTextBox()
        Me.cvarFrezTime = New Counter_Strike_BreakThrough_3.CSOTextBox()
        Me.cvarRoundTim = New Counter_Strike_BreakThrough_3.CSOTextBox()
        Me.cvarMapLimit = New Counter_Strike_BreakThrough_3.CSOTextBox()
        Me.cvarMaxRound = New Counter_Strike_BreakThrough_3.CSOTextBox()
        Me.cvarBotQuota = New Counter_Strike_BreakThrough_3.CSOTextBox()
        Me.cvarMaxSlots = New Counter_Strike_BreakThrough_3.CSOTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.MapThumb = New System.Windows.Forms.PictureBox()
        Me.MapList = New Counter_Strike_BreakThrough_3.CSOComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cvarHostName = New Counter_Strike_BreakThrough_3.CSOTextBox()
        Me.CsoMain1.SuspendLayout()
        Me.CsoGroupBox2.SuspendLayout()
        Me.CsoGroupBox1.SuspendLayout()
        CType(Me.MapThumb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CsoMain1
        '
        Me.CsoMain1.Controls.Add(Me.mainNews)
        Me.CsoMain1.Controls.Add(Me.mainQuit)
        Me.CsoMain1.Controls.Add(Me.CsoGroupBox2)
        Me.CsoMain1.Controls.Add(Me.CsoGroupBox1)
        Me.CsoMain1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CsoMain1.Location = New System.Drawing.Point(0, 0)
        Me.CsoMain1.Name = "CsoMain1"
        Me.CsoMain1.Size = New System.Drawing.Size(871, 533)
        Me.CsoMain1.TabIndex = 0
        Me.CsoMain1.Text = "Counter-Strike: BreakThrough"
        '
        'mainNews
        '
        Me.mainNews.ChoosenButton = Counter_Strike_BreakThrough_3.CSOMainButton.ButtonType.News
        Me.mainNews.Location = New System.Drawing.Point(754, 3)
        Me.mainNews.Name = "mainNews"
        Me.mainNews.Size = New System.Drawing.Size(50, 50)
        Me.mainNews.TabIndex = 5
        Me.mainNews.Text = "Website"
        '
        'mainQuit
        '
        Me.mainQuit.ChoosenButton = Counter_Strike_BreakThrough_3.CSOMainButton.ButtonType.Quit
        Me.mainQuit.Location = New System.Drawing.Point(810, 3)
        Me.mainQuit.Name = "mainQuit"
        Me.mainQuit.Size = New System.Drawing.Size(50, 50)
        Me.mainQuit.TabIndex = 2
        Me.mainQuit.Text = "Quit"
        '
        'CsoGroupBox2
        '
        Me.CsoGroupBox2.BackColor = System.Drawing.Color.Red
        Me.CsoGroupBox2.Controls.Add(Me.labelProcess)
        Me.CsoGroupBox2.Controls.Add(Me.LoadBar)
        Me.CsoGroupBox2.Controls.Add(Me.gameStart)
        Me.CsoGroupBox2.Controls.Add(Me.CsoSeperator1)
        Me.CsoGroupBox2.Controls.Add(Me.modePanel)
        Me.CsoGroupBox2.Location = New System.Drawing.Point(260, 64)
        Me.CsoGroupBox2.Name = "CsoGroupBox2"
        Me.CsoGroupBox2.Size = New System.Drawing.Size(600, 457)
        Me.CsoGroupBox2.TabIndex = 1
        '
        'labelProcess
        '
        Me.labelProcess.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.labelProcess.BackColor = System.Drawing.Color.Transparent
        Me.labelProcess.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.labelProcess.ForeColor = System.Drawing.Color.White
        Me.labelProcess.Location = New System.Drawing.Point(12, 421)
        Me.labelProcess.Name = "labelProcess"
        Me.labelProcess.Size = New System.Drawing.Size(482, 13)
        Me.labelProcess.TabIndex = 4
        Me.labelProcess.Text = "Label1"
        '
        'LoadBar
        '
        Me.LoadBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LoadBar.Location = New System.Drawing.Point(15, 437)
        Me.LoadBar.Maximum = 100
        Me.LoadBar.Name = "LoadBar"
        Me.LoadBar.Size = New System.Drawing.Size(479, 10)
        Me.LoadBar.TabIndex = 3
        Me.LoadBar.Text = "CsoProgressBar1"
        Me.LoadBar.Value = 1
        '
        'gameStart
        '
        Me.gameStart.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gameStart.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.gameStart.Font = New System.Drawing.Font("Verdana", 6.75!)
        Me.gameStart.Location = New System.Drawing.Point(500, 424)
        Me.gameStart.Name = "gameStart"
        Me.gameStart.Size = New System.Drawing.Size(87, 23)
        Me.gameStart.TabIndex = 2
        Me.gameStart.Text = "Play"
        '
        'CsoSeperator1
        '
        Me.CsoSeperator1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CsoSeperator1.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.CsoSeperator1.Location = New System.Drawing.Point(3, 403)
        Me.CsoSeperator1.Name = "CsoSeperator1"
        Me.CsoSeperator1.Size = New System.Drawing.Size(594, 15)
        Me.CsoSeperator1.TabIndex = 1
        Me.CsoSeperator1.Text = "CsoSeperator1"
        '
        'modePanel
        '
        Me.modePanel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.modePanel.AutoScroll = True
        Me.modePanel.BackColor = System.Drawing.Color.Transparent
        Me.modePanel.Location = New System.Drawing.Point(3, 14)
        Me.modePanel.Name = "modePanel"
        Me.modePanel.Size = New System.Drawing.Size(594, 383)
        Me.modePanel.TabIndex = 0
        '
        'CsoGroupBox1
        '
        Me.CsoGroupBox1.BackColor = System.Drawing.Color.Red
        Me.CsoGroupBox1.Controls.Add(Me.Label10)
        Me.CsoGroupBox1.Controls.Add(Me.Label9)
        Me.CsoGroupBox1.Controls.Add(Me.Label8)
        Me.CsoGroupBox1.Controls.Add(Me.Label7)
        Me.CsoGroupBox1.Controls.Add(Me.Label6)
        Me.CsoGroupBox1.Controls.Add(Me.Label5)
        Me.CsoGroupBox1.Controls.Add(Me.Label4)
        Me.CsoGroupBox1.Controls.Add(Me.cvarStartMon)
        Me.CsoGroupBox1.Controls.Add(Me.cvarBuyTimer)
        Me.CsoGroupBox1.Controls.Add(Me.cvarFrezTime)
        Me.CsoGroupBox1.Controls.Add(Me.cvarRoundTim)
        Me.CsoGroupBox1.Controls.Add(Me.cvarMapLimit)
        Me.CsoGroupBox1.Controls.Add(Me.cvarMaxRound)
        Me.CsoGroupBox1.Controls.Add(Me.cvarBotQuota)
        Me.CsoGroupBox1.Controls.Add(Me.cvarMaxSlots)
        Me.CsoGroupBox1.Controls.Add(Me.Label3)
        Me.CsoGroupBox1.Controls.Add(Me.MapThumb)
        Me.CsoGroupBox1.Controls.Add(Me.MapList)
        Me.CsoGroupBox1.Controls.Add(Me.Label2)
        Me.CsoGroupBox1.Controls.Add(Me.Label1)
        Me.CsoGroupBox1.Controls.Add(Me.cvarHostName)
        Me.CsoGroupBox1.Location = New System.Drawing.Point(12, 64)
        Me.CsoGroupBox1.Name = "CsoGroupBox1"
        Me.CsoGroupBox1.Size = New System.Drawing.Size(242, 457)
        Me.CsoGroupBox1.TabIndex = 0
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(10, 410)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(103, 23)
        Me.Label10.TabIndex = 24
        Me.Label10.Text = "Start money:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(10, 381)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(103, 23)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "Buy time:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(10, 352)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(103, 23)
        Me.Label8.TabIndex = 22
        Me.Label8.Text = "Freeze time: "
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(10, 323)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(103, 23)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "Round time:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(10, 294)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(103, 23)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Time limit:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(10, 265)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(103, 23)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Number of rounds: "
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(10, 236)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(103, 23)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Number of BOTs:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cvarStartMon
        '
        Me.cvarStartMon.BackColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer))
        Me.cvarStartMon.ForeColor = System.Drawing.Color.White
        Me.cvarStartMon.Location = New System.Drawing.Point(119, 410)
        Me.cvarStartMon.MaxCharacters = 32767
        Me.cvarStartMon.Name = "cvarStartMon"
        Me.cvarStartMon.SetTextType = Counter_Strike_BreakThrough_3.CSOTextBox.TextType.SingleText
        Me.cvarStartMon.Size = New System.Drawing.Size(110, 23)
        Me.cvarStartMon.TabIndex = 17
        Me.cvarStartMon.Text = "<start money>"
        Me.cvarStartMon.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.cvarStartMon.UsePasswordMask = False
        '
        'cvarBuyTimer
        '
        Me.cvarBuyTimer.BackColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer))
        Me.cvarBuyTimer.ForeColor = System.Drawing.Color.White
        Me.cvarBuyTimer.Location = New System.Drawing.Point(119, 381)
        Me.cvarBuyTimer.MaxCharacters = 32767
        Me.cvarBuyTimer.Name = "cvarBuyTimer"
        Me.cvarBuyTimer.SetTextType = Counter_Strike_BreakThrough_3.CSOTextBox.TextType.SingleText
        Me.cvarBuyTimer.Size = New System.Drawing.Size(110, 23)
        Me.cvarBuyTimer.TabIndex = 16
        Me.cvarBuyTimer.Text = "<buy time>"
        Me.cvarBuyTimer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.cvarBuyTimer.UsePasswordMask = False
        '
        'cvarFrezTime
        '
        Me.cvarFrezTime.BackColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer))
        Me.cvarFrezTime.ForeColor = System.Drawing.Color.White
        Me.cvarFrezTime.Location = New System.Drawing.Point(119, 352)
        Me.cvarFrezTime.MaxCharacters = 32767
        Me.cvarFrezTime.Name = "cvarFrezTime"
        Me.cvarFrezTime.SetTextType = Counter_Strike_BreakThrough_3.CSOTextBox.TextType.SingleText
        Me.cvarFrezTime.Size = New System.Drawing.Size(110, 23)
        Me.cvarFrezTime.TabIndex = 15
        Me.cvarFrezTime.Text = "<freeze time>"
        Me.cvarFrezTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.cvarFrezTime.UsePasswordMask = False
        '
        'cvarRoundTim
        '
        Me.cvarRoundTim.BackColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer))
        Me.cvarRoundTim.ForeColor = System.Drawing.Color.White
        Me.cvarRoundTim.Location = New System.Drawing.Point(119, 323)
        Me.cvarRoundTim.MaxCharacters = 32767
        Me.cvarRoundTim.Name = "cvarRoundTim"
        Me.cvarRoundTim.SetTextType = Counter_Strike_BreakThrough_3.CSOTextBox.TextType.SingleText
        Me.cvarRoundTim.Size = New System.Drawing.Size(110, 23)
        Me.cvarRoundTim.TabIndex = 14
        Me.cvarRoundTim.Text = "<round time>"
        Me.cvarRoundTim.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.cvarRoundTim.UsePasswordMask = False
        '
        'cvarMapLimit
        '
        Me.cvarMapLimit.BackColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer))
        Me.cvarMapLimit.ForeColor = System.Drawing.Color.White
        Me.cvarMapLimit.Location = New System.Drawing.Point(119, 294)
        Me.cvarMapLimit.MaxCharacters = 32767
        Me.cvarMapLimit.Name = "cvarMapLimit"
        Me.cvarMapLimit.SetTextType = Counter_Strike_BreakThrough_3.CSOTextBox.TextType.SingleText
        Me.cvarMapLimit.Size = New System.Drawing.Size(110, 23)
        Me.cvarMapLimit.TabIndex = 13
        Me.cvarMapLimit.Text = "<timle left>"
        Me.cvarMapLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.cvarMapLimit.UsePasswordMask = False
        '
        'cvarMaxRound
        '
        Me.cvarMaxRound.BackColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer))
        Me.cvarMaxRound.ForeColor = System.Drawing.Color.White
        Me.cvarMaxRound.Location = New System.Drawing.Point(119, 265)
        Me.cvarMaxRound.MaxCharacters = 32767
        Me.cvarMaxRound.Name = "cvarMaxRound"
        Me.cvarMaxRound.SetTextType = Counter_Strike_BreakThrough_3.CSOTextBox.TextType.SingleText
        Me.cvarMaxRound.Size = New System.Drawing.Size(110, 23)
        Me.cvarMaxRound.TabIndex = 12
        Me.cvarMaxRound.Text = "<max rounds>"
        Me.cvarMaxRound.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.cvarMaxRound.UsePasswordMask = False
        '
        'cvarBotQuota
        '
        Me.cvarBotQuota.BackColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer))
        Me.cvarBotQuota.ForeColor = System.Drawing.Color.White
        Me.cvarBotQuota.Location = New System.Drawing.Point(119, 236)
        Me.cvarBotQuota.MaxCharacters = 32767
        Me.cvarBotQuota.Name = "cvarBotQuota"
        Me.cvarBotQuota.SetTextType = Counter_Strike_BreakThrough_3.CSOTextBox.TextType.SingleText
        Me.cvarBotQuota.Size = New System.Drawing.Size(110, 23)
        Me.cvarBotQuota.TabIndex = 11
        Me.cvarBotQuota.Text = "<Bot Quota>"
        Me.cvarBotQuota.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.cvarBotQuota.UsePasswordMask = False
        '
        'cvarMaxSlots
        '
        Me.cvarMaxSlots.BackColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer))
        Me.cvarMaxSlots.ForeColor = System.Drawing.Color.White
        Me.cvarMaxSlots.Location = New System.Drawing.Point(119, 207)
        Me.cvarMaxSlots.MaxCharacters = 32767
        Me.cvarMaxSlots.Name = "cvarMaxSlots"
        Me.cvarMaxSlots.SetTextType = Counter_Strike_BreakThrough_3.CSOTextBox.TextType.SingleText
        Me.cvarMaxSlots.Size = New System.Drawing.Size(110, 23)
        Me.cvarMaxSlots.TabIndex = 10
        Me.cvarMaxSlots.Text = "<slots>"
        Me.cvarMaxSlots.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.cvarMaxSlots.UsePasswordMask = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(10, 207)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(103, 23)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Server slots: "
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MapThumb
        '
        Me.MapThumb.BackColor = System.Drawing.Color.Transparent
        Me.MapThumb.Location = New System.Drawing.Point(13, 109)
        Me.MapThumb.Name = "MapThumb"
        Me.MapThumb.Size = New System.Drawing.Size(216, 90)
        Me.MapThumb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.MapThumb.TabIndex = 8
        Me.MapThumb.TabStop = False
        '
        'MapList
        '
        Me.MapList.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.MapList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.MapList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MapList.ForeColor = System.Drawing.Color.White
        Me.MapList.FormattingEnabled = True
        Me.MapList.Location = New System.Drawing.Point(13, 82)
        Me.MapList.Name = "MapList"
        Me.MapList.Size = New System.Drawing.Size(216, 21)
        Me.MapList.StartIndex = 0
        Me.MapList.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(10, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(219, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Map:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(10, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(219, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Server Name"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cvarHostName
        '
        Me.cvarHostName.BackColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer))
        Me.cvarHostName.ForeColor = System.Drawing.Color.White
        Me.cvarHostName.Location = New System.Drawing.Point(13, 35)
        Me.cvarHostName.MaxCharacters = 32767
        Me.cvarHostName.Name = "cvarHostName"
        Me.cvarHostName.SetTextType = Counter_Strike_BreakThrough_3.CSOTextBox.TextType.SingleText
        Me.cvarHostName.Size = New System.Drawing.Size(216, 23)
        Me.cvarHostName.TabIndex = 0
        Me.cvarHostName.Text = "<server name>"
        Me.cvarHostName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.cvarHostName.UsePasswordMask = False
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(871, 533)
        Me.ControlBox = False
        Me.Controls.Add(Me.CsoMain1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMain"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Counter-Strike: BreakThrough"
        Me.CsoMain1.ResumeLayout(False)
        Me.CsoGroupBox2.ResumeLayout(False)
        Me.CsoGroupBox1.ResumeLayout(False)
        CType(Me.MapThumb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CsoMain1 As Counter_Strike_BreakThrough_3.CSOMain
    Friend WithEvents CsoGroupBox1 As Counter_Strike_BreakThrough_3.CSOGroupBox
    Friend WithEvents CsoGroupBox2 As Counter_Strike_BreakThrough_3.CSOGroupBox
    Friend WithEvents mainNews As Counter_Strike_BreakThrough_3.CSOMainButton
    Friend WithEvents mainQuit As Counter_Strike_BreakThrough_3.CSOMainButton
    Friend WithEvents CsoSeperator1 As Counter_Strike_BreakThrough_3.CSOSeperator
    Friend WithEvents modePanel As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents labelProcess As System.Windows.Forms.Label
    Friend WithEvents LoadBar As Counter_Strike_BreakThrough_3.CSOProgressBar
    Friend WithEvents gameStart As Counter_Strike_BreakThrough_3.CSOButton
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cvarStartMon As Counter_Strike_BreakThrough_3.CSOTextBox
    Friend WithEvents cvarBuyTimer As Counter_Strike_BreakThrough_3.CSOTextBox
    Friend WithEvents cvarFrezTime As Counter_Strike_BreakThrough_3.CSOTextBox
    Friend WithEvents cvarRoundTim As Counter_Strike_BreakThrough_3.CSOTextBox
    Friend WithEvents cvarMapLimit As Counter_Strike_BreakThrough_3.CSOTextBox
    Friend WithEvents cvarMaxRound As Counter_Strike_BreakThrough_3.CSOTextBox
    Friend WithEvents cvarBotQuota As Counter_Strike_BreakThrough_3.CSOTextBox
    Friend WithEvents cvarMaxSlots As Counter_Strike_BreakThrough_3.CSOTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents MapThumb As System.Windows.Forms.PictureBox
    Friend WithEvents MapList As Counter_Strike_BreakThrough_3.CSOComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cvarHostName As Counter_Strike_BreakThrough_3.CSOTextBox

End Class
