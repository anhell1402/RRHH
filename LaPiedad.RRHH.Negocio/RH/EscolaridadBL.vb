Imports LaPiedad.RRHH.Clases
Imports LaPiedad.RRHH.Datos
Public Class EscolaridadBL
    Public Property MensajeError As String
    Public Property HayError As Boolean

    Private cadenaConex As String
    Public Sub New(ByVal cadena As String)
        cadenaConex = cadena
        HayError = False
        MensajeError = String.Empty
    End Sub
    Public Sub Almacenar(ByVal esc_ As Escolaridad)
        Try
            Dim obj As New EscolaridadDA(cadenaConex)
            obj.Almacenar(esc_)
            HayError = obj.HayError
            MensajeError = obj.MensajeError
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
        End Try
    End Sub
    Public Sub Actualizar(ByVal esc_ As Escolaridad)
        Try
            Dim obj As New EscolaridadDA(cadenaConex)
            obj.Actualizar(esc_)
            HayError = obj.HayError
            MensajeError = obj.MensajeError
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
        End Try
    End Sub
    Public Sub Eliminar(ByVal esc_ As Escolaridad)
        Try
            Dim obj As New EscolaridadDA(cadenaConex)
            obj.Eliminar(esc_)
            HayError = obj.HayError
            MensajeError = obj.MensajeError
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
        End Try
    End Sub
    Public Function Obtener(ByVal esc_ As Escolaridad) As Escolaridad
        Dim esc As New Escolaridad()
        Try
            Dim obj As New EscolaridadDA(cadenaConex)
            esc = obj.Obtener(esc_)
            If obj.HayError Then
                esc = Nothing
            End If
            HayError = obj.HayError
            MensajeError = obj.MensajeError
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
            esc = Nothing
        End Try
        Return esc
    End Function
    Public Function ObtenerTodos(ByVal esc_ As Escolaridad) As Escolaridades
        Dim lst As New Escolaridades()
        Try
            Dim obj As New EscolaridadDA(cadenaConex)
            lst = obj.ObtenerTodos(esc_)
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
