Public Class Padecimiento
    Private idPadecimiento_ As Integer
    Public Property IdPadecimiento As Integer
        Get
            Return idPadecimiento_
        End Get
        Set(ByVal value As Integer)
            idPadecimiento_ = value
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
