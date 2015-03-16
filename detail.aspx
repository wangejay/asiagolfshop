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
   
   <style>
    #Title {
        font-size: 24px;
        margin-top: 0;
        padding-bottom: 23px;
    }
    
    #mainImg
    { 
    	background-position: center top;
        background-repeat: no-repeat;
        background-size: 80% auto;
        text-align: center;
        /* 商品大圖區塊最小高度 */
        /* min-height: 450px; */
    }
    
    #mainImg #productImgBig
    { width: 80%; }
    
    #productDisc {
    background-color: #eee;
    padding-bottom: 36px;
}
    
    #productDisc H3 {
        font-size: 21px;
    }
    
    #productDisc P {
        line-height: 2em;
        padding-left: 1.2em;
    }
    
    #productDisc UL
    {list-style: outside none none;
     padding-left: 1.2em;}
    
    #productDisc UL LI {
    border-bottom: 1px solid #ccc;
    margin-bottom: 0.4em;
    }
    
    

#productDisc UL LI::before {
    color: #999;
    content: "-";
    display: inline-block;
    margin-left: -10px;
    margin-right: 4px;
}

.productImgs 
{
	min-height: 120px;
	border-top: 1px solid #999;
    margin-top: 24px;
	}

.productImgs UL {
    margin: 8px auto;
    text-align: center;
    width: 80%;
}

.productImgs UL LI 
{
	vertical-align: middle;
    border: 1px solid #999;
    padding: 3px;
    width: 19.20%;
    margin-left: 1%;
    cursor: pointer;
    transition: width .25s ease-out;
    float:left;
}

.productImgs UL LI:first-child 
{
    margin-left: 0;
}

.productImgs UL:hover LI 
{
    width: 18%;
}

.productImgs UL:hover LI:hover 
{
    border: 1px solid #444;
    width: 24%;
}

.productImgs UL LI IMG
{
	width: 100%;
	vertical-align: middle;
	}

.detail H3
{
	font-size: 21px;
	}
	
#pPrice {
    color: red;
    font-weight: 600;
    margin-bottom: 32px;
    margin-top: -32px;
    text-align: right;
}
   </style>

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
                <div class="list-group" runat="server" id="left_menu">
                </div>
            </div>
            <div class="col-md-9">
                <!-- Portfolio Item Heading -->
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header" runat="server" id="Title">Portfolio Item
                    <small>Item Subheading</small>
                </h1>
            </div>
        </div>
        <!-- /.row -->

        <!-- Portfolio Item Row -->
        <div class="row">

            <div class="col-md-8">
                <div id="mainImg" runat="server">
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
                <input type="submit" value="加入購物車" id="btn-add-cart" class="button-secondary button-add-to-cart">
            </div>

        </div>
        <!-- /.row -->
        
        <div class="row detail" >
        <h3>詳細資訊</h3>
        <div class="col-md-12" id="fullintroduction" runat="server">
        </div>
        </div>
        <!--hr-->

        <!-- Footer -->
        <footer>
            <div class="row">
                <div class="col-lg-12">
                    <p>Copyright &copy; Your Website 2014</p>
                </div>
            </div>
            <!-- /.row -->
        </footer>
            </div>
        </div>
        

    </div>
</body>

<script>
($(function() {
    $('.productImgs>UL>LI')
        .mouseover(function() {
            $('#mainImg').css('background-image', 'url(' + $(this).find('IMG').attr('src') + ')');
            $('#productImgBig').css('visibility', 'hidden');
        })
        .click(function() {
            $('#productImgBig').attr('src', $(this).find('IMG').attr('src'));
        });
    $('.productImgs>UL')
        .mouseout(function() {
            $('#productImgBig').css('visibility', 'visible');
            $('#mainImg').css('background-image', 'none');
        });
}));
</script>
</html>
