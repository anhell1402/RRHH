Public Class Usuario
    Public Sub New()
        idEstatusUsuario_ = New EstatusUsuario
        idRol_ = New Rol
    End Sub

    Private idUsuario_ As Integer
    Public Property IdUsuario As Integer
        Get
            Return idUsuario_
        End Get
        Set(ByVal value As Integer)
            idUsuario_ = value
        End Set
    End Property
    Private nombre_ As String
    Public Property Nombre As String
        Get
            Return nombre_
        End Get
        Set(ByVal value As String)
            nombre_ = value
        End Set
    End Property
    Private paterno_ As String
    Public Property Paterno As String
        Get
            Return paterno_
        End Get
        Set(ByVal value As String)
            paterno_ = value
        End Set
    End Property
    Private materno_ As String
    Public Property Materno As String
        Get
            Return materno_
        End Get
        Set(ByVal value As String)
            materno_ = value
        End Set
    End Property
    Private nombreUsuario_ As String
    Public Property NombreUsuario As String
        Get
            Return nombreUsuario_
        End Get
        Set(ByVal value As String)
            nombreUsuario_ = value
        End Set
    End Property
    Private passwrd_ As String
    Public Property Passwd As String
        Get
            Return passwrd_
        End Get
        Set(ByVal value As String)
            passwrd_ = value
        End Set
    End Property
    Private idEstatusUsuario_ As EstatusUsuario
    Public Property IdEstatusUsuario As EstatusUsuario
        Get
            Return idEstatusUsuario_
        End Get
        Set(ByVal value As EstatusUsuario)
            idEstatusUsuario_ = value
        End Set
    End Property
    Private idRol_ As Rol
    Public Property IdRol As Rol
        Get
            Return idRol_
        End Get
        Set(ByVal value As Rol)
            idRol_ = value
        End Set
    End Property
    Public WriteOnly Property SetIdRol As Integer
        Set(value As Integer)
            idRol_.IdRol = value
        End Set
    End Property
    Public WriteOnly Property SetIdEstatusUsuario As Integer
        Set(value As Integer)
            idEstatusUsuario_.IdEstatusUsuario = value
        End Set
    End Property
    Public WriteOnly Property DescripcionEstatus As String
        Set(value As String)
            idEstatusUsuario_.Descripcion = value
        End Set
    End Property
    Public WriteOnly Property DescripcionRol As String
        Set(value As String)
            idRol_.Descripcion = value
        End Set
    End Property
    Public ReadOnly Property GetDescripcionEstatus As String
        Get
            Return idEstatusUsuario_.Descripcion
        End Get
    End Property
    Public ReadOnly Property GetDescripcionRol As String
        Get
            Return idRol_.Descripcion
        End Get
    End Property

End Class
