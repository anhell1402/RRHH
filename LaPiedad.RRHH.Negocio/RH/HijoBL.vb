Imports LaPiedad.RRHH.Clases
Imports LaPiedad.RRHH.Datos
Public Class HijoBL
    Public Property MensajeError As String
    Public Property HayError As Boolean

    Private cadenaConex As String
    Public Sub New(ByVal cadena As String)
        cadenaConex = cadena
        HayError = False
        MensajeError = String.Empty
    End Sub
    Public Sub Almacenar(ByVal hi_ As Hijo)
        Try
            Dim obj As New HijoDA(cadenaConex)
            obj.Almacenar(hi_)
            HayError = obj.HayError
            MensajeError = obj.MensajeError
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
        End Try
    End Sub
    Public Sub Actualizar(ByVal hi_ As Hijo)
        Try
            Dim obj As New HijoDA(cadenaConex)
            obj.Actualizar(hi_)
            HayError = obj.HayError
            MensajeError = obj.MensajeError
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
        End Try
    End Sub
    Public Sub Eliminar(ByVal hi_ As Hijo)
        Try
            Dim obj As New HijoDA(cadenaConex)
            obj.Eliminar(hi_)
            HayError = obj.HayError
            MensajeError = obj.MensajeError
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
        End Try
    End Sub
    Public Function Obtener(ByVal hi_ As Hijo) As Hijo
        Dim hijo_ As New Hijo()
        Try
            Dim obj As New HijoDA(cadenaConex)
            hijo_ = obj.Obtener(hi_)
            If obj.HayError Then
                hijo_ = Nothing
            End If
            HayError = obj.HayError
            MensajeError = obj.MensajeError
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
            hijo_ = Nothing
        End Try
        Return hijo_
    End Function
    Public Function ObtenerTodos() As Hijos
        Dim lst As New Hijos()
        Try
            Dim obj As New HijoDA(cadenaConex)
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
