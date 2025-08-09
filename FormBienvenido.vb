Public Class FormBienvenido

    ' Evento que se ejecuta cuando el formulario se carga
    Private Sub FormBienvenido_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Muestra un mensaje de bienvenida si es necesario
        LblMensaje.Text = "¡Bienvenido, " & Sesion.NombreUsuario & "!"

        ' Verifica el rol del usuario desde el módulo de sesión
        If Sesion.Rol <> "Admin" Then
            ' Si el usuario no es un administrador, oculta el botón del módulo de usuarios
            ' Asegúrate de que el nombre de tu botón para usuarios sea BtnUsuarios
            If Me.Controls.ContainsKey("BtnUsuarios") Then
                Me.Controls("BtnUsuarios").Visible = False
            End If
        End If
    End Sub

    ' Evento para salir de la aplicación
    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Dim resultado As DialogResult
        resultado = MessageBox.Show("¿Deseas salir de la aplicación?", "Confirmar salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If resultado = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

    ' Evento para volver a la pantalla de login
    Private Sub BtnVolver_Click(sender As Object, e As EventArgs) Handles BtnVolver.Click
        Me.Hide()
        Dim form1 As New Form1()
        form1.Show()
    End Sub

    ' Muestra el nombre de usuario en una etiqueta
    ' (Ahora se llama desde el FormBienvenido_Load)
    ' Public Sub MostrarBienvenida(nombreUsuario As String)
    '     LblMensaje.Text = "¡Bienvenido, " & nombreUsuario & "!"
    ' End Sub

    ' Evento para abrir el formulario de gestión de personas
    Private Sub BtnPersona_Click(sender As Object, e As EventArgs) Handles BtnPersona.Click
        Dim formPersona As New FormPersona()
        formPersona.Show()
        Me.Hide()
    End Sub

    ' Evento para abrir el formulario de especialidades
    Private Sub BtnEspecialidades_Click(sender As Object, e As EventArgs) Handles BtnEspecialidades.Click
        Dim formEspecialidades As New FormEspecialidades()
        formEspecialidades.Show()
        Me.Hide()
    End Sub

    ' Evento para abrir el formulario de gestión de doctores
    Private Sub BtnDoctores_Click(sender As Object, e As EventArgs) Handles BtnDoctores.Click
        Dim formDoctores As New FormDoctores()
        formDoctores.Show()
        Me.Hide()
    End Sub

    Private Sub BtnConsultas_Click(sender As Object, e As EventArgs) Handles BtnConsultas.Click
        Dim formConsultas As New FormConsultas()
        formConsultas.Show()
        Me.Hide()
    End Sub

    Private Sub BtnTratamientos_Click(sender As Object, e As EventArgs) Handles BtnTratamientos.Click
        Dim formTratamientos As New FormTratamientos()
        formTratamientos.Show()
        Me.Hide()
    End Sub

    Private Sub BtnUsuarios_Click(sender As Object, e As EventArgs) Handles BtnUsuarios.Click
        Dim formUsuarios As New FormUsuarios()
        formUsuarios.Show()
        Me.Hide()
    End Sub

    Private Sub BtnReporte_Click(sender As Object, e As EventArgs) Handles BtnReporte.Click
        Dim formReporte As New FormReporte()
        formReporte.Show()
        Me.Hide()
    End Sub
End Class