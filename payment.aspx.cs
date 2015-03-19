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
        string inner = "<ul class='list-inline'>";
        foreach (sOrderSelectList atom in list)
        {
            inner += "<li>" + 
                        "<label for='paytype" + atom.ID + "'>" + 
                            "<input type='radio' value='" + atom.ID + "' name='paytype' id='paytype" + atom.ID + "'>" +
                            atom.Name + 
                        "</label>" + 
                    "</li>";
        }
        PaymentWay.InnerHtml = inner + "</ul>";
        inner = "<ul class='list-inline'>";
        list = myCart.getPaymentTimeZone();
        foreach (sOrderSelectList atom in list)
        {
            inner += "<li>" + 
                        "<label for='paytime" + atom.ID + "'>" + 
                            "<input type='radio' value='" + atom.ID + "' name='paytime' id='paytime" + atom.ID + "'>" +
                            atom.Name + 
                        "</label>" + 
                    "</li>";
        }
        receiverTime.InnerHtml = inner + "</ul>";
        list = myCart.getTaiwanCityName();

        foreach (sOrderSelectList atom in list)
        {
            cityName.Items.Add(new ListItem(atom.Name, atom.ID));
        }
        inner = "<ul class='list-inline'>";
        list = myCart.getInvoiceWayList();
        foreach (sOrderSelectList atom in list)
        {
            inner += "<li>" +
                        "<label for='InvoiceInfo" + atom.ID + "'>" +
                            "<input type='radio' value='" + atom.ID + "' name='InvoiceInfo' id='InvoiceInfo" + atom.ID + "'>" +
                            atom.Name +
                        "</label>" +
                    "</li>";
        }
        InvoiceInfo.InnerHtml = inner + "</ul>";
        mMail.Value = HttpContext.Current.User.Identity.Name;
    }
}
