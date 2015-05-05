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

public partial class biddetail : System.Web.UI.Page
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
            left_menu.InnerHtml = mytheme.getBidLeftMenu(ID);
            footerDiv.InnerHtml = mytheme.getFooter();
            string inner = "";
            bidDB myStore = new bidDB();
            sBidItem myBidItem = myStore.searchBitItembyID(ID);
            inner = "<ul class='list-inline'>";
            foreach (string atom in myBidItem.ProductionPhoto)
            {
                // 加一個過濾無圖片資料的判斷
                if (!string.IsNullOrEmpty(atom) && atom != " ")
                {
                    inner += "<li><img src='./photos/production/" + atom + "' /></li>";
                }
            }
            inner += "</ul>";
            ImgIndex.InnerHtml = inner;
            if (myBidItem.ProductionPhoto.Count > 0)
                mainImg.InnerHtml = "<img id='productImgBig' src='./photos/production/" + myBidItem.ProductionPhoto[0] + "' />";
            
            fullintroduction.InnerHtml = myBidItem.FullIntro;
            MainTitle.InnerHtml = myBidItem.Name;
            pDescription.InnerHtml = myBidItem.Introduction;
            
            inner = "左/右手 : <select id='sHand'>";
            foreach (sProduct_List atom in myBidItem.HandName)
            {
                inner += "<option value='" + atom.ItemID + "'>" + atom.ItemName + "</option>";
            }
            inner += "</select>";
            pHand.InnerHtml = inner;

            inner = "角度 :    <select id='sAngle'>";
            foreach (sProduct_List atom in myBidItem.AngleName)
            {
                inner += "<option value='" + atom.ItemID + "'>" + atom.ItemName + "</option>";
            }
            inner += "</select>";
            pAngle.InnerHtml = inner;

            inner = "桿身 :    <select id='sGolfClub'>";
            foreach (sProduct_List atom in myBidItem.GolfClubName)
            {
                inner += "<option value='" + atom.ItemID + "'>" + atom.ItemName + "</option>";
            }
            inner += "</select>";
            pGolfClub.InnerHtml = inner;

            inner = "硬度 :    <select id='sGolfHard'>";
            foreach (sProduct_List atom in myBidItem.GolfHardName)
            {
                inner += "<option value='" + atom.ItemID + "'>" + atom.ItemName + "</option>";
            }
            inner += "</select>";
            pGolfHard.InnerHtml = inner;

            //pStartTime.InnerHtml = "開始時間：" + myBidItem.StartTime;
            pEndTime.InnerHtml = myBidItem.EndTime.ToString();
            pRecordCounter.InnerHtml = "出價次數：" + myBidItem.RecordCounter;

            pMaxBidPrice.InnerHtml = "<span>" + myBidItem.MaxBidPrice.ToString() + "</span>元";

            bidID.Value = ID;
            priceInterval.Value = myBidItem.PriceInterval;

        }
        catch (Exception ee)
        {
            string error = ee.Message;
        }

    }
}
