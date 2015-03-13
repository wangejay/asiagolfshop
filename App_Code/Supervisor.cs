using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Web.Script.Services;
using System.Web.Script.Serialization;

/// <summary>
/// Summary description for Supervisor
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
 [System.Web.Script.Services.ScriptService]
public class Supervisor : System.Web.Services.WebService {
    public bool Authenticated = false;
    public bool InAdminRoles = false;
    public const int Message_NoAuth = -1;
    public Supervisor () {
        Authenticated = HttpContext.Current.User.Identity.IsAuthenticated;
        InAdminRoles = HttpContext.Current.User.IsInRole("admin");
        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    //20150209 created by aaron
    [WebMethod]
    [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
    public void searchMember()
    {
        if (!Authenticated || !InAdminRoles)
        {
            return;
        }
        this.Context.Response.ContentType = "application/json";
        DTModelBinder Binder = new DTModelBinder();
        DTParameterModel ParameterModel = (DTParameterModel)Binder.BindModel(HttpContext.Current.Request);
        dataTables returnvalue = new dataTables();

        MemeberShipDA cMemeberShip = new MemeberShipDA();
        returnvalue.data = cMemeberShip.searchMemberData(ParameterModel);
        returnvalue.draw = ParameterModel.Draw;
        returnvalue.recordsTotal = returnvalue.data.Count;
        returnvalue.recordsFiltered = returnvalue.data.Count;
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        this.Context.Response.Write(serializer.Serialize(returnvalue));
        //string[] weekDays = { "Sun", "Mon", "Tue", "Wed", "<button>編輯</button>" };
    }
    [WebMethod]
    [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
    public void SearchProduct()
    {
        if (!Authenticated || !InAdminRoles)
        {
            return;
        }
        this.Context.Response.ContentType = "application/json";
        DTModelBinder Binder = new DTModelBinder();
        DTParameterModel ParameterModel = (DTParameterModel)Binder.BindModel(HttpContext.Current.Request);
        dataTables returnvalue = new dataTables();

        StoreDB myStore = new StoreDB();
        returnvalue.data = myStore.searchProduct(ParameterModel);
        returnvalue.draw = ParameterModel.Draw;
        returnvalue.recordsTotal = returnvalue.data.Count;
        returnvalue.recordsFiltered = returnvalue.data.Count;
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        this.Context.Response.Write(serializer.Serialize(returnvalue));
        //string[] weekDays = { "Sun", "Mon", "Tue", "Wed", "<button>編輯</button>" };

    }
    
    [WebMethod]
    public string UpdateProduction(sProduction obj)
    {
        //return "1";
        string returnValue = "";
        if (!Authenticated || !InAdminRoles)
            returnValue = Message_NoAuth.ToString();
        else
        {
            StoreDB myStore = new StoreDB();
            returnValue = myStore.UpdateProduction(obj);
            if (int.Parse(returnValue) >= 1)
                returnValue = obj.ID.ToString();
        }
        return returnValue;
    }
    [WebMethod]
    public string CreateProduction(sProduction obj)
    {
        //return "1";
        string returnValue = "";
        if (!Authenticated || !InAdminRoles)
            returnValue = Message_NoAuth.ToString();
        else
        {
            StoreDB myStore = new StoreDB();
            returnValue = myStore.CreateProduction(obj);
        }
        return returnValue;
    }
    [WebMethod]
    public string CreateCategory(string category)
    {
        string returnValue = "";
        if (!Authenticated || !InAdminRoles)
            returnValue = Message_NoAuth.ToString();
        else
        {
            StoreDB myStore = new StoreDB();
            returnValue = myStore.CreateProductionCategory(category);
        }
        return returnValue;
    }
    [WebMethod]
    public string PauseCategory(string CategoryID)
    {
        string returnValue = "";
        if (!Authenticated || !InAdminRoles)
            returnValue = Message_NoAuth.ToString();
        else
        {
            StoreDB myStore = new StoreDB();
            returnValue = myStore.PauseCategory(CategoryID,true);
        }
        return returnValue;
    }
    [WebMethod]
    public string RestartCategory(string CategoryID)
    {
        string returnValue = "";
        if (!Authenticated || !InAdminRoles)
            returnValue = Message_NoAuth.ToString();
        else
        {
            StoreDB myStore = new StoreDB();
            returnValue = myStore.PauseCategory(CategoryID, false);
        }
        return returnValue;
    }
    [WebMethod]
    public string DeleteCategory(string CategoryID)
    {
        string returnValue = "";
        if (!Authenticated || !InAdminRoles)
            returnValue = Message_NoAuth.ToString();
        else
        {
            StoreDB myStore = new StoreDB();
            returnValue = myStore.DeleteCategory(CategoryID);
        }
        return returnValue;
    }
    
    
    
}

