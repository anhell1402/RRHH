Imports LaPiedad.RRHH.Clases
Imports LaPiedad.RRHH.Datos
Public Class menuBL
    Public Property MensajeError As String
    Public Property HayError As Boolean

    Private cadenaConex As String
    Public Sub New(ByVal cadena As String)
        cadenaConex = cadena
        HayError = False
        MensajeError = String.Empty
    End Sub
    Public Sub Almacenar(ByVal men_ As menu)
        Try
            Dim obj As New menuDA(cadenaConex)
            obj.Almacenar(men_)
            HayError = obj.HayError
            MensajeError = obj.MensajeError
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
        End Try
    End Sub
    Public Sub Actualizar(ByVal men_ As menu)
        Try
            Dim obj As New menuDA(cadenaConex)
            obj.Actualizar(men_)
            HayError = obj.HayError
            MensajeError = obj.MensajeError
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
        End Try
    End Sub
    Public Sub Eliminar(ByVal men_ As menu)
        Try
            Dim obj As New menuDA(cadenaConex)
            obj.Eliminar(men_)
            HayError = obj.HayError
            MensajeError = obj.MensajeError
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
        End Try
    End Sub
    Public Function Obtener(ByVal men_ As menu) As menu
        Dim menu As New menu()
        Try
            Dim obj As New menuDA(cadenaConex)
            menu = obj.Obtener(men_)
            If obj.HayError Then
                menu = Nothing
            End If
            HayError = obj.HayError
            MensajeError = obj.MensajeError
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
            menu = Nothing
        End Try
        Return menu
    End Function
    Public Function ObtenerTodos() As menus
        Dim lst As New menus()
        Try
            Dim obj As New menuDA(cadenaConex)
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
