<%@ Page Language="C#" AutoEventWireup="true" CodeFile="payment.aspx.cs" Inherits="payment" %>

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
    <link href="css/payment.css" rel="stylesheet">
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
   <script src="js/payment.js"></script>


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
               
            </div>
            <div class="col-md-9">
                <!-- Portfolio Item Heading -->
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header" runat="server" id="Title">付款資訊</h1>
            </div>
        </div>
        <!-- /.row -->

        <!-- Portfolio Item Row -->
        <div class="row">
            付款方式
            <div class="col-md-12" id="PaymentWay" runat="server">
                         
            </div>
        </div>
        <div class="row">
            訂購人資訊
            <div class="col-md-12" id="OrderInfo" runat="server">
                  <div class="row">
                    訂購人姓名:<input type="text"  class="" id="mname" value="" name="member_name">
                  </div>  
                  <div class="row">
                    聯絡電話:<input type="text"  class="" id="Text1" value="" name="member_name">
                  </div>    
                  <div class="row">
                    email:<input type="text"  class="" id="Text3" value="" name="member_name">
                  </div>   
            </div>
        </div>
        <div class="row">
            收件人資訊
            <div class="col-md-12" id="ReceiverInfo" runat="server">
                       <div class="row">
                    收件人姓名:<input type="text"  class="" id="Text2" value="" name="member_name">
                  </div>  
                  <div class="row">
                    聯絡電話:<input type="text"  class="" id="Text4" value="" name="member_name">
                  </div>    
                  <div class="row">
                    email:<input type="text"  class="" id="Text5" value="" name="member_name">
                  </div>
                  <div class="row">
                    收件人地址:<select id="cityName" runat="server"></select><select id="townName"></select>
                    <input type="text"  class="" id="Text6" value="" name="member_name">
                  </div>    
                  <div class="row">
                    配送時間:<div  id="receiverTime" runat="server"></div>
                  </div>     
            </div>
        </div>
        <div class="row">
            發票資訊
            <div class="col-md-12" id="InvoceInfo" runat="server">
                         
            </div>
        </div>
        <div class="row">
            <button class="btn btn-primary" onclick="goOrder()">下一步</button>
        </div>
        <!-- /.row -->
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

