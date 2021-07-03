Imports LaPiedad.RRHH.Clases
Imports LaPiedad.RRHH.Negocio
Imports Piedad.MasterPS.Utilerias

Public Class frmBusqEmp
    Inherits BasePage

    Private cadena As String = ConfigurationManager.ConnectionStrings("RH").ConnectionString
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnBuscar_Click(sender As Object, e As EventArgs)
        Dim criterio As New Empleado()
        If (txtCveEmp.Text.Trim() = "") Then
            criterio.IdEmpleado = 0
        Else
            criterio.IdEmpleado = Convert.ToInt32(txtCveEmp.Text.Trim())
        End If
        criterio.Nombre = txtNombre.Text.Trim()
        criterio.Paterno = txtPaterno.Text.Trim()
        criterio.Materno = txtMaterno.Text.Trim()
        Dim obj As New EmpleadoBL(cadena)
        Dim lst As New Empleados()
        lst = obj.Buscar(criterio)
        If (Not obj.HayError) Then
            rptDatos.DataSource = lst
            rptDatos.DataBind()
        End If
    End Sub

    Protected Sub btnNuevo_Click(sender As Object, e As EventArgs)
        ModalPopupExtender1.Show()
    End Sub

    Protected Sub rptDatos_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        If e.CommandName = "seleccioneichon" Then
            Dim idEmp As String
            idEmp = e.CommandArgument.ToString()
            Response.Redirect("~/rh/frmemp.aspx?i=" + Protection.Encrypt(idEmp), False)
        End If
    End Sub

    Private Sub frmBusqEmp_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        Acceso(13)
    End Sub
End Class