' EspecialidadDAO.vb
Imports MySql.Data.MySqlClient
Imports System.Data

Public Class EspecialidadDAO
    Private ReadOnly conexion As New MySqlConnection("server=localhost; user id=root; password=Nina1234; database=clinica_usuarios")

    ' --- Método para INSERTAR una nueva especialidad ---
    Public Sub InsertarEspecialidad(e As Especialidad)
        Try
            Dim query As String = "INSERT INTO especialidad (nombre_especialidad) VALUES (@nombre)"
            Using comando As New MySqlCommand(query, conexion)
                comando.Parameters.AddWithValue("@nombre", e.NombreEspecialidad)
                conexion.Open()
                comando.ExecuteNonQuery()
            End Using
        Finally
            If conexion.State = ConnectionState.Open Then conexion.Close()
        End Try
    End Sub

    ' --- Método para LEER todas las especialidades ---
    Public Function ObtenerEspecialidades() As DataTable
        Dim tabla As New DataTable()
        Try
            Dim query As String = "SELECT * FROM especialidad"
            Using adaptador As New MySqlDataAdapter(query, conexion)
                conexion.Open()
                adaptador.Fill(tabla)
            End Using
            Return tabla
        Finally
            If conexion.State = ConnectionState.Open Then conexion.Close()
        End Try
    End Function

    ' --- Método para ACTUALIZAR una especialidad ---
    Public Sub ActualizarEspecialidad(e As Especialidad)
        Try
            Dim query As String = "UPDATE especialidad SET nombre_especialidad = @nombre WHERE idespecialidad = @id"
            Using comando As New MySqlCommand(query, conexion)
                comando.Parameters.AddWithValue("@nombre", e.NombreEspecialidad)
                comando.Parameters.AddWithValue("@id", e.Idespecialidad)
                conexion.Open()
                comando.ExecuteNonQuery()
            End Using
        Finally
            If conexion.State = ConnectionState.Open Then conexion.Close()
        End Try
    End Sub

    ' --- Método para ELIMINAR una especialidad ---
    Public Sub EliminarEspecialidad(id As Integer)
        Try
            Dim query As String = "DELETE FROM especialidad WHERE idespecialidad = @id"
            Using comando As New MySqlCommand(query, conexion)
                comando.Parameters.AddWithValue("@id", id)
                conexion.Open()
                comando.ExecuteNonQuery()
            End Using
        Finally
            If conexion.State = ConnectionState.Open Then conexion.Close()
        End Try
    End Sub
End Class
