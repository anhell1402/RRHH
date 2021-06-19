Imports LaPiedad.RRHH.Clases
Imports LaPiedad.RRHH.Datos
Public Class ClavePagoBL
    Public Property MensajeError As String
    Public Property HayError As Boolean

    Private cadenaConex As String
    Public Sub New(ByVal cadena As String)
        cadenaConex = cadena
        HayError = False
        MensajeError = String.Empty
    End Sub

    Public Sub Almacenar(ByVal clave_ As ClavePago)
        Try
            Dim obj As New ClavePagoDA(cadenaConex)
            obj.Almacenar(clave_)
            HayError = obj.HayError
            MensajeError = obj.MensajeError
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
        End Try
    End Sub
    Public Sub Actualizar(ByVal clave_ As ClavePago)
        Try
            Dim obj As New ClavePagoDA(cadenaConex)
            obj.Actualizar(clave_)
            HayError = obj.HayError
            MensajeError = obj.MensajeError
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
        End Try
    End Sub
    Public Sub Eliminar(ByVal clave_ As ClavePago)
        Try
            Dim obj As New ClavePagoDA(cadenaConex)
            obj.Eliminar(clave_)
            HayError = obj.HayError
            MensajeError = obj.MensajeError
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
        End Try
    End Sub
    Public Function Obtener(ByVal clave_ As ClavePago) As ClavePago
        Dim cl As New ClavePago()
        Try
            Dim obj As New ClavePagoDA(cadenaConex)
            cl = obj.Obtener(clave_)
            If obj.HayError Then
                cl = Nothing
            End If
            HayError = obj.HayError
            MensajeError = obj.MensajeError
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
            cl = Nothing
        End Try
        Return cl
    End Function

    Public Function ObtenerTodos(ByVal clave_ As ClavePago) As ClavePagos
        Dim lst As New ClavePagos()
        Try
            Dim obj As New ClavePagoDA(cadenaConex)
            lst = obj.ObtenerTodos(clave_)
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
