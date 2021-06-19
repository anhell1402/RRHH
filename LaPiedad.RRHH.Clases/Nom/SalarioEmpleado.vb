Public Class SalarioEmpleado
    'Aqui va el Constructor

    Public Sub New()
        'idEmpleado_ = New Empleado()
    End Sub
    Private idSalarioSemana_ As Integer
    Public Property IdSalarioSemana As Integer
        Get
            Return idSalarioSemana_
        End Get
        Set(ByVal value As Integer)
            idSalarioSemana_ = value
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
    Private salario_ As Decimal
    Public Property Salario As Decimal
        Get
            Return salario_
        End Get
        Set(ByVal value As Decimal)
            salario_ = value
        End Set
    End Property
    Private idEstatusSalarioEmp_ As EstatusSalarioEmpleado
    Public Property IdEstatusSalarioEmpleado As EstatusSalarioEmpleado
        Get
            Return idEstatusSalarioEmp_
        End Get
        Set(ByVal value As EstatusSalarioEmpleado)
            idEstatusSalarioEmp_ = value
        End Set
    End Property
    Private anio_ As Integer
    Public Property Anio As Integer
        Get
            Return anio_
        End Get
        Set(ByVal value As Integer)
            anio_ = value
        End Set
    End Property
    Private fechaCreacion_ As String
    Public Property FechaCreacion As String
        Get
            Return fechaCreacion_
        End Get
        Set(ByVal value As String)
            fechaCreacion_ = value
        End Set
    End Property
End Class
