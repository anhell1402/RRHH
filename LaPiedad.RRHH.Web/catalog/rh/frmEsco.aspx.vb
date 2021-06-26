Imports LaPiedad.RRHH.Clases
Imports LaPiedad.RRHH.Negocio
Public Class frmEsco
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
        Dim obj As New EscolaridadBL(cadena)
        Dim lst As New Escolaridades()
        lst = obj.ObtenerTodos()
        rptDatos.DataSource = lst
        rptDatos.DataBind()
    End Sub
    Protected Sub rptDatos_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        Dim id As String = e.CommandArgument
        Dim idEsc As New Escolaridad()
        idEsc.IdEscolaridad = id
        Dim obj As New EscolaridadBL(cadena)
        If e.CommandName = "editacion" Then
            idEsc = obj.Obtener(idEsc)
            hfIdAccion.Value = id
            ddlEmpleado.SelectedValue = idEsc.IdEmpleado
            ddlNivelAcademico.SelectedValue = idEsc.IdNivelAcademico.IdNivelAcademico
            txtNombreEscuela.Text = idEsc.NombreEscuela
            ddlEstatusEscolaridad.SelectedValue = idEsc.IdEstatusEscolaridad.IdEstatusEscolaridad
            ModalPopupExtender1.Show()
        Else
            obj.Eliminar(idEsc)
            If Not obj.HayError Then
                CargarDatos()
            End If
        End If
    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs)
        Dim valida As Boolean = False
        lblAviso.Visible = False
        If ddlEmpleado.SelectedValue <> 0 And ddlNivelAcademico.SelectedValue <> 0 And
           txtNombreEscuela.Text.Trim() <> String.Empty And ddlEstatusEscolaridad.SelectedValue <> 0 Then
            Dim idEsc As New Escolaridad()
            Dim obj As New EscolaridadBL(cadena)
            idEsc.IdEmpleado = ddlEmpleado.SelectedValue
            idEsc.IdNivelAcademico.IdNivelAcademico = ddlNivelAcademico.SelectedValue
            idEsc.NombreEscuela = txtNombreEscuela.Text.Trim()
            idEsc.IdEstatusEscolaridad.IdEstatusEscolaridad = ddlEstatusEscolaridad.SelectedValue
            If hfIdAccion.Value = -1 Then
                'alta
                obj.Almacenar(idEsc)
                valida = True
            Else
                'modificacion
                idEsc.IdEscolaridad = hfIdAccion.Value
                obj.Actualizar(idEsc)
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