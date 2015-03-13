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

public partial class manage_product : System.Web.UI.Page
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
            Session["aProductId"] = ID;
            theme manageTheme = new theme();
            left_menu.InnerHtml = manageTheme.getManageLeftMenu();
            StoreDB myStore = new StoreDB();
            sProduction myProduction = myStore.selectProduction(ID);

            String snum = ID.ToString();
            String pnum = snum.PadLeft(8, '0');
            String fnum = String.Format("{0:00000000}", Convert.ToInt32(snum));
            ProductID.InnerHtml = fnum;
            name.Value = myProduction.Name;
            price.Value = myProduction.Price;

            List<sProductionCategory> lProduction = myStore.searchProductionCategory();
            foreach (sProductionCategory myPorduct in lProduction)
            {
                Production_Category.Items.Add(new ListItem(myPorduct.CategoryName, myPorduct.ID.ToString()));
            }
            Production_Category.Items.FindByValue(myProduction.ProductionCategory).Selected = true;
            ProductionLevel.Items.FindByValue(myProduction.ProductionLevel).Selected = true;
            //Hand.Items.FindByValue(myProduction.Hand).Selected = true;
            //Angle.Items.FindByValue(myProduction.Angle).Selected = true;
            //GolfClub.Items.FindByValue(myProduction.GolfClub).Selected = true;
            //GolfHard.Items.FindByValue(myProduction.GolfHard).Selected = true;
            Introduction.Value = myProduction.Introduction;
            FullIntro.Value = myProduction.FullIntro;
        }
        catch
        {
            Page.Response.Redirect("./productsearch.aspx");
        }

        
    }
}
