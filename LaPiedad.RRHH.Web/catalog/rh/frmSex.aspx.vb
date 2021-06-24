Imports LaPiedad.RRHH.Clases
Imports LaPiedad.RRHH.Negocio
Public Class frmSex
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
        Dim obj As New SexoBL(cadena)
        Dim lst As New Sexos()
        lst = obj.ObtenerTodos()
        rptDatos.DataSource = lst
        rptDatos.DataBind()
    End Sub
    Protected Sub rptDatos_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        Dim id As String = e.CommandArgument
        Dim idSe As New Sexo()
        idSe.IdSexo = id
        Dim obj As New SexoBL(cadena)
        If e.CommandName = "editacion" Then
            idSe = obj.Obtener(idSe)
            hfIdAccion.Value = id
            txtDescripcion.Text = idSe.Descripcion
            ModalPopupExtender1.Show()
        Else
            obj.Eliminar(idSe)
            If Not obj.HayError Then
                CargarDatos()
            End If
        End If
    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs)
        Dim valida As Boolean = False
        lblAviso.Visible = False
        If txtDescripcion.Text.Trim() <> String.Empty Then
            Dim idSe As New Sexo()
            Dim obj As New SexoBL(cadena)
            idSe.Descripcion = txtDescripcion.Text.Trim()
            If hfIdAccion.Value = -1 Then
                'alta
                obj.Almacenar(idSe)
                valida = True
            Else
                'modificacion
                idSe.IdSexo = hfIdAccion.Value
                obj.Actualizar(idSe)
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