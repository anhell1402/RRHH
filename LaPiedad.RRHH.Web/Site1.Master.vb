Imports LaPiedad.RRHH.Clases
Imports LaPiedad.RRHH.Negocio

Public Class Site1
    Inherits System.Web.UI.MasterPage
    Private cadena As String = ConfigurationManager.ConnectionStrings("RH").ConnectionString
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim idUsuario As Integer = -1
        Dim nombre As String = String.Empty
        Try
            idUsuario = Convert.ToInt32(HttpContext.Current.Session(SesionVars.Usuario.ID_USUARIO))
            nombre = HttpContext.Current.Session(SesionVars.Usuario.NOMBRE_USUARIO)
            If (idUsuario <> -1 And nombre <> String.Empty) Then
                lblUsuario.Text = nombre
                'buscar datos de menu
                Dim usr As New Usuario()
                usr.IdUsuario = idUsuario
                Dim lstMenus As New MnMenus()
                Dim obj As New UsuarioBL(cadena)
                lstMenus = obj.ObtenerMenu(usr)
                HttpContext.Current.Session(SesionVars.Usuario.LISTA_MENU) = lstMenus
                RetrieveAllControls(Me.Page)
                For Each mn As MnMenu In lstMenus
                    Dim ctrl As Control = lst_controls.Find(Function(x) x.ID = mn.NomControl)
                    If ctrl IsNot Nothing Then ctrl.Visible = True
                Next
            Else
                Salir()
            End If
        Catch ex As Exception
            Salir()
        End Try

    End Sub
    Protected Sub Salir()
        HttpContext.Current.Session.Clear()
        FormsAuthentication.SignOut()
        FormsAuthentication.RedirectToLoginPage()
    End Sub

    Protected Sub Unnamed_LoggingOut(sender As Object, e As LoginCancelEventArgs)
        Salir()
    End Sub

    Private lst_controls As List(Of Control) = New List(Of Control)()
    Private Function RetrieveAllControls(ByVal control As Control) As List(Of Control)
        For Each ctr As Control In control.Controls
            If ctr IsNot Nothing Then
                lst_controls.Add(ctr)
                If ctr.HasControls() Then
                    RetrieveAllControls(ctr)
                End If
            End If
        Next
        Return Nothing
    End Function
End Class