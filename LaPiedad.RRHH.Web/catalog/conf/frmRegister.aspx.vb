Imports LaPiedad.RRHH.Clases
Imports LaPiedad.RRHH.Negocio
Imports Piedad.MasterPS.Utilerias
Public Class frmRegister
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
        Dim obj As New UsuarioBL(cadena)
        Dim lst As New Usuarios()
        lst = obj.ObtenerTodos()
        rptDatos.DataSource = lst
        rptDatos.DataBind()
        LlenarDropDowns()
    End Sub
    Public Sub LlenarDropDowns()
        Dim obj1 As New EstatusUsuarioBL(cadena)
        Dim lstEdo As New EstatusUsuarios()
        lstEdo = obj1.ObtenerTodosDDL()

        ddlEdoUsuario.DataSource = lstEdo
        ddlEdoUsuario.DataTextField = "Descripcion" 'lo que ve el usuario
        ddlEdoUsuario.DataValueField = "IdEstatusUsuario" 'lo que ve el código
        ddlEdoUsuario.DataBind()

        Dim obj2 As New RolBL(cadena)
        Dim lstRol As New Roles()
        lstRol = obj2.ObtenerTodosDDL()

        ddlRol.DataSource = lstRol
        ddlRol.DataTextField = "Descripcion"
        ddlRol.DataValueField = "IdRol"
        ddlRol.DataBind()
    End Sub
    Protected Sub rptDatos_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        Dim id As String = e.CommandArgument
        Dim usu_ As New Usuario()
        usu_.IdUsuario = id
        Dim obj As New UsuarioBL(cadena)
        If e.CommandName = "editacion" Then
            usu_ = obj.Obtener(usu_)
            hfIdAccion.Value = id
            txtNombre.Text = usu_.Nombre
            txtApPaterno.Text = usu_.Paterno
            txtApMaterno.Text = usu_.Materno
            txtUsuario.Text = usu_.NombreUsuario
            txtContra.Text = usu_.Passwd
            ddlEdoUsuario.SelectedValue = Convert.ToInt32(usu_.IdEstatusUsuario.IdEstatusUsuario)
            ddlRol.SelectedValue = Convert.ToInt32(usu_.IdRol.IdRol)
            ModalPopupExtender1.Show()
        Else
            obj.Eliminar(usu_)
            If Not obj.HayError Then
                CargarDatos()
            End If
        End If
    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs)
        Dim valida As Boolean = False
        lblAviso.Visible = False
        If txtNombre.Text.Trim() <> String.Empty And txtApPaterno.Text.Trim() <> String.Empty And txtApMaterno.Text.Trim() <> String.Empty And
           txtUsuario.Text.Trim() <> String.Empty And txtContra.Text.Trim() <> String.Empty And ddlEdoUsuario.SelectedValue <> -1 And
           ddlRol.SelectedValue <> -1 Then
            Dim usu As New Usuario()
            Dim obj As New UsuarioBL(cadena)
            usu.Nombre = txtNombre.Text.Trim()
            usu.Paterno = txtApPaterno.Text.Trim()
            usu.Materno = txtApMaterno.Text.Trim()
            usu.NombreUsuario = txtUsuario.Text.Trim()
            usu.Passwd = Protection.Encrypt(txtContra.Text.Trim())
            usu.IdRol.IdRol = ddlRol.SelectedValue
            If hfIdAccion.Value = -1 Then
                'alta
                obj.Almacenar(usu)
                valida = True
            Else
                'modificacion
                usu.IdUsuario = hfIdAccion.Value
                usu.IdEstatusUsuario.IdEstatusUsuario = ddlEdoUsuario.SelectedValue
                obj.Actualizar(usu)
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

    Private Sub frmRegister_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        Acceso(12)
    End Sub
End Class