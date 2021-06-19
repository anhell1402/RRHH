Imports LaPiedad.RRHH.Clases
Imports Piedad.MasterPS.DataAccess
Public Class PadecimientoDA
    Public Property HayError As Boolean
    Public Property MensajeError As String
    Private cadenaConex As String
    Public Sub New(ByVal cadenaConexion As String)
        cadenaConex = cadenaConexion
    End Sub

    Public Sub Almacenar(ByVal pad_ As Padecimiento)
        Try
            Using objDA As New ConexDB(cadenaConex)
                objDA.CrearComando("rh.sp_padecimiento_Alta")
                objDA.AgregarParametro("@descripcion", pad_.Descripcion)
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
    Public Sub Actualizar(ByVal pad_ As Padecimiento)
        Try
            Using objDA As New ConexDB(cadenaConex)
                objDA.CrearComando("rh.sp_padecimiento_Actualizar")
                objDA.AgregarParametro("@id", pad_.IdPadecimiento)
                objDA.AgregarParametro("@descripcion", pad_.Descripcion)
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
    Public Sub Eliminar(ByVal pad_ As Padecimiento)
        Try
            Using objDA As New ConexDB(cadenaConex)
                objDA.CrearComando("rh.sp_padecimiento_Eliminar")
                objDA.AgregarParametro("@id", pad_.IdPadecimiento)
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
    Public Function Obtener(ByVal pad_ As Padecimiento) As Padecimiento
        Dim pade As Padecimiento = Nothing
        Dim lst As List(Of Padecimiento)
        Try
            Using ObjDA As New ConexDB(cadenaConex)
                ObjDA.CrearComando("rh.sp_padecimiento_Obtener")
                ObjDA.AgregarParametro("@id", pad_.IdPadecimiento)
                ObjDA.EstablecerTipoComando = TipoComando.ProcedimientoAlmacenado
                lst = ObjDA.ObtenerResultados(Of Padecimiento)()
                If Not ObjDA.HayError Then
                    pade = New Padecimiento()
                    pade = lst(0)
                Else
                    pade = Nothing
                    HayError = ObjDA.HayError
                    MensajeError = ObjDA.MensajeError
                End If
                HayError = ObjDA.HayError
            End Using
        Catch ex As Exception
            pade = Nothing
            HayError = True
            MensajeError = ex.Message
        End Try
        Return pade
    End Function
    Public Function ObtenerTodos(ByVal pad_ As Padecimiento) As Padecimientos
        Dim lst As New Padecimientos()
        Try
            Using objDA As New ConexDB(cadenaConex)
                objDA.CrearComando("rh.sp_padecimiento_ObtenerTodos")
                objDA.EstablecerTipoComando = TipoComando.ProcedimientoAlmacenado
                Dim lista As New List(Of Padecimiento)
                lista = objDA.ObtenerResultados(Of Padecimiento)()
                If Not objDA.HayError Then
                    For Each tpo As Padecimiento In lista
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
