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
        theme mytheme = new theme();
        headerTop.InnerHtml = mytheme.getHeadertop();
        headerBottom.InnerHtml = mytheme.getHeaderbottom();
        footerDiv.InnerHtml = mytheme.getFooter();
        int TotalPrice = 0;
        Cart myCart = new Cart();
        List<sOrderProduction> sCartInfo = myCart.CartProductionInfoByUserName(HttpContext.Current.User.Identity.Name);
        string innerString = "<table><tr><th>商品圖片</th><th>商品明細</th><th>價格</th><th>數量</th><th>小記</th><th>變更明細</th></tr>";
        foreach (sOrderProduction atom in sCartInfo)
        {
            int subPrice=atom.ProductionPrice * atom.ProductionCounter;
            TotalPrice += subPrice;
            innerString += "<tr>" +
                "<td><img src='./photos/production/" + atom.PhotoName + "' width='100px'></td>" +
                "<td>" +
                    atom.ProductionName + "<br/>" +
                    atom.AngleName + "<br/>" +
                    atom.GolfClubName + "<br/>" +
                    atom.GolfHandName + "<br/>" +
                    atom.HandName + "<br/>" +
                "</td>" +
                "<td>" + atom.ProductionPrice + "</td>" +
                "<td>" + atom.ProductionCounter + "</td>" +
                "<td>" + subPrice + "</td>" +
                "<td>" + "<input type='button' value='刪除' onclick='deleteCart(" + atom.ID + ")'/>" + "</td>" +
                "</tr>";
        }
        innerString += "</table>";
        totalPrice.InnerHtml = "總價:" + TotalPrice.ToString();
        CartTable.InnerHtml = innerString;
    }
}
