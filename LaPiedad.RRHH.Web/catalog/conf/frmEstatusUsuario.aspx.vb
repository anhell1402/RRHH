Imports LaPiedad.RRHH.Clases
Imports LaPiedad.RRHH.Negocio
Public Class frmEstatusUsuario
    Inherits BasePage
    Private cadena As String = ConfigurationManager.ConnectionStrings("RH").ConnectionString
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then 'Determinar si es la primera vez que se manda llamar la página
            CargarDatos()
        End If
    End Sub
    Public Sub CargarDatos()
        rptDatos.DataSource = Nothing
        rptDatos.DataBind()
        Dim obj As New EstatusUsuarioBL(cadena)
        Dim lst As New EstatusUsuarios()
        lst = obj.ObtenerTodos()
        rptDatos.DataSource = lst
        rptDatos.DataBind()
    End Sub
    Protected Sub rptDatos_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        Dim id As String = e.CommandArgument
        Dim edo As New EstatusUsuario()
        edo.IdEstatusUsuario = id
        Dim obj As New EstatusUsuarioBL(cadena)
        If e.CommandName = "editacion" Then
            edo = obj.Obtener(edo)
            hfIdAccion.Value = id
            txtDescripcion.Text = edo.Descripcion
            ModalPopupExtender1.Show()
        Else
            obj.Eliminar(edo)
            If Not obj.HayError Then
                CargarDatos()
            End If
        End If
    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs)
        Dim valida As Boolean = False
        lblAviso.Visible = False
        If txtDescripcion.Text.Trim() <> String.Empty Then
            Dim edo As New EstatusUsuario()
            Dim obj As New EstatusUsuarioBL(cadena)
            edo.Descripcion = txtDescripcion.Text.Trim()
            If hfIdAccion.Value = -1 Then
                'alta
                obj.Almacenar(edo)
                valida = True
            Else
                'modificacion
                edo.IdEstatusUsuario = hfIdAccion.Value
                obj.Actualizar(edo)
                valida = True

            End If
            If Not obj.HayError Then

                ModalPopupExtender1.Hide()
            End If
        Else
            lblAviso.Visible = True
            lblAviso.Text = "La descripción es obligatoria"
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

    Private Sub frmEstatusUsuario_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        Acceso(11)
    End Sub
End Class