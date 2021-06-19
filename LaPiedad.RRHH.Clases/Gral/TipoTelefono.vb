Public Class TipoTelefono

    Private idTipoTelefono_ As Integer
    Public Property IdTipoTelefono As Integer
        Get
            Return idTipoTelefono_
        End Get
        Set(ByVal value As Integer)
            idTipoTelefono_ = value
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
