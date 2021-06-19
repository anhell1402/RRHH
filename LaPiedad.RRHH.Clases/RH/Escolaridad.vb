Public Class Escolaridad

    'Aqui va el Constructor

    Public Sub New()
        'idEmpleado_ = New Empleado()
        idNivelAcademico_ = New NivelAcademico()
        idEstatusEscolaridad_ = New EstatusEscolaridad()
    End Sub

    Private idEscolaridad_ As Integer
    Public Property IdEscolaridad As Integer
        Get
            Return idEscolaridad_
        End Get
        Set(ByVal value As Integer)
            idEscolaridad_ = value
        End Set
    End Property
    Private idEmpleado_ As Integer
    Public Property IdEmpleado As Integer
        Get
            Return idEmpleado_
        End Get
        Set(ByVal value As Integer)
            idEmpleado_ = value
        End Set
    End Property
    Private idNivelAcademico_ As NivelAcademico
    Public Property IdNivelAcademico As NivelAcademico
        Get
            Return idNivelAcademico_
        End Get
        Set(ByVal value As NivelAcademico)
            idNivelAcademico_ = value
        End Set
    End Property
    Private escuela_ As String
    Public Property NombreEscuela As String
        Get
            Return escuela_
        End Get
        Set(ByVal value As String)
            escuela_ = value
        End Set
    End Property
    Private idEstatusEscolaridad_ As EstatusEscolaridad
    Public Property IdEstatusEscolaridad As EstatusEscolaridad
        Get
            Return idEstatusEscolaridad_
        End Get
        Set(ByVal value As EstatusEscolaridad)
            idEstatusEscolaridad_ = value
        End Set
    End Property
End Class
