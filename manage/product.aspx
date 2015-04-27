<%@ Page Language="C#" AutoEventWireup="true" CodeFile="product.aspx.cs" Inherits="manage_product" %>

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
        <script type="text/javascript" src="../manage/js/production.js"></script>
        
        <style>
            label {
            	border-right: 1px solid #aaa;
                padding: 0 8px;
            }
            label:last-child {
            	border: none;
            }
            input[type=text],textarea {
            	width: 95%;
            }
            select {
            	min-width: 200px;
            }
        </style>
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
                            <h1>更新商品管理</h1>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-12">
                        <div class="panel panel-default bootstrap-admin-no-table-panel">
                            <div class="panel-heading">    
                                <form id="GmyForm" name="GmyForm" action="" method="post" enctype="multipart/form-data">
                                    <table class="table table-striped table-bordered" id="Table1" border="0">
                                            <tr>
		                                        <td width="150">產品編號</td>
		                                        <td colspan="5"><span id="ProductID" runat="server"></span></td>
    			                                
		                                        
		                                    </tr>
                                            <tr>
                                                <td width="150" rowspan="2">產品照片</td>
                                                <td>
		                                            <input id="uploadFile1" name="storePhoto" type="file" class="file_1" />
    			                                        
	                                                <br />
	                                                <div id="storePhotoHideDiv1" style="display:none;">
	                                                    <img id="storePhotoUrl1" href="../images/noAvatar2.jpg" ></img>
	                                                </div>
		                                            <div id="PhotoShow1"  runat="server"></div>
		                                        </td>
		                                        <td>
		                                            <input id="uploadFile2" name="storePhoto" type="file"  class="file_2" />
    			                                        
	                                                <br />
	                                                <div id="storePhotoHideDiv2" style="display:none;">
	                                                    <img id="storePhotoUrl2" href="../images/noAvatar2.jpg" ></img>
	                                                </div>
		                                            <div id="PhotoShow2"  runat="server"></div>
		                                        </td>
		                                        <td>
		                                            <input id="uploadFile3" name="storePhoto" type="file"  class="file_3" />
    			                                        
	                                                <br />
	                                                <div id="storePhotoHideDiv3" style="display:none;">
	                                                    <img id="storePhotoUrl3" href="../images/noAvatar2.jpg" ></img>
	                                                </div>
		                                            <div id="PhotoShow3"  runat="server"></div>
		                                        </td>
                                            </tr>
                                            <tr>
                                                
                                                <td>
		                                            <input id="uploadFile4" name="storePhoto" type="file"  class="file_4" />
    			                                        
	                                                <br />
	                                                <div id="storePhotoHideDiv4" style="display:none;">
	                                                    <img id="storePhotoUrl4" href="../images/noAvatar2.jpg" ></img>
	                                                </div>
		                                            <div id="PhotoShow4"  runat="server"></div>
		                                        </td>
		                                        <td>
		                                            <input id="uploadFile5" name="storePhoto" type="file"  class="file_5" />
    			                                        
	                                                <br />
	                                                <div id="storePhotoHideDiv5" style="display:none;">
	                                                    <img id="storePhotoUrl5" href="../images/noAvatar2.jpg" ></img>
	                                                </div>
		                                            <div id="PhotoShow5"  runat="server"></div>
		                                        </td>
                                            </tr>
		                                    <tr>
		                                        <td width="150">產品名稱</td>
		                                        <td colspan="5">
		                                        <input id="name" type="text" runat="server" /><span class="startMark">*</span></td>
    			                                
		                                    </tr>
		                                    <tr>
		                                        <td>產品價格</td>
		                                        <td colspan="5">
		                                            <input id="price" type="text" runat="server" /><span class="startMark">*</span>
		                                        </td>
    			                                
		                                    </tr>
		                                    <tr>
		                                        <td>產品分類</td>
		                                        <td colspan="5">
		                                            <select id="Production_Category" runat="server">
		                                               
		                                            </select>
		                                        </td>  
		                                    </tr>
		                                    <tr>
		                                        <td>產品等級</td>
		                                        <td colspan="5">
		                                            <select id="ProductionLevel" runat="server">
		                                                <option value="0">A+</option>
		                                                <option value="1">A</option>
		                                                <option value="2">B+</option>
		                                                <option value="3">B</option>
		                                                <option value="4">C+</option>
		                                                <option value="5">C</option>
		                                                <option value="6">D+</option>
		                                                <option value="7">D</option>
		                                            </select>
		                                        </td>  
		                                    </tr>
		                                    <tr>
		                                        <td>左右手</td>
		                                        <td colspan="5" runat="server" id="handBlock">
		                                            <label><input type="checkbox" name="hand" value="1"/>左手</label>
		                                            <label><input type="checkbox" name="hand" value="2" />右手</label>

		                                        </td>  
		                                    </tr>
		                                    <tr>
		                                        <td>角度</td>
		                                        <td colspan="5" runat="server" id="AngleBlock">
		                                            <select id="Angle" runat="server">
		                                                <option value="0">請選擇</option>
		                                               
		                                            </select>
		                                        </td>  
		                                    </tr>
		                                    <tr>
		                                        <td>桿身</td>
		                                        <td colspan="5" runat="server" id="golfClubBlock">
		                                            <select id="GolfClub" runat="server">
		                                                <option value="0">請選擇</option>
		                                               
		                                            </select>
		                                        </td>  
		                                    </tr>
		                                    <tr>
		                                        <td>硬度</td>
		                                        <td colspan="5" runat="server" id="hardnessBlock">
		                                            <select id="GolfHard" runat="server">
		                                                <option value="0">請選擇</option>
		                                               
		                                            </select>
		                                        </td>  
		                                    </tr>
		                                    
		                                    <tr>
		                                        <td>產品簡介</td>
		                                        <td colspan="5">
		                                            <textarea id="Introduction" rows="5" runat="server" ></textarea>
		                                        </td>
		                                    </tr>
		                                    <tr>
		                                        <td>完整商品圖文介紹</td>
		                                        <td colspan="5">
		                                            <textarea id="FullIntro" rows="5" runat="server" ></textarea>
		                                        </td>
		                                    </tr>
    			           
                                        </table>
                                    </form>
                                <button class="btn btn-lg btn-primary" onclick="UpdateProduction()">更新</button>
                               
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>