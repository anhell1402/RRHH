Public Class estatusUsuario

    Private idEstatusUsuario_ As Integer
    Public Property IdEstatusUsuario As Integer
        Get
            Return idEstatusUsuario_
        End Get
        Set(ByVal value As Integer)
            idEstatusUsuario_ = value
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
