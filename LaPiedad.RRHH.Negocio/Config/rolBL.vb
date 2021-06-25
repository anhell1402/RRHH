Imports LaPiedad.RRHH.Clases
Imports LaPiedad.RRHH.Datos
Public Class rolBL
    Public Property MensajeError As String
    Public Property HayError As Boolean

    Private cadenaConex As String
    Public Sub New(ByVal cadena As String)
        cadenaConex = cadena
        HayError = False
        MensajeError = String.Empty
    End Sub
    Public Sub Almacenar(ByVal rl_ As rol)
        Try
            Dim obj As New rolDA(cadenaConex)
            obj.Almacenar(rl_)
            HayError = obj.HayError
            MensajeError = obj.MensajeError
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
        End Try
    End Sub
    Public Sub Actualizar(ByVal rl_ As rol)
        Try
            Dim obj As New rolDA(cadenaConex)
            obj.Actualizar(rl_)
            HayError = obj.HayError
            MensajeError = obj.MensajeError
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
        End Try
    End Sub
    Public Sub Eliminar(ByVal rl_ As rol)
        Try
            Dim obj As New rolDA(cadenaConex)
            obj.Eliminar(rl_)
            HayError = obj.HayError
            MensajeError = obj.MensajeError
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
        End Try
    End Sub
    Public Function Obtener(ByVal rl_ As rol) As rol
        Dim rol_ As New rol()
        Try
            Dim obj As New rolDA(cadenaConex)
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
    Public Function ObtenerTodos() As roles
        Dim lst As New roles()
        Try
            Dim obj As New rolDA(cadenaConex)
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
End Class
