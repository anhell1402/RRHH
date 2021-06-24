Imports LaPiedad.RRHH.Clases
Imports LaPiedad.RRHH.Datos
Public Class EstadoCivilBL
    Public Property MensajeError As String
    Public Property HayError As Boolean

    Private cadenaConex As String
    Public Sub New(ByVal cadena As String)
        cadenaConex = cadena
        HayError = False
        MensajeError = String.Empty
    End Sub
    Public Sub Almacenar(ByVal edo_ As EstadoCivil)
        Try
            Dim obj As New EstadoCivilDA(cadenaConex)
            obj.Almacenar(edo_)
            HayError = obj.HayError
            MensajeError = obj.MensajeError
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
        End Try
    End Sub
    Public Sub Actualizar(ByVal edo_ As EstadoCivil)
        Try
            Dim obj As New EstadoCivilDA(cadenaConex)
            obj.Actualizar(edo_)
            HayError = obj.HayError
            MensajeError = obj.MensajeError
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
        End Try
    End Sub
    Public Sub Eliminar(ByVal edo_ As EstadoCivil)
        Try
            Dim obj As New EstadoCivilDA(cadenaConex)
            obj.Eliminar(edo_)
            HayError = obj.HayError
            MensajeError = obj.MensajeError
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
        End Try
    End Sub
    Public Function Obtener(ByVal edo_ As EstadoCivil) As EstadoCivil
        Dim edoC As New EstadoCivil()
        Try
            Dim obj As New EstadoCivilDA(cadenaConex)
            edoC = obj.Obtener(edo_)
            If obj.HayError Then
                edoC = Nothing
            End If
            HayError = obj.HayError
            MensajeError = obj.MensajeError
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
            edoC = Nothing
        End Try
        Return edoC
    End Function
    Public Function ObtenerTodos() As EstadoCiviles
        Dim lst As New EstadoCiviles()
        Try
            Dim obj As New EstadoCivilDA(cadenaConex)
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
