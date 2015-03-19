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
using System.Collections.Generic;

public partial class cartlist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!HttpContext.Current.User.Identity.IsAuthenticated)
        {
            Response.Redirect("./default.aspx", false);
        }
        theme mytheme = new theme();
        headerTop.InnerHtml = mytheme.getHeadertop();
        headerBottom.InnerHtml = mytheme.getHeaderbottom();
        footerDiv.InnerHtml = mytheme.getFooter();
        int TotalPrice = 0;
        Cart myCart = new Cart();
        List<sOrderProduction> sCartInfo = myCart.CartProductionInfoByUserName(HttpContext.Current.User.Identity.Name);
        string innerString = "<table class='table table-striped table-hover carlistTable'><thead><tr><th>商品圖片</th><th>商品明細</th><th>單價</th><th>數量</th><th>小記</th><th>變更明細</th></tr></thead><tbody>";
        foreach (sOrderProduction atom in sCartInfo)
        {
            int subPrice=atom.ProductionPrice * atom.ProductionCounter;
            TotalPrice += subPrice;
            innerString += "<tr>" +
                "<td><img src='./photos/production/" + atom.PhotoName + "' width='100px'></td>" +
                "<td>" +
                    "<h4 class='productName'>" + atom.ProductionName + "</h4>" +
                    "<ul class='productDetail list-unstyled'>" +
                        //"<li>" + atom.ProductionName + "</li>" +
                        "<li>" + atom.AngleName + "</li>" +
                        "<li>" + atom.GolfClubName + "</li>" +
                        "<li>" + atom.GolfHandName + "</li>" +
                        "<li>" + atom.HandName + "</li>" +
                    "</ul>" +
                "</td>" +
                "<td>" + atom.ProductionPrice + "</td>" +
                "<td>" + atom.ProductionCounter + "</td>" +
                "<td>" + subPrice + "</td>" +
                "<td>" + "<button class='btn btn-link' onclick='deleteCart(" + atom.ID + ")'/><span class='glyphicon glyphicon-trash' aria-hidden='true'></span> 刪除</button>" + "</td>" +
                "</tr>";
        }
        innerString += "</tbody></table>";
        totalPrice.InnerHtml = "總計＄ " + TotalPrice.ToString() + " 元";
        CartTable.InnerHtml = innerString;
    }
}
