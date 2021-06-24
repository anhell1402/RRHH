Imports LaPiedad.RRHH.Clases
Imports LaPiedad.RRHH.Negocio
Public Class frmSalEmp
    Inherits System.Web.UI.Page
    Private cadena As String = ConfigurationManager.ConnectionStrings("RH").ConnectionString
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'CodeBehind
        If Not Page.IsPostBack Then 'Determinar si es la primera vez que se manda llamar la página
            CargarDatos()
        End If
    End Sub
    Public Sub CargarDatos()
        rptDatos.DataSource = Nothing
        rptDatos.DataBind()
        Dim obj As New SalarioEmpleadoBL(cadena)
        Dim lst As New SalarioEmpleados()
        lst = obj.ObtenerTodos()
        rptDatos.DataSource = lst
        rptDatos.DataBind()
    End Sub
    Protected Sub rptDatos_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        Dim id As String = e.CommandArgument
        Dim idSal As New SalarioEmpleado()
        idSal.IdSalarioSemana = id
        Dim obj As New SalarioEmpleadoBL(cadena)
        If e.CommandName = "editacion" Then
            idSal = obj.Obtener(idSal)
            hfIdAccion.Value = id
            ddlEmpleado.SelectedValue = idSal.IdEmpleado
            txtSalario.Text = idSal.Salario
            ddlEstSal.SelectedValue = idSal.IdEstatusSalarioEmpleado
            txtAnio.Text = idSal.Anio
            txtFechaCreacion.Text = idSal.FechaCreacion
            ModalPopupExtender1.Show()
        Else
            obj.Eliminar(idSal)
            If Not obj.HayError Then
                CargarDatos()
            End If
        End If
    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs)
        Dim valida As Boolean = False
        lblAviso.Visible = False
        If ddlEmpleado.SelectedValue <> 0 And txtSalario.Text.Trim() <> String.Empty And ddlEstSal.SelectedValue <> 0 And
            txtAnio.Text.Trim() <> String.Empty And txtFechaCreacion.Text.Trim() <> String.Empty Then
            Dim idSuc As New SalarioEmpleado()
            Dim obj As New SalarioEmpleadoBL(cadena)
            idSuc.IdEmpleado = ddlEmpleado.SelectedValue
            idSuc.Salario = txtSalario.Text.Trim()
            idSuc.IdEstatusSalarioEmpleado = ddlEstSal.SelectedValue
            idSuc.Anio = txtAnio.Text.Trim()
            idSuc.FechaCreacion = txtFechaCreacion.Text.Trim()
            If hfIdAccion.Value = -1 Then
                'alta
                obj.Almacenar(idSuc)
                valida = True
            Else
                'modificacion
                idSuc.IdSalarioSemana = hfIdAccion.Value
                obj.Actualizar(idSuc)
                valida = True
            End If
            If Not obj.HayError Then
                ModalPopupExtender1.Hide()
            End If
        Else
            lblAviso.Visible = True
            lblAviso.Text = "Todos los campos deben estar llenos."
            ModalPopupExtender1.Show()
        End If
        If valida Then
            CargarDatos()
            ScriptManager.RegisterStartupScript(Me, GetType(Page), "jsKeys", "javascript:Forzar();", True)
        End If

    End Sub

    Protected Sub btnNuevo_Click(sender As Object, e As EventArgs)
        ModalPopupExtender1.Show()
    End Sub

    Protected Sub btnClose_Click(sender As Object, e As EventArgs)
        ModalPopupExtender1.Hide()
    End Sub
End Class