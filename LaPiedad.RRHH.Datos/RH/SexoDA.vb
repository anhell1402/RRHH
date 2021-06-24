Imports LaPiedad.RRHH.Clases
Imports Piedad.MasterPS.DataAccess
Public Class SexoDA
    Public Property HayError As Boolean
    Public Property MensajeError As String
    Private cadenaConex As String
    Public Sub New(ByVal cadenaConexion As String)
        cadenaConex = cadenaConexion
    End Sub
    Public Sub Almacenar(ByVal sex_ As Sexo)
        Try
            Using objDA As New ConexDB(cadenaConex)
                objDA.CrearComando("rh.sp_sexo_Alta")
                objDA.AgregarParametro("@descripcion", sex_.Descripcion)
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
    Public Sub Actualizar(ByVal sex_ As Sexo)
        Try
            Using objDA As New ConexDB(cadenaConex)
                objDA.CrearComando("rh.sp_sexo_Actualizar")
                objDA.AgregarParametro("@id", sex_.IdSexo)
                objDA.AgregarParametro("@descripcion", sex_.Descripcion)
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
    Public Sub Eliminar(ByVal sex_ As Sexo)
        Try
            Using objDA As New ConexDB(cadenaConex)
                objDA.CrearComando("rh.sp_sexo_Eliminar")
                objDA.AgregarParametro("@id", sex_.IdSexo)
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
    Public Function Obtener(ByVal sex_ As Sexo) As Sexo
        Dim sexo_ As Sexo = Nothing
        Dim lst As List(Of Sexo)
        Try
            Using ObjDA As New ConexDB(cadenaConex)
                ObjDA.CrearComando("rh.sp_sexo_Obtener")
                ObjDA.AgregarParametro("@id", sex_.IdSexo)
                ObjDA.EstablecerTipoComando = TipoComando.ProcedimientoAlmacenado
                lst = ObjDA.ObtenerResultados(Of Sexo)()
                If Not ObjDA.HayError Then
                    sexo_ = New Sexo()
                    sexo_ = lst(0)
                Else
                    sexo_ = Nothing
                    HayError = ObjDA.HayError
                    MensajeError = ObjDA.MensajeError
                End If
                HayError = ObjDA.HayError
            End Using
        Catch ex As Exception
            sexo_ = Nothing
            HayError = True
            MensajeError = ex.Message
        End Try
        Return sexo_
    End Function
    Public Function ObtenerTodos() As Sexos
        Dim lst As New Sexos()
        Try
            Using objDA As New ConexDB(cadenaConex)
                objDA.CrearComando("rh.sp_sexo_ObtenerTodos")
                objDA.EstablecerTipoComando = TipoComando.ProcedimientoAlmacenado
                Dim lista As New List(Of Sexo)
                lista = objDA.ObtenerResultados(Of Sexo)()
                If Not objDA.HayError Then
                    For Each tpo As Sexo In lista
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
