Imports LaPiedad.RRHH.Clases
Imports LaPiedad.RRHH.Datos
Public Class PadecimientoBL
    Public Property MensajeError As String
    Public Property HayError As Boolean

    Private cadenaConex As String
    Public Sub New(ByVal cadena As String)
        cadenaConex = cadena
        HayError = False
        MensajeError = String.Empty
    End Sub
    Public Sub Almacenar(ByVal pad_ As Padecimiento)
        Try
            Dim obj As New PadecimientoDA(cadenaConex)
            obj.Almacenar(pad_)
            HayError = obj.HayError
            MensajeError = obj.MensajeError
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
        End Try
    End Sub
    Public Sub Actualizar(ByVal pad_ As Padecimiento)
        Try
            Dim obj As New PadecimientoDA(cadenaConex)
            obj.Actualizar(pad_)
            HayError = obj.HayError
            MensajeError = obj.MensajeError
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
        End Try
    End Sub
    Public Sub Eliminar(ByVal pad_ As Padecimiento)
        Try
            Dim obj As New PadecimientoDA(cadenaConex)
            obj.Eliminar(pad_)
            HayError = obj.HayError
            MensajeError = obj.MensajeError
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
        End Try
    End Sub
    Public Function Obtener(ByVal pad_ As Padecimiento) As Padecimiento
        Dim pade As New Padecimiento()
        Try
            Dim obj As New PadecimientoDA(cadenaConex)
            pade = obj.Obtener(pad_)
            If obj.HayError Then
                pade = Nothing
            End If
            HayError = obj.HayError
            MensajeError = obj.MensajeError
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
            pade = Nothing
        End Try
        Return pade
    End Function
    Public Function ObtenerTodos() As Padecimientos
        Dim lst As New Padecimientos()
        Try
            Dim obj As New PadecimientoDA(cadenaConex)
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
