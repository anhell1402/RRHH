Imports LaPiedad.RRHH.Clases
Imports Piedad.MasterPS.DataAccess
Public Class SemanaDA
    Public Property HayError As Boolean
    Public Property MensajeError As String
    Private cadenaConex As String
    Public Sub New(ByVal cadenaConexion As String)
        cadenaConex = cadenaConexion
    End Sub

    Public Sub Almacenar(ByVal sem_ As Semana)
        Try
            Using objDA As New ConexDB(cadenaConex)
                objDA.CrearComando("nom.sp_semana_Alta")
                objDA.AgregarParametro("@inicio", sem_.Inicio)
                objDA.AgregarParametro("@fin", sem_.Fin)
                objDA.AgregarParametro("@idEstatusSemana", sem_.IdEstatusSemana)
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
    Public Sub Actualizar(ByVal sem_ As Semana)
        Try
            Using objDA As New ConexDB(cadenaConex)
                objDA.CrearComando("nom.sp_semana_Actualizar")
                objDA.AgregarParametro("@id", sem_.IdSemana)
                objDA.AgregarParametro("@inicio", sem_.Inicio)
                objDA.AgregarParametro("@fin", sem_.Fin)
                objDA.AgregarParametro("@idEstatusSemana", sem_.IdEstatusSemana)
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
    Public Sub Eliminar(ByVal sem_ As Semana)
        Try
            Using objDA As New ConexDB(cadenaConex)
                objDA.CrearComando("nom.sp_semana_Eliminar")
                objDA.AgregarParametro("@id", sem_.IdSemana)
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
    Public Function Obtener(ByVal sem_ As Semana) As Semana
        Dim sema As Semana = Nothing
        Dim lst As List(Of Semana)
        Try
            Using ObjDA As New ConexDB(cadenaConex)
                ObjDA.CrearComando("nom.sp_semana_Obtener")
                ObjDA.AgregarParametro("@id", sem_.IdSemana)
                ObjDA.EstablecerTipoComando = TipoComando.ProcedimientoAlmacenado
                lst = ObjDA.ObtenerResultados(Of Semana)()
                If Not ObjDA.HayError Then
                    sema = New Semana()
                    sema = lst(0)
                Else
                    sema = Nothing
                    HayError = ObjDA.HayError
                    MensajeError = ObjDA.MensajeError
                End If
                HayError = ObjDA.HayError
            End Using
        Catch ex As Exception
            sema = Nothing
            HayError = True
            MensajeError = ex.Message
        End Try
        Return sema
    End Function
    Public Function ObtenerTodos(ByVal sal_ As Semana) As Semanas
        Dim lst As New Semanas()
        Try
            Using objDA As New ConexDB(cadenaConex)
                objDA.CrearComando("nom.sp_semana_ObtenerTodos")
                objDA.EstablecerTipoComando = TipoComando.ProcedimientoAlmacenado
                Dim lista As New List(Of Semana)
                lista = objDA.ObtenerResultados(Of Semana)()
                If Not objDA.HayError Then
                    For Each tpo As Semana In lista
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
