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

public partial class manage_bidCreate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!HttpContext.Current.User.Identity.IsAuthenticated || !HttpContext.Current.User.IsInRole("admin"))
        {
            Response.Redirect("../Default.aspx");
        }
        theme manageTheme = new theme();
        left_menu.InnerHtml = manageTheme.getManageLeftMenu();
        StoreDB myStore = new StoreDB();
        List<sProductionCategory> lProduction = myStore.searchProductionCategory();
        foreach (sProductionCategory myPorduct in lProduction)
        {
            Production_Category.Items.Add(new ListItem(myPorduct.CategoryName, myPorduct.ID.ToString()));
        }
        List systemList = new List();
        string innerstring = "";
        List<sList> myList = systemList.getList("hand");
        foreach (sList atom in myList)
        {
            innerstring += "<label><input type='checkbox' name='hand' value='" + atom.ID + "'/>" + atom.ItemName + "</label>";
        }
        handBlock.InnerHtml = innerstring;

        innerstring = "";
        myList = systemList.getList("angle");
        foreach (sList atom in myList)
        {
            innerstring += "<label><input type='checkbox' name='angle' value='" + atom.ID + "'/>" + atom.ItemName + "</label>";
        }
        AngleBlock.InnerHtml = innerstring;

        innerstring = "";
        myList = systemList.getList("golfClub");
        foreach (sList atom in myList)
        {
            innerstring += "<label><input type='checkbox' name='golfClub' value='" + atom.ID + "'/>" + atom.ItemName + "</label>";
        }
        golfClubBlock.InnerHtml = innerstring;

        innerstring = "";
        myList = systemList.getList("hardness");
        foreach (sList atom in myList)
        {
            innerstring += "<label><input type='checkbox' name='hardness' value='" + atom.ID + "'/>" + atom.ItemName + "</label>";
        }
        hardnessBlock.InnerHtml = innerstring;
    }
}
