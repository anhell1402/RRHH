Imports LaPiedad.RRHH.Clases
Imports LaPiedad.RRHH.Negocio
Public Class frmRol
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
        Dim obj As New RolBL(cadena)
        Dim lst As New Roles()
        lst = obj.ObtenerTodos()
        rptDatos.DataSource = lst
        rptDatos.DataBind()

    End Sub
    Protected Sub rptDatos_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        Dim id As String = e.CommandArgument
        Dim rl As New Rol()
        rl.IdRol = id
        Dim obj As New RolBL(cadena)
        If e.CommandName = "editacion" Then
            rl = obj.Obtener(rl)
            hfIdAccion.Value = id
            txtDescripcion.Text = rl.Descripcion
            ModalPopupExtender1.Show()
        Else
            obj.Eliminar(rl)
            If Not obj.HayError Then
                CargarDatos()
            End If
        End If
    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs)
        Dim valida As Boolean = False
        lblAviso.Visible = False
        If txtDescripcion.Text.Trim() <> String.Empty Then
            Dim rl As New Rol()
            Dim obj As New RolBL(cadena)
            rl.Descripcion = txtDescripcion.Text.Trim()
            If hfIdAccion.Value = -1 Then
                'alta
                obj.Almacenar(rl)
                valida = True
            Else
                'modificacion
                rl.IdRol = hfIdAccion.Value
                obj.Actualizar(rl)
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

    Private Sub frmRol_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        Acceso(10)
    End Sub
End Class