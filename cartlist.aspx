<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cartlist.aspx.cs" Inherits="cartlist" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">

    <title>阿舍高爾夫</title>

    <!-- Bootstrap Core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet" media="screen">

    <!-- Custom CSS -->
    <link rel="stylesheet" type="text/css" href="./css/main.css" />
    <link href="css/portfolio-item.css" rel="stylesheet">
    <link href="css/cartlist.css" rel="stylesheet">
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
     <!-- jQuery -->
    <script src="js/jquery-1.10.2.js"></script>

    <!-- Bootstrap Core JavaScript -->
   <script src="js/bootstrap.min.js"></script>
   <script src="js/base.js"></script>
   <script src="js/cartlist.js"></script>


</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager" runat="server">
            <Services>
                <asp:ServiceReference Path="AspAjax.asmx" />
            </Services>
        </asp:ScriptManager>
    </form>
    <div class='' id="headerTop" runat="server"></div>
    <nav class='navbar navbar-inverse' id="headerBottom" role='navigation' runat="server"></nav>
    

    <!-- Page Content -->
    <div class="container">
        
        <div class="row">
            <div class="col-md-10 col-md-offset-1">
                <div class="row">
                    <div class="col-lg-12">
                        <ul class="orderStep list-unstyled list-inline">
                            <li>
                                放入購物車
                            </li>
                            <li class="currentStep">
                                確認購物明細
                            </li>
                            <li>
                                輸入購買資料
                            </li>
                            <li>
                                完成訂購
                            </li>
                        </ul>
                    </div>
                </div>
                
                <!-- Portfolio Item Heading -->
                <div class="row">
                    <div class="col-md-12">
                        <h1 class="page-header" runat="server" id="Title">您的購物清單</h1>
                    </div>
                </div>
                <!-- /.row -->

                <!-- Portfolio Item Row -->
                <div class="row">
                    <div class="col-md-12" id="CartTable" runat="server">
                                 
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12 text-right">
                        <div id="totalPrice" runat="server"></div>
                    </div>
                    <div class="col-md-12 text-right">
                        <button class="btn btn-info btn-lg" onclick="gobackProductionList()"><span class='glyphicon glyphicon-plus' aria-hidden='true'></span> 繼續選購</button>
                        <button class="btn btn-primary btn-lg" onclick="goOrder()">開始結帳 <span class='glyphicon glyphicon-circle-arrow-right' aria-hidden='true'></span></button>
                    </div>
                </div>
                <!-- /.row -->
                
                
                <footer>
                    <div class="row">
                        <div class="col-md-12" runat="server" id="footerDiv">
                            
                        </div>
                    </div>
                    <!-- /.row -->
                </footer>
                <!-- Footer -->
            </div>
        </div>
        

    </div>
</body>
</html>
