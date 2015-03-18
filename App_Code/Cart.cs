using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.Common;
using System.Collections.Generic;

/// <summary>
/// Summary description for Cart
/// </summary>
public struct sOrderSelectList
{
    public string ID;
    public string Name;
}

public struct sOrderProduction
{
    public Int64 ProductionID;
    public int ProductionCounter;
    public sProduction ProductionInfo;
    public int Hand;
    public int Angle;
    public int GolfClub;
    public int GolfHand;
}
public struct sSenderInfo
{
    public string Order_Name;
    public string Order_Cellphone;
    public string Order_Phone;
    public string Order_Email;
}
public struct sReceiverInfo
{
    public string Receiver_Name	;
    public string Receiver_Phone;
    public string Receiver_Email;
    public string Receiver_City;
    public string Receiver_Town;
    public string Receiver_Zip;
    public string Receiver_Address;
}

public struct sOrder
{
    public string UserID;
    public string UserName;
    public string OrderTime;
    public string PayTime;
    public int PayWay;
    public int InvoiceWay;
    public sSenderInfo SenderInfo;
    public sReceiverInfo ReceiverInfo;
    public List<sOrderProduction> lProductions;
}
public class Cart
{
	public Cart()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int AddToCart(string UserName, sOrderProduction OrderProduction)
    {
        int returnvalue = 0;
        MemeberShipDA myMember = new MemeberShipDA();
        string UserID = myMember.getUserID(UserName);
        DataBase db = new DataBase();
        string sqlString = "insert into order_OrdersCart (UserID,ProductID,Counter,Hand,Angle,GolfClub,GolfHard)" +
        " values " +
        "(@UserID,@ProductID,@Counter,@Hand,@Angle,@GolfClub,@GolfHard)" +
        " SELECT @@identity ";
        DbCommand command = db.GetSqlStringCommond(sqlString);
        using (command.Connection)
        {
            db.AddInParameter(command, "@UserID", DbType.String, UserID);
            db.AddInParameter(command, "@ProductID", DbType.Int64, OrderProduction.ProductionID);
            db.AddInParameter(command, "@Counter", DbType.Int32, OrderProduction.ProductionCounter);

            db.AddInParameter(command, "@Hand", DbType.Int16, OrderProduction.Hand);
            db.AddInParameter(command, "@Angle", DbType.Int16, OrderProduction.Angle);
            db.AddInParameter(command, "@GolfClub", DbType.Int16, OrderProduction.GolfClub);
            db.AddInParameter(command, "@GolfHard", DbType.Int16, OrderProduction.GolfHand);
            returnvalue = db.ExecuteNonQuery(command);
        }
        if (returnvalue > 0)
        {
            returnvalue = CartCounterByUserID(UserID);
        }
        return returnvalue;
    }
    public List<sOrderProduction> CartProductionInfoByUserID(string UserID)
    {
        List<sOrderProduction> returnvalue = new List<sOrderProduction>();
        sOrderProduction myCartProdction = new sOrderProduction();
        DataBase db = new DataBase();
        string sqlString = "select count(*) from order_OrdersCart where UserID=@UserID";
        DbCommand command = db.GetSqlStringCommond(sqlString);
        db.AddInParameter(command, "@UserID", DbType.String, UserID);
        using (command.Connection)
        {
            DbDataReader dr = db.ExecuteReader(command);
            myCartProdction.ProductionID = Int64.Parse(dr["ProductID"].ToString());
            myCartProdction.ProductionCounter = int.Parse(dr["Counter"].ToString());
            returnvalue.Add(myCartProdction);
        }
        return returnvalue;
    }
    public int CartCounterByUserID(string UserID)
    {
        int returnvalue = 0;
        DataBase db = new DataBase();
        string sqlString = "select count(*) from order_OrdersCart where UserID=@UserID";
        DbCommand command = db.GetSqlStringCommond(sqlString);
        db.AddInParameter(command, "@UserID", DbType.String, UserID);
        using (command.Connection)
        {
            returnvalue = int.Parse(db.ExecuteScalar(command).ToString());
        }
        return returnvalue;
    }
    public string CreateOrder(sOrder myOrder)
    {
        string returnValue = "";

        return returnValue;
    }
    public List<sOrderSelectList> getTaiwanCityName()
    {
        List<sOrderSelectList> returnvalue = new List<sOrderSelectList>();
        sOrderSelectList mySelectList = new sOrderSelectList();
        DataBase db = new DataBase();
        string sqlString = "select * from system_TaiwanCityName";
        DbCommand command = db.GetSqlStringCommond(sqlString);
        using (command.Connection)
        {
            DbDataReader dr = db.ExecuteReader(command);
            while (dr.Read())
            {
                mySelectList.ID = dr["CityID"].ToString();
                mySelectList.Name = dr["CityName"].ToString();
                returnvalue.Add(mySelectList);
            }
            dr.Close();
        }
        return returnvalue;
    }
    public List<sOrderSelectList> getTaiwanTownName(int CityID)
    {
        List<sOrderSelectList> returnvalue = new List<sOrderSelectList>();
        sOrderSelectList mySelectList = new sOrderSelectList();
        DataBase db = new DataBase();
        string sqlString = "select * from system_TaiwanTownName where tCityID=@tCityID";
        DbCommand command = db.GetSqlStringCommond(sqlString);
        db.AddInParameter(command, "@tCityID", DbType.String, CityID);
        using (command.Connection)
        {
            DbDataReader dr = db.ExecuteReader(command);
            while (dr.Read())
            {
                mySelectList.ID = dr["tTownID"].ToString();
                mySelectList.Name = dr["tTownName"].ToString();
                returnvalue.Add(mySelectList);
            }
            dr.Close();
        }
        return returnvalue;
    }
}
