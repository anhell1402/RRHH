Imports LaPiedad.RRHH.Clases
Imports LaPiedad.RRHH.Negocio
Imports System.Configuration

Public Class WebForm1
    Inherits System.Web.UI.Page
    Private cadena As String = ConfigurationManager.ConnectionStrings("RH").ConnectionString
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'CodeBehind
        If Not Page.IsPostBack Then 'Determinar si es la primera vez que se manda llamar la página
            CargarDatos()
        End If
    End Sub
    Public Sub CargarDatos()
        rptTiposTelefono.DataSource = Nothing
        rptTiposTelefono.DataBind()
        Dim obj As New TipoTelefonoBL(cadena)
        Dim lst As New TipoTelefonos()
        lst = obj.ObtenerTodos()
        rptTiposTelefono.DataSource = lst
        rptTiposTelefono.DataBind()

    End Sub
    Protected Sub rptTiposTelefono_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        If e.CommandName = "editacion" Then
        Else

        End If
    End Sub
End Class