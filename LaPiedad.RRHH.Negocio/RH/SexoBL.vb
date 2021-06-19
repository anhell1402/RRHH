Imports LaPiedad.RRHH.Clases
Imports LaPiedad.RRHH.Datos
Public Class SexoBL
    Public Property MensajeError As String
    Public Property HayError As Boolean

    Private cadenaConex As String
    Public Sub New(ByVal cadena As String)
        cadenaConex = cadena
        HayError = False
        MensajeError = String.Empty
    End Sub

    Public Sub Almacenar(ByVal sex_ As Sexo)
        Try
            Dim obj As New SexoDA(cadenaConex)
            obj.Almacenar(sex_)
            HayError = obj.HayError
            MensajeError = obj.MensajeError
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
        End Try
    End Sub
    Public Sub Actualizar(ByVal sex_ As Sexo)
        Try
            Dim obj As New SexoDA(cadenaConex)
            obj.Actualizar(sex_)
            HayError = obj.HayError
            MensajeError = obj.MensajeError
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
        End Try
    End Sub
    Public Sub Eliminar(ByVal sex_ As Sexo)
        Try
            Dim obj As New SexoDA(cadenaConex)
            obj.Eliminar(sex_)
            HayError = obj.HayError
            MensajeError = obj.MensajeError
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
        End Try
    End Sub
    Public Function Obtener(ByVal sex_ As Sexo) As Sexo
        Dim sex As New Sexo()
        Try
            Dim obj As New SexoDA(cadenaConex)
            sex = obj.Obtener(sex_)
            If obj.HayError Then
                sex = Nothing
            End If
            HayError = obj.HayError
            MensajeError = obj.MensajeError
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
            sex = Nothing
        End Try
        Return sex
    End Function
    Public Function ObtenerTodos(ByVal sex_ As Sexo) As Sexos
        Dim lst As New Sexos()
        Try
            Dim obj As New SexoDA(cadenaConex)
            lst = obj.ObtenerTodos(sex_)
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
