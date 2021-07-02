Imports LaPiedad.RRHH.Clases
Imports Piedad.MasterPS.DataAccess
Public Class EstatusUsuarioDA
    Public Property HayError As Boolean
    Public Property MensajeError As String
    Private cadenaConex As String
    Public Sub New(ByVal cadenaConexion As String)
        cadenaConex = cadenaConexion
    End Sub

    Public Sub Almacenar(ByVal edo_ As EstatusUsuario)
        Try
            Using objDA As New ConexDB(cadenaConex)
                objDA.CrearComando("conf.sp_estatusUsuario_Alta")
                objDA.AgregarParametro("@descripcion", edo_.Descripcion)
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
    Public Sub Actualizar(ByVal edo_ As EstatusUsuario)
        Try
            Using objDA As New ConexDB(cadenaConex)
                objDA.CrearComando("conf.sp_estatusUsuario_Actualizar")
                objDA.AgregarParametro("@id", edo_.IdEstatusUsuario)
                objDA.AgregarParametro("@descripcion", edo_.Descripcion)
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
    Public Sub Eliminar(ByVal edo_ As EstatusUsuario)
        Try
            Using objDA As New ConexDB(cadenaConex)
                objDA.CrearComando("conf.sp_estatusUsuario_Eliminar")
                objDA.AgregarParametro("@id", edo_.IdEstatusUsuario)
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
    Public Function Obtener(ByVal edo_ As EstatusUsuario) As EstatusUsuario
        Dim edoU As EstatusUsuario = Nothing
        Dim lst As List(Of EstatusUsuario)
        Try
            Using ObjDA As New ConexDB(cadenaConex)
                ObjDA.CrearComando("conf.sp_estatusUsuario_Obtener")
                ObjDA.AgregarParametro("@id", edo_.IdEstatusUsuario)
                ObjDA.EstablecerTipoComando = TipoComando.ProcedimientoAlmacenado
                lst = ObjDA.ObtenerResultados(Of EstatusUsuario)()
                If Not ObjDA.HayError Then
                    edoU = New EstatusUsuario()
                    edoU = lst(0)
                Else
                    edoU = Nothing
                    HayError = ObjDA.HayError
                    MensajeError = ObjDA.MensajeError
                End If
                HayError = ObjDA.HayError
            End Using
        Catch ex As Exception
            edoU = Nothing
            HayError = True
            MensajeError = ex.Message
        End Try
        Return edoU
    End Function
    Public Function ObtenerTodos() As EstatusUsuarios
        Dim lst As New EstatusUsuarios()
        Try
            Using objDA As New ConexDB(cadenaConex)
                objDA.CrearComando("conf.sp_estatusUsuario_ObtenerTodos")
                objDA.EstablecerTipoComando = TipoComando.ProcedimientoAlmacenado
                Dim lista As New List(Of EstatusUsuario)
                lista = objDA.ObtenerResultados(Of EstatusUsuario)()
                If Not objDA.HayError Then
                    For Each edo As EstatusUsuario In lista
                        lst.Add(edo)
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
    Public Function ObtenerTodosDDL() As EstatusUsuarios
        Dim lst As New EstatusUsuarios()
        Try
            Using objDA As New ConexDB(cadenaConex)
                objDA.CrearComando("conf.sp_estatusUsuario_ObtenerTodos_DDL")
                objDA.EstablecerTipoComando = TipoComando.ProcedimientoAlmacenado
                Dim lista As New List(Of EstatusUsuario)
                lista = objDA.ObtenerResultados(Of EstatusUsuario)()
                If Not objDA.HayError Then
                    For Each edo As EstatusUsuario In lista
                        lst.Add(edo)
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
