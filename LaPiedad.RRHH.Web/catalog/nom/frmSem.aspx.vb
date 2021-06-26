Imports LaPiedad.RRHH.Clases
Imports LaPiedad.RRHH.Negocio
Public Class Sem
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
        Dim obj As New SemanaBL(cadena)
        Dim lst As New Semanas()
        lst = obj.ObtenerTodos()
        rptDatos.DataSource = lst
        rptDatos.DataBind()
        Dim item As New ListItem("Seleccione", "0")
        ddlEstaSem.Items.Add(item)
        item = New ListItem("Vigente", "1")
        ddlEstaSem.Items.Add(item)
        item = New ListItem("Historial", "2")
        ddlEstaSem.Items.Add(item)
    End Sub
    Protected Sub rptDatos_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        Dim id As String = e.CommandArgument
        Dim sem As New Semana()
        sem.IdSemana = id
        Dim obj As New SemanaBL(cadena)
        If e.CommandName = "editacion" Then
            sem = obj.Obtener(sem)
            hfIdAccion.Value = id
            txtInicio.Text = sem.Inicio
            txtFin.Text = sem.Fin
            ddlEstaSem.SelectedValue = sem.IdEstatusSemana
            ModalPopupExtender1.Show()
        Else
            obj.Eliminar(sem)
            If Not obj.HayError Then
                CargarDatos()
            End If
        End If
    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs)
        Dim valida As Boolean = False
        lblAviso.Visible = False
        If txtInicio.Text.Trim() <> String.Empty And txtFin.Text.Trim() <> String.Empty And ddlEstaSem.SelectedValue <> 0 Then
            Dim sem As New Semana()
            Dim obj As New SemanaBL(cadena)
            sem.Inicio = txtInicio.Text.Trim()
            sem.Fin = txtFin.Text.Trim()
            sem.IdEstatusSemana = ddlEstaSem.SelectedValue
            If hfIdAccion.Value = -1 Then
                'alta
                obj.Almacenar(sem)
                valida = True
            Else
                'modificacion
                sem.IdSemana = hfIdAccion.Value
                obj.Actualizar(sem)
                valida = True

            End If
            If Not obj.HayError Then

                ModalPopupExtender1.Hide()
            End If
        Else
            lblAviso.Visible = True
            lblAviso.Text = "Los campos Fecha Inicio, Fecha Fin y el Estatus son obligatorios"
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

    Private Sub Sem_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        Acceso(3)
    End Sub
End Class