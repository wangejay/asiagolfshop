using System;
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
            "<div class='collapse navbar-collapse' id='bs-example-navbar-collapse-1'>" +
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
        return
        "<div class='container'>" +
            "<div class='row'>" +
                "<a href='./default.aspx'><img src='./images/logo.png'/></a>" +
                "<div id='header_function_list'>" +
                    //"<div id='header_search_txt' class='header_function_list_element'>" +
                    //    "<i></i>" +
                    //    "<input id='header_search' type='text' value=''>" +
                    //    "<img id='header_search_img' onclick='' title='搜尋Search' alt='搜尋Search' src='./images/btn_search.png'/>" +
                    //"</div>" +
                    "<div id='login_Div' class='header_function_list_element'><a href='./login.aspx'>登入</a>/<a href='./signup.aspx'>註冊</a></div>" +
                    "<div id='cart_Div' class='header_function_list_element'>" +
                        "<span class='sapn_title'>購物車</span><span id='cart_counter'>0</span><span class='sapn_title'>件</span></div>" +
                "</div>" +
            "</div>" +
        "</div>";
    
    }
}
