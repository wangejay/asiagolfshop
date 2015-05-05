using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.UI.MobileControls;
using System.Collections.Generic;
using System.Globalization;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    { 
        theme mytheme = new theme();
        headerTop.InnerHtml = mytheme.getHeadertop();
        headerBottom.InnerHtml = mytheme.getHeaderbottom();
        left_menu.InnerHtml = mytheme.getLeftMenu("0");
        footerDiv.InnerHtml = mytheme.getFooter();
        StoreDB myStore = new StoreDB();
        List<sProduction> myProduction = myStore.searchProduction(9);
        string innerString = "";
        foreach (sProduction production in myProduction)
        {
            innerString += "<div class='col-xs-8 col-xs-offset-2 col-sm-6 col-sm-offset-0 col-lg-4' onclick='goDetail(" + production.ID + ")'>" +
                        "<div class='thumbnail'>";
            if (production.ProductionPhoto.Count > 0)
            {
                innerString += "<div class='productIMG' style='background-image: url(./photos/production/" + production.ProductionPhoto[0] + ");'>" +
                    "<img src='images/placeholder.png' class='imgPlaceHolder'>" +
                "</div>";
            }
            innerString += "<div class='caption'>" +
                                "<h4>" + "<a href='./detail.aspx?id=" + production.ID + "'>" + production.Name + "</a></h4>" +
                                "<span class='originPrice pull-left'><del>NT$12345</del></span>" +
                                "<h5 class=''>NT$" + double.Parse(production.Price).ToString("#,#", CultureInfo.InvariantCulture) + "</h5>" +
                                //"<p>" + production.Introduction + "</p>" +
                                //"<button class='btn btn-block btn-primary'>詳細資訊</button>" +
                            "</div>" +
                        "</div>" +
                    "</div>";
        }
        ProductionDiv.InnerHtml = innerString;
    }
}
