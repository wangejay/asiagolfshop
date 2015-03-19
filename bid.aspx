<%@ Page Language="C#" AutoEventWireup="true" CodeFile="bid.aspx.cs" Inherits="bid" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    <title>阿舍高爾夫-競標</title>
     <!-- Bootstrap Core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet" media="screen">
    
        

    <!-- Custom CSS -->
    <link rel="stylesheet" type="text/css" href="./css/main.css" />
    <link href="css/shop-homepage.css" rel="stylesheet">
    
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
    <script src="js/bid.js"></script>
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

    <div class="container">
        <div class="row">
            <div class="col-md-3">
                <p class="lead">球具類別</p>
                <div class="list-group" runat="server" id="left_menu">
                </div>
            </div>
            <div class="col-md-9">
                 <!-- Page Header -->
                    <div class="row">
                        <div class="col-lg-12">
                            <h1 class="page-header" runat="server" id="MainTitle">競標區
                                
                            </h1>
                        </div>
                    </div>
                    <!-- /.row -->
                    <!-- Projects Row -->
                    <div id="ProductionDiv" runat="server">
                    
                    </div>

            </div>
        </div>
        
        <!-- Pagination -->
        <div class="row text-center">
            <div class="col-lg-12">
            <!--
                <ul class="pagination">
                    <li>
                        <a href="#">&laquo;</a>
                    </li>
                    <li class="active">
                        <a href="#">1</a>
                    </li>
                    <li>
                        <a href="#">2</a>
                    </li>
                    <li>
                        <a href="#">3</a>
                    </li>
                    <li>
                        <a href="#">4</a>
                    </li>
                    <li>
                        <a href="#">5</a>
                    </li>
                    <li>
                        <a href="#">&raquo;</a>
                    </li>
                </ul>
                -->
            </div>
        </div>
        
        <!-- /.row -->

        <hr>

        <!-- Footer -->
        <footer>
            <div class="row">
                <div class="col-lg-12" runat="server" id="footerDiv">
                    
                </div>
            </div>
            <!-- /.row -->
        </footer>
        
        
    </div>
    <!-- /.container -->
    
</body>
</html>
