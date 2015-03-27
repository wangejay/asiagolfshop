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
            Cart myCart = new Cart();
            sOrder myOrder = myCart.SearchOrder(ID);
            //設定table資本資料
            List myList = new List();
            List<sList> ListData = myList.getList("oStatus");
            string inner = "";
            foreach (sList atom in ListData)
            {
                OStatus.Items.Add(new ListItem(atom.ItemName.ToString(), atom.ID.ToString()));
                //inner += "<option value='" + atom.ID + "'>" + atom.ItemName + "</option>";
            }

            ////////////////////

            //設定table的值
            orderid.InnerHtml = myOrder.OrderID;
            ////////////////////

        }
        catch
        {
            Page.Response.Redirect("./productsearch.aspx");
        }


    }
}
