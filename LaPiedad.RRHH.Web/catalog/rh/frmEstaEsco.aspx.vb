Imports LaPiedad.RRHH.Clases
Imports LaPiedad.RRHH.Negocio
Public Class frmEstaEsco
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
        Dim obj As New EstatusEscolaridadBL(cadena)
        Dim lst As New EstatusEscolaridades()
        lst = obj.ObtenerTodos()
        rptDatos.DataSource = lst
        rptDatos.DataBind()
    End Sub
    Protected Sub rptDatos_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        Dim id As String = e.CommandArgument
        Dim idEd As New EstatusEscolaridad()
        idEd.IdEstatusEscolaridad = id
        Dim obj As New EstatusEscolaridadBL(cadena)
        If e.CommandName = "editacion" Then
            idEd = obj.Obtener(idEd)
            hfIdAccion.Value = id
            txtDescripcion.Text = idEd.Descripcion
            ModalPopupExtender1.Show()
        Else
            obj.Eliminar(idEd)
            If Not obj.HayError Then
                CargarDatos()
            End If
        End If
    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs)
        Dim valida As Boolean = False
        lblAviso.Visible = False
        If txtDescripcion.Text.Trim() <> String.Empty Then
            Dim idEd As New EstatusEscolaridad()
            Dim obj As New EstatusEscolaridadBL(cadena)
            idEd.Descripcion = txtDescripcion.Text.Trim()
            If hfIdAccion.Value = -1 Then
                'alta
                obj.Almacenar(idEd)
                valida = True
            Else
                'modificacion
                idEd.IdEstatusEscolaridad = hfIdAccion.Value
                obj.Actualizar(idEd)
                valida = True
            End If
            If Not obj.HayError Then
                ModalPopupExtender1.Hide()
            End If
        Else
            lblAviso.Visible = True
            lblAviso.Text = "El campo descripción es obligatorio."
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