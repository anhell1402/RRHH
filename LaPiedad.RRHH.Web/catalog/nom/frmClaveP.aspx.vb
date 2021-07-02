Imports LaPiedad.RRHH.Clases
Imports LaPiedad.RRHH.Negocio
Public Class frmClaveP
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
        Dim obj As New ClavePagoBL(cadena)
        Dim lst As New ClavePagos()
        lst = obj.ObtenerTodos()
        rptDatos.DataSource = lst
        rptDatos.DataBind()
    End Sub
    Protected Sub rptDatos_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        Dim id As String = e.CommandArgument
        Dim idCl As New ClavePago()
        idCl.IdClave = id
        Dim obj As New ClavePagoBL(cadena)
        If e.CommandName = "editacion" Then
            idCl = obj.Obtener(idCl)
            hfIdAccion.Value = id
            txtDescripcion.Text = idCl.Descripcion
            ddlTipoPago.SelectedValue = idCl.IdTipoPago
            ModalPopupExtender1.Show()
        Else
            obj.Eliminar(idCl)
            If Not obj.HayError Then
                CargarDatos()
            End If
        End If
    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs)
        Dim valida As Boolean = False
        lblAviso.Visible = False
        If txtDescripcion.Text.Trim() <> String.Empty And ddlTipoPago.SelectedValue <> 0 Then
            Dim idCl As New ClavePago()
            Dim obj As New ClavePagoBL(cadena)
            idCl.Descripcion = txtDescripcion.Text.Trim()
            idCl.IdTipoPago = ddlTipoPago.SelectedValue
            If hfIdAccion.Value = -1 Then
                'alta
                obj.Almacenar(idCl)
                valida = True
            Else
                'modificacion
                idCl.IdClave = hfIdAccion.Value
                obj.Actualizar(idCl)
                valida = True
            End If
            If Not obj.HayError Then
                ModalPopupExtender1.Hide()
            End If
        Else
            lblAviso.Visible = True
            lblAviso.Text = "La descripción y el tipo de pago es obligatorio."
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

    Private Sub frmClaveP_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        Acceso(1)
    End Sub
End Class