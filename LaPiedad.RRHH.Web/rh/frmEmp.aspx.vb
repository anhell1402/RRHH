Public Class frmEmp
    Inherits BasePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub frmEmp_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        Acceso(13)
    End Sub
End Class