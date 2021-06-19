Imports LaPiedad.RRHH.Clases
Imports Piedad.MasterPS.DataAccess
Public Class PasatiempoDA
    Public Property HayError As Boolean
    Public Property MensajeError As String
    Private cadenaConex As String
    Public Sub New(ByVal cadenaConexion As String)
        cadenaConex = cadenaConexion
    End Sub
    Public Sub Almacenar(ByVal pas_ As Pasatiempo)
        Try
            Using objDA As New ConexDB(cadenaConex)
                objDA.CrearComando("rh.sp_pasatiempo_Alta")
                objDA.AgregarParametro("@descripcion", pas_.Descripcion)
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
    Public Sub Actualizar(ByVal pas_ As Pasatiempo)
        Try
            Using objDA As New ConexDB(cadenaConex)
                objDA.CrearComando("rh.sp_pasatiempo_Actualizar")
                objDA.AgregarParametro("@id", pas_.IdPasatiempo)
                objDA.AgregarParametro("@descripcion", pas_.Descripcion)
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
    Public Sub Eliminar(ByVal pas_ As Pasatiempo)
        Try
            Using objDA As New ConexDB(cadenaConex)
                objDA.CrearComando("rh.sp_pasatiempo_Eliminar")
                objDA.AgregarParametro("@id", pas_.IdPasatiempo)
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
    Public Function Obtener(ByVal pas_ As Pasatiempo) As Pasatiempo
        Dim pasa As Pasatiempo = Nothing
        Dim lst As List(Of Pasatiempo)
        Try
            Using ObjDA As New ConexDB(cadenaConex)
                ObjDA.CrearComando("rh.sp_pasatiempo_Obtener")
                ObjDA.AgregarParametro("@id", pas_.IdPasatiempo)
                ObjDA.EstablecerTipoComando = TipoComando.ProcedimientoAlmacenado
                lst = ObjDA.ObtenerResultados(Of Pasatiempo)()
                If Not ObjDA.HayError Then
                    pasa = New Pasatiempo()
                    pasa = lst(0)
                Else
                    pasa = Nothing
                    HayError = ObjDA.HayError
                    MensajeError = ObjDA.MensajeError
                End If
                HayError = ObjDA.HayError
            End Using
        Catch ex As Exception
            pasa = Nothing
            HayError = True
            MensajeError = ex.Message
        End Try
        Return pasa
    End Function
    Public Function ObtenerTodos(ByVal pas_ As Pasatiempo) As Pasatiempos
        Dim lst As New Pasatiempos()
        Try
            Using objDA As New ConexDB(cadenaConex)
                objDA.CrearComando("rh.sp_pasatiempo_ObtenerTodos")
                objDA.EstablecerTipoComando = TipoComando.ProcedimientoAlmacenado
                Dim lista As New List(Of Pasatiempo)
                lista = objDA.ObtenerResultados(Of Pasatiempo)()
                If Not objDA.HayError Then
                    For Each tpo As Pasatiempo In lista
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
