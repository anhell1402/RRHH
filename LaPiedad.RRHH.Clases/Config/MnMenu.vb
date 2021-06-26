Public Class MnMenu

    Private idMenu_ As Integer
    Public Property IdMenu As Integer
        Get
            Return idMenu_
        End Get
        Set(ByVal value As Integer)
            idMenu_ = value
        End Set
    End Property
    Private url_ As String
    Public Property Url As String
        Get
            Return url_
        End Get
        Set(ByVal value As String)
            url_ = value
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
    Public Property NomControl As String

End Class
