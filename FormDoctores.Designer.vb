<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDoctores
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
        Me.DgvDoctores = New System.Windows.Forms.DataGridView()
        Me.TxtLicencia = New System.Windows.Forms.TextBox()
        Me.CmbPersona = New System.Windows.Forms.ComboBox()
        Me.CmbEspecialidad = New System.Windows.Forms.ComboBox()
        Me.BtnGuardar = New System.Windows.Forms.Button()
        Me.BtnEliminar = New System.Windows.Forms.Button()
        Me.BtnVolver = New System.Windows.Forms.Button()
        Me.BtnActualizar = New System.Windows.Forms.Button()
        CType(Me.DgvDoctores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DgvDoctores
        '
        Me.DgvDoctores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvDoctores.Location = New System.Drawing.Point(296, 83)
        Me.DgvDoctores.Name = "DgvDoctores"
        Me.DgvDoctores.RowHeadersWidth = 62
        Me.DgvDoctores.RowTemplate.Height = 28
        Me.DgvDoctores.Size = New System.Drawing.Size(676, 342)
        Me.DgvDoctores.TabIndex = 0
        '
        'TxtLicencia
        '
        Me.TxtLicencia.Location = New System.Drawing.Point(435, 25)
        Me.TxtLicencia.Name = "TxtLicencia"
        Me.TxtLicencia.Size = New System.Drawing.Size(165, 26)
        Me.TxtLicencia.TabIndex = 1
        Me.TxtLicencia.Text = "Licencia medica"
        '
        'CmbPersona
        '
        Me.CmbPersona.FormattingEnabled = True
        Me.CmbPersona.Location = New System.Drawing.Point(777, 23)
        Me.CmbPersona.Name = "CmbPersona"
        Me.CmbPersona.Size = New System.Drawing.Size(121, 28)
        Me.CmbPersona.TabIndex = 2
        '
        'CmbEspecialidad
        '
        Me.CmbEspecialidad.FormattingEnabled = True
        Me.CmbEspecialidad.Location = New System.Drawing.Point(620, 25)
        Me.CmbEspecialidad.Name = "CmbEspecialidad"
        Me.CmbEspecialidad.Size = New System.Drawing.Size(121, 28)
        Me.CmbEspecialidad.TabIndex = 3
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Location = New System.Drawing.Point(127, 45)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(163, 78)
        Me.BtnGuardar.TabIndex = 4
        Me.BtnGuardar.Text = "Guardar"
        Me.BtnGuardar.UseVisualStyleBackColor = True
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Location = New System.Drawing.Point(127, 152)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(163, 77)
        Me.BtnEliminar.TabIndex = 5
        Me.BtnEliminar.Text = "Eliminar"
        Me.BtnEliminar.UseVisualStyleBackColor = True
        '
        'BtnVolver
        '
        Me.BtnVolver.Location = New System.Drawing.Point(127, 250)
        Me.BtnVolver.Name = "BtnVolver"
        Me.BtnVolver.Size = New System.Drawing.Size(163, 68)
        Me.BtnVolver.TabIndex = 6
        Me.BtnVolver.Text = "Volver"
        Me.BtnVolver.UseVisualStyleBackColor = True
        '
        'BtnActualizar
        '
        Me.BtnActualizar.Location = New System.Drawing.Point(127, 334)
        Me.BtnActualizar.Name = "BtnActualizar"
        Me.BtnActualizar.Size = New System.Drawing.Size(163, 67)
        Me.BtnActualizar.TabIndex = 7
        Me.BtnActualizar.Text = "Actualizar"
        Me.BtnActualizar.UseVisualStyleBackColor = True
        '
        'FormDoctores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Blue
        Me.ClientSize = New System.Drawing.Size(984, 450)
        Me.Controls.Add(Me.BtnActualizar)
        Me.Controls.Add(Me.BtnVolver)
        Me.Controls.Add(Me.BtnEliminar)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.CmbEspecialidad)
        Me.Controls.Add(Me.CmbPersona)
        Me.Controls.Add(Me.TxtLicencia)
        Me.Controls.Add(Me.DgvDoctores)
        Me.Name = "FormDoctores"
        Me.Text = "FormDoctores"
        CType(Me.DgvDoctores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DgvDoctores As DataGridView
    Friend WithEvents TxtLicencia As TextBox
    Friend WithEvents CmbPersona As ComboBox
    Friend WithEvents CmbEspecialidad As ComboBox
    Friend WithEvents BtnGuardar As Button
    Friend WithEvents BtnEliminar As Button
    Friend WithEvents BtnVolver As Button
    Friend WithEvents BtnActualizar As Button
End Class
