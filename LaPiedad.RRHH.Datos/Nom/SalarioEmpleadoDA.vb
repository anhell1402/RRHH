Imports LaPiedad.RRHH.Clases
Imports Piedad.MasterPS.DataAccess
Public Class SalarioEmpleadoDA
    Public Property HayError As Boolean
    Public Property MensajeError As String
    Private cadenaConex As String
    Public Sub New(ByVal cadenaConexion As String)
        cadenaConex = cadenaConexion
    End Sub

    Public Sub Almacenar(ByVal sal_ As SalarioEmpleado)
        Try
            Using objDA As New ConexDB(cadenaConex)
                objDA.CrearComando("nom.sp_salarioEmpleado_Alta")
                objDA.AgregarParametro("@idEmpleado", sal_.IdEmpleado)
                objDA.AgregarParametro("@salario", sal_.Salario)
                objDA.AgregarParametro("@idEstatusSalarioEmpleado", sal_.IdEstatusSalarioEmpleado)
                objDA.AgregarParametro("@anio", sal_.Anio)
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

    Public Sub Actualizar(ByVal sal_ As SalarioEmpleado)
        Try
            Using objDA As New ConexDB(cadenaConex)
                objDA.CrearComando("nom.sp_salarioEmpleado_Actualizar")
                objDA.AgregarParametro("@id", sal_.IdSalarioSemana)
                objDA.AgregarParametro("@idEmpleado", sal_.IdEmpleado)
                objDA.AgregarParametro("@salario", sal_.Salario)
                objDA.AgregarParametro("@idEstatusSalarioEmpleado", sal_.IdEstatusSalarioEmpleado)
                objDA.AgregarParametro("@anio", sal_.Anio)
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
    Public Sub Eliminar(ByVal sal_ As SalarioEmpleado)
        Try
            Using objDA As New ConexDB(cadenaConex)
                objDA.CrearComando("nom.sp_salarioEmpleado_Eliminar")
                objDA.AgregarParametro("@id", sal_.IdSalarioSemana)
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
    Public Function Obtener(ByVal sal_ As SalarioEmpleado) As SalarioEmpleado
        Dim sala As SalarioEmpleado = Nothing
        Dim lst As List(Of SalarioEmpleado)
        Try
            Using ObjDA As New ConexDB(cadenaConex)
                ObjDA.CrearComando("nom.sp_salarioEmpleado_Obtener")
                ObjDA.AgregarParametro("@id", sal_.IdSalarioSemana)
                ObjDA.EstablecerTipoComando = TipoComando.ProcedimientoAlmacenado
                lst = ObjDA.ObtenerResultados(Of SalarioEmpleado)()
                If Not ObjDA.HayError Then
                    sala = New SalarioEmpleado()
                    sala = lst(0)
                Else
                    sala = Nothing
                    HayError = ObjDA.HayError
                    MensajeError = ObjDA.MensajeError
                End If
                HayError = ObjDA.HayError
            End Using
        Catch ex As Exception
            sala = Nothing
            HayError = True
            MensajeError = ex.Message
        End Try
        Return sala
    End Function
    Public Function ObtenerTodos(ByVal sal_ As SalarioEmpleado) As SalarioEmpleados
        Dim lst As New SalarioEmpleados()
        Try
            Using objDA As New ConexDB(cadenaConex)
                objDA.CrearComando("nom.sp_salarioEmpleado_ObtenerTodos")
                objDA.EstablecerTipoComando = TipoComando.ProcedimientoAlmacenado
                Dim lista As New List(Of SalarioEmpleado)
                lista = objDA.ObtenerResultados(Of SalarioEmpleado)()
                If Not objDA.HayError Then
                    For Each tpo As SalarioEmpleado In lista
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
