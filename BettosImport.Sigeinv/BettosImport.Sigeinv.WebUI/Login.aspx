
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BettosImport.Sigeinv.WebUI.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login</title>
    <link href="~/css/jquery-ui.min.css" rel="stylesheet" type="text/css" />
    <link href="~/css/jquery-ui.theme.min.css" rel="stylesheet" type="text/css" />
    <link href="~/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
     <link href="~/css/Site.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        var baseURL = "<%=BettosImport.Sigeinv.Common.WebUtil.AbsoluteWebRoot%>";
    </script>

     <script src="<%=BettosImport.Sigeinv.Common.WebUtil.AbsoluteWebRoot%>js/jquery-1.11.2.min.js" type="text/javascript"></script>
    <script src="<%=BettosImport.Sigeinv.Common.WebUtil.AbsoluteWebRoot%>js/jquery-ui.js" type="text/javascript"></script>
     <script src="<%=BettosImport.Sigeinv.Common.WebUtil.AbsoluteWebRoot%>js/bootstrap.js" type="text/javascript"></script>
    <script src="<%=BettosImport.Sigeinv.Common.WebUtil.AbsoluteWebRoot%>js/jquery.blockUI.js" type="text/javascript"></script>

    <script type="text/javascript">

        function mostrarMensaje(message, alertType) {
            $('#message').append('<div id="alertdiv" class="alert ' + alertType + '"><a class="close" data-dismiss="alert">×</a><span>' + message + '</span></div>');

            setTimeout(function () { $("#alertdiv").remove(); }, 5000);
        }
 
    </script>
</head>
<body>
    <nav class="navbar navbar-default">
        <div class="container-fluid" >
            <div class="navbar-header">
                <a class="navbar-brand" href="#">
                <img src="img/bettos3.png" alt="BettosImport" width="300px" height="100px"/>
                </a>
            </div>    
        </div>
    </nav>
    <div class="container">    
        
        <div id="loginbox" style="margin-top:50px;" class="mainbox col-md-6 col-md-offset-3 col-sm-8 col-sm-offset-2">                    
            <div id="message"></div>
            <div class="panel panel-info" >
                    <div class="panel-heading">
                        <div class="panel-title">Login</div>
                    </div>     

                    <div style="padding-top:30px" class="panel-body" >

                        <div style="display:none" id="login-alert" class="alert alert-danger col-sm-12"></div>
                        
                        <form id="loginform" class="form-horizontal" role="form" runat="server"> 
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <script type="text/javascript" language="javascript">
                            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
                            function EndRequestHandler(sender, args) {
                                if (args.get_error() != undefined) {
                                    args.set_errorHandled(true);
                                }
                            }
                        </script>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional"> 
                            <ContentTemplate>                              
                                <div style="margin-bottom: 25px" class="input-group">
                                    <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                                            <asp:TextBox ID="txtUsuario" CssClass="form-control" name="username" placeholder="usuario" runat="server"></asp:TextBox>
                                </div>
                                
                                <div style="margin-bottom: 25px" class="input-group">
                                            <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                                            <asp:TextBox ID="txtPassword" TextMode="Password" CssClass="form-control" name="password" placeholder="password" runat="server"></asp:TextBox>
                                </div>   
                                <asp:Button ID="btnIngresar" CssClass="btn btn-lg btn-danger btn-block" runat="server" Text="Iniciar Sesión" OnClick="btnIngresar_Click"/>
                                			                    
                        </ContentTemplate>
 
                    </asp:UpdatePanel>
                    </form>     
                    <script src="<%=BettosImport.Sigeinv.Common.WebUtil.AbsoluteWebRoot%>js/jsUpdateProgress.js" type="text/javascript"></script>
                  </div>                  
               </div>                     
           </div>  
        </div>
</body>
</html>
