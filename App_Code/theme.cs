﻿using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;

/// <summary>
/// Summary description for theme
/// </summary>
public class theme
{
	public theme()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public string getHeaderbottom()
    {
        return 
            "<!-- Navigation -->" +
    "" +
        "<div class='container'>" +
            "<!-- Brand and toggle get grouped for better mobile display -->" +
            "<div class='navbar-header'>" +
                "<button type='button' class='navbar-toggle' data-toggle='collapse' data-target='#bs-example-navbar-collapse-1'>" +
                    "<span class='sr-only'>Toggle navigation</span>" +
                    "<span class='icon-bar'></span>" +
                    "<span class='icon-bar'></span>" +
                    "<span class='icon-bar'></span>" +
                "</button>" +
            "</div>" +
            "<!-- Collect the nav links, forms, and other content for toggling -->" +
            "<div class='collapse navbar-collapse' id='main-navbar'>" +
                "<ul class='nav navbar-nav'>" +
                    "<li><a href='./product.aspx'>產品</a></li>" +
                    "<li><a href='./bid.aspx'>競標區</a>" +
                    "</li>" +
                    "<li><a href='./secondhand.aspx'>二手區</a>" +
                    "</li>" +
                    "<li><a href='./coach.aspx'>教練專區</a>" +
                    "</li>" +
                    "<li><a href='#contact'>連絡我們</a>" +
                    "</li>" +
                "</ul>" +
            "</div>" +
            "<!-- /.navbar-collapse -->" +
        "</div>" +
        "<!-- /.container -->" ;
    }
    public string getHeadertop()
    {
        string returnvalue = "";
        Cart myCart = new Cart();
        int counter = 0;
        if (HttpContext.Current.User.Identity.IsAuthenticated)
        {
            MemeberShipDA myMember = new MemeberShipDA();
            string UserID = myMember.getUserID(HttpContext.Current.User.Identity.Name);
            counter = myCart.CartCounterByUserID(UserID);
        }
        string ifHidden = "";
        if (counter < 1) {
            ifHidden = "hidden ";
        }
        returnvalue = "<div class='container'>" +
            "<div class='row'>" +
                "<a href='./default.aspx'>" +
                    "<img src='./images/logo.png' style='height: 48px;' />" +
                    "<img src='./images/asia-golf-shop-title.png' style='height: 30px; margin-top: 7px; margin-left: 4px;' />" +
                    "</a>" +
                "<div id='header_function_list'>" +
            //"<div id='header_search_txt' class='header_function_list_element'>" +
            //    "<i></i>" +
            //    "<input id='header_search' type='text' value=''>" +
            //    "<img id='header_search_img' onclick='' title='搜尋Search' alt='搜尋Search' src='./images/btn_search.png'/>" +
            //"</div>" +
                    "<div id='login_Div' class='header_function_list_element'>";
        if (HttpContext.Current.User.Identity.IsAuthenticated)
        {
            returnvalue +=
                HttpContext.Current.User.Identity.Name.Substring(0,HttpContext.Current.User.Identity.Name.IndexOf("@")) + " 您好" + 
        "<a href='javascript:logout()'>"+
        " <span class='glyphicon glyphicon-log-in' aria-hidden='true' style='font-size: 2.4rem; position: relative; top: 5px;'></span></a>";
                          
        }
        else
        {
            returnvalue +=
                            "<span style='position: relative; top: 4px;'>" +
                            "<a href='./login.aspx' style='text-decoration: none;'>登入</a> / " +
                            "<a href='./signup.aspx' style='text-decoration: none;'>註冊</a>" +
                            "</span>";
        }
        returnvalue +=
                    "</div>" +
                    "<div id='cart_Div' class='header_function_list_element'>" +
                        "<a href='./cartlist.aspx' style='font-size: 2.4rem;'>" +
                            "<span class='glyphicon glyphicon-shopping-cart' aria-hidden='true'></span>" +
                            "<span class='label label-success " + ifHidden + "' id='cart_counter'>" + counter + "</span>" +
                        "</a>" + 
                    "</div>" +
                "</div>" +
            "</div>" +
        "</div>";
        return returnvalue;
        
    
    }
    public string getManageLeftMenu()
    {
       
        return "<li>" +
                        "<a href='#MemberSetting' class='nav-header collapsed' data-toggle='collapse'>" +
                            "<i class='glyphicon glyphicon-cog'>" + "</i>會員管理" +
                            "<span class='pull-right glyphicon glyphicon-chevron-toggle'>" + "</span>" +
                        "</a>" +
                        "<ul id='MemberSetting' class='nav nav-list collapse secondmenu' style='height: 0px;'>" +
                            "<li class='active'>" + "<a href='member.aspx'>" + "<i class='glyphicon glyphicon-user'>" + "</i>&nbsp;會員管理" + "</a>" + "</li>" +

                        "</ul>" +
                    "</li>" +
                    "<li>" +
                        "<a href='#storeSetting' class='nav-header collapsed' data-toggle='collapse'>" +
                            "<i class='glyphicon glyphicon-cog'>" + "</i>商城管理" +
                            "<span class='pull-right glyphicon glyphicon-chevron-toggle'>" + "</span>" +
                        "</a>" +
                        "<ul id='storeSetting' class='nav nav-list collapse secondmenu' style='height: 0px;'>" +

                            "<li>" + "<a href='../manage/productorders.aspx'>" +
                                "<i class='glyphicon glyphicon-asterisk'>" + "</i>&nbsp;訂單查詢" + "</a>" + "</li>" +
                            "<li class='active'>" +
                                "<a href='../manage/productcreate.aspx'>" +
                                "<i class='glyphicon glyphicon-user'>" + "</i>&nbsp;新增產品" + "</a>" + "</li>" +
                           
                            "<li>" + "<a href='../manage/productsearch.aspx'>" +
                                "<i class='glyphicon glyphicon-th-list'>" + "</i>&nbsp;查詢產品" + "</a>" + "</li>" +
                            "<li>" + "<a href='../manage/productcategory.aspx'>" + 
                                "<i class='glyphicon glyphicon-asterisk'>" + "</i>&nbsp;分類設定" + "</a>" + "</li>" +
                         
                        "</ul>" +

                    "</li>" +
                    "<li>" +
                        "<a href='#bidSetting' class='nav-header collapsed' data-toggle='collapse'>" +
                            "<i class='glyphicon glyphicon-cog'>" + "</i>競標管理" +
                            "<span class='pull-right glyphicon glyphicon-chevron-toggle'>" + "</span>" +
                        "</a>" +
                        "<ul id='bidSetting' class='nav nav-list collapse secondmenu' style='height: 0px;'>" +

                            "<li>" + "<a href='../manage/bidorders.aspx'>" +
                                "<i class='glyphicon glyphicon-asterisk'>" + "</i>&nbsp;競標訂單查詢" + "</a>" + "</li>" +
                            "<li class='active'>" +
                                "<a href='../manage/bidCreate.aspx'>" +
                                "<i class='glyphicon glyphicon-user'>" + "</i>&nbsp;新增競標品" + "</a>" + "</li>" +

                            "<li>" + "<a href='../manage/bidsearch.aspx'>" +
                                "<i class='glyphicon glyphicon-th-list'>" + "</i>&nbsp;查詢競標" + "</a>" + "</li>" +
                           

                        "</ul>" +
                    "</li>" +
                    "<li>" +
                        "<a href='bid.aspx'>" + "<i class='glyphicon glyphicon-chevron-right'>" + "</i>二手管理" + "</a>" +
                    "</li>" +
                    "<li>" +
                        "<a href='secondhand.aspx'>" + "<i class='glyphicon glyphicon-chevron-right'>" + "</i>教練管理" + "</a>" +
                    "</li>";
    }
    public string getLeftMenu(string ID)
    {
        string inner = "";
        string currentFlag = "";
        StoreDB myStore = new StoreDB();
        List<sProductionCategory> lProduction = myStore.searchProductionCategory();
        foreach (sProductionCategory myPorduct in lProduction)
        {
            currentFlag = "";
            if (!string.IsNullOrEmpty(ID) && int.Parse(ID) == myPorduct.ID)
            {
                currentFlag = " currentCategory";
            }
            inner += "<a href='./product.aspx?id=" + myPorduct.ID + "' class='list-group-item" + currentFlag + "'>" + myPorduct.CategoryName + "</a>";
        }
        return inner;
    }

    public string getBidLeftMenu(string ID)
    {
        string inner = "";
        string currentFlag = "";
        StoreDB myStore = new StoreDB();
        List<sProductionCategory> lProduction = myStore.searchProductionCategory();
        foreach (sProductionCategory myPorduct in lProduction)
        {
            currentFlag = "";
            if (!string.IsNullOrEmpty(ID) && int.Parse(ID) == myPorduct.ID)
            {
                currentFlag = " currentCategory";
            }
            inner += "<a href='./bid.aspx?id=" + myPorduct.ID + "' class='list-group-item" + currentFlag + "'>" + myPorduct.CategoryName + "</a>";
        }
        return inner;
    }

    public string getFooter()
    {
        return "<p>Copyright &copy; AsiaGolfShop 2014</p>";
    }
}
