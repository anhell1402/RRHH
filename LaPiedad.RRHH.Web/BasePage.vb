Imports LaPiedad.RRHH.Clases

Public Class BasePage
    Inherits System.Web.UI.Page

    Public Sub Acceso(ByVal idMenu As Integer)
        Dim tieneAcceso As Boolean = False
        Dim listaMenus As MnMenus = CType(HttpContext.Current.Session(SesionVars.Usuario.LISTA_MENU), MnMenus)
        If listaMenus Is Nothing Then
            FormsAuthentication.SignOut()
            Response.Redirect("~/Account/Login.aspx", False)
        Else
            For Each mn As MnMenu In listaMenus
                If mn.IdMenu = idMenu Then
                    tieneAcceso = True
                    Exit For
                End If
            Next

            If Not tieneAcceso Then
                Response.Redirect("~/nopermitido.aspx", False)
            End If
        End If
    End Sub
End Class
