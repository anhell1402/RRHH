Public Class Sexo
    Private idSexo_ As Integer
    Public Property IdSexo As Integer
        Get
            Return idSexo_
        End Get
        Set(ByVal value As Integer)
            idSexo_ = value
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
