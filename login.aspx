<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>阿舍高爾夫</title>
     <!-- Bootstrap -->
        <link rel="stylesheet" media="screen" href="css/bootstrap.min.css">
        <link rel="stylesheet" media="screen" href="css/bootstrap-theme.min.css">

        <!-- Bootstrap Admin Theme -->
        <link rel="stylesheet" type="text/css" href="./css/main.css" />
        <link rel="stylesheet" media="screen" href="css/bootstrap-admin-theme.css">

        <!-- Custom styles -->
        <style type="text/css">
            .alert{
                margin: 0 auto 20px;
            }
        </style>

        <!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->
        <!--[if lt IE 9]>
           <script type="text/javascript" src="js/html5shiv.js"></script>
           <script type="text/javascript" src="js/respond.min.js"></script>
        <![endif]-->
     <!-- jQuery -->
    <script src="js/jquery-1.10.2.js"></script>

    <!-- Bootstrap Core JavaScript -->
    <script src="js/bootstrap.min.js"></script>
    <script src="js/base.js"></script>

</head>
<body id="login">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager" runat="server">
            <Services>
                <asp:ServiceReference Path="AspAjax.asmx" />
            </Services>
            <Scripts>
                <asp:ScriptReference Path="~/js/login.js" />
            </Scripts>
        </asp:ScriptManager>
    </form>
    <div class='' id="headerTop" runat="server"></div>
    <div class="navbar-inverse navbar " id="headerBottom" role='navigation' runat="server"></div>
    <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div method="post" action="about.html" class="bootstrap-admin-login-form">
                        <h1>阿舍高爾夫登入</h1>
                        <div class="form-group">
                            <input class="form-control" type="text" id="userEmail" name="email" placeholder="E-mail">
                        </div>
                        <div class="form-group">
                            <input class="form-control" type="password" id="userPassword" name="password" placeholder="Password">
                        </div>
                        <div class="form-group">
                            <label class="col-sm-12 col-lg-12 col-md-12">
                                <input type="checkbox" name="remember_me">
                                記得我
                                <a style="float:right;" href="./forget.aspx">忘記密碼</a>
                            </label>
                        </div>
                        
                        <button class="btn btn-lg btn-primary" onclick="goLogin()">登入</button>
                        <div id="signupResult" class="form-group"></div>
                    </div>
                </div>
            </div>
        </div>
</body>
</html>
