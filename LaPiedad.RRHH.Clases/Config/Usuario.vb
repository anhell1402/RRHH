﻿Public Class Usuario
    Public Sub New()
        idEstatusUsuario_ = New estatusUsuario()
        idRol_ = New rol()
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
    Public Property Contra As String
        Get
            Return passwrd_
        End Get
        Set(ByVal value As String)
            passwrd_ = value
        End Set
    End Property
    Private idEstatusUsuario_ As estatusUsuario
    Public Property IdEstatusUsuario As estatusUsuario
        Get
            Return idEstatusUsuario_
        End Get
        Set(ByVal value As estatusUsuario)
            idEstatusUsuario_ = value
        End Set
    End Property
    Private idRol_ As rol
    Public Property IdRol As rol
        Get
            Return idRol_
        End Get
        Set(ByVal value As rol)
            idRol_ = value
        End Set
    End Property

End Class
