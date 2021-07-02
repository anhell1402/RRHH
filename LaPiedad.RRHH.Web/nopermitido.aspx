<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="nopermitido.aspx.vb" Inherits="LaPiedad.RRHH.Web.nopermitido" %>
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
    <div class="mx-auto" style="height: 50px;"></div>
       <div class="text-center">
       <div class="error mx-auto" data-text="403">403</div>
           <p class="lead text-gray-8000  mb-10" >
           <H2> ACCESO DENEGADO! </H2>
           </P>
           <p class="text-gray-500 mb-0">No tienes los suficientes permisos para acceder a esta página...</p>
       </div>      
</asp:Content>
