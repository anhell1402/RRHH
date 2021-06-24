Imports LaPiedad.RRHH.Clases
Imports LaPiedad.RRHH.Datos
Public Class PasatiempoBL
    Public Property MensajeError As String
    Public Property HayError As Boolean

    Private cadenaConex As String
    Public Sub New(ByVal cadena As String)
        cadenaConex = cadena
        HayError = False
        MensajeError = String.Empty
    End Sub
    Public Sub Almacenar(ByVal pas_ As Pasatiempo)
        Try
            Dim obj As New PasatiempoDA(cadenaConex)
            obj.Almacenar(pas_)
            HayError = obj.HayError
            MensajeError = obj.MensajeError
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
        End Try
    End Sub
    Public Sub Actualizar(ByVal pas_ As Pasatiempo)
        Try
            Dim obj As New PasatiempoDA(cadenaConex)
            obj.Actualizar(pas_)
            HayError = obj.HayError
            MensajeError = obj.MensajeError
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
        End Try
    End Sub
    Public Sub Eliminar(ByVal pas_ As Pasatiempo)
        Try
            Dim obj As New PasatiempoDA(cadenaConex)
            obj.Eliminar(pas_)
            HayError = obj.HayError
            MensajeError = obj.MensajeError
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
        End Try
    End Sub
    Public Function Obtener(ByVal pas_ As Pasatiempo) As Pasatiempo
        Dim pasa As New Pasatiempo()
        Try
            Dim obj As New PasatiempoDA(cadenaConex)
            pasa = obj.Obtener(pas_)
            If obj.HayError Then
                pasa = Nothing
            End If
            HayError = obj.HayError
            MensajeError = obj.MensajeError
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
            pasa = Nothing
        End Try
        Return pasa
    End Function
    Public Function ObtenerTodos() As Pasatiempos
        Dim lst As New Pasatiempos()
        Try
            Dim obj As New PasatiempoDA(cadenaConex)
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
