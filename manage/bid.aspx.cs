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

public partial class manage_bid : System.Web.UI.Page
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
            Session["aBidId"] = ID;
            theme manageTheme = new theme();
            left_menu.InnerHtml = manageTheme.getManageLeftMenu();
            bidDB Bid = new bidDB();
            StoreDB myStore = new StoreDB();
            sBidItem myBid = Bid.searchBitItembyID(ID.ToString());

            String snum = ID.ToString();
            String pnum = snum.PadLeft(8, '0');
            String fnum = String.Format("{0:00000000}", Convert.ToInt32(snum));
            ProductID.InnerHtml = fnum;
            name.Value = myBid.Name;
            price.Value = myBid.Price;

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
                bool isCheck = false;
                foreach (sProduct_List Product_List in myBid.HandName)
                {
                    if (Product_List.ItemID == atom.ID)
                        isCheck = true;
                }
                if (isCheck)
                    innerstring += "<label><input type='checkbox' name='hand' value='" + atom.ID + "' checked='checked'/> " + atom.ItemName + "</label>";
                else
                    innerstring += "<label><input type='checkbox' name='hand' value='" + atom.ID + "'/> " + atom.ItemName + "</label>";
            }
            handBlock.InnerHtml = innerstring;


            innerstring = "";
            myList = systemList.getList("angle");
            foreach (sList atom in myList)
            {
                bool isCheck = false;
                foreach (sProduct_List Product_List in myBid.AngleName)
                {
                    if (Product_List.ItemID == atom.ID)
                        isCheck = true;
                }
                if (isCheck)
                    innerstring += "<label><input type='checkbox' name='angle' value='" + atom.ID + "' checked='checked'/> " + atom.ItemName + "</label>";
                else
                    innerstring += "<label><input type='checkbox' name='angle' value='" + atom.ID + "'/> " + atom.ItemName + "</label>";

            }
            AngleBlock.InnerHtml = innerstring;

            innerstring = "";
            myList = systemList.getList("golfClub");
            foreach (sList atom in myList)
            {
                bool isCheck = false;
                foreach (sProduct_List Product_List in myBid.GolfClubName)
                {
                    if (Product_List.ItemID == atom.ID)
                        isCheck = true;
                }
                if (isCheck)
                    innerstring += "<label><input type='checkbox' name='golfClub' value='" + atom.ID + "' checked='checked'/> " + atom.ItemName + "</label>";
                else
                    innerstring += "<label><input type='checkbox' name='golfClub' value='" + atom.ID + "'/> " + atom.ItemName + "</label>";
            }
            golfClubBlock.InnerHtml = innerstring;

            innerstring = "";
            myList = systemList.getList("hardness");
            foreach (sList atom in myList)
            {
                bool isCheck = false;
                foreach (sProduct_List Product_List in myBid.GolfHardName)
                {
                    if (Product_List.ItemID == atom.ID)
                        isCheck = true;
                }
                if (isCheck)
                    innerstring += "<label><input type='checkbox' name='hardness' value='" + atom.ID + "' checked='checked'/> " + atom.ItemName + "</label>";
                else
                    innerstring += "<label><input type='checkbox' name='hardness' value='" + atom.ID + "'/> " + atom.ItemName + "</label>";


            }
            hardnessBlock.InnerHtml = innerstring;


            Production_Category.Items.FindByValue(myBid.ProductionCategory).Selected = true;
            ProductionLevel.Items.FindByValue(myBid.ProductionLevel).Selected = true;
            //Hand.Items.FindByValue(myProduction.Hand).Selected = true;
            //Angle.Items.FindByValue(myProduction.Angle).Selected = true;
            //GolfClub.Items.FindByValue(myProduction.GolfClub).Selected = true;
            //GolfHard.Items.FindByValue(myProduction.GolfHard).Selected = true;
            Introduction.Value = myBid.Introduction;
            FullIntro.Value = myBid.FullIntro;
            //<img style="width:180px;" alt="" src="blob:http://localhost:26989/1fc4facf-9566-4d6f-8472-00517b948c2f">
            int counter = 1;
            foreach (string URL in myBid.ProductionPhoto)
            {
                if (counter == 1)
                {
                    PhotoShow1.InnerHtml = "<img style='width:180px;' alt='' src='../photos/production/" + URL + "'/>";
                }
                else if (counter == 2)
                {
                    PhotoShow2.InnerHtml = "<img style='width:180px;' alt='' src='../photos/production/" + URL + "'/>";
                }
                else if (counter == 3)
                {
                    PhotoShow3.InnerHtml = "<img style='width:180px;' alt='' src='../photos/production/" + URL + "'/>";
                }
                else if (counter == 4)
                {
                    PhotoShow4.InnerHtml = "<img style='width:180px;' alt='' src='../photos/production/" + URL + "'/>";
                }
                else if (counter == 5)
                {
                    PhotoShow5.InnerHtml = "<img style='width:180px;' alt='' src='../photos/production/" + URL + "'/>";
                }
                counter++;
            }





        }
        catch
        {
            Page.Response.Redirect("./bidsearch.aspx");
        }

        
    }
}
