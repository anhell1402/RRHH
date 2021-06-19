Public Class Hijo

    'Aqui va el Constructor

    Public Sub New()
        'idEmpleado_ = New Empleado()
    End Sub

    Private idHijo_ As Integer
    Public Property IdHijo As Integer
        Get
            Return idHijo_
        End Get
        Set(ByVal value As Integer)
            idHijo_ = value
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
    Private nombreHijo_ As String
    Public Property NombreHijo As String
        Get
            Return nombreHijo_
        End Get
        Set(ByVal value As String)
            nombreHijo_ = value
        End Set
    End Property
    Private fechaNac_ As String
    Public Property FechaNacimiento As String
        Get
            Return fechaNac_
        End Get
        Set(ByVal value As String)
            fechaNac_ = value
        End Set
    End Property
    Private observaciones_ As String
    Public Property Observaciones As String
        Get
            Return observaciones_
        End Get
        Set(ByVal value As String)
            observaciones_ = value
        End Set
    End Property
End Class
