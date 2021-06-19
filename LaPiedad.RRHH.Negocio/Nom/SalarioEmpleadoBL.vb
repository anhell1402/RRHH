Imports LaPiedad.RRHH.Clases
Imports LaPiedad.RRHH.Datos
Public Class SalarioEmpleadoBL
    Public Property MensajeError As String
    Public Property HayError As Boolean

    Private cadenaConex As String
    Public Sub New(ByVal cadena As String)
        cadenaConex = cadena
        HayError = False
        MensajeError = String.Empty
    End Sub

    Public Sub Almacenar(ByVal sal_ As SalarioEmpleado)
        Try
            Dim obj As New SalarioEmpleadoDA(cadenaConex)
            obj.Almacenar(sal_)
            HayError = obj.HayError
            MensajeError = obj.MensajeError
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
        End Try
    End Sub
    Public Sub Actualizar(ByVal sal_ As SalarioEmpleado)
        Try
            Dim obj As New SalarioEmpleadoDA(cadenaConex)
            obj.Actualizar(sal_)
            HayError = obj.HayError
            MensajeError = obj.MensajeError
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
        End Try
    End Sub
    Public Sub Eliminar(ByVal sal_ As SalarioEmpleado)
        Try
            Dim obj As New SalarioEmpleadoDA(cadenaConex)
            obj.Eliminar(sal_)
            HayError = obj.HayError
            MensajeError = obj.MensajeError
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
        End Try
    End Sub
    Public Function Obtener(ByVal sal_ As SalarioEmpleado) As SalarioEmpleado
        Dim tipo As New SalarioEmpleado()
        Try
            Dim obj As New SalarioEmpleadoDA(cadenaConex)
            tipo = obj.Obtener(sal_)
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
    Public Function ObtenerTodos(ByVal sal_ As SalarioEmpleado) As SalarioEmpleados
        Dim lst As New SalarioEmpleados()
        Try
            Dim obj As New SalarioEmpleadoDA(cadenaConex)
            lst = obj.ObtenerTodos(sal_)
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
