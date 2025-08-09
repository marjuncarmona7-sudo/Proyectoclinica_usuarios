' FormPersonas.vb
Imports System.Data

Public Class FormPersona
    Private personaDAO As New PersonaDAO()
    Private idSeleccionado As Integer = 0

    Private Sub FormPersona_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ActualizarDataGridView()
    End Sub

    ' --- Cargar los datos en el DataGridView ---
    Private Sub ActualizarDataGridView()
        DgvPersona.DataSource = personaDAO.ObtenerPersonas()
    End Sub

    ' --- Botón de Guardar (Crear) ---
    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        ' Crea un objeto de la clase Persona
        Dim nuevaPersona As New Persona()
        nuevaPersona.Nombre = TxtNombre.Text
        nuevaPersona.Apellido = TxtApellido.Text
        nuevaPersona.FechaNacimiento = DtFechaNacimiento.Value
        nuevaPersona.Identificacion = TxtIdentificacion.Text

        personaDAO.InsertarPersona(nuevaPersona)
        MessageBox.Show("Persona guardada exitosamente.")
        ActualizarDataGridView()
        LimpiarCampos()
    End Sub

    ' --- Botón de Actualizar ---
    Private Sub BtnActualizar_Click(sender As Object, e As EventArgs) Handles BtnActualizar.Click
        If idSeleccionado > 0 Then
            Dim personaActualizada As New Persona()
            personaActualizada.IdPersona = idSeleccionado
            personaActualizada.Nombre = TxtNombre.Text
            personaActualizada.Apellido = TxtApellido.Text
            personaActualizada.FechaNacimiento = DtFechaNacimiento.Value
            personaActualizada.Identificacion = TxtIdentificacion.Text

            personaDAO.ActualizarPersona(personaActualizada)
            MessageBox.Show("Persona actualizada exitosamente.")
            ActualizarDataGridView()
            LimpiarCampos()
        Else
            MessageBox.Show("Seleccione una persona para actualizar.")
        End If
    End Sub

    ' --- Botón de Eliminar ---
    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles BtnEliminar.Click
        If idSeleccionado > 0 Then
            Dim resultado As DialogResult = MessageBox.Show("¿Está seguro que desea eliminar este registro?", "Confirmar eliminación", MessageBoxButtons.YesNo)
            If resultado = DialogResult.Yes Then
                personaDAO.EliminarPersona(idSeleccionado)
                MessageBox.Show("Persona eliminada exitosamente.")
                ActualizarDataGridView()
                LimpiarCampos()
            End If
        Else
            MessageBox.Show("Seleccione una persona para eliminar.")
        End If
    End Sub

    ' --- Evento para llenar los campos al hacer clic en una fila del DataGridView ---
    Private Sub DgvPersona_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvPersona.CellClick
        If e.RowIndex >= 0 Then
            Dim fila As DataGridViewRow = DgvPersona.Rows(e.RowIndex)
            idSeleccionado = Convert.ToInt32(fila.Cells("idpersona").Value)
            TxtNombre.Text = fila.Cells("nombre").Value.ToString()
            TxtApellido.Text = fila.Cells("apellido").Value.ToString()
            DtFechaNacimiento.Value = Convert.ToDateTime(fila.Cells("fecha_nacimiento").Value)
            TxtIdentificacion.Text = fila.Cells("identificacion").Value.ToString()
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
        TxtNombre.Text = ""
        TxtApellido.Text = ""
        DtFechaNacimiento.Value = DateTime.Now
        TxtIdentificacion.Text = ""
    End Sub
End Class