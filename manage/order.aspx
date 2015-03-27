<%@ Page Language="C#" AutoEventWireup="true" CodeFile="order.aspx.cs" Inherits="manage_order" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>阿舍高爾夫後台管理系統</title>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">

        <!-- Bootstrap -->
        <link rel="stylesheet" media="screen" href="../css/bootstrap.min.css">
        <link rel="stylesheet" media="screen" href="../css/bootstrap-theme.min.css">

        <!-- Bootstrap Admin Theme -->
        <link rel="stylesheet" media="screen" href="../css/bootstrap-admin-theme.css">
        <link rel="stylesheet" media="screen" href="../css/bootstrap-admin-theme-change-size.css">

        <!-- Vendors -->
        <link rel="stylesheet" media="screen" href="../js/bootstrap-datepicker/css/datepicker.css">
        <link rel="stylesheet" media="screen" href="../css/datepicker.fixes.css">
        <link rel="stylesheet" media="screen" href="../js/uniform/themes/default/css/uniform.default.min.css">
        <link rel="stylesheet" media="screen" href="../css/uniform.default.fixes.css">
        <link rel="stylesheet" media="screen" href="../js/chosen.min.css">
        <link rel="stylesheet" media="screen" href="../js/selectize/dist/css/selectize.bootstrap3.css">
        <link rel="stylesheet" media="screen" href="../js/bootstrap-wysihtml5-rails-b3/vendor/assets/stylesheets/bootstrap-wysihtml5/core-b3.css">

        <!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->
        <!--[if lt IE 9]>
           <script type="text/javascript" src="../js/html5shiv.js"></script>
           <script type="text/javascript" src="../js/respond.min.js"></script>
        <![endif]-->
        <script type="text/javascript" src="../js/jquery-1.8.2.min.js"></script>
        <script type="text/javascript" src="../js/bootstrap.min.js"></script>
        <script type="text/javascript" src="../js/twitter-bootstrap-hover-dropdown.min.js"></script>
        <script type="text/javascript" src="../js/bootstrap-admin-theme-change-size.js"></script>
        <script type="text/javascript" src="../js/uniform/jquery.uniform.min.js"></script>
        <script type="text/javascript" src="../js/chosen.jquery.min.js"></script>
        <script type="text/javascript" src="../js/selectize/dist/js/standalone/selectize.min.js"></script>
        <script type="text/javascript" src="../js/bootstrap-datepicker/js/bootstrap-datepicker.js"></script>
        <script type="text/javascript" src="../js/bootstrap-wysihtml5-rails-b3/vendor/assets/javascripts/bootstrap-wysihtml5/wysihtml5.js"></script>
        <script type="text/javascript" src="../js/bootstrap-wysihtml5-rails-b3/vendor/assets/javascripts/bootstrap-wysihtml5/core-b3.js"></script>
        <script type="text/javascript" src="../js/twitter-bootstrap-wizard/jquery.bootstrap.wizard-for.bootstrap3.js"></script>
        <script type="text/javascript" src="../js/boostrap3-typeahead/bootstrap3-typeahead.min.js"></script>
         <script type="text/javascript" src="../js/ckeditor/ckeditor.js"></script>
        <script type="text/javascript" src="../js/jquery.form.js"></script>
        <script type="text/javascript" src="../js/uploadPreview.js"></script>
        <script type="text/javascript" src="../js/jquery.mu.image.resize.js"></script>
        <script type="text/javascript" src="../js/base.js"></script>
        <script type="text/javascript" src="../manage/js/order.js"></script>
</head>
<body class="bootstrap-admin-with-small-navbar wysihtml5-supported">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager" runat="server">
            <Services>
                <asp:ServiceReference Path="~/Supervisor.asmx" />
            </Services>
        </asp:ScriptManager>
    </form>
    <!-- main / large navbar -->
    <nav class="navbar navbar-default navbar-fixed-top bootstrap-admin-navbar bootstrap-admin-navbar-under-small" role="navigation">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="navbar-header">
                        <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".main-navbar-collapse">
                            <span class="sr-only"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                        </button>
                        <a class="navbar-brand" href="./default.aspx">阿舍高爾夫-總後台管理</a>
                    </div>
                    
                </div>
            </div>
        </div><!-- /.container -->
    </nav>
    <div class="container">
        <!-- left, vertical navbar & content -->
        <div class="row">
            <!-- left, vertical navbar -->
            <div class="col-md-2 bootstrap-admin-col-left">
                <ul id="left_menu" class="nav navbar-collapse collapse bootstrap-admin-navbar-side" runat="server"></ul>
            </div>
            <!-- content -->
            <div class="col-md-10">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="page-header">
                            <h1>訂單內容管理</h1>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-12">
                        <div class="panel panel-default bootstrap-admin-no-table-panel">
                            <div class="panel-heading">    
                                <table width="100%" cellspacing="0" cellpadding="0" border="0">
                                    <tbody>
                                        <tr>
                                            <th width="100" height="30">訂單編號</th>
                                            <td runat="server" id="orderid"></td>
                                            <td width="20">&nbsp;</td>
                                            <th width="100">訂單狀態</th>
                                            <td>
                                                <select id="OStatus" runat="server">
                                                </select></td>
                                            <td width="20">&nbsp;</td>
                                            <th width="90">訂單日期</th>
                                            <td id="ODate" runat="server">2015/2/11 下午 10:54:05</td>
                                        </tr>
                                        <tr>
                                            <th height="30">訂單會員</th>
                                            <td id="orderMember" runat="server"></td>
                                            <td>&nbsp;</td>
                                            <th>E-mail</th>
                                            <td id="orderEmail" runat="server">neko0228@hotmail.com</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <th height="30">對帳狀態</th>
                                            <td>
                                                <select id="PayStatus">
                                                    <option value="22" selected="selected">等待處理</option>
                                                    <option value="23">對帳中</option>
                                                    <option value="24">對帳完成</option>
                                                    <option value="25">處理中</option>
                                                    <option value="27"></option>
                                                </select>
                                            </td>
                                            <td>&nbsp;</td>
                                            <th>匯款類型</th>
                                            <td>
                                                <select id="PayType">
                                                    <option value="7" selected="selected">超商取貨付款</option>
                                                    <option value="9">ATM轉帳</option>
                                                    <option value="38">無摺存款</option>
                                                </select></td><td>&nbsp;</td>
                                            <th>交易型態</th>
                                            <td>
                                                <select id="TradeType">
                                                    <option value="19" selected="selected">取貨付款</option>
                                                    <option value="20">取貨不付款</option>
                                                </select>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th height="30">銀行代號</th>
                                            <td><input type="text" maxlength="3" value="" id="BankCode"></td>
                                            <td>&nbsp;</td>
                                            <th>銀行末五碼</th>
                                            <td><input type="text" maxlength="5" value="" id="BankUserCode"></td>
                                            <td>&nbsp;</td><td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <th height="30">總金額</th>
                                            <td>1698</td>
                                            <td>&nbsp;</td>
                                            <th>商品總金額</th>
                                            <td>1698</td>
                                            <td>&nbsp;</td>
                                            <th>折價卷折抵</th>
                                            <td>0</td>
                                        </tr>
                                        <tr>
                                            <th height="30">商品數量</th>
                                            <td id="ProductQuantity">4</td>
                                            <td>&nbsp;</td>
                                            <th>送貨類型</th>
                                            <td>
                                                <select id="TransportType">
                                                    <option value="17" selected="selected">超商取貨付款</option>
                                                    <option value="18">宅配</option>
                                                </select></td><td>&nbsp;</td>
                                            <th>運費</th>
                                            <td><input type="text" value="0" id="TransportCost"></td>
                                        </tr>
                                        <tr>
                                            <th height="30">門市服務代號</th>
                                            <td><input type="text" value="14696" id="STNO"></td>
                                            <td>&nbsp;</td>
                                            <th>店取店名</th>
                                            <td><input type="text" value="全家瑞芳龍川店" id="TransportName"></td>
                                            <td>&nbsp;</td>
                                            <th>店取地址</th>
                                            <td><input type="text" value="新北市瑞芳區一坑路11號" id="TransportAddress"></td>
                                        </tr>
                                        <tr>
                                            <th height="30">大物流代號</th>
                                            <td><input type="text" value="" id="EDCNO"></td>
                                            <td>&nbsp;</td><th>包裹號碼</th>
                                            <td><input type="text" value="43984297" id="PackageID"></td>
                                            <td>&nbsp;</td>
                                            <th>出貨日期</th>
                                            <td><input type="text" value="1000/1/1 上午 12:00:00" id="DeliveryDate" class="hasDatepicker"></td>
                                        </tr>
                                        <tr>
                                            <th height="30">貨品抵達日期</th>
                                            <td><input type="text" colspan="7" value="1000/1/1 上午 12:00:00" id="TransportFinData" class="hasDatepicker"></td>
                                        </tr>
                                        <tr>
                                            <th height="30">收件人姓名</th>
                                            <td colspan="2">
                                                <input type="text" style="width:95px;" value="江先生" id="SName"> 
                                                <select id="SSex">
                                                    <option value="1" selected="selected">先生</option>
                                                    <option value="2">小姐</option>
                                                </select>
                                            </td>
                                            <th>收件人電話</th>
                                            <td><input type="text" value="0224651375" id="SHPhone"></td>
                                            <td>&nbsp;</td>
                                            <th>收件人手機</th>
                                            <td><input type="text" value="0988502013" id="SPhone"></td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td height="30" colspan="3">&nbsp;</td>
                                            <th>收件人地址</th>
                                            <td colspan="4">
                                                <select id="SCity"></select>&nbsp;
                                                <select id="STown"></select>&nbsp;
                                                <input type="text" value="其餘地址" id="SAddress">
                                            </td>
                                        </tr>
                                        <tr>
                                            <th height="30">發票類型</th>
                                            <td>
                                                <select id="InvoiceType">
                                                    <option value="28">三聯式發票</option>
                                                    <option value="29" selected="selected">二聯式發票</option>
                                                </select>
                                            </td>
                                            <td>&nbsp;</td>
                                            <th>統一編號</th>
                                            <td><input type="text" maxlength="8" value="" id="UnifiedBusinessNo"></td>
                                            <td>&nbsp;</td><th>抬頭</th>
                                            <td><input type="text" value="" id="UnifiedBusinessNoName"></td>
                                        </tr>
                                        <tr>
                                            <th height="30">發票處理</th>
                                            <td>
                                                <select id="InvoiceTransport">
                                                    <option value="0" selected="selected">隨貨寄出</option>
                                                    <option value="1">另外寄送至</option>
                                                </select></td>
                                            <td>&nbsp;</td>
                                            <th>發票地址</th>
                                            <td id="InvoiceTable" colspan="4" style="display: none;">
                                                <select id="InvoiceSendCity"></select>&nbsp;
                                                <select id="InvoiceSendTown"></select>&nbsp;
                                                <input type="text" value="其餘地址" name="InvoiceSendAddress" id="InvoiceSendAddress">
                                            </td>
                                        </tr>
                                        <tr>
                                            <th height="30">備註</th>
                                            <td><input type="text" value="" id="Remarks"></td>
                                            <td>&nbsp;</td>
                                            <th>交易完成日期</th>
                                            <td><input type="text" value="1000/1/1 上午 12:00:00" id="TradeFinDate" class="hasDatepicker"></td>
                                            <td>&nbsp;</td>
                                            <th>退貨編號</th>
                                            <td><input type="text" value="" id="PurchaseReturn"></td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="8"><input type="button" value="存檔"></td>
                                        </tr>
                                    </tbody>
                                </table>
                             
                               
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
