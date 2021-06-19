Imports LaPiedad.RRHH.Clases
Imports Piedad.MasterPS.DataAccess
Public Class EstatusEscolaridadDA
    Public Property HayError As Boolean
    Public Property MensajeError As String
    Private cadenaConex As String
    Public Sub New(ByVal cadenaConexion As String)
        cadenaConex = cadenaConexion
    End Sub

    Public Sub Almacenar(ByVal edo_ As EstatusEscolaridad)
        Try
            Using objDA As New ConexDB(cadenaConex)
                objDA.CrearComando("rh.sp_estatusEscolaridad_Alta")
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
    Public Sub Actualizar(ByVal edo_ As EstatusEscolaridad)
        Try
            Using objDA As New ConexDB(cadenaConex)
                objDA.CrearComando("rh.sp_estatusEscolaridad_Actualizar")
                objDA.AgregarParametro("@id", edo_.IdEstatusEscolaridad)
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
    Public Sub Eliminar(ByVal edo_ As EstatusEscolaridad)
        Try
            Using objDA As New ConexDB(cadenaConex)
                objDA.CrearComando("rh.sp_estatusEscolaridad_Eliminar")
                objDA.AgregarParametro("@id", edo_.IdEstatusEscolaridad)
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
    Public Function Obtener(ByVal edo_ As EstatusEscolaridad) As EstatusEscolaridad
        Dim edoE As EstatusEscolaridad = Nothing
        Dim lst As List(Of EstatusEscolaridad)
        Try
            Using ObjDA As New ConexDB(cadenaConex)
                ObjDA.CrearComando("rh.sp_estatusEscolaridad_Obtener")
                ObjDA.AgregarParametro("@id", edo_.IdEstatusEscolaridad)
                ObjDA.EstablecerTipoComando = TipoComando.ProcedimientoAlmacenado
                lst = ObjDA.ObtenerResultados(Of EstatusEscolaridad)()
                If Not ObjDA.HayError Then
                    edoE = New EstatusEscolaridad()
                    edoE = lst(0)
                Else
                    edoE = Nothing
                    HayError = ObjDA.HayError
                    MensajeError = ObjDA.MensajeError
                End If
                HayError = ObjDA.HayError
            End Using
        Catch ex As Exception
            edoE = Nothing
            HayError = True
            MensajeError = ex.Message
        End Try
        Return edoE
    End Function
    Public Function ObtenerTodos(ByVal edo_ As EstatusEscolaridad) As EstatusEscolaridades
        Dim lst As New EstatusEscolaridades()
        Try
            Using objDA As New ConexDB(cadenaConex)
                objDA.CrearComando("rh.sp_estatusEscolaridad_ObtenerTodos")
                objDA.EstablecerTipoComando = TipoComando.ProcedimientoAlmacenado
                Dim lista As New List(Of EstatusEscolaridad)
                lista = objDA.ObtenerResultados(Of EstatusEscolaridad)()
                If Not objDA.HayError Then
                    For Each tpo As EstatusEscolaridad In lista
                        lst.Add(tpo)
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
