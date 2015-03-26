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

public partial class manage_order : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!HttpContext.Current.User.Identity.IsAuthenticated || !HttpContext.Current.User.IsInRole("admin"))
        {
            Response.Redirect("../Default.aspx");
        }
        try
        {
            int ID = int.Parse(Context.Request.QueryString["id"].ToString());
           
            theme manageTheme = new theme();
            left_menu.InnerHtml = manageTheme.getManageLeftMenu();

        }
        catch
        {
            Page.Response.Redirect("./productsearch.aspx");
        }


    }
}
