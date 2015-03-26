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

public partial class payment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!HttpContext.Current.User.Identity.IsAuthenticated)
        {
            Response.Redirect("./default.aspx", false);
        }

        theme mytheme = new theme();
        headerTop.InnerHtml = mytheme.getHeadertop();
        headerBottom.InnerHtml = mytheme.getHeaderbottom();
        footerDiv.InnerHtml = mytheme.getFooter();


        Cart myCart = new Cart();
        List<sOrderSelectList> list = myCart.getPaymentList();
        string inner = "";
        foreach (sOrderSelectList atom in list)
        {
            inner += "<label class='radio-inline' for='paytype" + atom.ID + "'>" + 
                            "<input type='radio' value='" + atom.ID + "' name='paytype' id='paytype" + atom.ID + "'>" +
                            atom.Name + 
                        "</label>";
        }
        PaymentWay.InnerHtml = inner;

        inner = "";
        list = myCart.getPaymentTimeZone();
        foreach (sOrderSelectList atom in list)
        {
            inner += "<label class='radio-inline' for='paytime" + atom.ID + "'>" + 
                            "<input type='radio' value='" + atom.ID + "' name='paytime' id='paytime" + atom.ID + "'> " +
                            atom.Name + 
                        "</label>";
        }
        receiverTime.InnerHtml = inner;

        list = myCart.getTaiwanCityName();

        foreach (sOrderSelectList atom in list)
        {
            cityName.Items.Add(new ListItem(atom.Name, atom.ID));
        }

        inner = "";
        list = myCart.getInvoiceWayList();
        foreach (sOrderSelectList atom in list)
        {
            inner += "<label class='radio-inline' for='InvoiceInfo" + atom.ID + "'>" +
                            "<input type='radio' value='" + atom.ID + "' name='InvoiceInfo' id='InvoiceInfo" + atom.ID + "'> " +
                            atom.Name +
                        "</label>";
        }
        InvoiceInfo.InnerHtml = inner;

        mMail.Value = HttpContext.Current.User.Identity.Name;
    }
}
