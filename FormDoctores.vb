Imports System.Data

Public Class FormDoctores
    Private doctorDAO As New DoctorDAO()
    Private personaDAO As New PersonaDAO()
    Private especialidadDAO As New EspecialidadDAO()
    Private idSeleccionado As Integer = 0
    Private WithEvents ErrorProvider1 As New ErrorProvider()
    Private WithEvents ToolTip1 As New ToolTip()

    Private Sub FormDoctores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarCombos()
        ActualizarDataGridView()
        ' --- Asignar Tooltips para dar ayuda al usuario ---
        ToolTip1.SetToolTip(TxtLicencia, "Ingrese la cédula profesional del doctor.")
        ToolTip1.SetToolTip(CmbPersona, "Seleccione la persona asociada al doctor.")
        ToolTip1.SetToolTip(CmbEspecialidad, "Seleccione la especialidad del doctor.")
    End Sub

    ' --- Cargar los datos en los ComboBoxes ---
    Private Sub CargarCombos()
        ' ComboBox de Personas
        CmbPersona.DataSource = personaDAO.ObtenerPersonas()
        CmbPersona.DisplayMember = "nombre_completo" ' Asumiendo que tu DAO devuelve el nombre completo
        CmbPersona.ValueMember = "idpersona"

        ' ComboBox de Especialidades
        CmbEspecialidad.DataSource = especialidadDAO.ObtenerEspecialidades()
        CmbEspecialidad.DisplayMember = "nombre_especialidad"
        CmbEspecialidad.ValueMember = "idespecialidad"
    End Sub

    ' --- Cargar los datos en el DataGridView ---
    Private Sub ActualizarDataGridView()
        DgvDoctores.DataSource = doctorDAO.ObtenerDoctores()
    End Sub

    ' --- Botón de Guardar (Crear) ---
    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        If Not ValidarCampos() Then
            Return ' Salir si la validación falla
        End If

        Dim nuevoDoctor As New Doctor With {
            .LicenciaMedica = TxtLicencia.Text,
            .IdPersona = Convert.ToInt32(CmbPersona.SelectedValue),
            .IdEspecialidad = Convert.ToInt32(CmbEspecialidad.SelectedValue)
        }
        doctorDAO.InsertarDoctor(nuevoDoctor)
        MessageBox.Show("Doctor guardado exitosamente.")
        ActualizarDataGridView()
        LimpiarCampos()
    End Sub

    ' --- Botón de Actualizar ---
    Private Sub BtnActualizar_Click(sender As Object, e As EventArgs) Handles BtnActualizar.Click
        If Not ValidarCampos() Then
            Return ' Salir si la validación falla
        End If

        If idSeleccionado > 0 Then
            Dim doctorActualizado As New Doctor With {
                .IdDoctor = idSeleccionado,
                .LicenciaMedica = TxtLicencia.Text,
                .IdPersona = Convert.ToInt32(CmbPersona.SelectedValue),
                .IdEspecialidad = Convert.ToInt32(CmbEspecialidad.SelectedValue)
            }
            doctorDAO.ActualizarDoctor(doctorActualizado)
            MessageBox.Show("Doctor actualizado exitosamente.")
            ActualizarDataGridView()
            LimpiarCampos()
        Else
            MessageBox.Show("Seleccione un doctor para actualizar.")
        End If
    End Sub

    ' --- Botón de Eliminar ---
    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles BtnEliminar.Click
        If idSeleccionado > 0 Then
            Dim resultado As DialogResult = MessageBox.Show("¿Está seguro que desea eliminar este registro?", "Confirmar eliminación", MessageBoxButtons.YesNo)
            If resultado = DialogResult.Yes Then
                doctorDAO.EliminarDoctor(idSeleccionado)
                MessageBox.Show("Doctor eliminado exitosamente.")
                ActualizarDataGridView()
                LimpiarCampos()
            End If
        Else
            MessageBox.Show("Seleccione un doctor para eliminar.")
        End If
    End Sub

    ' --- Evento para llenar los campos al hacer clic en una fila del DataGridView ---
    Private Sub DgvDoctores_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvDoctores.CellClick
        If e.RowIndex >= 0 Then
            Dim fila As DataGridViewRow = DgvDoctores.Rows(e.RowIndex)
            idSeleccionado = Convert.ToInt32(fila.Cells("iddoctor").Value)
            TxtLicencia.Text = fila.Cells("licencia_medica").Value.ToString()
            CmbPersona.Text = fila.Cells("nombre_paciente").Value.ToString() & " " & fila.Cells("apellido_paciente").Value.ToString()
            CmbEspecialidad.Text = fila.Cells("nombre_especialidad").Value.ToString()
        End If
    End Sub

    ' --- Botón de Volver al Dashboard ---
    Private Sub BtnVolver_Click(sender As Object, e As EventArgs) Handles BtnVolver.Click
        Dim formBienvenido As New FormBienvenido()
        formBienvenido.Show()
        Me.Close()
    End Sub

    ' --- Método de utilidad para limpiar los campos del formulario ---
    Private Sub LimpiarCampos()
        idSeleccionado = 0
        TxtLicencia.Text = ""
        CmbPersona.SelectedIndex = -1
        CmbEspecialidad.SelectedIndex = -1
    End Sub

    ' --- FUNCIÓN PARA VALIDAR LOS CAMPOS ---
    Private Function ValidarCampos() As Boolean
        ErrorProvider1.Clear()
        Dim isValid As Boolean = True

        ' Validar TxtLicencia
        If String.IsNullOrWhiteSpace(TxtLicencia.Text) Then
            ErrorProvider1.SetError(TxtLicencia, "La licencia médica es obligatoria.")
            isValid = False
        End If

        ' Validar CmbPersona
        If CmbPersona.SelectedIndex = -1 Then
            ErrorProvider1.SetError(CmbPersona, "Debe seleccionar una persona.")
            isValid = False
        End If

        ' Validar CmbEspecialidad
        If CmbEspecialidad.SelectedIndex = -1 Then
            ErrorProvider1.SetError(CmbEspecialidad, "Debe seleccionar una especialidad.")
            isValid = False
        End If

        Return isValid
    End Function
End Class