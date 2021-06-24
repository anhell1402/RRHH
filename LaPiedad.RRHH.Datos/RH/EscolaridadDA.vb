Imports LaPiedad.RRHH.Clases
Imports Piedad.MasterPS.DataAccess
Public Class EscolaridadDA
    Public Property HayError As Boolean
    Public Property MensajeError As String
    Private cadenaConex As String
    Public Sub New(ByVal cadenaConexion As String)
        cadenaConex = cadenaConexion
    End Sub

    Public Sub Almacenar(ByVal esc_ As Escolaridad)
        Try
            Using objDA As New ConexDB(cadenaConex)
                objDA.CrearComando("rh.sp_escolaridad_Alta")
                objDA.AgregarParametro("@idEmpleado", esc_.IdEmpleado)
                objDA.AgregarParametro("@idNivelAcademico", esc_.IdNivelAcademico)
                objDA.AgregarParametro("@escuela", esc_.NombreEscuela)
                objDA.AgregarParametro("@idEstatusEscolaridad", esc_.IdEstatusEscolaridad)
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
    Public Sub Actualizar(ByVal esc_ As Escolaridad)
        Try
            Using objDA As New ConexDB(cadenaConex)
                objDA.CrearComando("rh.sp_escolaridad_Actualizar")
                objDA.AgregarParametro("@id", esc_.IdEscolaridad)
                objDA.AgregarParametro("@idEmpleado", esc_.IdEmpleado)
                objDA.AgregarParametro("@idNivelAcademico", esc_.IdNivelAcademico)
                objDA.AgregarParametro("@escuela", esc_.NombreEscuela)
                objDA.AgregarParametro("@idEstatusEscolaridad", esc_.IdEstatusEscolaridad)
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
    Public Sub Eliminar(ByVal esc_ As Escolaridad)
        Try
            Using objDA As New ConexDB(cadenaConex)
                objDA.CrearComando("rh.sp_escolaridad_Eliminar")
                objDA.AgregarParametro("@id", esc_.IdEscolaridad)
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
    Public Function Obtener(ByVal esc_ As Escolaridad) As Escolaridad
        Dim escu As Escolaridad = Nothing
        Dim lst As List(Of Escolaridad)
        Try
            Using ObjDA As New ConexDB(cadenaConex)
                ObjDA.CrearComando("rh.sp_escolaridad_Obtener")
                ObjDA.AgregarParametro("@id", esc_.IdEscolaridad)
                ObjDA.EstablecerTipoComando = TipoComando.ProcedimientoAlmacenado
                lst = ObjDA.ObtenerResultados(Of Escolaridad)()
                If Not ObjDA.HayError Then
                    escu = New Escolaridad()
                    escu = lst(0)
                Else
                    escu = Nothing
                    HayError = ObjDA.HayError
                    MensajeError = ObjDA.MensajeError
                End If
                HayError = ObjDA.HayError
            End Using
        Catch ex As Exception
            escu = Nothing
            HayError = True
            MensajeError = ex.Message
        End Try
        Return escu
    End Function
    Public Function ObtenerTodos() As Escolaridades
        Dim lst As New Escolaridades()
        Try
            Using objDA As New ConexDB(cadenaConex)
                objDA.CrearComando("rh.sp_escolaridad_ObtenerTodos")
                objDA.EstablecerTipoComando = TipoComando.ProcedimientoAlmacenado
                Dim lista As New List(Of Escolaridad)
                lista = objDA.ObtenerResultados(Of Escolaridad)()
                If Not objDA.HayError Then
                    For Each tpo As Escolaridad In lista
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
