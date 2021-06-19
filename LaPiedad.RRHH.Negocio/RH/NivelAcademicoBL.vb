Imports LaPiedad.RRHH.Clases
Imports LaPiedad.RRHH.Datos
Public Class NivelAcademicoBL
    Public Property MensajeError As String
    Public Property HayError As Boolean

    Private cadenaConex As String
    Public Sub New(ByVal cadena As String)
        cadenaConex = cadena
        HayError = False
        MensajeError = String.Empty
    End Sub
    Public Sub Almacenar(ByVal nv_ As NivelAcademico)
        Try
            Dim obj As New NivelAcademicoDA(cadenaConex)
            obj.Almacenar(nv_)
            HayError = obj.HayError
            MensajeError = obj.MensajeError
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
        End Try
    End Sub
    Public Sub Actualizar(ByVal nv_ As NivelAcademico)
        Try
            Dim obj As New NivelAcademicoDA(cadenaConex)
            obj.Actualizar(nv_)
            HayError = obj.HayError
            MensajeError = obj.MensajeError
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
        End Try
    End Sub
    Public Sub Eliminar(ByVal nv_ As NivelAcademico)
        Try
            Dim obj As New NivelAcademicoDA(cadenaConex)
            obj.Eliminar(nv_)
            HayError = obj.HayError
            MensajeError = obj.MensajeError
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
        End Try
    End Sub
    Public Function Obtener(ByVal nv_ As NivelAcademico) As NivelAcademico
        Dim nivel As New NivelAcademico()
        Try
            Dim obj As New NivelAcademicoDA(cadenaConex)
            nivel = obj.Obtener(nv_)
            If obj.HayError Then
                nivel = Nothing
            End If
            HayError = obj.HayError
            MensajeError = obj.MensajeError
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
            nivel = Nothing
        End Try
        Return nivel
    End Function
    Public Function ObtenerTodos(ByVal nv_ As NivelAcademico) As NivelAcademicos
        Dim lst As New NivelAcademicos()
        Try
            Dim obj As New NivelAcademicoDA(cadenaConex)
            lst = obj.ObtenerTodos(nv_)
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
