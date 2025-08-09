' PersonaDAO.vb
Imports MySql.Data.MySqlClient
Imports System.Data

Public Class PersonaDAO
    ' La variable de conexión se declara como ReadOnly porque su valor no cambia.
    Private ReadOnly conexion As New MySqlConnection("server=localhost; user id=root; password=Nina1234; database=clinica_usuarios")

    ' --- Método para INSERTAR una nueva persona ---
    Public Sub InsertarPersona(p As Persona)
        Try
            Dim query As String = "INSERT INTO persona (nombre, apellido, fecha_nacimiento, identificacion) VALUES (@nombre, @apellido, @fecha_nacimiento, @identificacion)"
            Using comando As New MySqlCommand(query, conexion)
                comando.Parameters.AddWithValue("@nombre", p.Nombre)
                comando.Parameters.AddWithValue("@apellido", p.Apellido)
                comando.Parameters.AddWithValue("@fecha_nacimiento", p.FechaNacimiento)
                comando.Parameters.AddWithValue("@identificacion", p.Identificacion)
                conexion.Open()
                comando.ExecuteNonQuery()
            End Using
        Finally
            If conexion.State = ConnectionState.Open Then conexion.Close()
        End Try
    End Sub

    ' --- Método para LEER todas las personas ---
    Public Function ObtenerPersonas() As DataTable
        Dim tabla As New DataTable()
        Try
            Dim query As String = "SELECT * FROM persona"
            Using adaptador As New MySqlDataAdapter(query, conexion)
                conexion.Open()
                adaptador.Fill(tabla)
            End Using
            Return tabla
        Finally
            If conexion.State = ConnectionState.Open Then conexion.Close()
        End Try
    End Function

    ' --- Método para ACTUALIZAR una persona ---
    Public Sub ActualizarPersona(p As Persona)
        Try
            Dim query As String = "UPDATE persona SET nombre = @nombre, apellido = @apellido, fecha_nacimiento = @fecha_nacimiento, identificacion = @identificacion WHERE idpersona = @id"
            Using comando As New MySqlCommand(query, conexion)
                comando.Parameters.AddWithValue("@nombre", p.Nombre)
                comando.Parameters.AddWithValue("@apellido", p.Apellido)
                comando.Parameters.AddWithValue("@fecha_nacimiento", p.FechaNacimiento)
                comando.Parameters.AddWithValue("@identificacion", p.Identificacion)
                comando.Parameters.AddWithValue("@id", p.IdPersona)
                conexion.Open()
                comando.ExecuteNonQuery()
            End Using
        Finally
            If conexion.State = ConnectionState.Open Then conexion.Close()
        End Try
    End Sub

    ' --- Método para ELIMINAR una persona ---
    Public Sub EliminarPersona(id As Integer)
        Try
            Dim query As String = "DELETE FROM persona WHERE idpersona = @id"
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