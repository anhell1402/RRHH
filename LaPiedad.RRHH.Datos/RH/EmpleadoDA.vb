Imports LaPiedad.RRHH.Clases
Imports Piedad.MasterPS.DataAccess
Public Class EmpleadoDA
    Public Property HayError As Boolean
    Public Property MensajeError As String
    Private cadenaConex As String
    Public Sub New(ByVal cadenaConexion As String)
        cadenaConex = cadenaConexion
    End Sub
    Public Function Buscar(ByVal criterios As Empleado) As Empleados
        Dim lst As Empleados = Nothing
        Try
            Using objDA As New ConexDB(cadenaConex)
                objDA.CrearComando("rh.sp_Empleado_Buscar")
                objDA.AgregarParametro("@nombre", criterios.Nombre)
                objDA.AgregarParametro("@paterno", criterios.Paterno)
                objDA.AgregarParametro("@materno", criterios.Materno)
                objDA.AgregarParametro("@idEmp", criterios.IdEmpleado)
                Dim lista As New List(Of Empleado)
                lista = objDA.ObtenerResultados(Of Empleado)
                If Not objDA.HayError Then
                    lst = New Empleados()
                    For Each emp In lista
                        lst.Add(emp)
                    Next
                Else
                    lst = Nothing
                    HayError = True
                    MensajeError = objDA.MensajeError
                End If
            End Using
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
            lst = Nothing
        End Try
        Return lst
    End Function
    Public Sub Almacenar(ByVal info As Empleado)
        Try
            Using objDA As New ConexDB(cadenaConex)
                objDA.CrearComando("rh.sp_Empleado_Buscar")
                objDA.AgregarParametro("@nombre", info.Nombre)
                objDA.AgregarParametro("@paterno", info.Paterno)
                objDA.AgregarParametro("@materno", info.Materno)
                objDA.AgregarParametro("@rfc", info.RFC)
                objDA.AgregarParametro("@curp", info.CURP)
                objDA.AgregarParametro("@imss", info.IMSS)
                objDA.AgregarParametro("@altaImss", info.AltaIMSS)
                objDA.AgregarParametro("@ine", info.INE)
                objDA.AgregarParametro("@nacimiento", info.FechaNacimiento)
                objDA.AgregarParametro("@sexo", info.InfoSexo.IdSexo)
                objDA.AgregarParametro("@mail", info.Email)
                objDA.AgregarParametro("@sucursal", info.IdSucursal)
                objDA.AgregarParametro("@estatus", info.InfoEstatus.ID)
                objDA.AgregarParametro("@calle", info.InfoDireccion.Calle)
                objDA.AgregarParametro("@colonia", info.InfoDireccion.Colonia)
                objDA.AgregarParametro("@cp", info.InfoDireccion.CP)
                objDA.AgregarParametro("@numExt", info.InfoDireccion.NumExt)
                objDA.AgregarParametro("@numInt", info.InfoDireccion.NumInt)
                objDA.AgregarParametro("@idMun", info.InfoDireccion.InfoMunicipio.ID)
                objDA.EjecutaComando()
                HayError = objDA.HayError
                MensajeError = objDA.MensajeError
            End Using
        Catch ex As Exception
            HayError = True
            MensajeError = ex.Message
        End Try
    End Sub
End Class
