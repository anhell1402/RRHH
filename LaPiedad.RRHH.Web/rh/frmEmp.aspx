<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="frmEmp.aspx.vb" Inherits="LaPiedad.RRHH.Web.frmEmp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Scripts/bootstrap.min.js"></script>
    <script src="../Scripts/jquery-3.6.0.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card shadow mb-4">                       
        <div class="card-body">
            <div class="row">
                <div class="col-3 text-center">
                    <asp:Image ID="imgFoto" ImageUrl="~/img/1611162270_013847_1611162672_noticia_normal.jpg" runat="server" Width="200" Height="200" CssClass="rounded-circle" />   
                </div>
                <div class="col-9">
                    <ul class="nav nav-tabs" id="myTab" role="tablist">
                        <li class="nav-item" role="presentation">
                            <button class="nav-link active" id="home-tab" data-bs-toggle="tab" data-bs-target="#home" type="button" role="tab" aria-controls="home" aria-selected="true">General</button>
                        </li>
                        <li class="nav-item" role="presentation">
                            <button class="nav-link" id="profile-tab" data-bs-toggle="tab" data-bs-target="#profile" type="button" role="tab" aria-controls="profile" aria-selected="false">Domicilio</button>
                        </li>
                        <li class="nav-item" role="presentation">
                            <button class="nav-link" id="mas-tab" data-bs-toggle="tab" data-bs-target="#mas" type="button" role="tab" aria-controls="mas" aria-selected="false">Mas</button>
                        </li>
                        <li class="nav-item" role="presentation">
                            <button class="nav-link" id="academico-tab" data-bs-toggle="tab" data-bs-target="#academico" type="button" role="tab" aria-controls="academico" aria-selected="false">Académico</button>
                        </li>
                        <li class="nav-item" role="presentation">
                            <button class="nav-link" id="laboral-tab" data-bs-toggle="tab" data-bs-target="#laboral" type="button" role="tab" aria-controls="laboral" aria-selected="false">Laboral</button>
                        </li>
                        <li class="nav-item" role="presentation">
                            <button class="nav-link" id="emparentar-tab" data-bs-toggle="tab" data-bs-target="#emparentar" type="button" role="tab" aria-controls="emparentar" aria-selected="false">Emparentar</button>
                        </li>
                        <li class="nav-item" role="presentation">
                            <button class="nav-link" id="carjudic-tab" data-bs-toggle="tab" data-bs-target="#carjudic" type="button" role="tab" aria-controls="carjudic" aria-selected="false">Carrera Juidicial</button>
                        </li>
                    </ul>
                    <div class="tab-content" id="myTabContent">
                        <div class="tab-pane fade show active" id="home" role="tabpanel" aria-labelledby="home-tab"></div>
                        <div class="tab-pane fade" id="profile" role="tabpanel" aria-labelledby="profile-tab"></div>
                        <div class="tab-pane fade" id="mas" role="tabpanel" aria-labelledby="mas-tab"></div>
                        <div class="tab-pane fade" id="academico" role="tabpanel" aria-labelledby="academico-tab"></div>
                        <div class="tab-pane fade" id="laboral" role="tabpanel" aria-labelledby="laboral-tab"></div>
                        <div class="tab-pane fade" id="emparentar" role="tabpanel" aria-labelledby="emparentar-tab"></div>
                        <div class="tab-pane fade" id="carjudic"  role="tabpanel" aria-labelledby="carjudic-tab"></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
