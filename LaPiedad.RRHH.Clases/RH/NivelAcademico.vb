Public Class NivelAcademico

    Private idNivelAcadenmico_ As Integer
    Public Property IdNivelAcademico As Integer
        Get
            Return idNivelAcadenmico_
        End Get
        Set(ByVal value As Integer)
            idNivelAcadenmico_ = value
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
