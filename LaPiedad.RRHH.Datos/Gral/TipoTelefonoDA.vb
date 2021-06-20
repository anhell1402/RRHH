Imports LaPiedad.RRHH.Clases
Imports Piedad.MasterPS.DataAccess
Public Class TipoTelefonoDA
    Public Property HayError As Boolean
    Public Property MensajeError As String
    Private cadenaConex As String
    Public Sub New(ByVal cadenaConexion As String)
        cadenaConex = cadenaConexion
    End Sub

    Public Sub Almacenar(ByVal tipo_ As TipoTelefono)
        Try
            Using objDA As New ConexDB(cadenaConex)
                objDA.CrearComando("dbo.sp_tipoTelefono_Alta")
                objDA.AgregarParametro("@tipo", tipo_.Descripcion)
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
    Public Sub Actualizar(ByVal tipo_ As TipoTelefono)
        Try
            Using objDA As New ConexDB(cadenaConex)
                objDA.CrearComando("dbo.sp_tipoTelefono_Actualizar")
                objDA.AgregarParametro("@id", tipo_.IdTipoTelefono)
                objDA.AgregarParametro("@tipo", tipo_.Descripcion)
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
    Public Sub Eliminar(ByVal tipo_ As TipoTelefono)
        Try
            Using objDA As New ConexDB(cadenaConex)
                objDA.CrearComando("dbo.sp_tipoTelefono_Eliminar")
                objDA.AgregarParametro("@id", tipo_.IdTipoTelefono)
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
    Public Function Obtener(ByVal tipo_ As TipoTelefono) As TipoTelefono
        Dim tipoTel As TipoTelefono = Nothing
        Dim lst As List(Of TipoTelefono)
        Try
            Using ObjDA As New ConexDB(cadenaConex)
                ObjDA.CrearComando("dbo.sp_tipoTelefono_Obtener")
                ObjDA.AgregarParametro("@id", tipo_.IdTipoTelefono)
                ObjDA.EstablecerTipoComando = TipoComando.ProcedimientoAlmacenado
                lst = ObjDA.ObtenerResultados(Of TipoTelefono)()
                If Not ObjDA.HayError Then
                    tipoTel = New TipoTelefono()
                    tipoTel = lst(0)
                Else
                    tipoTel = Nothing
                    HayError = ObjDA.HayError
                    MensajeError = ObjDA.MensajeError
                End If
                HayError = ObjDA.HayError
            End Using
        Catch ex As Exception
            tipoTel = Nothing
            HayError = True
            MensajeError = ex.Message
        End Try
        Return tipoTel
    End Function
    Public Function ObtenerTodos() As TipoTelefonos
        Dim lst As New TipoTelefonos()
        Try
            Using objDA As New ConexDB(cadenaConex)
                objDA.CrearComando("dbo.sp_tipoTelefono_ObtenerTodos")
                objDA.EstablecerTipoComando = TipoComando.ProcedimientoAlmacenado
                Dim lista As New List(Of TipoTelefono)
                lista = objDA.ObtenerResultados(Of TipoTelefono)()
                If Not objDA.HayError Then
                    For Each tpo As TipoTelefono In lista
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
