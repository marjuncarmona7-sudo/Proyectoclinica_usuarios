' FormEspecialidades.vb
Imports System.Data

Public Class FormEspecialidades
    Private especialidadDAO As New EspecialidadDAO()
    Private idSeleccionado As Integer = 0

    Private Sub FormEspecialidades_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ActualizarDataGridView()
    End Sub

    Private Sub ActualizarDataGridView()
        DgvEspecialidades.DataSource = especialidadDAO.ObtenerEspecialidades()
    End Sub

    ' --- Botón Guardar (Crear) ---
    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Dim nuevaEspecialidad As New Especialidad With {
            .NombreEspecialidad = TxtNombreEspecialidad.Text
        }
        especialidadDAO.InsertarEspecialidad(nuevaEspecialidad)
        MessageBox.Show("Especialidad guardada.")
        ActualizarDataGridView()
        LimpiarCampos()
    End Sub

    ' --- Botón Actualizar ---
    Private Sub BtnActualizar_Click(sender As Object, e As EventArgs) Handles BtnActualizar.Click
        If idSeleccionado > 0 Then
            Dim especialidadActualizada As New Especialidad With {
                .Idespecialidad = idSeleccionado,
                .NombreEspecialidad = TxtNombreEspecialidad.Text
            }
            especialidadDAO.ActualizarEspecialidad(especialidadActualizada)
            MessageBox.Show("Especialidad actualizada.")
            ActualizarDataGridView()
            LimpiarCampos()
        Else
            MessageBox.Show("Seleccione una especialidad para actualizar.")
        End If
    End Sub

    ' --- Botón Eliminar ---
    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles BtnEliminar.Click
        If idSeleccionado > 0 Then
            Dim resultado As DialogResult = MessageBox.Show("¿Está seguro?", "Confirmar eliminación", MessageBoxButtons.YesNo)
            If resultado = DialogResult.Yes Then
                especialidadDAO.EliminarEspecialidad(idSeleccionado)
                MessageBox.Show("Especialidad eliminada.")
                ActualizarDataGridView()
                LimpiarCampos()
            End If
        Else
            MessageBox.Show("Seleccione una especialidad para eliminar.")
        End If
    End Sub

    ' --- Volver al dashboard ---
    Private Sub BtnVolver_Click(sender As Object, e As EventArgs) Handles BtnVolver.Click
        Dim formBienvenido As New FormBienvenido()
        formBienvenido.Show()
        Me.Close()
    End Sub

    ' --- Llenar los campos al seleccionar una fila ---
    Private Sub DgvEspecialidades_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvEspecialidades.CellClick
        If e.RowIndex >= 0 Then
            Dim fila As DataGridViewRow = DgvEspecialidades.Rows(e.RowIndex)
            idSeleccionado = Convert.ToInt32(fila.Cells("idespecialidad").Value)
            TxtNombreEspecialidad.Text = fila.Cells("nombre_especialidad").Value.ToString()
        End If
    End Sub

    ' --- Método de utilidad ---
    Private Sub LimpiarCampos()
        idSeleccionado = 0
        TxtNombreEspecialidad.Text = ""
    End Sub
End Class