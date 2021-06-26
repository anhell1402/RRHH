Imports LaPiedad.RRHH.Clases
Imports Piedad.MasterPS.DataAccess
Public Class MenuDA
    Public Property HayError As Boolean
    Public Property MensajeError As String
    Private cadenaConex As String
    Public Sub New(ByVal cadenaConexion As String)
        cadenaConex = cadenaConexion
    End Sub
    Public Sub Almacenar(ByVal menu_ As MnMenu)
        Try
            Using objDA As New ConexDB(cadenaConex)
                objDA.CrearComando("conf.sp_menu_Alta")
                objDA.AgregarParametro("@url", menu_.Url)
                objDA.AgregarParametro("@descripcion", menu_.Descripcion)
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
    Public Sub Actualizar(ByVal menu_ As MnMenu)
        Try
            Using objDA As New ConexDB(cadenaConex)
                objDA.CrearComando("conf.sp_menu_Actualizar")
                objDA.AgregarParametro("@id", menu_.IdMenu)
                objDA.AgregarParametro("@url", menu_.Url)
                objDA.AgregarParametro("@descripcion", menu_.Descripcion)
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
    Public Sub Eliminar(ByVal menu_ As MnMenu)
        Try
            Using objDA As New ConexDB(cadenaConex)
                objDA.CrearComando("conf.sp_menu_Eliminar")
                objDA.AgregarParametro("@id", menu_.IdMenu)
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
    Public Function Obtener(ByVal menu_ As MnMenu) As MnMenu
        Dim men As MnMenu = Nothing
        Dim lst As List(Of MnMenu)
        Try
            Using ObjDA As New ConexDB(cadenaConex)
                ObjDA.CrearComando("conf.sp_menu_Obtener")
                ObjDA.AgregarParametro("@id", menu_.IdMenu)
                ObjDA.EstablecerTipoComando = TipoComando.ProcedimientoAlmacenado
                lst = ObjDA.ObtenerResultados(Of MnMenu)()
                If Not ObjDA.HayError Then
                    men = New MnMenu()
                    men = lst(0)
                Else
                    men = Nothing
                    HayError = ObjDA.HayError
                    MensajeError = ObjDA.MensajeError
                End If
                HayError = ObjDA.HayError
            End Using
        Catch ex As Exception
            men = Nothing
            HayError = True
            MensajeError = ex.Message
        End Try
        Return men
    End Function
    Public Function ObtenerTodos() As MnMenus
        Dim lst As New MnMenus()
        Try
            Using objDA As New ConexDB(cadenaConex)
                objDA.CrearComando("conf.sp_menu_ObtenerTodos")
                objDA.EstablecerTipoComando = TipoComando.ProcedimientoAlmacenado
                Dim lista As New List(Of MnMenu)
                lista = objDA.ObtenerResultados(Of MnMenu)()
                If Not objDA.HayError Then
                    For Each men As MnMenu In lista
                        lst.Add(men)
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
