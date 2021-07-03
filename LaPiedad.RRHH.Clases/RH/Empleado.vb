Public Class Empleado
    Public Sub New()
        InfoEstatus = New EstatusEmpleado()
        InfoDireccion = New Direccion()
        InfoSexo = New Sexo()
    End Sub
    Public Property IdEmpleado As Integer
    Public Property Nombre As String
    Public Property Paterno As String
    Public Property Materno As String
    Public Property RFC As String
    Public Property CURP As String
    Public Property IMSS As String
    Public Property AltaIMSS As String
    Public Property INE As String
    Public Property FechaNacimiento As String
    Public Property InfoSexo As Sexo
    Public Property Email As String
    Public Property IdSucursal As Integer
    Public Property InfoEstatus As EstatusEmpleado
    Public Property InfoDireccion As Direccion
End Class
