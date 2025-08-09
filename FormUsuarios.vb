' FormUsuarios.vb
Imports System.Data

Public Class FormUsuarios
    Private usuarioDAO As New UsuarioDAO()
    Private idSeleccionado As Integer = 0

    Private Sub FormUsuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarRoles()
        ActualizarDataGridView()
    End Sub

    Private Sub CargarRoles()
        CmbRol.Items.Add("Admin")
        CmbRol.Items.Add("Recepcionista")
        CmbRol.SelectedIndex = 1 ' Valor por defecto
    End Sub

    Private Sub ActualizarDataGridView()
        DgvUsuarios.DataSource = usuarioDAO.ObtenerUsuarios()
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Dim nuevoUsuario As New Usuario With {
            .Username = TxtUsuario.Text,
            .PasswordHash = TxtPassword.Text,
            .Rol = CmbRol.SelectedItem.ToString()
        }
        usuarioDAO.InsertarUsuario(nuevoUsuario)
        MessageBox.Show("Usuario guardado exitosamente.")
        ActualizarDataGridView()
        LimpiarCampos()
    End Sub

    Private Sub BtnActualizar_Click(sender As Object, e As EventArgs) Handles BtnActualizar.Click
        If idSeleccionado > 0 Then
            Dim usuarioActualizado As New Usuario With {
                .IdUsuario = idSeleccionado,
                .Username = TxtUsuario.Text,
                .Rol = CmbRol.SelectedItem.ToString()
            }
            usuarioDAO.ActualizarUsuario(usuarioActualizado)
            MessageBox.Show("Usuario actualizado exitosamente.")
            ActualizarDataGridView()
            LimpiarCampos()
        Else
            MessageBox.Show("Seleccione un usuario para actualizar.")
        End If
    End Sub

    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles BtnEliminar.Click
        If idSeleccionado > 0 Then
            Dim resultado As DialogResult = MessageBox.Show("¿Está seguro?", "Confirmar eliminación", MessageBoxButtons.YesNo)
            If resultado = DialogResult.Yes Then
                usuarioDAO.EliminarUsuario(idSeleccionado)
                MessageBox.Show("Usuario eliminado exitosamente.")
                ActualizarDataGridView()
                LimpiarCampos()
            End If
        Else
            MessageBox.Show("Seleccione un usuario para eliminar.")
        End If
    End Sub

    Private Sub DgvUsuarios_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvUsuarios.CellClick
        If e.RowIndex >= 0 Then
            Dim fila As DataGridViewRow = DgvUsuarios.Rows(e.RowIndex)
            idSeleccionado = Convert.ToInt32(fila.Cells("id_usuario").Value)
            TxtUsuario.Text = fila.Cells("nombre_usuario").Value.ToString()
            CmbRol.Text = fila.Cells("rol").Value.ToString()
        End If
    End Sub

    Private Sub BtnVolver_Click(sender As Object, e As EventArgs) Handles BtnVolver.Click
        Dim formBienvenido As New FormBienvenido()
        formBienvenido.Show()
        Me.Close()
    End Sub

    Private Sub LimpiarCampos()
        idSeleccionado = 0
        TxtUsuario.Text = ""
        TxtPassword.Text = ""
        CmbRol.SelectedIndex = 1 ' Vuelve a establecer el valor por defecto
    End Sub
End Class