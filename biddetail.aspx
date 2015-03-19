<%@ Page Language="C#" AutoEventWireup="true" CodeFile="biddetail.aspx.cs" Inherits="biddetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">

    <title>阿舍高爾夫-產品競標</title>

    <!-- Bootstrap Core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet" media="screen">

    <!-- Custom CSS -->
    <link rel="stylesheet" type="text/css" href="./css/main.css" />
    <link href="css/portfolio-item.css" rel="stylesheet">

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

</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
    <div class='' id="headerTop" runat="server"></div>
    <nav class='navbar navbar-inverse' id="headerBottom" role='navigation' runat="server"></nav>
    

    <!-- Page Content -->
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
                <!-- Portfolio Item Heading -->
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Portfolio Item
                    <small>Item Subheading</small>
                </h1>
            </div>
        </div>
        <!-- /.row -->

        <!-- Portfolio Item Row -->
        <div class="row">

            <div class="col-md-8">
                <img class="img-responsive" src="./images/golfimg1.png" alt="">
            </div>

            <div class="col-md-4">
                <h3>高爾夫球具組</h3>
                <p>使用兩年，狀況良好，因有新球具故忍痛割愛。希望能讓有需求的人士接手。</p>
                <h3>目前出價</h3>
                <p>2500元</p>
                <h3>最低出價</h3>
                <p>2000元</p>
                <h3>直購價</h3>
                <p>20000元</p>
            </div>

        </div>
        <!-- /.row -->

        <!-- Related Projects Row -->
        <div class="row">

            <div class="col-lg-12">
                <h3 class="page-header">商品圖片</h3>
            </div>

            <div class="col-sm-3 col-xs-6">
                <a href="#">
                    <img class="img-responsive portfolio-item" src="./images/golfimg2.png" alt="">
                </a>
            </div>

            <div class="col-sm-3 col-xs-6">
                <a href="#">
                    <img class="img-responsive portfolio-item" src="./images/golfimg3.png" alt="">
                </a>
            </div>

            <div class="col-sm-3 col-xs-6">
                <a href="#">
                    <img class="img-responsive portfolio-item" src="./images/golfimg4.png" alt="">
                </a>
            </div>

            <div class="col-sm-3 col-xs-6">
                <a href="#">
                    <img class="img-responsive portfolio-item" src="./images/golfimg5.png" alt="">
                </a>
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
        </div>
        

    </div>
</body>
</html>
