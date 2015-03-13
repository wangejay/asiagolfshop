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

public partial class detail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string ID = "";
        try
        {
            ID = Context.Request.QueryString["id"].ToString();
            theme mytheme = new theme();
            headerTop.InnerHtml = mytheme.getHeadertop();
            headerBottom.InnerHtml = mytheme.getHeaderbottom();
            left_menu.InnerHtml = mytheme.getLeftMenu();
            string inner = "";
            StoreDB myStore = new StoreDB();
            sProduction myProduction = myStore.searchProductionbyID(ID);
            inner = "<ul class='list-unstyle list-inline'>";
            foreach (string atom in myProduction.ProductionPhoto)
            {
                inner += "<li><img src='./photos/production/" + atom + "' /></li>";

            }
            inner += "</ul>";
            ImgIndex.InnerHtml = inner;
            if(myProduction.ProductionPhoto.Count>0)
                mainImg.InnerHtml = "<img id='productImgBig' src='./photos/production/" + myProduction.ProductionPhoto[0] + "' />";
            fullintroduction.InnerHtml = myProduction.FullIntro;
            Title.InnerHtml = myProduction.Name;
            pDescription.InnerHtml = myProduction.Introduction;

            inner = "左/右手 : <select>";
            foreach(sProduct_List atom in myProduction.HandName)
            {
                inner += "<option value='" + atom.ItemID + "'>" + atom.ItemName + "</option>";
            }
            inner+="</select>";
            pHand.InnerHtml = inner;

            inner = "角度 :    <select>";
            foreach (sProduct_List atom in myProduction.AngleName)
            {
                inner += "<option value='" + atom.ItemID + "'>" + atom.ItemName + "</option>";
            }
            inner += "</select>";
            pAngle.InnerHtml = inner;

            inner = "桿身 :    <select>";
            foreach (sProduct_List atom in myProduction.GolfClubName)
            {
                inner += "<option value='" + atom.ItemID + "'>" + atom.ItemName + "</option>";
            }
            inner += "</select>";
            pGolfClub.InnerHtml = inner;

            inner = "硬度 :    <select>";
            foreach (sProduct_List atom in myProduction.GolfHardName)
            {
                inner += "<option value='" + atom.ItemID + "'>" + atom.ItemName + "</option>";
            }
            inner += "</select>";
            pGolfHard.InnerHtml = inner;


        }
        catch(Exception ee)
        {
            string error = ee.Message;
        }
        
    }
}
