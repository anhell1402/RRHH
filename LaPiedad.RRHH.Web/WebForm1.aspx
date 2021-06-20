<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm1.aspx.vb" Inherits="LaPiedad.RRHH.Web.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Repeater ID="rptTiposTelefono" runat="server" OnItemCommand="rptTiposTelefono_ItemCommand">
        <HeaderTemplate>
            <table>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%#Eval("Descripcion") %></td>
                <td>
                    
                    <%--<asp:Button ID="btnEditar" runat="server" CssClass="btn btn-info btn-icon-split" CommandName="editacion" 
                    CommandArgument='<%#Eval("IdTipoTelefono") %>' Text="Editar" />--%></td>
                <td><%--<asp:Button ID="btnEliminar" runat="server" CommandName="eliminacion" CommandArgument='<%#Eval("IdTipoTelefono") %>'
                    OnClientClick="return confirm('¿Está seguro que desea eliminar?');" 
                    CssClass="btn btn-danger btn-icon-split" Text="Eliminar" OnClick="btnEliminar_Click" />--%>
                    <asp:ImageButton ID="imgEliminar" runat="server" AlternateText="Eliminar" 
                        CommandName="eliminacion" CommandArgument='<%#Eval("IdTipoTelefono") %>' />
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    </form>
</body>
</html>
