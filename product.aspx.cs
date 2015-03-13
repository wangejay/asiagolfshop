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

public partial class product : System.Web.UI.Page
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
        left_menu.InnerHtml = mytheme.getLeftMenu();
        StoreDB myStore = new StoreDB();
        MainTitle.InnerHtml = ID.Length == 0 ? "全部商品" : myStore.searchProductionCategoryName(ID);
        List<sProduction> myProduction = myStore.searchProductionbyCateogry(ID);
        string innerString = "";
        int counter = 0;
        foreach (sProduction production in myProduction)
        {
            if (counter % 3 == 0)
            {
                innerString += " <div class='row'>";
            }
            innerString += "<div class='col-sm-4 col-lg-4 col-md-4' onclick='goDetail(" + production.ID + ")'>" +
                        "<div class='thumbnail'>";
                        if (production.ProductionPhoto.Count > 0)
            {
                innerString += "<img src='./photos/production/" + production.ProductionPhoto[0] + "' alt=''>" ;
            }

                        innerString += "<div class='caption'>" +
                                "<p><h4>" + "<a href='./detail.aspx?id=" + production.ID + "'>" + production.Name + "</a></p>" +
                                "<h4 class='pull-right'>$" + production.Price + "</h4>" +

                                "</h4>" +
                                "<p>" + production.Introduction + "</p>" +
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
