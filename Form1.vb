Imports MySql.Data.MySqlClient
Imports System.Data

Public Class Form1
    ' --- Conexión a la base de datos ---
    Dim conexion As New MySqlConnection("server=localhost; user id=root; password=Nina1234; database=clinica_usuarios")

    ' --- Evento al hacer clic en el botón de Iniciar Sesión ---
    Private Sub BtnLogin_Click(sender As Object, e As EventArgs) Handles BtnLogin.Click
        Try
            ' Validar que los campos no estén vacíos
            If String.IsNullOrEmpty(TxtUsuario.Text.Trim()) OrElse String.IsNullOrEmpty(TxtPassword.Text.Trim()) Then
                MessageBox.Show("Por favor, ingrese el nombre de usuario y la contraseña.")
                Return
            End If

            conexion.Open()

            ' 1. La consulta SQL para obtener el hash, el salt y el rol del usuario
            Dim query As String = "SELECT contrasena, salt, rol FROM usuarios WHERE nombre_usuario = @usuario"
            Dim comando As New MySqlCommand(query, conexion)
            comando.Parameters.AddWithValue("@usuario", TxtUsuario.Text.Trim())

            Dim lector As MySqlDataReader = comando.ExecuteReader()

            ' 2. Se verifica si se encontró un usuario
            If lector.Read() Then
                Dim hashGuardado As String = lector("contrasena").ToString()
                Dim saltGuardado As String = lector("salt").ToString()
                Dim rolGuardado As String = lector("rol").ToString() ' <-- Aquí obtenemos el rol

                lector.Close()

                ' 3. Se hashea la contraseña ingresada con el salt de la base de datos
                Dim contrasenaConSalt As String = TxtPassword.Text.Trim() & saltGuardado
                Dim hashIngresado As String = Seguridad.HashSHA256(contrasenaConSalt)

                ' 4. Se compara el hash ingresado con el hash guardado
                If hashIngresado = hashGuardado Then
                    ' ¡Autenticación exitosa!

                    ' <-- AÑADE ESTO AQUÍ
                    ' Guardamos el nombre de usuario y el rol en el módulo de sesión
                    Sesion.NombreUsuario = TxtUsuario.Text.Trim()
                    Sesion.Rol = rolGuardado

                    MessageBox.Show("Bienvenido, " & TxtUsuario.Text)
                    Me.Hide()
                    Dim formBienvenido As New FormBienvenido()
                    formBienvenido.Show()
                Else
                    MessageBox.Show("Usuario o contraseña incorrectos.")
                End If
            Else
                lector.Close()
                MessageBox.Show("Usuario o contraseña incorrectos.")
            End If

        Catch ex As Exception
            MessageBox.Show("Error al conectar con la base de datos: " & ex.Message)
        Finally
            If conexion.State = ConnectionState.Open Then conexion.Close()
        End Try
    End Sub

    ' --- Evento al hacer clic en el botón de Crear Cuenta ---
    Private Sub BtnCrear_Click(sender As Object, e As EventArgs) Handles BtnCrear.Click
        Me.Hide()
        Dim formRegistro As New FormRegistro()
        formRegistro.Show()
    End Sub
End Class
