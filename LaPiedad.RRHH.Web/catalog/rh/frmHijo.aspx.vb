Imports LaPiedad.RRHH.Clases
Imports LaPiedad.RRHH.Negocio
Public Class frmHijo
    Inherits BasePage
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
        Dim obj As New HijoBL(cadena)
        Dim lst As New Hijos()
        lst = obj.ObtenerTodos()
        rptDatos.DataSource = lst
        rptDatos.DataBind()
    End Sub
    Protected Sub rptDatos_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        Dim id As String = e.CommandArgument
        Dim idHi As New Hijo()
        idHi.IdHijo = id
        Dim obj As New HijoBL(cadena)
        If e.CommandName = "editacion" Then
            idHi = obj.Obtener(idHi)
            hfIdAccion.Value = id
            ddlEmpleado.SelectedValue = idHi.IdEmpleado
            txtNomHijo.Text = idHi.NombreHijo
            txtFechaNac.Text = idHi.FechaNac
            txtObserv.Text = idHi.Observaciones
            ModalPopupExtender1.Show()
        Else
            obj.Eliminar(idHi)
            If Not obj.HayError Then
                CargarDatos()
            End If
        End If
    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs)
        Dim valida As Boolean = False
        lblAviso.Visible = False
        If ddlEmpleado.SelectedValue <> 0 And txtNomHijo.Text.Trim() <> String.Empty And
           txtFechaNac.Text.Trim() <> String.Empty And txtObserv.Text.Trim() <> String.Empty Then
            Dim idHi As New Hijo()
            Dim obj As New HijoBL(cadena)
            idHi.IdEmpleado = ddlEmpleado.SelectedValue
            idHi.NombreHijo = txtNomHijo.Text.Trim()
            idHi.FechaNac = txtFechaNac.Text.Trim()
            idHi.Observaciones = txtObserv.Text.Trim()
            If hfIdAccion.Value = -1 Then
                'alta
                obj.Almacenar(idHi)
                valida = True
            Else
                'modificacion
                idHi.IdHijo = hfIdAccion.Value
                obj.Actualizar(idHi)
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