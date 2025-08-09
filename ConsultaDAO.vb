' ConsultaDAO.vb
Imports MySql.Data.MySqlClient
Imports System.Data

Public Class ConsultaDAO
    Private ReadOnly conexion As New MySqlConnection("server=localhost; user id=root; password=Nina1234; database=clinica_usuarios")

    ' --- Método para INSERTAR una nueva consulta ---
    Public Sub InsertarConsulta(c As Consulta)
        Try
            Dim query As String = "INSERT INTO consulta (id_paciente, id_doctor, id_tratamiento, fecha_consulta, hora_consulta, observaciones) VALUES (@paciente, @doctor, @tratamiento, @fecha, @hora, @observaciones)"
            Using comando As New MySqlCommand(query, conexion)
                comando.Parameters.AddWithValue("@paciente", c.IdPaciente)
                comando.Parameters.AddWithValue("@doctor", c.IdDoctor)
                comando.Parameters.AddWithValue("@tratamiento", c.IdTratamiento)
                comando.Parameters.AddWithValue("@fecha", c.FechaConsulta)
                comando.Parameters.AddWithValue("@hora", c.HoraConsulta)
                comando.Parameters.AddWithValue("@observaciones", c.Observaciones)
                conexion.Open()
                comando.ExecuteNonQuery()
            End Using
        Finally
            If conexion.State = ConnectionState.Open Then conexion.Close()
        End Try
    End Sub

    ' --- Método para LEER todas las consultas (usando la vista) ---
    Public Function ObtenerConsultas() As DataTable
        Dim tabla As New DataTable()
        Try
            ' *** CAMBIO AQUI: Usando la vista para simplificar la consulta ***
            Dim query As String = "SELECT * FROM vista_consultas"
            Using adaptador As New MySqlDataAdapter(query, conexion)
                conexion.Open()
                adaptador.Fill(tabla)
            End Using
            Return tabla
        Finally
            If conexion.State = ConnectionState.Open Then conexion.Close()
        End Try
    End Function

    ' --- Método para ACTUALIZAR una consulta ---
    Public Sub ActualizarConsulta(c As Consulta)
        Try
            Dim query As String = "UPDATE consulta SET id_paciente = @paciente, id_doctor = @doctor, id_tratamiento = @tratamiento, fecha_consulta = @fecha, hora_consulta = @hora, observaciones = @observaciones WHERE id_consulta = @id"
            Using comando As New MySqlCommand(query, conexion)
                comando.Parameters.AddWithValue("@paciente", c.IdPaciente)
                comando.Parameters.AddWithValue("@doctor", c.IdDoctor)
                comando.Parameters.AddWithValue("@tratamiento", c.IdTratamiento)
                comando.Parameters.AddWithValue("@fecha", c.FechaConsulta)
                comando.Parameters.AddWithValue("@hora", c.HoraConsulta)
                comando.Parameters.AddWithValue("@observaciones", c.Observaciones)
                comando.Parameters.AddWithValue("@id", c.IdConsulta)
                conexion.Open()
                comando.ExecuteNonQuery()
            End Using
        Finally
            If conexion.State = ConnectionState.Open Then conexion.Close()
        End Try
    End Sub

    ' --- Método para ELIMINAR una consulta ---
    Public Sub EliminarConsulta(id As Integer)
        Try
            Dim query As String = "DELETE FROM consulta WHERE id_consulta = @id"
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