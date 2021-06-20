<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="frmTTel.aspx.vb" Inherits="LaPiedad.RRHH.Web.frmTTel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="card shadow mb-4">                       
            <div class="card-body">
                <div class="table-responsive">
    <asp:Repeater ID="rptDatos" runat="server" OnItemCommand="rptDatos_ItemCommand">
        <HeaderTemplate>
            <table class="table table-bordered" id="dataTable" width="100%" cellspacing="0">
                <thead>
                    <tr>
                        <th>Descripcion</th>
                        <th>Editar</th>
                        <th>Eliminar</th>
                    </tr>
                </thead>
                <tbody>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%#Eval("Descripcion") %></td>
                <td>
                    <asp:Button CssClass="btn btn-info btn-icon-split" Text="Editar" ID="imgEditar" runat="server" CommandName="editacion" />
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
                </tbody>
                <tfooter>
                    <tr>
                        <th>Descripcion</th>
                        <th>Editar</th>
                        <th>Eliminar</th>
                    </tr>
                </tfooter>
            </table>
        </FooterTemplate>
    </asp:Repeater>
                    </div>
                </div>
            </div>
</asp:Content>

