Public Class Semana

    Private idSemana_ As Integer
    Public Property IdSemana As Integer
        Get
            Return idSemana_
        End Get
        Set(ByVal value As Integer)
            idSemana_ = value
        End Set
    End Property

    Private inicio_ As String
    Public Property Inicio As String
        Get
            Return inicio_
        End Get
        Set(ByVal value As String)
            inicio_ = value
        End Set
    End Property

    Private fin_ As String
    Public Property Fin As String
        Get
            Return inicio_
        End Get
        Set(ByVal value As String)
            inicio_ = value
        End Set
    End Property

    Private idEstatusSemana_ As EstatusSemana
    Public Property IdEstatusSemana As EstatusSemana
        Get
            Return idEstatusSemana_
        End Get
        Set(ByVal value As EstatusSemana)
            idEstatusSemana_ = value
        End Set
    End Property

End Class
