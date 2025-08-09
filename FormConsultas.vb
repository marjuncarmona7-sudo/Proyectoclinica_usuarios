' FormConsultas.vb
Imports System.Data

Public Class FormConsultas
    Private consultaDAO As New ConsultaDAO()
    Private personaDAO As New PersonaDAO()
    Private doctorDAO As New DoctorDAO()
    Private tratamientoDAO As New TratamientoDAO()
    Private idSeleccionado As Integer = 0

    Private Sub FormConsultas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarCombos()
        ActualizarDataGridView()
    End Sub

    ' --- Cargar los datos en los ComboBoxes ---
    Private Sub CargarCombos()
        ' ComboBox de Pacientes (Personas)
        CmbPaciente.DataSource = personaDAO.ObtenerPersonas()
        CmbPaciente.DisplayMember = "nombre"
        CmbPaciente.ValueMember = "idpersona"

        ' ComboBox de Doctores
        Dim doctoresDT As DataTable = doctorDAO.ObtenerDoctores()
        Dim doctoresList As New List(Of Object)()
        For Each row As DataRow In doctoresDT.Rows
            doctoresList.Add(New With {.Id = row("iddoctor"), .NombreCompleto = row("nombre").ToString() & " " & row("apellido").ToString()})
        Next
        CmbDoctor.DataSource = doctoresList
        CmbDoctor.DisplayMember = "NombreCompleto"
        CmbDoctor.ValueMember = "Id"

        ' ComboBox de Tratamientos
        CmbTratamiento.DataSource = tratamientoDAO.ObtenerTratamientos()
        CmbTratamiento.DisplayMember = "nombre_tratamiento"
        CmbTratamiento.ValueMember = "id_tratamiento"
    End Sub

    ' --- Cargar los datos en el DataGridView ---
    Private Sub ActualizarDataGridView()
        DgvConsultas.DataSource = consultaDAO.ObtenerConsultas()
    End Sub

    ' --- Botón de Guardar (Crear) ---
    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Dim nuevaConsulta As New Consulta With {
            .IdPaciente = Convert.ToInt32(CmbPaciente.SelectedValue),
            .IdDoctor = Convert.ToInt32(CmbDoctor.SelectedValue),
            .IdTratamiento = Convert.ToInt32(CmbTratamiento.SelectedValue),
            .FechaConsulta = DtFecha.Value.Date,
            .HoraConsulta = DtHora.Value.TimeOfDay,
            .Observaciones = TxtObservaciones.Text
        }
        consultaDAO.InsertarConsulta(nuevaConsulta)
        MessageBox.Show("Consulta guardada exitosamente.")
        ActualizarDataGridView()
        LimpiarCampos()
    End Sub

    ' --- Botón de Actualizar ---
    Private Sub BtnActualizar_Click(sender As Object, e As EventArgs) Handles BtnActualizar.Click
        If idSeleccionado > 0 Then
            Dim consultaActualizada As New Consulta With {
                .IdConsulta = idSeleccionado,
                .IdPaciente = Convert.ToInt32(CmbPaciente.SelectedValue),
                .IdDoctor = Convert.ToInt32(CmbDoctor.SelectedValue),
                .IdTratamiento = Convert.ToInt32(CmbTratamiento.SelectedValue),
                .FechaConsulta = DtFecha.Value.Date,
                .HoraConsulta = DtHora.Value.TimeOfDay,
                .Observaciones = TxtObservaciones.Text
            }
            consultaDAO.ActualizarConsulta(consultaActualizada)
            MessageBox.Show("Consulta actualizada exitosamente.")
            ActualizarDataGridView()
            LimpiarCampos()
        Else
            MessageBox.Show("Seleccione una consulta para actualizar.")
        End If
    End Sub

    ' --- Botón de Eliminar ---
    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles BtnEliminar.Click
        If idSeleccionado > 0 Then
            Dim resultado As DialogResult = MessageBox.Show("¿Está seguro?", "Confirmar eliminación", MessageBoxButtons.YesNo)
            If resultado = DialogResult.Yes Then
                consultaDAO.EliminarConsulta(idSeleccionado)
                MessageBox.Show("Consulta eliminada exitosamente.")
                ActualizarDataGridView()
                LimpiarCampos()
            End If
        Else
            MessageBox.Show("Seleccione una consulta para eliminar.")
        End If
    End Sub

    ' --- Llenar los campos al hacer clic en una fila del DataGridView ---
    Private Sub DgvConsultas_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvConsultas.CellClick
        If e.RowIndex >= 0 Then
            Dim fila As DataGridViewRow = DgvConsultas.Rows(e.RowIndex)
            ' Aquí necesitarás obtener los IDs de las tablas relacionadas para los ComboBoxes
            ' Esto es un poco más complejo, ya que la DGV muestra nombres, no IDs.
            ' Por ahora, para simplificar, usaremos los nombres para buscar en los ComboBoxes
            idSeleccionado = Convert.ToInt32(fila.Cells("id_consulta").Value)
            CmbPaciente.Text = fila.Cells("nombre_paciente").Value.ToString()
            CmbDoctor.Text = fila.Cells("nombre_doctor").Value.ToString()
            CmbTratamiento.Text = fila.Cells("nombre_tratamiento").Value.ToString()
            DtFecha.Value = Convert.ToDateTime(fila.Cells("fecha_consulta").Value)
            ' DtHora.Value = Convert.ToDateTime(fila.Cells("hora_consulta").Value) ' Esta línea puede dar error si el formato no es compatible.
            TxtObservaciones.Text = fila.Cells("observaciones").Value.ToString()
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
        CmbPaciente.SelectedIndex = -1
        CmbDoctor.SelectedIndex = -1
        CmbTratamiento.SelectedIndex = -1
        DtFecha.Value = DateTime.Now
        DtHora.Value = DateTime.Now
        TxtObservaciones.Text = ""
    End Sub
End Class