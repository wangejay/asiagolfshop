<%@ Page Language="C#" AutoEventWireup="true" CodeFile="detail.aspx.cs" Inherits="detail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
    <link href="css/detail.css" rel="stylesheet">
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
   <script src="js/detail.js"></script>
   

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
            <div class="col-md-3">
                <p class="lead">球具類別</p>
                <div class="list-group" runat="server" id="left_menu">
                </div>
            </div>
            <div class="col-md-9">
                <!-- Portfolio Item Heading -->
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header lead" runat="server" id="MainTitle">Portfolio Item
                    <small>Item Subheading</small>
                </h1>
            </div>
        </div>
        <!-- /.row -->

        <!-- Portfolio Item Row -->
        <div class="row">

            <div class="col-md-8">
                <div id="mainImg" runat="server">
                    <!-- img id="productImgBig" src="images/placeholder.png" -->
                </div>
                
                <div class="productImgs" id="ImgIndex" runat="server">
                    <ul class="list-unstyle list-inline">
                        <li><img src="images/5.png" /></li>
                        <li><img src="images/product1.gif" /></li>
                        <li><img src="images/product2.gif" /></li>
                        <li><img src="images/product3.gif" /></li>
                        <li><img src="images/golfimg8.png" /></li>
                    </ul>
                </div>                
            </div>

            <div id="productDisc" class="col-md-4">
                <h3>產品描述</h3>
                <p id="pDescription" runat="server">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam viverra euismod odio, gravida pellentesque urna varius vitae. Sed dui lorem, adipiscing in adipiscing et, interdum nec metus. Mauris ultricies, justo eu convallis placerat, felis enim.</p>
                <h3>產品規格</h3>
                <ul>
                    <li runat="server" id="pHand">Lorem Ipsum</li>
                    <li runat="server" id="pAngle">Dolor Sit Amet</li>
                    <li runat="server" id="pGolfClub">Consectetur</li>
                    <li runat="server" id="pGolfHard">Adipiscing Elit</li>
                </ul>
                <h3>付款方式</h3>
                <p><img src="./images/ico_credi_201008.png"></p>
                <h3>交貨方式</h3>
                <p>
                    貨運 / 宅配 (購物滿800元免運費) 、7-11取貨付款 (購物滿500元免運費)
                </p>
                <h3>價格</h3>
                <h4 id="pPrice" runat="server"></h4>
                <button type="button" id="btn-add-cart" onclick="goCart()" class="btn btn-block btn-primary"> 加入購物車 </button>
            </div>

        </div>
        <!-- /.row -->
        
        <div class="row detail" >
            <h3>詳細資訊</h3>
            <div class="col-md-12" id="fullintroduction" runat="server">
            </div>
            <div class="col-md-12">
                
                <h3>
                    退貨需知
                </h3>
                <p>
                    線上購物的消費者，都可以依照消費者保護法的規定，享有商品貨到日起七天猶豫期的權益。
                    但猶豫期並非試用期，所以，您所退回的商品必須是全新的狀態、而且完整包裝；
                    請注意保持商品本體、配件、贈品、保證書、原廠包裝及所有附隨文件或資料的完整性，切勿缺漏任何配件或損毀原廠外盒。
                </p>
                <p>
                    若您要辦理退貨，請先透過線上購物客服系統填寫退訂單，我們將於接獲申請之次日起3個工作天內檢視您的退貨要求，
                    檢視完畢後將以E-mail回覆通知您，並將委託本公司指定之宅配公司，在5個工作天內透過電話與您連絡前往取回退貨商品。
                </p>
                <p>
                    本公司收到您所退回的商品及相關單據後，若經確認無誤，將於7個工作天內為您辦理退款，退款日當天會再發送E-mail通知函給您。
                </p>
                
            </div>
        </div>
        <!--hr-->
            </div>
        </div>
        

    </div>
    
<hr>

    <footer class="container">
        <div class="row">
            <div class="col-lg-12 text-center" runat="server" id="footerDiv">
              
            </div>
        </div>
    </footer><!-- /.container -->
</body>


</html>
