Imports LaPiedad.RRHH.Clases
Imports Piedad.MasterPS.DataAccess
Public Class HijoDA
    Public Property HayError As Boolean
    Public Property MensajeError As String
    Private cadenaConex As String
    Public Sub New(ByVal cadenaConexion As String)
        cadenaConex = cadenaConexion
    End Sub
    Public Sub Almacenar(ByVal hijo_ As Hijo)
        Try
            Using objDA As New ConexDB(cadenaConex)
                objDA.CrearComando("rh.sp_hijo_Alta")
                objDA.AgregarParametro("@idEmpleado", hijo_.IdEmpleado)
                objDA.AgregarParametro("@nombreHijo", hijo_.NombreHijo)
                objDA.AgregarParametro("@fechaNacimiento", hijo_.FechaNacimiento)
                objDA.AgregarParametro("@observaciones", hijo_.Observaciones)
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
    Public Sub Actualizar(ByVal hijo_ As Hijo)
        Try
            Using objDA As New ConexDB(cadenaConex)
                objDA.CrearComando("rh.sp_hijo_Actualizar")
                objDA.AgregarParametro("@id", hijo_.IdHijo)
                objDA.AgregarParametro("@idEmpleado", hijo_.IdEmpleado)
                objDA.AgregarParametro("@nombreHijo", hijo_.NombreHijo)
                objDA.AgregarParametro("@fechaNacimiento", hijo_.FechaNacimiento)
                objDA.AgregarParametro("@observaciones", hijo_.Observaciones)
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
    Public Sub Eliminar(ByVal hijo_ As Hijo)
        Try
            Using objDA As New ConexDB(cadenaConex)
                objDA.CrearComando("rh.sp_hijo_Eliminar")
                objDA.AgregarParametro("@id", hijo_.IdHijo)
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
    Public Function Obtener(ByVal hi_ As Hijo) As Hijo
        Dim hij As Hijo = Nothing
        Dim lst As List(Of Hijo)
        Try
            Using ObjDA As New ConexDB(cadenaConex)
                ObjDA.CrearComando("rh.sp_hijo_Obtener")
                ObjDA.AgregarParametro("@id", hi_.IdHijo)
                ObjDA.EstablecerTipoComando = TipoComando.ProcedimientoAlmacenado
                lst = ObjDA.ObtenerResultados(Of Hijo)()
                If Not ObjDA.HayError Then
                    hij = New Hijo()
                    hij = lst(0)
                Else
                    hij = Nothing
                    HayError = ObjDA.HayError
                    MensajeError = ObjDA.MensajeError
                End If
                HayError = ObjDA.HayError
            End Using
        Catch ex As Exception
            hij = Nothing
            HayError = True
            MensajeError = ex.Message
        End Try
        Return hij
    End Function
    Public Function ObtenerTodos(ByVal hi_ As Hijo) As Hijos
        Dim lst As New Hijos()
        Try
            Using objDA As New ConexDB(cadenaConex)
                objDA.CrearComando("rh.sp_hijo_ObtenerTodos")
                objDA.EstablecerTipoComando = TipoComando.ProcedimientoAlmacenado
                Dim lista As New List(Of Hijo)
                lista = objDA.ObtenerResultados(Of Hijo)()
                If Not objDA.HayError Then
                    For Each tpo As Hijo In lista
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
