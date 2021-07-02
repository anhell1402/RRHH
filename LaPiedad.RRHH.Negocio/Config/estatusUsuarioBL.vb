Imports LaPiedad.RRHH.Clases
Imports LaPiedad.RRHH.Datos
Public Class EstatusUsuarioBL
    Public Property MensajeError As String
    Public Property HayError As Boolean

    Private cadenaConex As String
    Public Sub New(ByVal cadena As String)
        cadenaConex = cadena
        HayError = False
        MensajeError = String.Empty
    End Sub

    Public Sub Almacenar(ByVal edo_ As EstatusUsuario)
        Try
            Dim obj As New EstatusUsuarioDA(cadenaConex)
            obj.Almacenar(edo_)
            HayError = obj.HayError
            MensajeError = obj.MensajeError
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
        End Try
    End Sub
    Public Sub Actualizar(ByVal edo_ As EstatusUsuario)
        Try
            Dim obj As New EstatusUsuarioDA(cadenaConex)
            obj.Actualizar(edo_)
            HayError = obj.HayError
            MensajeError = obj.MensajeError
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
        End Try
    End Sub
    Public Sub Eliminar(ByVal edo_ As EstatusUsuario)
        Try
            Dim obj As New EstatusUsuarioDA(cadenaConex)
            obj.Eliminar(edo_)
            HayError = obj.HayError
            MensajeError = obj.MensajeError
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
        End Try
    End Sub
    Public Function Obtener(ByVal edo_ As EstatusUsuario) As EstatusUsuario
        Dim edoU As New EstatusUsuario()
        Try
            Dim obj As New EstatusUsuarioDA(cadenaConex)
            edoU = obj.Obtener(edo_)
            If obj.HayError Then
                edoU = Nothing
            End If
            HayError = obj.HayError
            MensajeError = obj.MensajeError
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
            edoU = Nothing
        End Try
        Return edoU
    End Function
    Public Function ObtenerTodos() As EstatusUsuarios
        Dim lst As New EstatusUsuarios()
        Try
            Dim obj As New EstatusUsuarioDA(cadenaConex)
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
    Public Function ObtenerTodosDDL() As EstatusUsuarios
        Dim lst As New EstatusUsuarios()
        Try
            Dim obj As New EstatusUsuarioDA(cadenaConex)
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
