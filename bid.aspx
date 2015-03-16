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
                <div class="list-group">
                    <a href="./product.aspx?id=1" class="list-group-item">Drivers 一號木桿</a>
                    <a href="./product.aspx?id=2" class="list-group-item">FW 球道木桿 </a>
                    <a href="./product.aspx?id=3" class="list-group-item">Iron sets 鐵桿組</a>
                    <a href="./product.aspx?id=4" class="list-group-item">Wedges 挖起桿</a>
                    <a href="./product.aspx?id=5" class="list-group-item">Putters 推桿</a>
                    <a href="./product.aspx?id=5" class="list-group-item">Hybrid 混合桿</a>
                    <a href="./product.aspx?id=6" class="list-group-item">Shafts&Grips 桿身、握把</a>
                    <a href="./product.aspx?id=7" class="list-group-item">Accessories 配件</a>
                    <a href="./product.aspx?id=8" class="list-group-item">Apparel 服飾</a>
                    
                </div>
            </div>
            <div class="col-md-9">
                 <!-- Page Header -->
                    <div class="row">
                        <div class="col-lg-12">
                            <h1 class="page-header">Page Heading
                                <small>Secondary Text</small>
                            </h1>
                        </div>
                    </div>
                    <!-- /.row -->
                    <!-- Projects Row -->
                    <div class="row">
                        <div class="col-md-4 portfolio-item">
                            <a href="./biddetail.aspx">
                                <img class="img-responsive" src="./images/golfimg1.png" alt="">
                            </a>
                            <h3>
                                <a href="#">高爾夫球具組</a>
                            </h3>
                            <p>剩餘:02:41:30</p>
                            <p>目前出價:25元</p>
                            <p>直購價:30,000元</p>
                            <p><button onclick="goBidDetail(1)">下標去</button></p>
                        </div>
                        <div class="col-md-4 portfolio-item">
                            <a href="./biddetail.aspx">
                                <img class="img-responsive" src="./images/golfimg2.png" alt="">
                            </a>
                            <h3>
                                <a href="#">高爾夫球具組</a>
                            </h3>
                            <p>剩餘:02:41:30</p>
                            <p>目前出價:25元</p>
                            <p>直購價:30,000元</p>
                            <p><button onclick="goBidDetail(1)">下標去</button></p>
                        </div>
                        <div class="col-md-4 portfolio-item">
                            <a href="./biddetail.aspx">
                                <img class="img-responsive" src="./images/golfimg3.png" alt="">
                            </a>
                            <h3>
                                <a href="#">高爾夫球具組</a>
                            </h3>
                            <p>剩餘:02:41:30</p>
                            <p>目前出價:25元</p>
                            <p>直購價:30,000元</p>
                            <p><button onclick="goBidDetail(1)">下標去</button></p>
                        </div>
                    </div>
                    <!-- /.row -->

                    <!-- Projects Row -->
                    <div class="row">
                        <div class="col-md-4 portfolio-item">
                            <a href="./biddetail.aspx">
                                <img class="img-responsive" src="./images/golfimg4.png" alt="">
                            </a>
                            <h3>
                                <a href="#">高爾夫球具組</a>
                            </h3>
                            <p>剩餘:02:41:30</p>
                            <p>目前出價:25元</p>
                            <p>直購價:30,000元</p>
                            <p><button onclick="goBidDetail(1)">下標去</button></p>
                        </div>
                        <div class="col-md-4 portfolio-item">
                            <a href="./biddetail.aspx">
                                <img class="img-responsive" src="./images/golfimg5.png" alt="">
                            </a>
                            <h3>
                                <a href="#">高爾夫球具組</a>
                            </h3>
                            <p>剩餘:02:41:30</p>
                            <p>目前出價:25元</p>
                            <p>直購價:30,000元</p>
                            <p><button onclick="goBidDetail(1)">下標去</button></p>
                        </div>
                        <div class="col-md-4 portfolio-item">
                            <a href="./biddetail.aspx">
                                <img class="img-responsive" src="./images/golfimg6.png" alt="">
                            </a>
                            <h3>
                                <a href="#">高爾夫球具組</a>
                            </h3>
                            <p>剩餘:02:41:30</p>
                            <p>目前出價:25元</p>
                            <p>直購價:30,000元</p>
                            <p><button onclick="goBidDetail(1)">下標去</button></p>
                        </div>
                    </div>

                    <!-- Projects Row -->
                    <div class="row">
                        <div class="col-md-4 portfolio-item">
                            <a href="./biddetail.aspx">
                                <img class="img-responsive" src="./images/golfimg7.png" alt="">
                            </a>
                            <h3>
                                <a href="#">高爾夫球具組</a>
                            </h3>
                            <p>剩餘:02:41:30</p>
                            <p>目前出價:25元</p>
                            <p>直購價:30,000元</p>
                            <p><button onclick="goBidDetail(1)">下標去</button></p>
                        </div>
                        <div class="col-md-4 portfolio-item">
                            <a href="./biddetail.aspx">
                                <img class="img-responsive" src="./images/golfimg8.png" alt="">
                            </a>
                            <h3>
                                <a href="#">高爾夫球具組</a>
                            </h3>
                            <p>剩餘:02:41:30</p>
                            <p>目前出價:25元</p>
                            <p>直購價:30,000元</p>
                            <p><button onclick="goBidDetail(1)">下標去</button></p>
                        </div>
                        <div class="col-md-4 portfolio-item">
                            <a href="./biddetail.aspx">
                                <img class="img-responsive" src="./images/golfimg1.png" alt="">
                            </a>
                            <h3>
                                <a href="#">高爾夫球具組</a>
                            </h3>
                            <p>剩餘:02:41:30</p>
                            <p>目前出價:25元</p>
                            <p>直購價:30,000元</p>
                            <p><button onclick="goBidDetail(1)">下標去</button></p>
                        </div>
                    </div>
                    <!-- /.row -->

                    <hr>

            </div>
        </div>
    </div>
</body>
</html>
