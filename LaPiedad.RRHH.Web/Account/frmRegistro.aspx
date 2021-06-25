<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmRegistro.aspx.vb" Inherits="LaPiedad.RRHH.Web.frmRegistro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">

    <title>SB Admin 2 - Register</title>

    <!-- Custom fonts for this template-->
    <link href= "<%=ResolveUrl("~/vendor/fontawesome-free/css/all.min.css")%>"rel="stylesheet" type="text/css">
    <link
        href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i"
        rel="stylesheet">

    <!-- Custom styles for this template-->
    <link href= "<%=ResolveUrl("~/css/sb-admin-2.min.css")%>" rel="stylesheet">
</head>
<body runat="server">
   <body class="bg-gradient-primary">

    <div class="container">

        <div class="card o-hidden border-0 shadow-lg my-5">
            <div class="card-body p-0">
                <!-- Nested Row within Card Body -->
                <div class="row">
                    <div class="col-lg-5 d-none d-lg-block bg-register-image"></div>
                    <div class="col-lg-7">
                        <div class="p-5">
                            <div class="text-center">
                                <h1 class="h4 text-gray-900 mb-4">REGISTRATE!</h1>
                            </div>
                            <form class="user" runat="server">
                                <div class="form-group">
                                        <input type="text" class="form-control form-control-user" id="exampleFirstName"
                                            placeholder="Nombre(s)">
                                </div>

                                  <div class="form-group row">
                                    <div class="col-sm-6 mb-3 mb-sm-0">
                                        <input type="text" class="form-control form-control-user" id="exampleLastName1"
                                            placeholder="Apellido Paterno">
                                    </div>
                                    <div class="col-sm-6">
                                        <input type="text" class="form-control form-control-user" id="exampleLastName2"
                                            placeholder="Apellido Materno">
                                    </div>
                                </div>


                                <div class="form-group">
                                    <input type="email" class="form-control form-control-user" id="exampleUserName"
                                        placeholder="Usuario">
                                </div>
                                <div class="form-group">
                                   
                                        <input type="password" class="form-control form-control-user"
                                            id="exampleInputPassword" placeholder="Contraseña">
                                </div>

                                 

                                <div class="form-group" runat="server" align ="center">
                                    <div class="col-7">
                                        <asp:DropDownList  ID="ddlRol" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="0">-Seleccione-</asp:ListItem>
                                        <asp:ListItem Value="1">Gerente</asp:ListItem>
                                        <asp:ListItem Value="2">Asistente</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                       
                               
                           
                                   
                              
                               





                                <a href="login.html" class="btn btn-primary btn-user btn-block">
                                    CREAR CUENTA
                                </a>
                                <hr>
                                <a href="index.html" class="btn btn-google btn-user btn-block">
                                    <i class="fab fa-google fa-fw"></i> Registrate con Google
                                </a>
                                <a href="index.html" class="btn btn-facebook btn-user btn-block">
                                    <i class="fab fa-facebook-f fa-fw"></i> Registrate con Facebook
                                </a>
                            </form>
                            <hr>
                            <div class="text-center">
                                <a class="small" href="forgot-password.html">¿Olvidaste tu Contraseña?</a>
                            </div>
                            <div class="text-center">
                                <a class="small" href="login.html">¿Ya tienes una cuenta? Inicia Sesión!</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>

    <!-- Bootstrap core JavaScript-->
    <script src="<%=ResolveUrl("~/vendor/jquery/jquery.min.js")%>"></script>
    <script src="<%=ResolveUrl("~/vendor/bootstrap/js/bootstrap.bundle.min.js")%>"></script>

    <!-- Core plugin JavaScript-->
    <script src="<%=ResolveUrl("~/vendor/jquery-easing/jquery.easing.min.js")%>"></script>

    <!-- Custom scripts for all pages-->
    <script src="<%=ResolveUrl("~/js/sb-admin-2.min.js")%>"></script>
  </body>
</body>
</html>
