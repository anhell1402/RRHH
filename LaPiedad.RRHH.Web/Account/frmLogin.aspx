<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmLogin.aspx.vb" Inherits="LaPiedad.RRHH.Web.frmLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta name="description" content="" />
    <meta name="author" content="" />

    <title>SB Admin 2 - Dashboard</title>

    <!-- Custom fonts for this template-->
    <link href= "<%=ResolveUrl("~/vendor/fontawesome-free/css/all.min.css")%>" rel="stylesheet" type="text/css" />
    <link 
        href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i"
        rel="stylesheet" />

    <!-- Custom styles for this template-->
    <link href="<%=ResolveUrl("~/css/sb-admin-2.min.css")%>" rel="stylesheet" />
  
</head>
   <body class="bg-gradient-primary">
       
    <div class="container">

        <!-- Outer Row -->
        <div class="row justify-content-center">

            <div class="col-xl-10 col-lg-12 col-md-9">

                <div class="card o-hidden border-0 shadow-lg my-5">
                    <div class="card-body p-0">
                        <!-- Nested Row within Card Body -->
                        <div class="row">
                           <div class="col-lg-6 d-none d-lg-block bg-login-image"></div>
                            <div class="col-lg-6">
                                <div class="p-5">
                                    <div class="text-center">
                                        <h1 class="h4 text-gray-900 mb-4">Inicio de Sesión</h1>
                                    </div>
                                    <form class="user" runat="server">
                                        <div class="form-group">
                                            <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control form-control-user"
                                                placeholder="Usuario..."></asp:TextBox>
                                            <%--<input type="email" class="form-control form-control-user"
                                                id="exampleInputEmail" aria-describedby="emailHelp"
                                                placeholder="Correo Electrónico..." />--%>
                                        </div>
                                        <div class="form-group">
                                            <%--<input type="password" class="form-control form-control-user"
                                                id="exampleInputPassword" placeholder="Contraseña..." />--%>
                                            <asp:TextBox ID="txtPasswd" runat="server" CssClass="form-control form-control-user"
                                                placeholder="Contraseña..." TextMode="Password"></asp:TextBox>
                                        </div>
                                        <%--<div class="form-group">
                                            <div class="custom-control custom-checkbox small">
                                                <input type="checkbox" class="custom-control-input" id="customCheck" />
                                                <label class="custom-control-label" for="customCheck">Recordarme</label>
                                            </div>
                                        </div>--%>
                                        <%--<a href="index.html" class="btn btn-primary btn-user btn-block">
                                            Iniciar Sesión
                                        </a>--%>
                                        <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-primary btn-user btn-block" Text="Iniciar Sesión"
                                            OnClick="btnLogin_Click" />
                                        <hr />
                                        <asp:Label ID="lblAviso" runat="server" CssClass="alert alert-danger" Visible="false"></asp:Label>
                                        <%--<a href="index.html" class="btn btn-google btn-user btn-block">
                                            <i class="fab fa-google fa-fw"></i> Iniciar con Google
                                        </a>
                                        <a href="index.html" class="btn btn-facebook btn-user btn-block">
                                            <i class="fab fa-facebook-f fa-fw"></i> Iniciar con Facebook
                                        </a>--%>
                                    </form>
                                    <hr />
                                    <%--<div class="text-center">
                                        <a class="small" href="forgot-password.html">¿Olvidaste tu Contraseña?</a>
                                    </div>
                                    <div class="text-center">
                                        <a class="small" href="register.html">Crear Cuenta!</a>
                                    </div>--%>
                                </div>
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
</html>
