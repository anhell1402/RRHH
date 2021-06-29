<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="frmRegister.aspx.vb" Inherits="LaPiedad.RRHH.Web.frmRegister" %>

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
                            <h5 class="modal-title" id="exampleModalLabel5"><asp:Label ID="Label1" runat="server" Text="Alta"></asp:Label> de Usuarios</h5>                        
                            <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <div class="form-group-user row">
                                  <div class="col-sm-12 mb-3 mb-sm-0">
                                    <asp:TextBox ID="txtNombre" placeholder="Nombre(s)" runat="server" CssClass="form-control"></asp:TextBox>
                                    <div class="mx-auto" style="height: 10px;"></div>
                                </div>
                                
                                <div class="col-sm-6 mb-3 mb-sm-0">
                                    <asp:TextBox ID="txtApPaterno" placeholder="Apellido Paterno" runat="server" CssClass="form-control"></asp:TextBox>
                                    <div class="mx-auto" style="height: 10px;"></div>
                                </div>
                                 
                                <div class="col-sm-6 mb-3 mb-sm-0">
                                    <asp:TextBox ID="txtApMaterno" placeholder="Apellido Materno" runat="server" CssClass="form-control"></asp:TextBox>
                                    <div class="mx-auto" style="height: 10px;"></div>
                                </div>
                                 
                                <div class="col-sm-12 mb-3 mb-sm-0">
                                    <asp:TextBox ID="txtUsuario" placeholder="Usuario" runat="server" CssClass="form-control"></asp:TextBox>
                                    <div class="mx-auto" style="height: 10px;"></div>
                                </div>
                                 
                                <div class="col-sm-12 mb-3 mb-sm-0">
                                    <asp:TextBox ID="txtContra" placeholder="Contraseña" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                    <div class="mx-auto" style="height: 10px;"></div>
                                </div>
                           
                                 <div class="col-6">
                                   <asp:DropDownList ID="ddlEdoUsuario" runat="server" CssClass="form-control"></asp:DropDownList>
                                   <div class="mx-auto" style="height: 10px;"></div>
                                </div>
                                 
                                <div class="col-6">
                                    <asp:DropDownList ID="ddlRol" runat="server" CssClass="form-control"></asp:DropDownList>
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
        <asp:Button ID="btnNuevo" runat="server" Text ="Nuevo usuario"  CssClass="btn btn-primary" />
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
                                    <th>Nombre</th>
                                    <th>Apellido Paterno</th>
                                    <th>Apellido Materno</th>
                                    <th>Usuario</th>
                                    <th>Estatus</th>
                                    <th>Rol</th>
                                    <th>Editar</th>
                                    <th>Eliminar</th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%#Eval("Nombre") %></td>
                            <td><%#Eval("Paterno") %></td>
                            <td><%#Eval("Materno") %></td>
                            <td><%#Eval("NombreUsuario") %></td>
                            <td><%#Eval("GetDescripcionEstatus") %></td>
                            <td><%#Eval("GetDescripcionRol") %></td>

                            <td>
                                <asp:Button CssClass="btn btn-info btn-icon-split" Text="Editar" ID="imgEditar"
                                    CommandArgument='<%#Eval("IdUsuario") %>'
                                    runat="server" CommandName="editacion" />
                            </td>
                            <td>
                                <asp:Button CssClass="btn btn-danger btn-icon-split" Text="Eliminar" ID="btnEliminar"
                                    CommandArgument='<%#Eval("IdUsuario") %>' OnClientClick="return confirm('¿Está seguro que desea eliminar?')"
                                    runat="server" CommandName="eliminacion" />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                            </tbody>
                            <tfoot>
                                <tr>
                                    <th>Nombre</th>
                                    <th>Apellido Paterno</th>
                                    <th>Apellido Materno</th>
                                    <th>Usuario</th>
                                    <th>Estatus</th>
                                    <th>Rol</th>
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
