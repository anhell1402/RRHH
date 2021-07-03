<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="frmBusqEmp.aspx.vb" Inherits="LaPiedad.RRHH.Web.frmBusqEmp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
            width: 800px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:LinkButton ID="lnkDummy" runat="server"></asp:LinkButton>
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="Panel1"
        BackgroundCssClass="modalBackground" TargetControlID="lnkDummy" CancelControlID="btnClose" ></ajaxToolkit:ModalPopupExtender>

    <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" align="center" Style="display: none">
        
  
        <div class="modal-content"  role="document">
            <div class="modal-header">
                <h5 class="modal-title" id="exampleModalLabel5">Alta de Empleado</h5>                                                    
            </div>
            <div class="modal-body">
                <div class="row">
                    <div class="col-2">Nombre:</div>
                    <div class="col-4">
                        <asp:TextBox ID="txtNombreEmp" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-2">Paterno:</div>
                    <div class="col-4">
                        <asp:TextBox ID="txtPaternoEmp" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>                
                <div class="row">
                    <div class="col-2">Materno:</div>
                    <div class="col-4">
                        <asp:TextBox ID="txtMaternoEmp" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-2">RFC:</div>
                    <div class="col-4">
                        <asp:TextBox ID="txtRFC" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>                
                <div class="row">
                    <div class="col-2">CURP:</div>
                    <div class="col-4">
                        <asp:TextBox ID="txtCurpEmp" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-2">IMSS:</div>
                    <div class="col-4">
                        <asp:TextBox ID="txtImssEmp" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-2">Alta IMSS:</div>
                    <div class="col-4">
                        <asp:TextBox ID="txtAltaIMSS" runat="server" CssClass="form-control"></asp:TextBox>
                        <%--<ajaxToolkit:CalendarExtender runat="server" Format="dd.MM.yyyy" Enabled="True" />--%>
                    </div>
                    <div class="col-2">INE:</div>
                    <div class="col-4">
                        <asp:TextBox ID="txtIne" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-2">Nacimiento:</div>
                    <div class="col-4">
                        <asp:TextBox ID="txtFechaNac" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-2">Sexo:</div>
                    <div class="col-4">
                        <asp:DropDownList ID="ddlSexo" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                </div>
                <div class="row">
                    <div class="col-2">E-mail:</div>
                    <div class="col-4">
                        <asp:TextBox ID="txtMail" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-2">Sucursal:</div>
                    <div class="col-4">
                        <asp:DropDownList ID="ddlSucursal" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                </div>
                <div class="row">
                    <div class="col-2">Estatus:</div>
                    <div class="col-4">
                        <asp:DropDownList ID="ddlEstatus" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>                    
                </div> 
                <div class="modal-header">
                    <h5 class="modal-title" >Domicilio</h5>                                                    
                </div>
                <div class="row">
                    <div class="col-2">Calle:</div>
                    <div class="col-4">
                        <asp:TextBox ID="txtCalle" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-2">Colonia:</div>
                    <div class="col-4">
                        <asp:TextBox ID="txtColonia" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>  
                <div class="row">
                    <div class="col-2">CP:</div>
                    <div class="col-4">
                        <asp:TextBox ID="txtCP" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-2">Num Ext:</div>
                    <div class="col-4">
                        <asp:TextBox ID="txtNumExt" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>   
                <div class="row">
                    <div class="col-2">Num Int:</div>
                    <div class="col-4">
                        <asp:TextBox ID="txtNumInt" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-2">País:</div>
                    <div class="col-4">
                        <asp:DropDownList ID="ddlPais" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                </div>   
                <div class="row">
                    <div class="col-2">Estado:</div>
                    <div class="col-4">
                        <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                    <div class="col-2">Municipio:</div>
                    <div class="col-4">
                        <asp:DropDownList ID="ddlMunicipio" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                </div>   
            </div>  
            
            <div class="modal-footer">
                <asp:Label ID="lblAviso" runat="server" CssClass="alert alert-danger" Visible="false"></asp:Label>
                <asp:Button ID="btnClose" CssClass="btn btn-secondary" runat="server" Text="Cerrar" />
                <asp:HiddenField ID="hfIdAccion" runat="server" Value="-1" />
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" />                
            </div>
        </div>   
      
            
    </asp:Panel>
    <div class="card shadow mb-4">                       
        <div class="card-body">
            <div class="row">
                <div class="col-10">&nbsp;</div>
                <div class="col-2"><asp:Button ID="btnNuevo" runat="server" Text="Nuevo empleado" CssClass="btn btn-primary" OnClick="btnNuevo_Click" /></div>
            </div>
            <div class="row">
                <div class="col-1">Cve. Emp:</div>
                <div class="col-2">
                    <asp:TextBox ID="txtCveEmp" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-1">Nombre:</div>
                <div class="col-2">
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-1">Paterno:</div>
                <div class="col-2">
                    <asp:TextBox ID="txtPaterno" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-1">Materno:</div>
                <div class="col-2">
                    <asp:TextBox ID="txtMaterno" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-5">&nbsp;</div>
                <div class="col-2">
                    <asp:Button ID="btnBuscar" runat="server" CssClass="btn btn-primary" Text="Buscar empleado" OnClick="btnBuscar_Click" />
                </div>
                <div class="col-5">&nbsp;</div>
            </div>
            <div style="overflow-y:scroll;height:269px;">
                <asp:Repeater ID="rptDatos" runat="server" OnItemCommand="rptDatos_ItemCommand">
                    <HeaderTemplate>
                        <table class="table table-striped">
                            <thead>
                                <tr>
                                    <th scope="col">ID</th>
                                    <th scope="col">Nombre</th>
                                    <th scope="col">Paterno</th>
                                    <th scope="col">Materno</th>
                                    <th scope="col">Seleccione</th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%#Eval("IdEmpleado") %></td>
                            <td><%#Eval("Nombre") %></td>
                            <td><%#Eval("Paterno") %></td>
                            <td><%#Eval("Materno") %></td>
                            <td>
                                <asp:Button ID="btnSeleccionar" runat="server" Text="Seleccionar" CssClass="btn btn-success" 
                                    CommandName="seleccioneichon" CommandArgument='<%#Eval("IdEmpleado") %>' />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                            </tbody>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</asp:Content>
