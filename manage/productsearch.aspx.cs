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

public partial class manage_productsearch : System.Web.UI.Page
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
        List<sProductionCategory> lProductionCategory = myStore.searchProductionCategory();
        search_category.Items.Add(new ListItem("請選擇", "0"));
        foreach (sProductionCategory atom in lProductionCategory)
        {
            search_category.Items.Add(new ListItem(atom.CategoryName.ToString(), atom.ID.ToString()));
        }
    }
}
