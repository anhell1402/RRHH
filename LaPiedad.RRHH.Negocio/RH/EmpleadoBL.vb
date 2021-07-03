Imports LaPiedad.RRHH.Clases
Imports LaPiedad.RRHH.Datos

Public Class EmpleadoBL
    Public Property HayError As Boolean
    Public Property MensajeError As String
    Private cadenaConex As String
    Public Sub New(ByVal cadenaConexion As String)
        cadenaConex = cadenaConexion
    End Sub
    Public Function Buscar(ByVal criterios As Empleado) As Empleados
        Dim lst As Empleados = Nothing
        Try
            Dim obj As New EmpleadoDA(cadenaConex)
            lst = obj.Buscar(criterios)
            If (obj.HayError) Then
                lst = Nothing
                HayError = True
                MensajeError = obj.MensajeError
            End If
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
            lst = Nothing
        End Try
        Return lst
    End Function
    Public Sub Almacenar(ByVal info As Empleado)
        Try
            Dim obj As New EmpleadoDA(cadenaConex)
            obj.Almacenar(info)
            HayError = obj.HayError
            MensajeError = obj.MensajeError
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
        End Try
    End Sub
End Class
