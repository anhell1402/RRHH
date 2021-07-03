Public Class Direccion
    Public Sub New()
        InfoMunicipio = New Municipio()
    End Sub
    Public Property ID As Integer
    Public Property Calle As String
    Public Property Colonia As String
    Public Property CP As String
    Public Property NumExt As String
    Public Property NumInt As String
    Public Property InfoMunicipio As Municipio
End Class
