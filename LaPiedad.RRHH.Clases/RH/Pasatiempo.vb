Public Class Pasatiempo
    Private idPasatiempo_ As Integer
    Public Property IdPasatiempo As Integer
        Get
            Return idPasatiempo_
        End Get
        Set(ByVal value As Integer)
            idPasatiempo_ = value
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
