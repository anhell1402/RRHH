Imports LaPiedad.RRHH.Clases
Imports LaPiedad.RRHH.Datos
Public Class UsuarioBL
    Public Property MensajeError As String
    Public Property HayError As Boolean

    Private cadenaConex As String
    Public Sub New(ByVal cadena As String)
        cadenaConex = cadena
        HayError = False
        MensajeError = String.Empty
    End Sub
    Public Sub Almacenar(ByVal usu_ As Usuario)
        Try
            Dim obj As New UsuarioDA(cadenaConex)
            obj.Almacenar(usu_)
            HayError = obj.HayError
            MensajeError = obj.MensajeError
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
        End Try
    End Sub
    Public Sub Actualizar(ByVal usu_ As Usuario)
        Try
            Dim obj As New UsuarioDA(cadenaConex)
            obj.Actualizar(usu_)
            HayError = obj.HayError
            MensajeError = obj.MensajeError
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
        End Try
    End Sub
    Public Sub Eliminar(ByVal usu_ As Usuario)
        Try
            Dim obj As New UsuarioDA(cadenaConex)
            obj.Eliminar(usu_)
            HayError = obj.HayError
            MensajeError = obj.MensajeError
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
        End Try
    End Sub
    Public Function Obtener(ByVal usu_ As Usuario) As Usuario
        Dim usua As New Usuario()
        Try
            Dim obj As New UsuarioDA(cadenaConex)
            usua = obj.Obtener(usu_)
            If obj.HayError Then
                usua = Nothing
            End If
            HayError = obj.HayError
            MensajeError = obj.MensajeError
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
            usua = Nothing
        End Try
        Return usua
    End Function
    Public Function ObtenerTodos() As Usuarios
        Dim lst As New Usuarios()
        Try
            Dim obj As New UsuarioDA(cadenaConex)
            lst = obj.ObtenerTodos()
            If obj.HayError Then
                lst = Nothing
            End If
            HayError = obj.HayError
            MensajeError = obj.MensajeError
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
            lst = Nothing
        End Try
        Return lst
    End Function
    Public Function Autenticar(ByVal usr As Usuario) As Usuario
        Try
            Dim obj As New UsuarioDA(cadenaConex)
            usr = obj.Autenticar(usr)
            If obj.HayError Then
                usr = Nothing
            End If
            HayError = obj.HayError
            MensajeError = obj.MensajeError
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
            usr = Nothing
        End Try
        Return usr
    End Function
    Public Function ObtenerMenu(ByVal usr As Usuario) As MnMenus
        Dim lst As MnMenus = Nothing
        Try
            Dim obj As New UsuarioDA(cadenaConex)
            lst = obj.ObtenerMenu(usr)
            If obj.HayError Then
                lst = Nothing
                HayError = True
                MensajeError = obj.MensajeError
            End If
            HayError = obj.HayError
            MensajeError = obj.MensajeError
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
            lst = Nothing
        End Try
        Return lst
    End Function
End Class
