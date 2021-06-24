﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="frmSalEmp.aspx.vb" Inherits="LaPiedad.RRHH.Web.frmSalEmp" %>

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
                            <h5 class="modal-title" id="exampleModalLabel5"><asp:Label ID="Label1" runat="server" Text="Alta"></asp:Label> del Salario por Empleado</h5>                        
                            <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <div class="col-4">
                                    ID Empleado:
                                </div>
                                <div class="col-8">
                                    <asp:DropDownList  ID="ddlEmpleado" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="0">-Seleccione-</asp:ListItem>
                                    <asp:ListItem Value="1">Empleado-1</asp:ListItem>
                                    <asp:ListItem Value="2">Empleado-2</asp:ListItem>
                                  </asp:DropDownList>
                                </div>
                            </div>
                            <!-- ESTO HACE UN ESPACIO DE "X" PIXELES ENTRE LINEAS-->
                            <div class="mx-auto" style="height: 10px;"></div>
                            <!-- AQUI TERMINA -->
                            <div class="row">
                                <div class="col-4">
                                    Salario:
                                </div>
                                <div class="col-8">
                                   <asp:TextBox ID="txtSalario" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <!-- ESTO HACE UN ESPACIO DE "X" PIXELES ENTRE LINEAS-->
                            <div class="mx-auto" style="height: 10px;"></div>
                            <!-- AQUI TERMINA -->
                              <div class="row">
                                <div class="col-4">
                                    Estatus del Salario:
                                </div>
                                <div class="col-8">
                                  <asp:DropDownList  ID="ddlEstSal" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="0">-Seleccione-</asp:ListItem>
                                    <asp:ListItem Value="1">Activo</asp:ListItem>
                                    <asp:ListItem Value="2">Retenido</asp:ListItem>
                                    <asp:ListItem Value="3">Cancelado</asp:ListItem>
                                  </asp:DropDownList>
                                </div>
                            </div>
                              <div class="row">
                                <div class="col-4">
                                    Año:
                                </div>
                                <div class="col-8">
                                   <asp:TextBox ID="txtAnio" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <!-- ESTO HACE UN ESPACIO DE "X" PIXELES ENTRE LINEAS-->
                            <div class="mx-auto" style="height: 10px;"></div>
                            <!-- AQUI TERMINA -->
                             <div class="row">
                                <div class="col-4">
                                    Fecha de Creación:
                                </div>
                                <div class="col-8">
                                   <asp:TextBox ID="txtFechaCreacion" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <!-- ESTO HACE UN ESPACIO DE "X" PIXELES ENTRE LINEAS-->
                            <div class="mx-auto" style="height: 10px;"></div>
                            <!-- AQUI TERMINA -->
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
        <asp:Button ID="btnNuevo" runat="server" Text ="Nuevo Salario del Empleado"  CssClass="btn btn-primary" />
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
                                    <th>ID Empleado</th>
                                    <th>Salario</th>
                                    <th>Estatus Salario</th>
                                    <th>Año</th>
                                    <th>Fecha Creacion</th>
                                    <th>Editar</th>
                                    <th>Eliminar</th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%#Eval("IdEmpleado") %></td>
                            <td><%#Eval("Salario") %></td>
                            <td><%#Eval("IdEstatusSalarioEmpleado") %></td>
                            <td><%#Eval("Anio") %></td>
                            <td><%#Eval("FechaCreacion") %></td>
                            
                            <td>
                                <asp:Button CssClass="btn btn-info btn-icon-split" Text="Editar" ID="imgEditar"
                                    CommandArgument='<%#Eval("IdSalarioSemana") %>'
                                    runat="server" CommandName="editacion" />
                            </td>
                            <td>
                                <asp:Button CssClass="btn btn-danger btn-icon-split" Text="Eliminar" ID="btnEliminar"
                                    CommandArgument='<%#Eval("IdSalarioSemana") %>' OnClientClick="return confirm('¿Está seguro que desea eliminar?')"
                                    runat="server" CommandName="eliminacion" />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                            </tbody>
                            <tfoot>
                                <tr>
                                     <th>ID Empleado</th>
                                    <th>Salario</th>
                                    <th>Estatus Salario</th>
                                    <th>Año</th>
                                    <th>Fecha Creacion</th>
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
