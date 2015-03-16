<%@ Page Language="C#" AutoEventWireup="true" CodeFile="signup.aspx.cs" Inherits="signup" %>

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
            #validateJpg
            {
            	cursor:pointer;
            }
        </style>

        <!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->
        <!--[if lt IE 9]>
           <script type="text/javascript" src="js/html5shiv.js"></script>
           <script type="text/javascript" src="js/respond.min.js"></script>
        <![endif]-->
     <!-- jQuery -->
    <script src="js/jquery-1.10.2.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/base.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager" runat="server">
            <Services>
                <asp:ServiceReference Path="AspAjax.asmx" />
            </Services>
            <Scripts>
                <asp:ScriptReference Path="~/js/signup.js" />
            </Scripts>
        </asp:ScriptManager>
    </form>
    <div class='' id="headerTop" runat="server"></div>
    <div class="navbar-inverse navbar " id="headerBottom" role='navigation' runat="server"></div>
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default bootstrap-admin-no-table-panel">
                    <div class="panel-heading">
                        <legend class="text-muted bootstrap-admin-box-title">會員註冊</legend>
                    </div>
                    <div class="bootstrap-admin-no-table-panel-content bootstrap-admin-panel-content collapse in">
                        <div class="form-horizontal">
                            <fieldset>
                                <div class="form-group">
                                    <label class="col-lg-2 control-label">帳號</label>
                                    <div class="col-lg-10">
                                        <input id="userEmail" class="form-control" type="text" name="email" placeholder="請輸入E-mail">
                                    </div> 
                                </div>
                                <div class="form-group">
                                    <label class="col-lg-2 control-label">密碼</label>
                                    <div class="col-lg-10">
                                        <input id="userPassword" class="form-control" type="password" name="password" placeholder="請輸入密碼，六位數中英組合">
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-lg-2 control-label">密碼確認</label>
                                    <div class="col-lg-10">
                                        <input id="userPasswordConfirm" class="form-control" type="password" name="password" placeholder="請再次輸入密碼">
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-lg-2 control-label">輸入驗證碼</label>
                                    <div class="col-lg-10">
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <input class="form-control" id="validImg" type="text" value="" size="10" />
                                            </div>
                                            <div class="col-lg-6" >
                                                <img id="validateJpg" alt="" src="./SentValidate.ashx" title="點擊圖片換另一張" alt="點擊圖片換另一張" /> 
                                                （點擊圖片換另一張，分大小寫。）
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div id="signupResult" class="form-group">
                                </div>
                                <div class="col-lg-12" style="text-align:center;">
                                    <button id="btn_signup" class="btn btn-lg btn-primary">註冊</button>
                                </div>
                            </fieldset>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
