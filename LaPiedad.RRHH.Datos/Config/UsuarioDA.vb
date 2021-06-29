Imports LaPiedad.RRHH.Clases
Imports Piedad.MasterPS.DataAccess
Public Class UsuarioDA
    Public Property HayError As Boolean
    Public Property MensajeError As String
    Private cadenaConex As String
    Public Sub New(ByVal cadenaConexion As String)
        cadenaConex = cadenaConexion
    End Sub
    Public Sub Almacenar(ByVal usu_ As Usuario)
        Try
            Using objDA As New ConexDB(cadenaConex)
                objDA.CrearComando("conf.sp_usuario_Alta")
                objDA.AgregarParametro("@nombre", usu_.Nombre)
                objDA.AgregarParametro("@paterno", usu_.Paterno)
                objDA.AgregarParametro("@materno", usu_.Materno)
                objDA.AgregarParametro("@userName", usu_.NombreUsuario)
                objDA.AgregarParametro("@pass", usu_.Passwd)
                objDA.AgregarParametro("@idRol", usu_.IdRol.IdRol)
                objDA.EstablecerTipoComando = TipoComando.ProcedimientoAlmacenado
                objDA.EjecutaComando()
                HayError = objDA.HayError
                MensajeError = objDA.MensajeError
            End Using
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
        End Try
    End Sub
    Public Sub Actualizar(ByVal usu_ As Usuario)
        Try
            Using objDA As New ConexDB(cadenaConex)
                objDA.CrearComando("conf.sp_usuario_Actualizar")
                objDA.AgregarParametro("@id", usu_.IdUsuario)
                objDA.AgregarParametro("@nombre", usu_.Nombre)
                objDA.AgregarParametro("@paterno", usu_.Paterno)
                objDA.AgregarParametro("@materno", usu_.Materno)
                objDA.AgregarParametro("@userName", usu_.NombreUsuario)
                objDA.AgregarParametro("@pass", usu_.Passwd)
                objDA.AgregarParametro("@idEstatusUsuario", usu_.IdEstatusUsuario.IdEstatusUsuario)
                objDA.AgregarParametro("@idRol", usu_.IdRol.IdRol)
                objDA.EstablecerTipoComando = TipoComando.ProcedimientoAlmacenado
                objDA.EjecutaComando()
                HayError = objDA.HayError
                MensajeError = objDA.MensajeError
            End Using
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
        End Try
    End Sub
    Public Sub Eliminar(ByVal usu_ As Usuario)
        Try
            Using objDA As New ConexDB(cadenaConex)
                objDA.CrearComando("conf.sp_usuario_Eliminar")
                objDA.AgregarParametro("@id", usu_.IdUsuario)
                objDA.EstablecerTipoComando = TipoComando.ProcedimientoAlmacenado
                objDA.EjecutaComando()
                HayError = objDA.HayError
                MensajeError = objDA.MensajeError
            End Using
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
        End Try
    End Sub
    Public Function Obtener(ByVal usu_ As Usuario) As Usuario
        Dim usua As Usuario = Nothing
        Dim lst As List(Of Usuario)
        Try
            Using ObjDA As New ConexDB(cadenaConex)
                ObjDA.CrearComando("conf.sp_usuario_Obtener")
                ObjDA.AgregarParametro("@id", usu_.IdUsuario)
                ObjDA.EstablecerTipoComando = TipoComando.ProcedimientoAlmacenado
                lst = ObjDA.ObtenerResultados(Of Usuario)()
                If Not ObjDA.HayError Then
                    usua = New Usuario()
                    usua = lst(0)
                Else
                    usua = Nothing
                    HayError = ObjDA.HayError
                    MensajeError = ObjDA.MensajeError
                End If
                HayError = ObjDA.HayError
            End Using
        Catch ex As Exception
            usua = Nothing
            HayError = True
            MensajeError = ex.Message
        End Try
        Return usua
    End Function
    Public Function ObtenerTodos() As Usuarios
        Dim lst As New Usuarios()
        Try
            Using objDA As New ConexDB(cadenaConex)
                objDA.CrearComando("conf.sp_usuario_ObtenerTodos")
                objDA.EstablecerTipoComando = TipoComando.ProcedimientoAlmacenado
                Dim lista As New List(Of Usuario)
                lista = objDA.ObtenerResultados(Of Usuario)()
                If Not objDA.HayError Then
                    For Each usuar As Usuario In lista
                        lst.Add(usuar)
                    Next
                Else
                    lst = Nothing
                    HayError = objDA.HayError
                    MensajeError = objDA.MensajeError
                End If
                HayError = objDA.HayError
            End Using
        Catch ex As Exception
            lst = Nothing
            HayError = True
            MensajeError = ex.Message
        End Try
        Return lst
    End Function
    Public Function Autenticar(ByVal usr As Usuario) As Usuario
        Try
            Using ObjDA As New ConexDB(cadenaConex)
                ObjDA.CrearComando("conf.sp_AutenticaUsuario")
                ObjDA.AgregarParametro("@usrname", usr.NombreUsuario)
                ObjDA.AgregarParametro("@passwd", usr.Passwd)
                ObjDA.EstablecerTipoComando = TipoComando.ProcedimientoAlmacenado
                Dim lst As New List(Of Usuario)
                lst = ObjDA.ObtenerResultados(Of Usuario)()
                If Not ObjDA.HayError Then
                    usr = lst(0)
                Else
                    usr = Nothing
                    HayError = ObjDA.HayError
                    MensajeError = ObjDA.MensajeError
                End If
                HayError = ObjDA.HayError
            End Using
        Catch ex As Exception
            usr = Nothing
            HayError = True
            MensajeError = ex.Message
        End Try
        Return usr
    End Function

    Public Function ObtenerMenu(ByVal usr As Usuario) As MnMenus
        Dim lst As MnMenus = Nothing
        Try
            Using obj As New ConexDB(cadenaConex)
                obj.CrearComando("conf.sp_ObtenerMenuPermisos")
                obj.AgregarParametro("@idUsuario", usr.IdUsuario)
                obj.EstablecerTipoComando = TipoComando.ProcedimientoAlmacenado
                Dim lista As New List(Of MnMenu)
                lista = obj.ObtenerResultados(Of MnMenu)()
                If (Not obj.HayError) Then
                    lst = New MnMenus()
                    For Each mn As MnMenu In lista
                        lst.Add(mn)
                    Next
                Else
                    lst = Nothing
                    HayError = True
                    MensajeError = obj.MensajeError
                End If
            End Using
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
            lst = Nothing
        End Try
        Return lst
    End Function
End Class
