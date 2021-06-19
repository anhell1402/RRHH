Imports LaPiedad.RRHH.Clases
Imports Piedad.MasterPS.DataAccess
Public Class EstadoCivilDA
    Public Property HayError As Boolean
    Public Property MensajeError As String
    Private cadenaConex As String
    Public Sub New(ByVal cadenaConexion As String)
        cadenaConex = cadenaConexion
    End Sub

    Public Sub Almacenar(ByVal edo_ As EstadoCivil)
        Try
            Using ObjDA As New ConexDB(cadenaConex)
                ObjDA.CrearComando("rh.sp_estadoCivil_Alta")
                ObjDA.AgregarParametro("@descripcion", edo_.Descripcion)
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
    Public Sub Actualizar(ByVal edo_ As EstadoCivil)
        Try
            Using ObjDA As New ConexDB(cadenaConex)
                ObjDA.CrearComando("rh.sp_estadoCivil_Actualizar")
                ObjDA.AgregarParametro("@id", edo_.IdEstadoCivil)
                ObjDA.AgregarParametro("@descripcion", edo_.Descripcion)
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
    Public Sub Eliminar(ByVal edo_ As EstadoCivil)
        Try
            Using ObjDA As New ConexDB(cadenaConex)
                ObjDA.CrearComando("rh.sp_estadoCivil_Eliminar")
                ObjDA.AgregarParametro("@id", edo_.IdEstadoCivil)
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
    Public Function Obtener(ByVal edo_ As EstadoCivil) As EstadoCivil
        Dim edoC As EstadoCivil = Nothing
        Dim lst As List(Of EstadoCivil)
        Try
            Using ObjDA As New ConexDB(cadenaConex)
                ObjDA.CrearComando("rh.sp_estadoCivil_Obtener")
                ObjDA.AgregarParametro("@id", edo_.IdEstadoCivil)
                ObjDA.EstablecerTipoComando = TipoComando.ProcedimientoAlmacenado
                lst = ObjDA.ObtenerResultados(Of EstadoCivil)()
                If Not ObjDA.HayError Then
                    edoC = New EstadoCivil()
                    edoC = lst(0)
                Else
                    edoC = Nothing
                    HayError = ObjDA.HayError
                    MensajeError = ObjDA.MensajeError
                End If
                HayError = ObjDA.HayError
            End Using
        Catch ex As Exception
            edoC = Nothing
            HayError = True
            MensajeError = ex.Message
        End Try
        Return edoC
    End Function
    Public Function ObtenerTodos(ByVal edo_ As EstadoCivil) As EstadoCiviles
        Dim lst As New EstadoCiviles()
        Try
            Using objDA As New ConexDB(cadenaConex)
                objDA.CrearComando("rh.sp_estadoCivil_ObtenerTodos")
                objDA.EstablecerTipoComando = TipoComando.ProcedimientoAlmacenado
                Dim lista As New List(Of EstadoCivil)
                lista = objDA.ObtenerResultados(Of EstadoCivil)()
                If Not objDA.HayError Then
                    For Each edoC As EstadoCivil In lista
                        lst.Add(edoC)
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
