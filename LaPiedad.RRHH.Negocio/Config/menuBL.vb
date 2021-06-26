Imports LaPiedad.RRHH.Clases
Imports LaPiedad.RRHH.Datos
Public Class MenuBL
    Public Property MensajeError As String
    Public Property HayError As Boolean

    Private cadenaConex As String
    Public Sub New(ByVal cadena As String)
        cadenaConex = cadena
        HayError = False
        MensajeError = String.Empty
    End Sub
    Public Sub Almacenar(ByVal men_ As MnMenu)
        Try
            Dim obj As New MenuDA(cadenaConex)
            obj.Almacenar(men_)
            HayError = obj.HayError
            MensajeError = obj.MensajeError
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
        End Try
    End Sub
    Public Sub Actualizar(ByVal men_ As MnMenu)
        Try
            Dim obj As New MenuDA(cadenaConex)
            obj.Actualizar(men_)
            HayError = obj.HayError
            MensajeError = obj.MensajeError
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
        End Try
    End Sub
    Public Sub Eliminar(ByVal men_ As MnMenu)
        Try
            Dim obj As New MenuDA(cadenaConex)
            obj.Eliminar(men_)
            HayError = obj.HayError
            MensajeError = obj.MensajeError
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
        End Try
    End Sub
    Public Function Obtener(ByVal men_ As MnMenu) As MnMenu
        Dim menu As New MnMenu()
        Try
            Dim obj As New MenuDA(cadenaConex)
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
    Public Function ObtenerTodos() As MnMenus
        Dim lst As New MnMenus()
        Try
            Dim obj As New MenuDA(cadenaConex)
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
