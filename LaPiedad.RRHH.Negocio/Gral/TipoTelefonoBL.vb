Imports LaPiedad.RRHH.Clases
Imports LaPiedad.RRHH.Datos
Public Class TipoTelefonoBL
    Public Property MensajeError As String
    Public Property HayError As Boolean

    Private cadenaConex As String
    Public Sub New(ByVal cadena As String)
        cadenaConex = cadena
        HayError = False
        MensajeError = String.Empty
    End Sub
    Public Sub Almacenar(ByVal tipo_ As TipoTelefono)
        Try
            Dim obj As New TipoTelefonoDA(cadenaConex)
            obj.Almacenar(tipo_)
            HayError = obj.HayError
            MensajeError = obj.MensajeError
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
        End Try
    End Sub
    Public Sub Actualizar(ByVal tipo_ As TipoTelefono)
        Try
            Dim obj As New TipoTelefonoDA(cadenaConex)
            obj.Actualizar(tipo_)
            HayError = obj.HayError
            MensajeError = obj.MensajeError
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
        End Try
    End Sub
    Public Sub Eliminar(ByVal tipo_ As TipoTelefono)
        Try
            Dim obj As New TipoTelefonoDA(cadenaConex)
            obj.Eliminar(tipo_)
            HayError = obj.HayError
            MensajeError = obj.MensajeError
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
        End Try
    End Sub
    Public Function Obtener(ByVal tipo_ As TipoTelefono) As TipoTelefono
        Dim tipo As New TipoTelefono()
        Try
            Dim obj As New TipoTelefonoDA(cadenaConex)
            tipo = obj.Obtener(tipo_)
            If obj.HayError Then
                tipo = Nothing
            End If
            HayError = obj.HayError
            MensajeError = obj.MensajeError
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
            tipo = Nothing
        End Try
        Return tipo
    End Function
    Public Function ObtenerTodos() As TipoTelefonos
        Dim lst As New TipoTelefonos()
        Try
            Dim obj As New TipoTelefonoDA(cadenaConex)
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
