Imports System
Imports System.Collections.Generic
Imports System.Runtime.InteropServices
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.Drawing.Text
Imports System.Windows.Forms
Imports System.IO

Module CSOThemeModule
    Friend G As Graphics

    Private TextBitmap As Bitmap
    Private TextGraphics As Graphics
    Private CreateRoundPath As GraphicsPath
    Private CreateRoundRectangle As Rectangle

    Sub New()
        TextBitmap = New Bitmap(1, 1)
        TextGraphics = Graphics.FromImage(TextBitmap)
    End Sub

    Friend Function MeasureString(text As String, font As Font) As SizeF
        Return TextGraphics.MeasureString(text, font)
    End Function

    Friend Function MeasureString(text As String, font As Font, width As Integer) As SizeF
        Return TextGraphics.MeasureString(text, font, width, StringFormat.GenericTypographic)
    End Function

    Friend Function CreateRound(ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer, ByVal slope As Integer) As GraphicsPath
        CreateRoundRectangle = New Rectangle(x, y, width, height)
        Return CreateRound(CreateRoundRectangle, slope)
    End Function

    Friend Function CreateRound(ByVal r As Rectangle, ByVal slope As Integer) As GraphicsPath
        CreateRoundPath = New GraphicsPath(FillMode.Winding)
        CreateRoundPath.AddArc(r.X, r.Y, slope, slope, 180.0F, 90.0F)
        CreateRoundPath.AddArc(r.Right - slope, r.Y, slope, slope, 270.0F, 90.0F)
        CreateRoundPath.AddArc(r.Right - slope, r.Bottom - slope, slope, slope, 0.0F, 90.0F)
        CreateRoundPath.AddArc(r.X, r.Bottom - slope, slope, slope, 90.0F, 90.0F)
        CreateRoundPath.CloseFigure()
        Return CreateRoundPath
    End Function
End Module

Public Class CSOMain : Inherits ContainerControl
#Region " Control Help - Movement & Flicker Control "
    Private MouseP As Point = New Point(0, 0)
    Private Cap As Boolean = False
    Private MoveHeight As Integer

    Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)

    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        If e.Button = Windows.Forms.MouseButtons.Left And New Rectangle(0, 0, Width, MoveHeight).Contains(e.Location) Then
            Cap = True : MouseP = e.Location
        End If
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        MyBase.OnMouseUp(e) : Cap = False
    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
        MyBase.OnMouseMove(e)
        If Cap Then
            Parent.Location = MousePosition - MouseP
        End If
    End Sub

    Protected Overrides Sub OnTextChanged(ByVal e As EventArgs)
        MyBase.OnTextChanged(e)
        Invalidate()
    End Sub
#End Region

    Sub New()
        MyBase.New()
        Dock = DockStyle.Fill
        MoveHeight = 45
        DoubleBuffered = True
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim G As Graphics = e.Graphics

        MyBase.OnPaint(e)

        If Not Me.ParentForm.FormBorderStyle = FormBorderStyle.None Then
            Me.ParentForm.FormBorderStyle = FormBorderStyle.None
        End If

        Dim glossLGB As New LinearGradientBrush(New Rectangle(0, 33, Width, 20), Color.Black, Color.FromArgb(60, 60, 60), 90S)

        G.Clear(Color.Black)
        G.FillRectangle(glossLGB, New Rectangle(0, 33, Width, 20))
    End Sub
End Class

Public Class CSOForm : Inherits ContainerControl
    Dim WithEvents CloseBtn As New CSOTopButton With {.Location = New Point(412, 7)}

#Region " Control Help - Movement & Flicker Control "
    Private MouseP As Point = New Point(0, 0)
    Private Cap As Boolean = False
    Private MoveHeight As Integer

    Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)

    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        If e.Button = Windows.Forms.MouseButtons.Left And New Rectangle(0, 0, Width, MoveHeight).Contains(e.Location) Then
            Cap = True : MouseP = e.Location
        End If
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        MyBase.OnMouseUp(e) : Cap = False
    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
        MyBase.OnMouseMove(e)
        If Cap Then
            Parent.Location = MousePosition - MouseP
        End If
    End Sub

    Protected Overrides Sub OnTextChanged(ByVal e As EventArgs)
        MyBase.OnTextChanged(e)
        Invalidate()
    End Sub
#End Region

    Sub New()
        MyBase.New()
        SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        BackColor = Color.Red
        Dock = DockStyle.Fill
        MoveHeight = 45
        DoubleBuffered = True
        Controls.Add(CloseBtn)
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim G As Graphics = e.Graphics
        Dim GP As New GraphicsPath

        CloseBtn.Location = New Point(Width - 25, 16)

        MyBase.OnPaint(e)

        If Not Me.ParentForm.FormBorderStyle = FormBorderStyle.None Then
            Me.ParentForm.FormBorderStyle = FormBorderStyle.None
        End If

        Dim TopL As New Bitmap(My.Resources.TopL)
        Dim TopR As New Bitmap(My.Resources.TopR)

        Dim TopLDim As New Bitmap(CInt(TopL.Width), CInt(TopL.Height))
        Dim TopRDim As New Bitmap(CInt(TopR.Width), CInt(TopR.Height))

        Dim glossLGB As New LinearGradientBrush(New Rectangle(0, 0, Width, 15), Color.FromArgb(73, 73, 73), Color.FromArgb(58, 58, 58), 90S)

        G.Clear(Color.FromArgb(33, 33, 33))

        GP.StartFigure()
        GP.AddArc(New Rectangle(0, 0, 10, 10), 180, 90)
        GP.AddArc(New Rectangle(Me.Width - 10, 0, 10, 10), -90, 90)
        GP.AddArc(New Rectangle(Me.Width - 10, Me.Height - 10, 10, 10), 0, 90)
        GP.AddArc(New Rectangle(0, Me.Height - 10, 10, 10), 90, 90)
        GP.CloseFigure()

        Me.Region = New Region(GP)

        Me.ParentForm.BackColor = Color.Red
        Me.ParentForm.TransparencyKey = Me.ParentForm.BackColor

        G.DrawImage(TopL, 0, 0, TopL.Width, TopL.Height)
        G.DrawImage(TopR, Width - 14, 0, TopR.Width, TopR.Height)

        G.FillRectangle(glossLGB, New Rectangle(24, 0, Width - 38, 12))

        G.DrawString(Text, New Font("calibri", 10), Brushes.Gray, 15, 15)
    End Sub
End Class

Public Class CSOTopButton : Inherits Control

#Region " Control Help - MouseState & Flicker Control"
    Dim buttonColor As Color

    Private State As MouseState = MouseState.None

    Protected Overrides Sub OnMouseEnter(ByVal e As System.EventArgs)
        MyBase.OnMouseEnter(e)
        State = MouseState.Over
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseDown(e)
        State = MouseState.Down
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseLeave(ByVal e As System.EventArgs)
        MyBase.OnMouseLeave(e)
        State = MouseState.None
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseUp(e)
        State = MouseState.Over
        Invalidate()
    End Sub

    Protected Overrides Sub OnPaintBackground(ByVal pevent As System.Windows.Forms.PaintEventArgs)

    End Sub

    Protected Overrides Sub OnTextChanged(ByVal e As System.EventArgs)
        MyBase.OnTextChanged(e)
        Invalidate()
    End Sub

    Sub buttonFunction() Handles Me.Click
        Me.Parent.FindForm.Close()
    End Sub
#End Region

    Sub New()
        MyBase.New()
        BackColor = Color.FromArgb(38, 38, 38)
        Size = New Size(17, 17)
        DoubleBuffered = True
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim G As Graphics = e.Graphics
        MyBase.OnPaint(e)

        G.Clear(Color.FromArgb(36, 34, 30))

        Select Case State
            Case MouseState.None 'Mouse None
                buttonColor = Color.FromArgb(163, 163, 162)
            Case MouseState.Over 'Mouse Hover
                buttonColor = Color.FromArgb(255, 255, 255)
            Case MouseState.Down 'Mouse Down
                buttonColor = Color.FromArgb(255, 255, 255)
        End Select

        G.DrawLine(New Pen(New SolidBrush(buttonColor), 2), 4, 4, 12, 11)
        G.DrawLine(New Pen(New SolidBrush(buttonColor), 2), 12, 4, 4, 11)
        G.DrawLine(New Pen(New SolidBrush(buttonColor)), 4, 4, 5, 5)
        G.DrawLine(New Pen(New SolidBrush(buttonColor)), 4, 11, 5, 10)
    End Sub
End Class

Public Class CSOGroupBox : Inherits ContainerControl

#Region " Control Help - Properties & Flicker Control"
    Protected Overrides Sub OnPaintBackground(ByVal pevent As PaintEventArgs)

    End Sub

    Protected Overrides Sub OnTextChanged(ByVal e As EventArgs)
        MyBase.OnTextChanged(e)
        Invalidate()
    End Sub
#End Region

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        MyBase.OnPaint(e)

        Dim G As Graphics = e.Graphics
        Dim GP As New GraphicsPath
        Dim TopL As New Bitmap(My.Resources.TopL)
        Dim TopR As New Bitmap(My.Resources.TopR)
        Dim TopLDim As New Bitmap(CInt(TopL.Width), CInt(TopL.Height))
        Dim TopRDim As New Bitmap(CInt(TopR.Width), CInt(TopR.Height))
        Dim glossLGB As New LinearGradientBrush(New Rectangle(0, 0, Width, 15), Color.FromArgb(73, 73, 73), Color.FromArgb(58, 58, 58), 90S)

        BackColor = Color.Red

        GP.StartFigure()
        GP.AddArc(New Rectangle(0, 0, 10, 10), 180, 90)
        GP.AddArc(New Rectangle(Width - 10, 0, 10, 10), -90, 90)
        GP.AddArc(New Rectangle(Width - 10, Height - 10, 10, 10), 0, 90)
        GP.AddArc(New Rectangle(0, Height - 10, 10, 10), 90, 90)
        GP.CloseFigure()

        Region = New Region(GP)

        G.Clear(Color.FromArgb(33, 33, 33))
        G.DrawImage(TopL, 0, 0, TopL.Width, TopL.Height)
        G.DrawImage(TopR, Width - 14, 0, TopR.Width, TopR.Height)
        G.FillRectangle(glossLGB, New Rectangle(24, 0, Width - 38, 12))
        G.DrawString(Text, New Font("calibri", 10), Brushes.Gray, 15, 15)
    End Sub
End Class

<DefaultEvent("CheckedChanged")> Public Class CSORadioButton : Inherits Control

#Region " Control Help - MouseState & Flicker Control"
    Private R1 As Rectangle
    Private G1 As LinearGradientBrush
    Private State As MouseState = MouseState.None
    Private _Checked As Boolean

    Protected Overrides Sub OnMouseEnter(ByVal e As EventArgs)
        MyBase.OnMouseEnter(e)
        State = MouseState.Over
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        State = MouseState.Down
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseLeave(ByVal e As EventArgs)
        MyBase.OnMouseLeave(e)
        State = MouseState.None
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        State = MouseState.Over
        Invalidate()
    End Sub

    Protected Overrides Sub OnPaintBackground(ByVal pevent As System.Windows.Forms.PaintEventArgs)

    End Sub

    Protected Overrides Sub OnTextChanged(ByVal e As System.EventArgs)
        MyBase.OnTextChanged(e)
        Invalidate()
    End Sub

    Property Checked() As Boolean
        Get
            Return _Checked
        End Get

        Set(ByVal value As Boolean)
            _Checked = value
            InvalidateControls()
            RaiseEvent CheckedChanged(Me)
            Invalidate()
        End Set
    End Property

    Protected Overrides Sub OnClick(ByVal e As EventArgs)
        If Not _Checked Then Checked = True
        MyBase.OnClick(e)
    End Sub

    Event CheckedChanged(ByVal sender As Object)

    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()
        InvalidateControls()
    End Sub

    Private Sub InvalidateControls()
        If Not IsHandleCreated OrElse Not _Checked Then Return

        For Each C As Control In Parent.Controls
            If C IsNot Me AndAlso TypeOf C Is CSORadioButton Then
                DirectCast(C, CSORadioButton).Checked = False
            End If
        Next
    End Sub
#End Region

    Sub New()
        MyBase.New()
        ForeColor = Color.White
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim G As Graphics = e.Graphics

        Height = 16

        G.Clear(Color.FromArgb(33, 33, 33))

        Dim RadioUnchk As New Bitmap(My.Resources.radiobutton_off)
        Dim RadioChk As New Bitmap(My.Resources.radiobutton_on)

        If _Checked Then
            G.DrawImage(RadioChk, 0, 0, RadioChk.Width, RadioChk.Height)
        Else
            G.DrawImage(RadioUnchk, 0, 0, RadioUnchk.Width, RadioUnchk.Height)
        End If

        G.DrawString(Text, New Font("calibri", 10), New SolidBrush(ForeColor), 18, 1)
    End Sub
End Class

<DefaultEvent("CheckedChanged")> Public Class CSOCheckBox : Inherits Control

#Region " Control Help - MouseState & Flicker Control"
    Private State As MouseState = MouseState.None
    Private _Checked As Boolean

    Protected Overrides Sub OnMouseEnter(ByVal e As EventArgs)
        MyBase.OnMouseEnter(e)
        State = MouseState.Over
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        State = MouseState.Down
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseLeave(ByVal e As EventArgs)
        MyBase.OnMouseLeave(e)
        State = MouseState.None
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        State = MouseState.Over
        Invalidate()
    End Sub

    Protected Overrides Sub OnPaintBackground(ByVal pevent As PaintEventArgs)

    End Sub

    Protected Overrides Sub OnTextChanged(ByVal e As EventArgs)
        MyBase.OnTextChanged(e)
        Invalidate()
    End Sub

    Property Checked() As Boolean
        Get
            Return _Checked
        End Get
        Set(ByVal value As Boolean)
            _Checked = value
            Invalidate()
        End Set
    End Property

    Protected Overrides Sub OnClick(ByVal e As EventArgs)
        _Checked = Not _Checked
        RaiseEvent CheckedChanged(Me)
        MyBase.OnClick(e)
    End Sub

    Event CheckedChanged(ByVal sender As Object)
#End Region

    Sub New()
        MyBase.New()
        ForeColor = Color.White
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim G As Graphics = e.Graphics

        Height = 16

        G.Clear(Color.FromArgb(33, 33, 33))

        Dim CBox_On As New Bitmap(My.Resources.checkbox_on)
        Dim CBox_Off As New Bitmap(My.Resources.checkbox_off)

        G.DrawImage(CBox_Off, 0, 0, CBox_Off.Width, CBox_Off.Height)

        If _Checked Then
            G.DrawImage(CBox_On, 0, 0, CBox_On.Width, CBox_On.Height)
        End If

        G.DrawString(Text, New Font("calibri", 10), New SolidBrush(ForeColor), 18, 1)
    End Sub
End Class

<DefaultEvent("CheckedChanged")> Public Class CSOModeChanger : Inherits Control

#Region " Control Help - MouseState & Flicker Control"
    Enum ChoosenMode As Byte
        Original = 0
        Basic = 1
        Deathmatch = 2
        TeamDeathmatch = 3
        GunDeathmatch = 4
        ZombieOriginal = 5
        ZombieMutation = 6
        ZombieHero = 7
        Zombie4 = 8
        ZombieUnion = 9
        ZombieEscape = 10
        ZombieShelter = 11
        ZombieScenario = 12
        HumanScenario = 13
        Challenge = 14
        Hidden = 15
        BazookaBattle = 16
        Soccer = 17
        RushBattle = 18
        MetalArena = 19
        Beasts = 20
    End Enum

    Private R1 As Rectangle
    Private G1 As LinearGradientBrush
    Private State As MouseState = MouseState.None
    Private _modType As ChoosenMode = ChoosenMode.Original
    Private _Checked As Boolean

    Event CheckedChanged(ByVal sender As Object)

    Public Property GameMode() As ChoosenMode
        Get
            Return _modType
        End Get

        Set(ByVal v As ChoosenMode)
            _modType = v
            Invalidate()
        End Set
    End Property

    Protected Overrides Sub OnMouseEnter(ByVal e As EventArgs)
        MyBase.OnMouseEnter(e)
        State = MouseState.Over
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        State = MouseState.Down
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseLeave(ByVal e As EventArgs)
        MyBase.OnMouseLeave(e)
        State = MouseState.None
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        State = MouseState.Over
        Invalidate()
    End Sub

    Protected Overrides Sub OnPaintBackground(ByVal pevent As PaintEventArgs)

    End Sub

    Protected Overrides Sub OnTextChanged(ByVal e As EventArgs)
        MyBase.OnTextChanged(e)
        Invalidate()
    End Sub

    Property Checked() As Boolean
        Get
            Return _Checked
        End Get

        Set(ByVal value As Boolean)
            _Checked = value
            InvalidateControls()
            RaiseEvent CheckedChanged(Me)
            Invalidate()
        End Set
    End Property

    Protected Overrides Sub OnClick(ByVal e As EventArgs)
        If Not _Checked Then Checked = True
        MyBase.OnClick(e)
    End Sub

    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()
        InvalidateControls()
    End Sub

    Private Sub InvalidateControls()
        If Not IsHandleCreated OrElse Not _Checked Then Return

        For Each C As Control In Parent.Controls
            If C IsNot Me AndAlso TypeOf C Is CSOModeChanger Then
                DirectCast(C, CSOModeChanger).Checked = False
            End If
        Next
    End Sub
#End Region

    Sub New()
        MyBase.New()
        ForeColor = Color.White
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        MyBase.OnPaint(e)
        Me.Width = 135
        Me.Height = 75

        Dim G As Graphics = e.Graphics

        Select Case State
            Case MouseState.None
                Select Case GameMode
                    Case ChoosenMode.Original
                        Dim ModeImage As String = Application.StartupPath & "\platform\launcher\modes\Mode_Original.png"
                        Dim ModeThumb As Image = Image.FromFile(ModeImage)

                        If File.Exists(ModeImage) Then
                            G.DrawImage(New Bitmap(ModeThumb), 0, 0)
                        Else

                        End If
                    Case ChoosenMode.Basic
                        Dim ModeImage As String = Application.StartupPath & "\platform\launcher\modes\Mode_Basic.png"
                        Dim ModeThumb As Image = Image.FromFile(ModeImage)

                        If File.Exists(ModeImage) Then
                            G.DrawImage(New Bitmap(ModeThumb), 0, 0)
                        Else

                        End If
                    Case ChoosenMode.Deathmatch
                        Dim ModeImage As String = Application.StartupPath & "\platform\launcher\modes\Mode_Deathmatch.png"
                        Dim ModeThumb As Image = Image.FromFile(ModeImage)

                        If File.Exists(ModeImage) Then
                            G.DrawImage(New Bitmap(ModeThumb), 0, 0)
                        Else

                        End If
                    Case ChoosenMode.TeamDeathmatch
                        Dim ModeImage As String = Application.StartupPath & "\platform\launcher\modes\Mode_TeamDeathmatch.png"
                        Dim ModeThumb As Image = Image.FromFile(ModeImage)

                        If File.Exists(ModeImage) Then
                            G.DrawImage(New Bitmap(ModeThumb), 0, 0)
                        Else

                        End If
                    Case ChoosenMode.GunDeathmatch
                        Dim ModeImage As String = Application.StartupPath & "\platform\launcher\modes\Mode_GunDeathmatch.png"
                        Dim ModeThumb As Image = Image.FromFile(ModeImage)

                        If File.Exists(ModeImage) Then
                            G.DrawImage(New Bitmap(ModeThumb), 0, 0)
                        Else

                        End If
                    Case ChoosenMode.ZombieOriginal
                        Dim ModeImage As String = Application.StartupPath & "\platform\launcher\modes\Mode_ZombieOriginal.png"
                        Dim ModeThumb As Image = Image.FromFile(ModeImage)

                        If File.Exists(ModeImage) Then
                            G.DrawImage(New Bitmap(ModeThumb), 0, 0)
                        Else

                        End If
                    Case ChoosenMode.ZombieMutation
                        Dim ModeImage As String = Application.StartupPath & "\platform\launcher\modes\Mode_ZombieMutation.png"
                        Dim ModeThumb As Image = Image.FromFile(ModeImage)

                        If File.Exists(ModeImage) Then
                            G.DrawImage(New Bitmap(ModeThumb), 0, 0)
                        Else

                        End If
                    Case ChoosenMode.ZombieHero
                        Dim ModeImage As String = Application.StartupPath & "\platform\launcher\modes\Mode_ZombieHero.png"
                        Dim ModeThumb As Image = Image.FromFile(ModeImage)

                        If File.Exists(ModeImage) Then
                            G.DrawImage(New Bitmap(ModeThumb), 0, 0)
                        Else

                        End If
                    Case ChoosenMode.Zombie4
                        Dim ModeImage As String = Application.StartupPath & "\platform\launcher\modes\Mode_Zombie4.png"
                        Dim ModeThumb As Image = Image.FromFile(ModeImage)

                        If File.Exists(ModeImage) Then
                            G.DrawImage(New Bitmap(ModeThumb), 0, 0)
                        Else

                        End If
                    Case ChoosenMode.ZombieUnion
                        Dim ModeImage As String = Application.StartupPath & "\platform\launcher\modes\Mode_ZombieUnion.png"
                        Dim ModeThumb As Image = Image.FromFile(ModeImage)

                        If File.Exists(ModeImage) Then
                            G.DrawImage(New Bitmap(ModeThumb), 0, 0)
                        Else

                        End If
                    Case ChoosenMode.ZombieEscape
                        Dim ModeImage As String = Application.StartupPath & "\platform\launcher\modes\Mode_ZombieEscape.png"
                        Dim ModeThumb As Image = Image.FromFile(ModeImage)

                        If File.Exists(ModeImage) Then
                            G.DrawImage(New Bitmap(ModeThumb), 0, 0)
                        Else

                        End If
                    Case ChoosenMode.ZombieShelter
                        Dim ModeImage As String = Application.StartupPath & "\platform\launcher\modes\Mode_ZombieShelter.png"
                        Dim ModeThumb As Image = Image.FromFile(ModeImage)

                        If File.Exists(ModeImage) Then
                            G.DrawImage(New Bitmap(ModeThumb), 0, 0)
                        Else

                        End If
                    Case ChoosenMode.ZombieScenario
                        Dim ModeImage As String = Application.StartupPath & "\platform\launcher\modes\Mode_ZombieScenario.png"
                        Dim ModeThumb As Image = Image.FromFile(ModeImage)

                        If File.Exists(ModeImage) Then
                            G.DrawImage(New Bitmap(ModeThumb), 0, 0)
                        Else

                        End If
                    Case ChoosenMode.HumanScenario
                        Dim ModeImage As String = Application.StartupPath & "\platform\launcher\modes\Mode_HumanScenario.png"
                        Dim ModeThumb As Image = Image.FromFile(ModeImage)

                        If File.Exists(ModeImage) Then
                            G.DrawImage(New Bitmap(ModeThumb), 0, 0)
                        Else

                        End If
                    Case ChoosenMode.Challenge
                        Dim ModeImage As String = Application.StartupPath & "\platform\launcher\modes\Mode_Challenge.png"
                        Dim ModeThumb As Image = Image.FromFile(ModeImage)

                        If File.Exists(ModeImage) Then
                            G.DrawImage(New Bitmap(ModeThumb), 0, 0)
                        Else

                        End If
                    Case ChoosenMode.Hidden
                        Dim ModeImage As String = Application.StartupPath & "\platform\launcher\modes\Mode_Hidden.png"
                        Dim ModeThumb As Image = Image.FromFile(ModeImage)

                        If File.Exists(ModeImage) Then
                            G.DrawImage(New Bitmap(ModeThumb), 0, 0)
                        Else

                        End If
                    Case ChoosenMode.BazookaBattle
                        Dim ModeImage As String = Application.StartupPath & "\platform\launcher\modes\Mode_BazookaBattle.png"
                        Dim ModeThumb As Image = Image.FromFile(ModeImage)

                        If File.Exists(ModeImage) Then
                            G.DrawImage(New Bitmap(ModeThumb), 0, 0)
                        Else

                        End If
                    Case ChoosenMode.Soccer
                        Dim ModeImage As String = Application.StartupPath & "\platform\launcher\modes\Mode_Soccer.png"
                        Dim ModeThumb As Image = Image.FromFile(ModeImage)

                        If File.Exists(ModeImage) Then
                            G.DrawImage(New Bitmap(ModeThumb), 0, 0)
                        Else

                        End If
                    Case ChoosenMode.RushBattle
                        Dim ModeImage As String = Application.StartupPath & "\platform\launcher\modes\Mode_RushBattle.png"
                        Dim ModeThumb As Image = Image.FromFile(ModeImage)

                        If File.Exists(ModeImage) Then
                            G.DrawImage(New Bitmap(ModeThumb), 0, 0)
                        Else

                        End If
                    Case ChoosenMode.MetalArena
                        Dim ModeImage As String = Application.StartupPath & "\platform\launcher\modes\Mode_MetalArena.png"
                        Dim ModeThumb As Image = Image.FromFile(ModeImage)

                        If File.Exists(ModeImage) Then
                            G.DrawImage(New Bitmap(ModeThumb), 0, 0)
                        Else

                        End If
                    Case ChoosenMode.Beasts
                        Dim ModeImage As String = Application.StartupPath & "\platform\launcher\modes\Mode_Beasts.png"
                        Dim ModeThumb As Image = Image.FromFile(ModeImage)

                        If File.Exists(ModeImage) Then
                            G.DrawImage(New Bitmap(ModeThumb), 0, 0)
                        Else

                        End If
                End Select
            Case MouseState.Over
                G.DrawImage(New Bitmap(My.Resources.selectedmode), 0, 0)

                Dim OverSound As String = Application.StartupPath & "\platform\launcher\sound\ModeOver.wav"
                If File.Exists(OverSound) Then My.Computer.Audio.Play(OverSound)
            Case MouseState.Down
                Dim DownSound As String = Application.StartupPath & "\platform\launcher\sound\ModeClick.wav"
                If File.Exists(DownSound) Then My.Computer.Audio.Play(DownSound)
        End Select

        If _Checked Then
            G.DrawImage(New Bitmap(My.Resources.selectedmode), 0, 0)
        End If

        G.DrawString(Text, New Font("calibri", 10), New SolidBrush(ForeColor), Width / 2 - (3 * Text.Length) - 5, 52)
    End Sub
End Class

Public Class CSOMainButton : Inherits Control

#Region " Control Help - MouseState & Flicker Control"
    Enum ButtonType As Byte
        Quit = 0
        Options = 1
        Report = 2
        Barrack = 3
        Shop = 4
        News = 5
    End Enum

    Private _btnType As ButtonType = ButtonType.Quit
    Private State As MouseState = MouseState.None

    Public Property ChoosenButton() As ButtonType
        Get
            Return _btnType
        End Get

        Set(ByVal v As ButtonType)
            _btnType = v
            Invalidate()
        End Set
    End Property

    Protected Overrides Sub OnMouseEnter(ByVal e As EventArgs)
        MyBase.OnMouseEnter(e)
        State = MouseState.Over
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        State = MouseState.Down
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseLeave(ByVal e As EventArgs)
        MyBase.OnMouseLeave(e)
        State = MouseState.None
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        State = MouseState.Over
        Invalidate()
    End Sub

    Protected Overrides Sub OnPaintBackground(ByVal pevent As PaintEventArgs)

    End Sub

    Protected Overrides Sub OnTextChanged(ByVal e As EventArgs)
        MyBase.OnTextChanged(e)
        Invalidate()
    End Sub
#End Region

    Sub New()
        MyBase.New()
        DoubleBuffered = True
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim G As Graphics = e.Graphics
        MyBase.OnPaint(e)

        Me.Width = 50
        Me.Height = 50

        Dim glossLGB As New LinearGradientBrush(New Rectangle(0, 30, Width, 20), Color.Black, Color.FromArgb(60, 60, 60), 90S)

        G.Clear(Color.Black)
        G.FillRectangle(glossLGB, New Rectangle(0, 30, Width, 20))

        Select Case ChoosenButton
            Case ButtonType.Quit
                Select Case State
                    Case MouseState.None
                        G.DrawImage(New Bitmap(My.Resources.btn_exit_n), 0, 0, Me.Width, Me.Height)
                    Case MouseState.Over
                        G.DrawImage(New Bitmap(My.Resources.btn_exit_o), 0, 0, Me.Width, Me.Height)

                        Dim UIOverSound As String = Application.StartupPath & "\platform\launcher\sound\UIOver.wav"
                        If File.Exists(UIOverSound) Then My.Computer.Audio.Play(UIOverSound)
                    Case MouseState.Down
                        G.DrawImage(New Bitmap(My.Resources.btn_exit_n), 0, 0, Me.Width, Me.Height)

                        Dim UIDownSound As String = Application.StartupPath & "\platform\launcher\sound\UIClick.wav"
                        If File.Exists(UIDownSound) Then My.Computer.Audio.Play(UIDownSound)
                End Select
            Case ButtonType.Options
                Select Case State
                    Case MouseState.None
                        G.DrawImage(New Bitmap(My.Resources.btn_option_n), 0, 0, Me.Width, Me.Height)
                    Case MouseState.Over
                        G.DrawImage(New Bitmap(My.Resources.btn_option_o), 0, 0, Me.Width, Me.Height)

                        Dim UIOverSound As String = Application.StartupPath & "\platform\launcher\sound\UIOver.wav"
                        If File.Exists(UIOverSound) Then My.Computer.Audio.Play(UIOverSound)
                    Case MouseState.Down
                        G.DrawImage(New Bitmap(My.Resources.btn_option_n), 0, 0, Me.Width, Me.Height)

                        Dim UIDownSound As String = Application.StartupPath & "\platform\launcher\sound\UIClick.wav"
                        If File.Exists(UIDownSound) Then My.Computer.Audio.Play(UIDownSound)
                End Select
            Case ButtonType.Report
                Select Case State
                    Case MouseState.None
                        G.DrawImage(New Bitmap(My.Resources.btn_report_n), 0, 0, Me.Width, Me.Height)
                    Case MouseState.Over
                        G.DrawImage(New Bitmap(My.Resources.btn_report_o), 0, 0, Me.Width, Me.Height)

                        Dim UIOverSound As String = Application.StartupPath & "\platform\launcher\sound\UIOver.wav"
                        If File.Exists(UIOverSound) Then My.Computer.Audio.Play(UIOverSound)
                    Case MouseState.Down
                        G.DrawImage(New Bitmap(My.Resources.btn_report_n), 0, 0, Me.Width, Me.Height)

                        Dim UIDownSound As String = Application.StartupPath & "\platform\launcher\sound\UIClick.wav"
                        If File.Exists(UIDownSound) Then My.Computer.Audio.Play(UIDownSound)
                End Select
            Case ButtonType.Barrack
                Select Case State
                    Case MouseState.None
                        G.DrawImage(New Bitmap(My.Resources.btn_myinfo_n), 0, 0, Me.Width, Me.Height)
                    Case MouseState.Over
                        G.DrawImage(New Bitmap(My.Resources.btn_myinfo_o), 0, 0, Me.Width, Me.Height)

                        Dim UIOverSound As String = Application.StartupPath & "\platform\launcher\sound\UIOver.wav"
                        If File.Exists(UIOverSound) Then My.Computer.Audio.Play(UIOverSound)
                    Case MouseState.Down
                        G.DrawImage(New Bitmap(My.Resources.btn_myinfo_n), 0, 0, Me.Width, Me.Height)

                        Dim UIDownSound As String = Application.StartupPath & "\platform\launcher\sound\UIClick.wav"
                        If File.Exists(UIDownSound) Then My.Computer.Audio.Play(UIDownSound)
                End Select
            Case ButtonType.Shop
                Select Case State
                    Case MouseState.None
                        G.DrawImage(New Bitmap(My.Resources.btn_store_n), 0, 0, Me.Width, Me.Height)
                    Case MouseState.Over
                        G.DrawImage(New Bitmap(My.Resources.btn_store_o), 0, 0, Me.Width, Me.Height)

                        Dim UIOverSound As String = Application.StartupPath & "\platform\launcher\sound\UIOver.wav"
                        If File.Exists(UIOverSound) Then My.Computer.Audio.Play(UIOverSound)
                    Case MouseState.Down
                        G.DrawImage(New Bitmap(My.Resources.btn_store_n), 0, 0, Me.Width, Me.Height)

                        Dim UIDownSound As String = Application.StartupPath & "\platform\launcher\sound\UIClick.wav"
                        If File.Exists(UIDownSound) Then My.Computer.Audio.Play(UIDownSound)
                End Select
            Case ButtonType.News
                Select Case State
                    Case MouseState.None
                        G.DrawImage(New Bitmap(My.Resources.btn_bulletin_n), 0, 0, Me.Width, Me.Height)
                    Case MouseState.Over
                        G.DrawImage(New Bitmap(My.Resources.btn_bulletin_o), 0, 0, Me.Width, Me.Height)

                        Dim UIOverSound As String = Application.StartupPath & "\platform\launcher\sound\UIOver.wav"
                        If File.Exists(UIOverSound) Then My.Computer.Audio.Play(UIOverSound)
                    Case MouseState.Down
                        G.DrawImage(New Bitmap(My.Resources.btn_bulletin_n), 0, 0, Me.Width, Me.Height)

                        Dim UIDownSound As String = Application.StartupPath & "\platform\launcher\sound\UIClick.wav"
                        If File.Exists(UIDownSound) Then My.Computer.Audio.Play(UIDownSound)
                End Select
        End Select

        G.DrawString(Text, New Font("calibri", 8), New SolidBrush(Color.White), Width / 2 - (3 * Text.Length), 35)
    End Sub
End Class

Public Class CSOTextBox : Inherits Control
    Dim WithEvents txtbox As New TextBox

#Region " Control Help - Properties & Flicker Control "
    Enum TextType As Byte
        SingleText = 0
        MultiText = 1
    End Enum

    Private _passmask As Boolean = False
    Private _maxchars As Integer = 32767
    Private _align As HorizontalAlignment
    Private _tbType As TextType = TextType.SingleText

    Public Property SetTextType() As TextType
        Get
            Return _tbType
        End Get

        Set(ByVal v As TextType)
            _tbType = v
            Invalidate()
        End Set
    End Property

    Public Property UsePasswordMask() As Boolean
        Get
            Return _passmask
        End Get

        Set(ByVal v As Boolean)
            _passmask = v
            Invalidate()
        End Set
    End Property

    Public Property MaxCharacters() As Integer
        Get
            Return _maxchars
        End Get

        Set(ByVal v As Integer)
            _maxchars = v
            Invalidate()
        End Set
    End Property

    Public Property TextAlign() As HorizontalAlignment
        Get
            Return _align
        End Get

        Set(ByVal v As HorizontalAlignment)
            _align = v
            Invalidate()
        End Set
    End Property

    Protected Overrides Sub OnPaintBackground(ByVal pevent As PaintEventArgs)

    End Sub

    Protected Overrides Sub OnTextChanged(ByVal e As EventArgs)
        MyBase.OnTextChanged(e)
        Invalidate()
    End Sub

    Protected Overrides Sub OnBackColorChanged(ByVal e As EventArgs)
        MyBase.OnBackColorChanged(e)
        txtbox.BackColor = BackColor
        Invalidate()
    End Sub

    Protected Overrides Sub OnForeColorChanged(ByVal e As EventArgs)
        MyBase.OnForeColorChanged(e)
        txtbox.ForeColor = ForeColor
        Invalidate()
    End Sub

    Protected Overrides Sub OnFontChanged(ByVal e As EventArgs)
        MyBase.OnFontChanged(e)
        txtbox.Font = Font
    End Sub

    Protected Overrides Sub OnGotFocus(ByVal e As EventArgs)
        MyBase.OnGotFocus(e)
        txtbox.Focus()
    End Sub

    Sub TextChngTxtBox() Handles txtbox.TextChanged
        Text = txtbox.Text
    End Sub

    Sub TextChng() Handles MyBase.TextChanged
        txtbox.Text = Text
    End Sub

    Sub NewTextBox()
        With txtbox
            .Multiline = False
            .BackColor = BackColor
            .ForeColor = ForeColor
            .Text = String.Empty
            .TextAlign = HorizontalAlignment.Center
            .BorderStyle = BorderStyle.None
            .Location = New Point(5, 5)
            .Font = New Font("calibri", 7.25)
            .Size = New Size(Width - 10, Height - 11)
            .UseSystemPasswordChar = UsePasswordMask
            .MaxLength = MaxCharacters
        End With
    End Sub
#End Region

    Sub New()
        MyBase.New()
        NewTextBox()
        Controls.Add(txtbox)
        Text = ""
        BackColor = Color.FromArgb(17, 17, 17)
        ForeColor = Color.White
        Size = New Size(135, 35)
        DoubleBuffered = True
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim G As Graphics = e.Graphics
        Dim GP As New GraphicsPath

        MyBase.OnPaint(e)

        Select Case SetTextType
            Case TextType.SingleText
                Height = txtbox.Height + 11

                With txtbox
                    .Multiline = False
                    .Width = Width - 10
                    .TextAlign = TextAlign
                    .UseSystemPasswordChar = UsePasswordMask
                    .MaxLength = MaxCharacters
                End With
            Case TextType.MultiText
                txtbox.TextAlign = TextAlign

                With txtbox
                    .Multiline = True
                    .TextAlign = TextAlign
                    .UseSystemPasswordChar = UsePasswordMask
                    .Size = New Size(Width - 10, Height - 10)
                    .MaxLength = MaxCharacters
                End With

                Controls.Add(txtbox)
        End Select


        G.SmoothingMode = SmoothingMode.HighQuality
        G.Clear(Color.FromArgb(17, 17, 17))
        G.DrawRectangle((New Pen(New SolidBrush(Color.FromArgb(70, 70, 70)))), New Rectangle(0, 0, Width - 1, Height - 1))
        G.DrawLine(New Pen(New SolidBrush(Color.FromArgb(10, 10, 10))), 0, 0, Width, 0)
        G.DrawLine(New Pen(New SolidBrush(Color.FromArgb(10, 10, 10))), 0, 0, 0, Height)

        GP.StartFigure()
        GP.AddArc(New Rectangle(0, 0, 5, 5), 180, 90)
        GP.AddArc(New Rectangle(Width - 7, 0, 7, 7), -90, 90)
        GP.AddArc(New Rectangle(Width - 10, Height - 10, 10, 10), 0, 90)
        GP.AddArc(New Rectangle(0, Height - 7, 7, 7), 90, 90)
        GP.CloseFigure()

        Region = New Region(GP)
    End Sub
End Class

Public Class CSOComboBox : Inherits ComboBox

#Region " Control Help - Properties & Flicker Control "
    Protected Overrides Sub OnPaintBackground(ByVal pevent As System.Windows.Forms.PaintEventArgs)

    End Sub

    Private _StartIndex As Integer = 0

    Public Property StartIndex As Integer
        Get
            Return _StartIndex
        End Get

        Set(ByVal value As Integer)
            _StartIndex = value

            Try
                MyBase.SelectedIndex = value
            Catch

            End Try

            Invalidate()
        End Set
    End Property

    Sub ReplaceItem(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles Me.DrawItem
        e.DrawBackground()
        Try
            If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
                e.Graphics.FillRectangle(New SolidBrush(Color.Gray), e.Bounds) '37 37 37
            End If

            Using b As New SolidBrush(e.ForeColor)
                e.Graphics.DrawString(MyBase.GetItemText(MyBase.Items(e.Index)), e.Font, b, e.Bounds)
            End Using
        Catch

        End Try
        e.DrawFocusRectangle()
    End Sub
    Protected Sub DrawTriangle(ByVal Clr As Color, ByVal FirstPoint As Point, ByVal SecondPoint As Point, ByVal ThirdPoint As Point, ByVal G As Graphics)
        Dim points As New List(Of Point)()
        points.Add(FirstPoint)
        points.Add(SecondPoint)
        points.Add(ThirdPoint)
        G.FillPolygon(New SolidBrush(Clr), points.ToArray)
    End Sub
#End Region

    Sub New()
        MyBase.New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.ResizeRedraw Or ControlStyles.UserPaint Or ControlStyles.DoubleBuffer, True)
        DrawMode = Windows.Forms.DrawMode.OwnerDrawFixed
        BackColor = Color.FromArgb(45, 45, 45)
        ForeColor = Color.White
        DropDownStyle = ComboBoxStyle.DropDownList
        DoubleBuffered = True
        Invalidate()
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        MyBase.OnPaint(e)

        Dim G As Graphics = e.Graphics
        Dim GP As New GraphicsPath

        G.SmoothingMode = SmoothingMode.HighQuality
        G.Clear(Color.FromArgb(17, 17, 17))
        G.DrawString(Text, Font, Brushes.White, New Rectangle(3, 0, Width - 20, Height), New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Near})
        G.DrawLine(New Pen(New SolidBrush(Color.FromArgb(70, 70, 70))), 0, Height - 1, Width, Height - 1)
        DrawTriangle(Color.White, New Point(Width - 14, 8), New Point(Width - 7, 8), New Point(Width - 11, 11), G)

        GP.StartFigure()
        GP.AddArc(New Rectangle(0, 0, 5, 5), 180, 90)
        GP.AddArc(New Rectangle(Width - 7, 0, 7, 7), -90, 90)
        GP.AddArc(New Rectangle(Width - 10, Height - 10, 10, 10), 0, 90)
        GP.AddArc(New Rectangle(0, Height - 7, 7, 7), 90, 90)
        GP.CloseFigure()

    End Sub
End Class

Public Class CSOButton : Inherits Control

#Region " Control Help - MouseState & Flicker Control"
    Private State As MouseState = MouseState.None

    Protected Overrides Sub OnMouseEnter(ByVal e As System.EventArgs)
        MyBase.OnMouseEnter(e)
        State = MouseState.Over
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseDown(e)
        State = MouseState.Down
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseLeave(ByVal e As System.EventArgs)
        MyBase.OnMouseLeave(e)
        State = MouseState.None
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseUp(e)
        State = MouseState.Over
        Invalidate()
    End Sub

    Protected Overrides Sub OnPaintBackground(ByVal pevent As System.Windows.Forms.PaintEventArgs)

    End Sub

    Protected Overrides Sub OnTextChanged(ByVal e As System.EventArgs)
        MyBase.OnTextChanged(e)
        Invalidate()
    End Sub
#End Region

    Sub New()
        MyBase.New()
        BackColor = Color.FromArgb(33, 33, 33)
        Font = New Font("Verdana", 6.75F)
        DoubleBuffered = True
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim G As Graphics = e.Graphics
        Dim GP As New GraphicsPath
        MyBase.OnPaint(e)

        GP.StartFigure()
        GP.AddArc(New Rectangle(0, 0, 5, 5), 180, 90)
        GP.AddArc(New Rectangle(Width - 7, 0, 7, 7), -90, 90)
        GP.AddArc(New Rectangle(Width - 10, Height - 10, 10, 10), 0, 90)
        GP.AddArc(New Rectangle(0, Height - 7, 7, 7), 90, 90)
        GP.CloseFigure()

        Region = New Region(GP)

        Dim NormalGradient As New LinearGradientBrush(New Rectangle(0, 0, Width, Height), Color.FromArgb(53, 53, 53), Color.FromArgb(10, 10, 10), 90S)
        Dim ClickedGradient As New LinearGradientBrush(New Rectangle(0, 0, Width, Height), Color.FromArgb(10, 10, 10), Color.FromArgb(53, 53, 53), 90S)

        Select Case State
            Case MouseState.None
                G.FillRectangle(NormalGradient, New Rectangle(0, 0, Width, Height))
            Case MouseState.Over
                G.Clear(Color.FromArgb(55, 65, 67))
                G.FillRectangle(NormalGradient, New Rectangle(2, 2, Width - 4, Height - 4))
            Case MouseState.Down
                G.Clear(Color.FromArgb(55, 65, 67))
                G.FillRectangle(ClickedGradient, New Rectangle(2, 2, Width - 4, Height - 4))
        End Select

        G.DrawString(Text, Font, Brushes.White, New Rectangle(0, 0, Width, Height), New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Center})
    End Sub
End Class

Public Class CSOProgressBar : Inherits Control

#Region " Control Help - Properties & Flicker Control "
    Private _Maximum As Integer = 100

    Public Property Maximum() As Integer
        Get
            Return _Maximum
        End Get
        Set(ByVal v As Integer)
            Select Case v
                Case Is < _Value
                    _Value = v
            End Select
            _Maximum = v
            Invalidate()
        End Set
    End Property

    Private _Value As Integer = 0
    Public Property Value() As Integer
        Get
            Select Case _Value
                Case 0
                    Return 1
                Case Else
                    Return _Value
            End Select
        End Get

        Set(ByVal v As Integer)
            Select Case v
                Case Is > _Maximum
                    v = _Maximum
            End Select
            _Value = v
            Invalidate()
        End Set
    End Property
    Protected Overrides Sub OnPaintBackground(ByVal pevent As System.Windows.Forms.PaintEventArgs)

    End Sub
#End Region

    Sub New()
        MyBase.New()
        DoubleBuffered = True
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim G As Graphics = e.Graphics
        MyBase.OnPaint(e)

        Height = 10

        Dim intValue As Integer = CInt(_Value / _Maximum * Width)

        Dim backGrad1 As New LinearGradientBrush(New Rectangle(0, 2, Width, Height - 5), Color.FromArgb(72, 72, 72), Color.FromArgb(35, 35, 35), 90S)
        Dim backGrad2 As New LinearGradientBrush(New Rectangle(0, Width, Width, Height - 3), Color.FromArgb(35, 35, 35), Color.FromArgb(52, 52, 52), 90S)
        G.DrawLine(New Pen(Color.FromArgb(40, 40, 40)), 0, 0, Width, 0)
        G.DrawLine(New Pen(Color.FromArgb(56, 56, 56)), 0, 1, Width, 1)
        G.FillRectangle(backGrad1, New Rectangle(0, 2, Width, Height - 5))
        G.FillRectangle(backGrad2, New Rectangle(0, Height - 3, Width, Height - 3))

        Dim backGrad3 As New LinearGradientBrush(New Rectangle(0, 2, intValue - 1, Height - 5), Color.FromArgb(255, 225, 130), Color.FromArgb(190, 140, 0), 90S)
        Dim backGrad4 As New LinearGradientBrush(New Rectangle(0, Height - 3, intValue - 1, Height - 3), Color.FromArgb(190, 140, 0), Color.FromArgb(240, 190, 40), 90S)
        G.DrawLine(New Pen(Color.FromArgb(190, 140, 45)), 0, 0, intValue - 1, 0)
        G.DrawLine(New Pen(Color.FromArgb(230, 175, 65)), 0, 1, intValue - 1, 1)
        G.FillRectangle(backGrad3, New Rectangle(0, 2, intValue, Height - 5))
        G.FillRectangle(backGrad4, New Rectangle(0, Height - 3, intValue, Height - 3))
    End Sub
End Class

Public Class CSOSeperator : Inherits Control

    Sub New()
        MyBase.New()
        DoubleBuffered = True
        BackColor = Color.FromArgb(33, 33, 33)
    End Sub

    Private P1, P2 As Pen

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim G As Graphics = e.Graphics
        MyBase.OnPaint(e)

        Dim P1 As New Pen(Color.FromArgb(35, 35, 35))
        Dim P2 As New Pen(Color.FromArgb(55, 55, 55))

        Height = 15

        G.Clear(BackColor)

        G.DrawLine(P1, 0, 5, Width, 5)
        G.DrawLine(P2, 0, 6, Width, 6)
    End Sub

End Class

Public Class CSOTabControl : Inherits TabControl

#Region " Control Help - Properties & Flicker Control "
    Private DrawGradientBrush, DrawGradientBrush2 As LinearGradientBrush
    Private _TabBrColor As Color
    Private _ControlBColor As Color

    Public Property TabBorderColor() As Color
        Get
            Return _TabBrColor
        End Get

        Set(ByVal v As Color)
            _TabBrColor = v
            Invalidate()
        End Set
    End Property

    Public Property TabTextColor() As Color
        Get
            Return _ControlBColor
        End Get

        Set(ByVal v As Color)
            _ControlBColor = v
            Invalidate()
        End Set
    End Property

    Protected Overrides Sub OnPaintBackground(ByVal pevent As PaintEventArgs)

    End Sub
#End Region

    Sub New()
        MyBase.New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.ResizeRedraw Or ControlStyles.UserPaint Or ControlStyles.DoubleBuffer, True)
        TabBorderColor = Color.White
        TabTextColor = Color.White
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim G As Graphics = e.Graphics
        MyBase.OnPaint(e)

        Dim ItemBounds As Rectangle
        Dim TextBrush As New SolidBrush(Color.Empty)
        Dim StringF As New StringFormat

        G.Clear(Color.FromArgb(32, 32, 32))

        For TabItemIndex As Integer = 0 To Me.TabCount - 1
            ItemBounds = Me.GetTabRect(TabItemIndex)

            Dim TabBG1 As New LinearGradientBrush(New Rectangle(ItemBounds.Location.X, ItemBounds.Location.Y, ItemBounds.Width, ItemBounds.Height - 6), Color.FromArgb(90, 90, 90), Color.FromArgb(90, 90, 90), 90S)

            If TabItemIndex = SelectedIndex Then
                G.FillRectangle(TabBG1, New Rectangle(ItemBounds.Location.X, ItemBounds.Location.Y, ItemBounds.Width - 2, ItemBounds.Height - 6))
            Else
                G.FillRectangle(TabBG1, New Rectangle(ItemBounds.Location.X, ItemBounds.Location.Y + 3, ItemBounds.Width - 2, ItemBounds.Height - 8))
            End If

            If Me.SelectedIndex = TabItemIndex Then
                TextBrush.Color = Color.White
            Else
                TextBrush.Color = Color.FromArgb(176, 176, 176)
            End If

            StringF.LineAlignment = StringAlignment.Center
            StringF.Alignment = StringAlignment.Center
            G.DrawString(TabPages(TabItemIndex).Text, Font, TextBrush, RectangleF.op_Implicit(Me.GetTabRect(TabItemIndex)), StringF)

            Try
                TabPages(TabItemIndex).BackColor = Color.FromArgb(32, 32, 32)
            Catch

            End Try
        Next

        Try
            For Each tabpg As TabPage In Me.TabPages
                tabpg.BorderStyle = BorderStyle.None
            Next
        Catch

        End Try
    End Sub
End Class