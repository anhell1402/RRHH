Imports LaPiedad.RRHH.Clases
Imports Piedad.MasterPS.DataAccess
Public Class RolDA
    Public Property HayError As Boolean
    Public Property MensajeError As String
    Private cadenaConex As String
    Public Sub New(ByVal cadenaConexion As String)
        cadenaConex = cadenaConexion
    End Sub

    Public Sub Almacenar(ByVal rl_ As Rol)
        Try
            Using objDA As New ConexDB(cadenaConex)
                objDA.CrearComando("conf.sp_rol_Alta")
                objDA.AgregarParametro("@descripcion", rl_.Descripcion)
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
    Public Sub Actualizar(ByVal rl_ As Rol)
        Try
            Using objDA As New ConexDB(cadenaConex)
                objDA.CrearComando("conf.sp_rol_Actualizar")
                objDA.AgregarParametro("@id", rl_.IdRol)
                objDA.AgregarParametro("@descripcion", rl_.Descripcion)
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
    Public Sub Eliminar(ByVal rl_ As Rol)
        Try
            Using objDA As New ConexDB(cadenaConex)
                objDA.CrearComando("conf.sp_rol_Eliminar")
                objDA.AgregarParametro("@id", rl_.IdRol)
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
    Public Function Obtener(ByVal rl_ As Rol) As Rol
        Dim rol As Rol = Nothing
        Dim lst As List(Of Rol)
        Try
            Using ObjDA As New ConexDB(cadenaConex)
                ObjDA.CrearComando("conf.sp_rol_Obtener")
                ObjDA.AgregarParametro("@id", rl_.IdRol)
                ObjDA.EstablecerTipoComando = TipoComando.ProcedimientoAlmacenado
                lst = ObjDA.ObtenerResultados(Of Rol)()
                If Not ObjDA.HayError Then
                    rol = New Rol()
                    rol = lst(0)
                Else
                    rol = Nothing
                    HayError = ObjDA.HayError
                    MensajeError = ObjDA.MensajeError
                End If
                HayError = ObjDA.HayError
            End Using
        Catch ex As Exception
            rol = Nothing
            HayError = True
            MensajeError = ex.Message
        End Try
        Return rol
    End Function
    Public Function ObtenerTodos() As Roles
        Dim lst As New Roles()
        Try
            Using objDA As New ConexDB(cadenaConex)
                objDA.CrearComando("conf.sp_rol_ObtenerTodos")
                objDA.EstablecerTipoComando = TipoComando.ProcedimientoAlmacenado
                Dim lista As New List(Of Rol)
                lista = objDA.ObtenerResultados(Of Rol)()
                If Not objDA.HayError Then
                    For Each rol As Rol In lista
                        lst.Add(rol)
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
    Public Function ObtenerTodosDDL() As Roles
        Dim lst As New Roles()
        Try
            Using objDA As New ConexDB(cadenaConex)
                objDA.CrearComando("conf.sp_rol_ObtenerTodos_DDL")
                objDA.EstablecerTipoComando = TipoComando.ProcedimientoAlmacenado
                Dim lista As New List(Of Rol)
                lista = objDA.ObtenerResultados(Of Rol)()
                If Not objDA.HayError Then
                    For Each rol As Rol In lista
                        lst.Add(rol)
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
End Class
