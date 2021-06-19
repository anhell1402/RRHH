Public Class EstatusEscolaridad
    Private idEstatusEscolaridad_ As Integer
    Public Property IdEstatusEscolaridad As Integer
        Get
            Return idEstatusEscolaridad_
        End Get
        Set(ByVal value As Integer)
            idEstatusEscolaridad_ = value
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
