' DoctorDAO.vb
Imports MySql.Data.MySqlClient
Imports System.Data

Public Class DoctorDAO
    Private ReadOnly conexion As New MySqlConnection("server=localhost; user id=root; password=Nina1234; database=clinica_usuarios")

    ' --- Método para INSERTAR un nuevo doctor ---
    Public Sub InsertarDoctor(d As Doctor)
        Try
            Dim query As String = "INSERT INTO doctor (licencia_medica, id_persona, id_especialidad) VALUES (@licencia, @idpersona, @idespecialidad)"
            Using comando As New MySqlCommand(query, conexion)
                comando.Parameters.AddWithValue("@licencia", d.LicenciaMedica)
                comando.Parameters.AddWithValue("@idpersona", d.IdPersona)
                comando.Parameters.AddWithValue("@idespecialidad", d.IdEspecialidad)
                conexion.Open()
                comando.ExecuteNonQuery()
            End Using
        Finally
            If conexion.State = ConnectionState.Open Then conexion.Close()
        End Try
    End Sub

    ' --- Método para LEER todos los doctores (datos combinados) ---
    Public Function ObtenerDoctores() As DataTable
        Dim tabla As New DataTable()
        Try
            Dim query As String = "SELECT d.iddoctor, d.licencia_medica, p.nombre, p.apellido, e.nombre_especialidad FROM doctor d INNER JOIN persona p ON d.id_persona = p.idpersona INNER JOIN especialidad e ON d.id_especialidad = e.idespecialidad"
            Using adaptador As New MySqlDataAdapter(query, conexion)
                conexion.Open()
                adaptador.Fill(tabla)
            End Using
            Return tabla
        Finally
            If conexion.State = ConnectionState.Open Then conexion.Close()
        End Try
    End Function

    ' --- Método para ACTUALIZAR un doctor ---
    Public Sub ActualizarDoctor(d As Doctor)
        Try
            Dim query As String = "UPDATE doctor SET licencia_medica = @licencia, id_persona = @idpersona, id_especialidad = @idespecialidad WHERE iddoctor = @id"
            Using comando As New MySqlCommand(query, conexion)
                comando.Parameters.AddWithValue("@licencia", d.LicenciaMedica)
                comando.Parameters.AddWithValue("@idpersona", d.IdPersona)
                comando.Parameters.AddWithValue("@idespecialidad", d.IdEspecialidad)
                comando.Parameters.AddWithValue("@id", d.IdDoctor)
                conexion.Open()
                comando.ExecuteNonQuery()
            End Using
        Finally
            If conexion.State = ConnectionState.Open Then conexion.Close()
        End Try
    End Sub

    ' --- Método para ELIMINAR un doctor ---
    Public Sub EliminarDoctor(id As Integer)
        Try
            Dim query As String = "DELETE FROM doctor WHERE iddoctor = @id"
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