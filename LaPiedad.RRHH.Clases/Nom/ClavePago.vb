Public Class ClavePago

    Private idClave_ As Integer
    Public Property IdClave As Integer
        Get
            Return idClave_
        End Get
        Set(ByVal value As Integer)
            idClave_ = value
        End Set
    End Property

    Private descripcion_ As String
    Public Property Descripcion As String
        Get
            Return descripcion_
        End Get
        Set(ByVal value As String)
            descripcion_ = value
        End Set
    End Property
End Class
