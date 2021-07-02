Imports LaPiedad.RRHH.Clases
Imports LaPiedad.RRHH.Datos
Public Class RolBL
    Public Property MensajeError As String
    Public Property HayError As Boolean

    Private cadenaConex As String
    Public Sub New(ByVal cadena As String)
        cadenaConex = cadena
        HayError = False
        MensajeError = String.Empty
    End Sub
    Public Sub Almacenar(ByVal rl_ As Rol)
        Try
            Dim obj As New RolDA(cadenaConex)
            obj.Almacenar(rl_)
            HayError = obj.HayError
            MensajeError = obj.MensajeError
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
        End Try
    End Sub
    Public Sub Actualizar(ByVal rl_ As Rol)
        Try
            Dim obj As New RolDA(cadenaConex)
            obj.Actualizar(rl_)
            HayError = obj.HayError
            MensajeError = obj.MensajeError
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
        End Try
    End Sub
    Public Sub Eliminar(ByVal rl_ As Rol)
        Try
            Dim obj As New RolDA(cadenaConex)
            obj.Eliminar(rl_)
            HayError = obj.HayError
            MensajeError = obj.MensajeError
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
        End Try
    End Sub
    Public Function Obtener(ByVal rl_ As Rol) As Rol
        Dim rol_ As New Rol()
        Try
            Dim obj As New RolDA(cadenaConex)
            rol_ = obj.Obtener(rl_)
            If obj.HayError Then
                rol_ = Nothing
            End If
            HayError = obj.HayError
            MensajeError = obj.MensajeError
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
            rol_ = Nothing
        End Try
        Return rol_
    End Function
    Public Function ObtenerTodos() As Roles
        Dim lst As New Roles()
        Try
            Dim obj As New RolDA(cadenaConex)
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
    Public Function ObtenerTodosDDL() As Roles
        Dim lst As New Roles()
        Try
            Dim obj As New RolDA(cadenaConex)
            lst = obj.ObtenerTodosDDL()
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
End Class
