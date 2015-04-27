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
using System.Data.Common;
using System.Collections.Generic;
using System.Globalization;

public partial class bid : System.Web.UI.Page
{
        protected void Page_Load(object sender, EventArgs e)
    {
        string ID = "";
        try
        {
            ID = Context.Request.QueryString["id"].ToString();
            
        }
        catch
        { 
        }
        theme mytheme = new theme();
        headerTop.InnerHtml = mytheme.getHeadertop();
        headerBottom.InnerHtml = mytheme.getHeaderbottom();
        footerDiv.InnerHtml = mytheme.getFooter();
        left_menu.InnerHtml = mytheme.getBidLeftMenu();
        bidDB myStore = new bidDB();
        //MainTitle.InnerHtml = ID.Length == 0 ? "全部商品" : myStore.searchBidItembyName(ID);
        MainTitle.InnerHtml = "全部商品";
        List<sBidItem> myBidItem = myStore.searchBidItembyCateogry(ID);
        string innerString = "";
        int counter = 0;
        foreach (sBidItem thisBidItem in myBidItem)
        {
            if (counter % 3 == 0)
            {
                innerString += " <div class='row'>";
            }
            innerString += "<div class='col-xs-4' onclick='goBidDetail(" + thisBidItem.ID + ")'>" +
                        "<div class='thumbnail'>";
            if (thisBidItem.ProductionPhoto.Count > 0)
            {
                innerString += "<div class='productIMG' style='background-image: url(./photos/bid/" + thisBidItem.ID + "_0.jpg);'>" +
                                    "<img src='images/placeholder.png' class='imgPlaceHolder'>" +
                                "</div>";
            }

            innerString += "<div class='caption'>" +
                    "<h4>" + "<a href='./biddetail.aspx?id=" + thisBidItem.ID + "'>" + thisBidItem.Name + "</a></h4>" +

                    "<h5 class=''>目前出價：NT$" + thisBidItem.MaxBidPrice + "</h5>" +

                    //"<p>" + thisBidItem.Introduction + "</p>" +
                        "<ul class='list-inline'>" +
                            "<li>" + "已有" + thisBidItem.RecordCounter + "次出價，</li>" +
                            "<li>" + "還有" + thisBidItem.EndTime.ToString("y") + "結標。</li>" +
                        "</ul>" +
                    //"<button class='btn btn-block btn-primary'>我要出價</button>" +
                "</div>" +
            "</div>" +
        "</div>";
            if (counter % 3 == 2)
            {
                innerString += " </div>";
            }
            counter++;
        }
        if (counter % 3 == 1 || counter % 3 == 2)
        {
            innerString += " </div>";
        }
        ProductionDiv.InnerHtml = innerString;
    }
}
