Imports LaPiedad.RRHH.Clases
Imports LaPiedad.RRHH.Datos
Public Class SemanaBL
    Public Property MensajeError As String
    Public Property HayError As Boolean

    Private cadenaConex As String
    Public Sub New(ByVal cadena As String)
        cadenaConex = cadena
        HayError = False
        MensajeError = String.Empty
    End Sub
    Public Sub Almacenar(ByVal sem_ As Semana)
        Try
            Dim obj As New SemanaDA(cadenaConex)
            obj.Almacenar(sem_)
            HayError = obj.HayError
            MensajeError = obj.MensajeError
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
        End Try
    End Sub
    Public Sub Actualizar(ByVal sem_ As Semana)
        Try
            Dim obj As New SemanaDA(cadenaConex)
            obj.Actualizar(sem_)
            HayError = obj.HayError
            MensajeError = obj.MensajeError
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
        End Try
    End Sub
    Public Sub Eliminar(ByVal sem_ As Semana)
        Try
            Dim obj As New SemanaDA(cadenaConex)
            obj.Eliminar(sem_)
            HayError = obj.HayError
            MensajeError = obj.MensajeError
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
        End Try
    End Sub
    Public Function Obtener(ByVal sem_ As Semana) As Semana
        Dim sema_ As New Semana()
        Try
            Dim obj As New SemanaDA(cadenaConex)
            sema_ = obj.Obtener(sem_)
            If obj.HayError Then
                sema_ = Nothing
            End If
            HayError = obj.HayError
            MensajeError = obj.MensajeError
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
            sema_ = Nothing
        End Try
        Return sema_
    End Function
    Public Function ObtenerTodos() As Semanas
        Dim lst As New Semanas()
        Try
            Dim obj As New SemanaDA(cadenaConex)
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
