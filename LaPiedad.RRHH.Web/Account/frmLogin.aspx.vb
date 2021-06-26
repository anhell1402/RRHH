Imports LaPiedad.RRHH.Clases
Imports LaPiedad.RRHH.Negocio
Imports Piedad.MasterPS.Utilerias

Public Class frmLogin
    Inherits System.Web.UI.Page

    Private cadena As String = ConfigurationManager.ConnectionStrings("RH").ConnectionString
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Session.Clear()
            FormsAuthentication.SignOut()
        End If
    End Sub

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs)
        Dim usr As New Usuario()
        usr.NombreUsuario = txtUsuario.Text.Trim()
        usr.Passwd = Protection.Encrypt(txtPasswd.Text.Trim())
        Dim obj As New UsuarioBL(cadena)
        usr = obj.Autenticar(usr)
        If Not obj.HayError Then
            If (usr.IdUsuario <> -1) Then
                HttpContext.Current.Session(SesionVars.Usuario.ID_USUARIO) = usr.IdUsuario
                HttpContext.Current.Session(SesionVars.Usuario.NOMBRE_USUARIO) = usr.Nombre + " " + usr.Paterno
                HttpContext.Current.Session(SesionVars.Usuario.ROL_) = usr.IdRol.IdRol
                FormsAuthentication.SetAuthCookie(usr.IdUsuario, False)
                Response.Redirect("~/Default.aspx")
            Else
                lblAviso.Visible = True
                lblAviso.Text = "Usuario y/o Contraseña incorrectos"
            End If
        Else
            lblAviso.Visible = True
            lblAviso.Text = "Error: " + obj.MensajeError
        End If
    End Sub
End Class