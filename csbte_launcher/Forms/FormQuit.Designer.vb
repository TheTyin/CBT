<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormQuit
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormQuit))
        Me.CsoForm1 = New Counter_Strike_BreakThrough_3.CSOForm()
        Me.CsoButton1 = New Counter_Strike_BreakThrough_3.CSOButton()
        Me.CsoButton2 = New Counter_Strike_BreakThrough_3.CSOButton()
        Me.labelProcess = New System.Windows.Forms.Label()
        Me.CsoForm1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CsoForm1
        '
        Me.CsoForm1.BackColor = System.Drawing.Color.Red
        Me.CsoForm1.Controls.Add(Me.labelProcess)
        Me.CsoForm1.Controls.Add(Me.CsoButton2)
        Me.CsoForm1.Controls.Add(Me.CsoButton1)
        Me.CsoForm1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CsoForm1.Location = New System.Drawing.Point(0, 0)
        Me.CsoForm1.Name = "CsoForm1"
        Me.CsoForm1.Size = New System.Drawing.Size(303, 143)
        Me.CsoForm1.TabIndex = 0
        Me.CsoForm1.Text = "Quit"
        '
        'CsoButton1
        '
        Me.CsoButton1.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.CsoButton1.Font = New System.Drawing.Font("Verdana", 6.75!)
        Me.CsoButton1.Location = New System.Drawing.Point(25, 104)
        Me.CsoButton1.Name = "CsoButton1"
        Me.CsoButton1.Size = New System.Drawing.Size(121, 23)
        Me.CsoButton1.TabIndex = 1
        Me.CsoButton1.Text = "No"
        '
        'CsoButton2
        '
        Me.CsoButton2.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.CsoButton2.Font = New System.Drawing.Font("Verdana", 6.75!)
        Me.CsoButton2.Location = New System.Drawing.Point(152, 104)
        Me.CsoButton2.Name = "CsoButton2"
        Me.CsoButton2.Size = New System.Drawing.Size(121, 23)
        Me.CsoButton2.TabIndex = 2
        Me.CsoButton2.Text = "Yes"
        '
        'labelProcess
        '
        Me.labelProcess.BackColor = System.Drawing.Color.Transparent
        Me.labelProcess.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.labelProcess.ForeColor = System.Drawing.Color.White
        Me.labelProcess.Location = New System.Drawing.Point(22, 64)
        Me.labelProcess.Name = "labelProcess"
        Me.labelProcess.Size = New System.Drawing.Size(251, 13)
        Me.labelProcess.TabIndex = 5
        Me.labelProcess.Text = "You want to stop playing now ?"
        Me.labelProcess.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FormQuit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(303, 143)
        Me.Controls.Add(Me.CsoForm1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormQuit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Quit"
        Me.TransparencyKey = System.Drawing.Color.Red
        Me.CsoForm1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CsoForm1 As Counter_Strike_BreakThrough_3.CSOForm
    Friend WithEvents CsoButton2 As Counter_Strike_BreakThrough_3.CSOButton
    Friend WithEvents CsoButton1 As Counter_Strike_BreakThrough_3.CSOButton
    Friend WithEvents labelProcess As System.Windows.Forms.Label
End Class
