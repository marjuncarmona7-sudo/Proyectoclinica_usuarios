<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormRegistro
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.LblNuevoUser = New System.Windows.Forms.Label()
        Me.lblNuevoPass = New System.Windows.Forms.Label()
        Me.TxtNuevoUser = New System.Windows.Forms.TextBox()
        Me.TxtNuevoPass = New System.Windows.Forms.TextBox()
        Me.BtnRegistrar = New System.Windows.Forms.Button()
        Me.CmbPersona = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'LblNuevoUser
        '
        Me.LblNuevoUser.AutoSize = True
        Me.LblNuevoUser.BackColor = System.Drawing.Color.AliceBlue
        Me.LblNuevoUser.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNuevoUser.Location = New System.Drawing.Point(86, 44)
        Me.LblNuevoUser.Name = "LblNuevoUser"
        Me.LblNuevoUser.Size = New System.Drawing.Size(159, 29)
        Me.LblNuevoUser.TabIndex = 0
        Me.LblNuevoUser.Text = "Nuevo Usuario"
        '
        'lblNuevoPass
        '
        Me.lblNuevoPass.AutoSize = True
        Me.lblNuevoPass.BackColor = System.Drawing.Color.AliceBlue
        Me.lblNuevoPass.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNuevoPass.Location = New System.Drawing.Point(73, 90)
        Me.lblNuevoPass.Name = "lblNuevoPass"
        Me.lblNuevoPass.Size = New System.Drawing.Size(192, 29)
        Me.lblNuevoPass.TabIndex = 1
        Me.lblNuevoPass.Text = "Nueva contrasena"
        '
        'TxtNuevoUser
        '
        Me.TxtNuevoUser.Location = New System.Drawing.Point(280, 44)
        Me.TxtNuevoUser.Name = "TxtNuevoUser"
        Me.TxtNuevoUser.Size = New System.Drawing.Size(93, 26)
        Me.TxtNuevoUser.TabIndex = 2
        '
        'TxtNuevoPass
        '
        Me.TxtNuevoPass.Location = New System.Drawing.Point(280, 93)
        Me.TxtNuevoPass.Name = "TxtNuevoPass"
        Me.TxtNuevoPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtNuevoPass.Size = New System.Drawing.Size(93, 26)
        Me.TxtNuevoPass.TabIndex = 3
        '
        'BtnRegistrar
        '
        Me.BtnRegistrar.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRegistrar.Location = New System.Drawing.Point(398, 67)
        Me.BtnRegistrar.Name = "BtnRegistrar"
        Me.BtnRegistrar.Size = New System.Drawing.Size(109, 38)
        Me.BtnRegistrar.TabIndex = 4
        Me.BtnRegistrar.Text = "Registrar"
        Me.BtnRegistrar.UseVisualStyleBackColor = True
        '
        'CmbPersona
        '
        Me.CmbPersona.FormattingEnabled = True
        Me.CmbPersona.Location = New System.Drawing.Point(583, 75)
        Me.CmbPersona.Name = "CmbPersona"
        Me.CmbPersona.Size = New System.Drawing.Size(90, 28)
        Me.CmbPersona.TabIndex = 5
        '
        'FormRegistro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Blue
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.CmbPersona)
        Me.Controls.Add(Me.BtnRegistrar)
        Me.Controls.Add(Me.TxtNuevoPass)
        Me.Controls.Add(Me.TxtNuevoUser)
        Me.Controls.Add(Me.lblNuevoPass)
        Me.Controls.Add(Me.LblNuevoUser)
        Me.Name = "FormRegistro"
        Me.Text = "Form2"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LblNuevoUser As Label
    Friend WithEvents lblNuevoPass As Label
    Friend WithEvents TxtNuevoUser As TextBox
    Friend WithEvents TxtNuevoPass As TextBox
    Friend WithEvents BtnRegistrar As Button
    Friend WithEvents CmbPersona As ComboBox
End Class
