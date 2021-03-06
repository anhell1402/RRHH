<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="frmPadec.aspx.vb" Inherits="LaPiedad.RRHH.Web.frmPadec" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/javascript">        
        function Forzar() {
            __doPostBack('', '');            
        }
     </script>
    <style type="text/css">        
        .modalBackground
        {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }
        .modalPopup
        {
            background-color: #fff;
            border: 3px solid #ccc;
            padding: 10px;
            width: 500px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="Panel1"
        BackgroundCssClass="modalBackground" TargetControlID="btnNuevo" CancelControlID="btnClose" ></ajaxToolkit:ModalPopupExtender>

    <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" align="center" Style="display: none">
        <div style="">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>                   
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="exampleModalLabel5"><asp:Label ID="Label1" runat="server" Text="Alta"></asp:Label> de Padecimientos</h5>                        
                            <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <div class="col-4">
                                    Descripción:
                                </div>
                                <div class="col-8">
                                    <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:Label ID="lblAviso" runat="server" CssClass="alert alert-danger" Visible="false"></asp:Label>
                            <asp:Button ID="btnClose" CssClass="btn btn-secondary" runat="server" Text="Cerrar" OnClick="btnClose_Click" />
                            <asp:HiddenField ID="hfIdAccion" runat="server" Value="-1" />
                            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />                
                        </div>
                    </div>           
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>            
    </asp:Panel>    
    <div class="container-fluid text-right">    
        <asp:Button ID="btnNuevo" runat="server" Text ="Nuevo padecimiento"  CssClass="btn btn-primary" />
        <div class="mx-auto" style="height: 10px;"></div>
    </div>
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
                                <asp:Button CssClass="btn btn-info btn-icon-split" Text="Editar" ID="imgEditar"
                                    CommandArgument='<%#Eval("IdPadecimiento") %>'
                                    runat="server" CommandName="editacion" />
                            </td>
                            <td>
                                <asp:Button CssClass="btn btn-danger btn-icon-split" Text="Eliminar" ID="btnEliminar"
                                    CommandArgument='<%#Eval("IdPadecimiento") %>' OnClientClick="return confirm('¿Está seguro que desea eliminar?')"
                                    runat="server" CommandName="eliminacion" />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                            </tbody>
                            <tfoot>
                                <tr>
                                    <th>Descripcion</th>
                                    <th>Editar</th>
                                    <th>Eliminar</th>
                                </tr>
                            </tfoot>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</asp:Content>
