Imports LaPiedad.RRHH.Clases
Imports LaPiedad.RRHH.Datos
Public Class EstatusEscolaridadBL
    Public Property MensajeError As String
    Public Property HayError As Boolean

    Private cadenaConex As String
    Public Sub New(ByVal cadena As String)
        cadenaConex = cadena
        HayError = False
        MensajeError = String.Empty
    End Sub
    Public Sub Almacenar(ByVal estat_ As EstatusEscolaridad)
        Try
            Dim obj As New EstatusEscolaridadDA(cadenaConex)
            obj.Almacenar(estat_)
            HayError = obj.HayError
            MensajeError = obj.MensajeError
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
        End Try
    End Sub
    Public Sub Actualizar(ByVal estat_ As EstatusEscolaridad)
        Try
            Dim obj As New EstatusEscolaridadDA(cadenaConex)
            obj.Actualizar(estat_)
            HayError = obj.HayError
            MensajeError = obj.MensajeError
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
        End Try
    End Sub
    Public Sub Eliminar(ByVal estat_ As EstatusEscolaridad)
        Try
            Dim obj As New EstatusEscolaridadDA(cadenaConex)
            obj.Eliminar(estat_)
            HayError = obj.HayError
            MensajeError = obj.MensajeError
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
        End Try
    End Sub
    Public Function Obtener(ByVal est_ As EstatusEscolaridad) As EstatusEscolaridad
        Dim est As New EstatusEscolaridad()
        Try
            Dim obj As New EstatusEscolaridadDA(cadenaConex)
            est = obj.Obtener(est_)
            If obj.HayError Then
                est = Nothing
            End If
            HayError = obj.HayError
            MensajeError = obj.MensajeError
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
            est = Nothing
        End Try
        Return est
    End Function
    Public Function ObtenerTodos(ByVal est_ As EstatusEscolaridad) As EstatusEscolaridades
        Dim lst As New EstatusEscolaridades()
        Try
            Dim obj As New EstatusEscolaridadDA(cadenaConex)
            lst = obj.ObtenerTodos(est_)
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
