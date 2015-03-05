using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Web.Security;
using System.Text;
using System.Globalization;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Collections.Generic;

/// <summary>
/// Summary description for AspAjax
/// </summary>
public struct createUser
{
    public string Email;
    public string Password;
    public string checkNo;
    public string errorMsg;
}
public struct dataTables
{
    public int draw;
    public int recordsTotal;
    public int recordsFiltered;
    public List<object> data;
}
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class AspAjax : System.Web.Services.WebService {

    public AspAjax () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }
    //20150208 aaron created
    [WebMethod]
    public void Logout()
    {
        if (HttpContext.Current.User.Identity.IsAuthenticated)
            FormsAuthentication.SignOut();
    }
    //20150208 aaron created
    [WebMethod]
    public string IsAuthenticated()
    {
        if (HttpContext.Current.User.Identity.IsAuthenticated)
            return HttpContext.Current.User.Identity.Name;
        else
            return "";
    }
    //20150207 aaron created
    [WebMethod]
    public bool CheckUserIDNotExit(string UserID)
    {
        //0 存在
        //1 不存在
        if (Membership.GetUser(UserID) != null)
            return true;
        else
            return false;
    }
    //20150207 aaron created
    [WebMethod(EnableSession = true)]
    public bool ValidateCheck(string validateWord)
    {
        if ((string)HttpContext.Current.Session["ValidateCode"] == validateWord)
            return true;
        else
            return false;
    }
    //20150207 aaron created
    [WebMethod]
    public string CreateUserMember(createUser StructureData)
    {
        System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();//引用stopwatch物件
        sw.Reset();//碼表歸零
        sw.Start();//碼表開始計時
        string CreateMessage = string.Empty;
        object ouser = null;
        MembershipCreateStatus msCrCreateStatus;
        try
        {
            Membership.CreateUser(StructureData.Email, StructureData.Password, StructureData.Email, null, null, true, ouser, out msCrCreateStatus);
            CreateMessage = msCrCreateStatus.ToString();
            /*
            if (CreateMessage == "Success")
            {
                MemeberShipDA DA = new MemeberShipDA();
                createUserInterview StructureData2 = new createUserInterview();
                CreateMessage =DA.setUserProfile(StructureData, StructureData2);
            }
            */

        }
        catch (Exception ee)
        {
            CreateMessage = ee.ToString();
        }
        sw.Stop();//碼錶停止

        //印出所花費的總豪秒數
        string result1 = sw.Elapsed.TotalMilliseconds.ToString();
        return CreateMessage;
    }
    //20150209 created by aaron
    [WebMethod]
    [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
    public void searchMember()
    {
        this.Context.Response.ContentType = "application/json";
        DTModelBinder Binder = new DTModelBinder();
        DTParameterModel ParameterModel = (DTParameterModel)Binder.BindModel(HttpContext.Current.Request);
        dataTables returnvalue = new dataTables();

        MemeberShipDA cMemeberShip = new MemeberShipDA();
        returnvalue.data=cMemeberShip.searchMemberData(ParameterModel);
        returnvalue.draw = ParameterModel.Draw;
        returnvalue.recordsTotal = returnvalue.data.Count;
        returnvalue.recordsFiltered = returnvalue.data.Count;
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        this.Context.Response.Write(serializer.Serialize(returnvalue));
        //string[] weekDays = { "Sun", "Mon", "Tue", "Wed", "<button>編輯</button>" };
    }
}

