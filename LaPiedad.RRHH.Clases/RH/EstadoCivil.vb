Public Class EstadoCivil
    Private idEstadoCivil_ As Integer
    Public Property IdEstadoCivil As Integer
        Get
            Return idEstadoCivil_
        End Get
        Set(ByVal value As Integer)
            idEstadoCivil_ = value
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
