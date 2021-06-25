Imports LaPiedad.RRHH.Clases
Imports Piedad.MasterPS.DataAccess
Public Class menuDA
    Public Property HayError As Boolean
    Public Property MensajeError As String
    Private cadenaConex As String
    Public Sub New(ByVal cadenaConexion As String)
        cadenaConex = cadenaConexion
    End Sub
    Public Sub Almacenar(ByVal menu_ As menu)
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
    Public Sub Actualizar(ByVal menu_ As menu)
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
    Public Sub Eliminar(ByVal menu_ As menu)
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
    Public Function Obtener(ByVal menu_ As menu) As menu
        Dim men As menu = Nothing
        Dim lst As List(Of menu)
        Try
            Using ObjDA As New ConexDB(cadenaConex)
                ObjDA.CrearComando("conf.sp_menu_Obtener")
                ObjDA.AgregarParametro("@id", menu_.IdMenu)
                ObjDA.EstablecerTipoComando = TipoComando.ProcedimientoAlmacenado
                lst = ObjDA.ObtenerResultados(Of menu)()
                If Not ObjDA.HayError Then
                    men = New menu()
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
    Public Function ObtenerTodos() As menus
        Dim lst As New menus()
        Try
            Using objDA As New ConexDB(cadenaConex)
                objDA.CrearComando("conf.sp_menu_ObtenerTodos")
                objDA.EstablecerTipoComando = TipoComando.ProcedimientoAlmacenado
                Dim lista As New List(Of menu)
                lista = objDA.ObtenerResultados(Of menu)()
                If Not objDA.HayError Then
                    For Each men As menu In lista
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
