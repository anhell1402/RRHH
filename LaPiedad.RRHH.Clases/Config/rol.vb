Public Class rol
    Private idRol_ As Integer
    Public Property IdRol As Integer
        Get
            Return idRol_
        End Get
        Set(ByVal value As Integer)
            idRol_ = value
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
