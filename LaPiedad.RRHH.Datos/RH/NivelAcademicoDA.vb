Imports LaPiedad.RRHH.Clases
Imports Piedad.MasterPS.DataAccess
Public Class NivelAcademicoDA
    Public Property HayError As Boolean
    Public Property MensajeError As String
    Private cadenaConex As String
    Public Sub New(ByVal cadenaConexion As String)
        cadenaConex = cadenaConexion
    End Sub

    Public Sub Almacenar(ByVal nivel_ As NivelAcademico)
        Try
            Using objDA As New ConexDB(cadenaConex)
                objDA.CrearComando("rh.sp_nivelAcademico_Alta")
                objDA.AgregarParametro("@descripcion", nivel_.Descripcion)
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
    Public Sub Actualizar(ByVal nivel_ As NivelAcademico)
        Try
            Using objDA As New ConexDB(cadenaConex)
                objDA.CrearComando("rh.sp_nivelAcademico_Actualizar")
                objDA.AgregarParametro("@id", nivel_.IdNivelAcademico)
                objDA.AgregarParametro("@descripcion", nivel_.Descripcion)
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
    Public Sub Eliminar(ByVal nivel_ As NivelAcademico)
        Try
            Using objDA As New ConexDB(cadenaConex)
                objDA.CrearComando("rh.sp_nivelAcademico_Eliminar")
                objDA.AgregarParametro("@id", nivel_.IdNivelAcademico)
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
    Public Function Obtener(ByVal nivel_ As NivelAcademico) As NivelAcademico
        Dim nv As NivelAcademico = Nothing
        Dim lst As List(Of NivelAcademico)
        Try
            Using ObjDA As New ConexDB(cadenaConex)
                ObjDA.CrearComando("rh.sp_nivelAcademico_Obtener")
                ObjDA.AgregarParametro("@id", nivel_.IdNivelAcademico)
                ObjDA.EstablecerTipoComando = TipoComando.ProcedimientoAlmacenado
                lst = ObjDA.ObtenerResultados(Of NivelAcademico)()
                If Not ObjDA.HayError Then
                    nv = New NivelAcademico()
                    nv = lst(0)
                Else
                    nv = Nothing
                    HayError = ObjDA.HayError
                    MensajeError = ObjDA.MensajeError
                End If
                HayError = ObjDA.HayError
            End Using
        Catch ex As Exception
            nv = Nothing
            HayError = True
            MensajeError = ex.Message
        End Try
        Return nv
    End Function
    Public Function ObtenerTodos() As NivelAcademicos
        Dim lst As New NivelAcademicos()
        Try
            Using objDA As New ConexDB(cadenaConex)
                objDA.CrearComando("rh.sp_nivelAcademico_ObtenerTodos")
                objDA.EstablecerTipoComando = TipoComando.ProcedimientoAlmacenado
                Dim lista As New List(Of NivelAcademico)
                lista = objDA.ObtenerResultados(Of NivelAcademico)()
                If Not objDA.HayError Then
                    For Each tpo As NivelAcademico In lista
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
