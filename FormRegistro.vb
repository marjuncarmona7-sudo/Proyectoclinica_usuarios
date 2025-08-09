Imports MySql.Data.MySqlClient
Imports System.Data

Public Class FormRegistro
    ' --- Conexión a la base de datos ---
    ' Se crea un objeto de conexión a la base de datos MySQL.
    Dim conexion As New MySqlConnection("server=localhost; user id=root; password=Nina1234; database=clinica_usuarios")

    ' --- Evento que se ejecuta al cargar el formulario ---
    Private Sub FormRegistro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Llama a la función para llenar el ComboBox de personas.
        CargarPersonas()
    End Sub

    ' --- Cargar lista de personas al ComboBox ---
    ' Esta función consulta la tabla 'persona' y llena el ComboBox.
    Private Sub CargarPersonas()
        Try
            conexion.Open()
            ' Consulta SQL para obtener la identificación y el nombre completo de las personas.
            Dim query As String = "SELECT idpersona, CONCAT(nombre, ' ', apellido) AS nombre_completo FROM persona"
            Dim adaptador As New MySqlDataAdapter(query, conexion)
            Dim tabla As New DataTable()
            adaptador.Fill(tabla)

            ' Asigna la tabla como origen de datos del ComboBox.
            CmbPersona.DataSource = tabla
            CmbPersona.DisplayMember = "nombre_completo" ' Lo que se muestra al usuario.
            CmbPersona.ValueMember = "idpersona" ' El valor que se usa internamente (el ID).
        Catch ex As Exception
            MessageBox.Show("Error al cargar personas: " & ex.Message)
        Finally
            If conexion.State = ConnectionState.Open Then conexion.Close()
        End Try
    End Sub

    ' --- Evento al hacer clic en el botón de Registrar ---
    Private Sub BtnRegistrar_Click(sender As Object, e As EventArgs) Handles BtnRegistrar.Click
        Try
            ' Valida que los campos de usuario y contraseña no estén vacíos.
            If String.IsNullOrEmpty(TxtNuevoUser.Text.Trim()) OrElse String.IsNullOrEmpty(TxtNuevoPass.Text.Trim()) Then
                MessageBox.Show("Por favor, complete todos los campos.")
                Return
            End If

            conexion.Open()

            ' 1. Genera un salt único y hashea la contraseña.
            Dim salt As String = Seguridad.GenerarSalt()
            Dim contrasenaConSalt As String = TxtNuevoPass.Text.Trim() & salt
            Dim contrasenaHasheada As String = Seguridad.HashSHA256(contrasenaConSalt)

            ' 2. Prepara la consulta SQL para insertar un nuevo usuario.
            Dim comando As New MySqlCommand("INSERT INTO usuarios (nombre_usuario, contrasena, salt, id_persona) VALUES (@usuario, @contrasena, @salt, @id_persona)", conexion)

            ' 3. Añade los parámetros a la consulta para evitar inyección SQL.
            comando.Parameters.AddWithValue("@usuario", TxtNuevoUser.Text.Trim())
            comando.Parameters.AddWithValue("@contrasena", contrasenaHasheada)
            comando.Parameters.AddWithValue("@salt", salt)
            comando.Parameters.AddWithValue("@id_persona", CmbPersona.SelectedValue)

            ' 4. Ejecuta la consulta para insertar el nuevo registro.
            comando.ExecuteNonQuery()

            MessageBox.Show("Usuario creado correctamente.")
            Me.Hide()
            Dim formLogin As New Form1()
            formLogin.Show()
        Catch ex As MySqlException
            ' Maneja el error específico de clave duplicada (código 1062).
            If ex.Number = 1062 Then
                MessageBox.Show("El nombre de usuario ya existe. Por favor, elija otro.")
            Else
                MessageBox.Show("Error al registrar el usuario: " & ex.Message)
            End If
        Finally
            If conexion.State = ConnectionState.Open Then conexion.Close()
        End Try
    End Sub
End Class