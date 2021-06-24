Imports LaPiedad.RRHH.Clases
Imports Piedad.MasterPS.DataAccess
Public Class ClavePagoDA
    Public Property HayError As Boolean
    Public Property MensajeError As String
    Private cadenaConex As String
    Public Sub New(ByVal cadenaConexion As String)
        cadenaConex = cadenaConexion
    End Sub
    Public Sub Almacenar(ByVal clave_ As ClavePago)
        Try
            Using ObjDA As New ConexDB(cadenaConex)
                ObjDA.CrearComando("nom.sp_clavePago_Alta")
                ObjDA.AgregarParametro("@descripcion", clave_.Descripcion)
                ObjDA.AgregarParametro("@idTipoPago", clave_.IdTipoPago)
                ObjDA.EstablecerTipoComando = TipoComando.ProcedimientoAlmacenado
                ObjDA.EjecutaComando()
                HayError = ObjDA.HayError
                MensajeError = ObjDA.MensajeError
            End Using
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
        End Try
    End Sub
    Public Sub Actualizar(ByVal clave_ As ClavePago)
        Try
            Using ObjDA As New ConexDB(cadenaConex)
                ObjDA.CrearComando("nom.sp_clavePago_Actualizar")
                ObjDA.AgregarParametro("@id", clave_.IdClave)
                ObjDA.AgregarParametro("@descripcion", clave_.Descripcion)
                ObjDA.AgregarParametro("@idTipoPago", clave_.IdTipoPago)
                ObjDA.EstablecerTipoComando = TipoComando.ProcedimientoAlmacenado
                ObjDA.EjecutaComando()
                HayError = ObjDA.HayError
                MensajeError = ObjDA.MensajeError
            End Using
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
        End Try
    End Sub
    Public Sub Eliminar(ByVal clave_ As ClavePago)
        Try
            Using ObjDA As New ConexDB(cadenaConex)
                ObjDA.CrearComando("nom.sp_clavePago_Eliminar")
                ObjDA.AgregarParametro("@id", clave_.IdClave)
                ObjDA.EstablecerTipoComando = TipoComando.ProcedimientoAlmacenado
                ObjDA.EjecutaComando()
                HayError = ObjDA.HayError
                MensajeError = ObjDA.MensajeError
            End Using
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
        End Try
    End Sub
    Public Function Obtener(ByVal clave_ As ClavePago) As ClavePago
        Dim cl As ClavePago = Nothing
        Dim lst As List(Of ClavePago)
        Try
            Using ObjDA As New ConexDB(cadenaConex)
                ObjDA.CrearComando("nom.sp_clavePago_Obtener")
                ObjDA.AgregarParametro("@id", clave_.IdClave)
                ObjDA.EstablecerTipoComando = TipoComando.ProcedimientoAlmacenado
                lst = ObjDA.ObtenerResultados(Of ClavePago)()
                If Not ObjDA.HayError Then
                    cl = New ClavePago()
                    cl = lst(0)
                Else
                    cl = Nothing
                    HayError = ObjDA.HayError
                    MensajeError = ObjDA.MensajeError
                End If
                HayError = ObjDA.HayError
            End Using
        Catch ex As Exception
            cl = Nothing
            HayError = True
            MensajeError = ex.Message
        End Try
        Return cl
    End Function
    Public Function ObtenerTodos() As ClavePagos
        Dim lst As New ClavePagos()
        Try
            Using objDA As New ConexDB(cadenaConex)
                objDA.CrearComando("nom.sp_clavePago_ObtenerTodos")
                objDA.EstablecerTipoComando = TipoComando.ProcedimientoAlmacenado
                Dim lista As New List(Of ClavePago)
                lista = objDA.ObtenerResultados(Of ClavePago)()
                If Not objDA.HayError Then
                    For Each tpo As ClavePago In lista
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
