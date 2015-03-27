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
    public Int64 ID;
    public Int64 ProductionID;
    public int ProductionCounter;
    public int ProductionPrice;
    //public sProduction ProductionInfo;
    public int Hand;
    public int Angle;
    public int GolfClub;
    public int GolfHand;
    public string HandName;
    public string AngleName;
    public string GolfClubName;
    public string GolfHandName;
    public string PhotoName;
    public string ProductionName;
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
    public Int16 Receiver_City;
    public Int16 Receiver_Town;
    public string Receiver_Zip;
    public string Receiver_Address;
}
public struct sInvoiceInfo
{
    public Int16 InvoiceWay;
    public string CompanyID;
    public string CompanyName;
}
public struct sOrder
{
    public string OrderID;
    public string UserID;
    public string UserName;
    public string OrderTime;
    public Int16 PayTime;
    public Int16 PayWay;
    public sInvoiceInfo InvoiceInfo;
    public sSenderInfo SenderInfo;
    public sReceiverInfo ReceiverInfo;
    public List<sOrderProduction> lProductions;
}
public class Cart
{
    public const string MessageSuccess = "success";
	public Cart()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public sOrder SearchOrder(int ID)
    {
        sOrder returnvalue = new sOrder();
        DataBase db = new DataBase();
        string sqlString = "select * from order_OrderInfo where ID=@ID";
        DbCommand command = db.GetSqlStringCommond(sqlString);
        db.AddInParameter(command, "@ID", DbType.Int32, ID);
        DbDataReader dr = db.ExecuteReader(command);
        returnvalue.SenderInfo = new sSenderInfo();
        while (dr.Read())
        {
            returnvalue.OrderID = dr["ID"].ToString();
            returnvalue.OrderTime = dr["OrderTime"].ToString();
            returnvalue.SenderInfo.Order_Name = dr["Order_Name"].ToString();
            returnvalue.SenderInfo.Order_Email = dr["Order_Email"].ToString();
            returnvalue.SenderInfo.Order_Phone = dr["Order_Phone"].ToString();
        }
        dr.Close();
        command.Connection.Close();
        return returnvalue;
    }
    //加到購物清單當中
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
    public int deleteCartProductionbyUserID(Int64 CartID, string UserID)
    {
        //DELETE FROM store_Production_List where ProductID = @ProductID; 
        int returnvalue = 0;
        DataBase db = new DataBase();
        string sqlString = "update order_OrdersCart set isDelete=1  where ID = @ID and UserID=@UserID";
        DbCommand command = db.GetSqlStringCommond(sqlString);
        db.AddInParameter(command, "@ID", DbType.Int64, CartID);
        db.AddInParameter(command, "@UserID", DbType.String, UserID);
        returnvalue = db.ExecuteNonQuery(command);
        command.Connection.Close();
        return returnvalue;

    }
    public int deleteCartProduction(int CartID, string UserName)
    {
        //DELETE FROM store_Production_List where ProductID = @ProductID; 
        MemeberShipDA myMember = new MemeberShipDA();
        string UserID = myMember.getUserID(UserName);
        return deleteCartProductionbyUserID(CartID, UserID);
    }
    public List<sOrderProduction> CartProductionInfoByUserName(string UserName)
    {
        MemeberShipDA myMember = new MemeberShipDA();
        string UserID = myMember.getUserID(UserName);
        return CartProductionInfoByUserID(UserID);
    }
    public List<sOrderProduction> CartProductionInfoByUserID(string UserID)
    {
        List<sOrderProduction> returnvalue = new List<sOrderProduction>();
        sOrderProduction myCartProdction = new sOrderProduction();
        DataBase db = new DataBase();
        string sqlString =
  "select A.*,B.ItemName as 'HandName',C.ItemName as 'AngleName',D.ItemName as 'GolfClubName',E.ItemName as 'GolfHardName', F.ProductionPhoto0" +
  ",F.Name as 'ProductionName', F.Price from order_OrdersCart A " +
  "left join system_List B on (A.Hand=B.ItemID and B.GroupName='hand' )" +
  "left join system_List C on (A.Angle=C.ItemID and C.GroupName='angle' )" +
  "left join system_List D on (A.GolfClub=D.ItemID and D.GroupName='golfClub' )" +
  "left join system_List E on (A.GolfHard=E.ItemID and E.GroupName='hardness' )" +
  "left join store_Production F on (A.ProductID=F.ID)" +
  "where (UserID=@UserID and isDelete=0)";
        DbCommand command = db.GetSqlStringCommond(sqlString);
        db.AddInParameter(command, "@UserID", DbType.String, UserID);
        using (command.Connection)
        {
            DbDataReader dr = db.ExecuteReader(command);
            while (dr.Read())
            {
                myCartProdction.ID = Int64.Parse(dr["ID"].ToString());
                myCartProdction.ProductionID = Int64.Parse(dr["ProductID"].ToString());
                myCartProdction.ProductionCounter = int.Parse(dr["Counter"].ToString());
                myCartProdction.Hand = int.Parse(dr["Hand"].ToString());
                myCartProdction.Angle = int.Parse(dr["Angle"].ToString());
                myCartProdction.GolfClub = int.Parse(dr["GolfClub"].ToString());
                myCartProdction.GolfHand = int.Parse(dr["GolfHard"].ToString());
                myCartProdction.HandName = dr["HandName"].ToString();
                myCartProdction.AngleName = dr["AngleName"].ToString();
                myCartProdction.GolfClubName = dr["GolfClubName"].ToString();
                myCartProdction.GolfHandName = dr["GolfHardName"].ToString();
                myCartProdction.PhotoName = dr["ProductionPhoto0"].ToString();
                myCartProdction.ProductionName = dr["ProductionName"].ToString();
                myCartProdction.ProductionPrice = int.Parse(dr["Price"].ToString());
                //
                returnvalue.Add(myCartProdction);
            }
            dr.Close();
        }
        return returnvalue;
    }
    public int CartCounterByUserID(string UserID)
    {
        int returnvalue = 0;
        DataBase db = new DataBase();
        string sqlString = "select count(*) from order_OrdersCart where (UserID=@UserID and isDelete=0)";
        DbCommand command = db.GetSqlStringCommond(sqlString);
        db.AddInParameter(command, "@UserID", DbType.String, UserID);
        using (command.Connection)
        {
            returnvalue = int.Parse(db.ExecuteScalar(command).ToString());
        }
        return returnvalue;
    }
    
    public List<object> SearchOrder(DTParameterModel ParameterModel)
    {
        List<object> returnvalue = new List<object>();
        string wheresql = " where 1=1";
        foreach (DTCondition myCondition in ParameterModel.Condition)
        {
            switch (myCondition.Name)
            {
                case "search_account":
                    if (myCondition.Value.Length > 0)
                    {
                        wheresql += " and A.ID = @" + myCondition.Name + " ";
                    }
                    break;
                case "search_OrderStatus":
                    if (myCondition.Value.Length > 0)
                    {
                       
                        wheresql += " and A.OrderStatus like @" + myCondition.Name + " ";
                    }
                    break;
            }
        }
        DataBase db = new DataBase();
        string sqlString = "select A.ID ,B.OrderStatus,A.Order_Name,"+
"(select COUNT(*) from order_OrderProduction where order_OrderProduction.OrderID=A.ID) as pCounter ,"+
"(select SUM(order_OrderProduction.Price) from order_OrderProduction where order_OrderProduction.OrderID=A.ID) as pTotalPrice " +
"from order_OrderInfo A left join order_OrderStatus B on A.OrderStatus=B.ID"  
            + wheresql;
        DbCommand command = db.GetSqlStringCommond(sqlString);
        foreach (DTCondition myCondition in ParameterModel.Condition)
        {
            switch (myCondition.Name)
            {
                case "search_account":
                    if (myCondition.Value.Length > 0)
                    {
                        db.AddInParameter(command, "@" + myCondition.Name, DbType.Int64, myCondition.Value);
                    }
                    break;
                case "search_OrderStatus":
                    if (myCondition.Value.Length > 0)
                    {
                        db.AddInParameter(command, "@" + myCondition.Name, DbType.String, "%" + myCondition.Value + "%");
                    }
                    break;
               
            }
        }

        DbDataReader dr = db.ExecuteReader(command);
        while (dr.Read())
        {
            string[] atom = { dr["ID"].ToString(), dr["OrderStatus"].ToString(), dr["Order_Name"].ToString(), dr["pCounter"].ToString(),
                                dr["pTotalPrice"].ToString(),
                                "<a href='../manage/order.aspx?id=" + dr["ID"].ToString() + "'>檢視</a>" };
            returnvalue.Add(atom);
        }
        dr.Close();
        command.Connection.Close();

        return returnvalue;
    }
    public string CreateOrder(sOrder myOrder, string UserName)
    {
        string returnValue = "";
       
        MemeberShipDA myMember = new MemeberShipDA();
        string UserID = myMember.getUserID(UserName);
        DataBase db = new DataBase();
        int orderID = 0;
        string sqlString =
            /*
            "insert into order_OrderInfo(UserID,PayWay,PayTime,InvoiceWay,CompanyID,CompanyName,Order_Name,Order_Phone)" +
       " values " +
       "(@UserID,@PayWay,@PayTime,@InvoiceWay,@CompanyID,@CompanyName,@Order_Name,@Order_Phone)" +
       " SELECT @@identity ";
          */
        "insert into order_OrderInfo(UserID,PayWay,PayTime,InvoiceWay,CompanyID,CompanyName,Order_Name,Order_Phone,Order_Email,Receiver_Name," +
        "Receiver_Phone,Receiver_Email,Receiver_City,Receiver_Town,Receiver_Address)" +
        " values " +
        "(@UserID,@PayWay,@PayTime,@InvoiceWay,@CompanyID,@CompanyName,@Order_Name,@Order_Phone,@Order_Email,@Receiver_Name,@Receiver_Phone,@Receiver_Email," +
        "@Receiver_City,@Receiver_Town,@Receiver_Address)" +
        " SELECT @@identity ";
           

        DbCommand command = db.GetSqlStringCommond(sqlString);
        using (command.Connection)
        {
            db.AddInParameter(command, "@UserID", DbType.String, UserID);
            db.AddInParameter(command, "@PayWay", DbType.Int32, myOrder.PayWay);
            db.AddInParameter(command, "@PayTime", DbType.Int32, myOrder.PayTime);
            db.AddInParameter(command, "@InvoiceWay", DbType.Int32, myOrder.InvoiceInfo.InvoiceWay);
            db.AddInParameter(command, "@CompanyID", DbType.String, myOrder.InvoiceInfo.CompanyID);
            db.AddInParameter(command, "@CompanyName", DbType.String, myOrder.InvoiceInfo.CompanyName);
            db.AddInParameter(command, "@Order_Name", DbType.String, myOrder.SenderInfo.Order_Name);
            db.AddInParameter(command, "@Order_Phone", DbType.String, myOrder.SenderInfo.Order_Phone);
           
            db.AddInParameter(command, "@Order_Email", DbType.String, myOrder.SenderInfo.Order_Email);
            db.AddInParameter(command, "@Receiver_Name", DbType.String, myOrder.ReceiverInfo.Receiver_Email);
            db.AddInParameter(command, "@Receiver_Phone", DbType.String, myOrder.ReceiverInfo.Receiver_Phone);
            db.AddInParameter(command, "@Receiver_Email", DbType.String, myOrder.ReceiverInfo.Receiver_Email);
            db.AddInParameter(command, "@Receiver_City", DbType.Int32, myOrder.ReceiverInfo.Receiver_City);
            db.AddInParameter(command, "@Receiver_Town", DbType.Int32, myOrder.ReceiverInfo.Receiver_Town);
            db.AddInParameter(command, "@Receiver_Address", DbType.String, myOrder.ReceiverInfo.Receiver_Address);
            
            orderID = int.Parse(db.ExecuteScalar(command).ToString());
        }
        List<sOrderProduction> ProductionInCart = CartProductionInfoByUserID(UserID);
        int intreturn = orderID;
        foreach (sOrderProduction atom in ProductionInCart)
        {
            intreturn = SetOrderProduction(atom, orderID);
            deleteCartProductionbyUserID(atom.ID, UserID);
        }

        if (intreturn > 0)
            returnValue = MessageSuccess;
        return returnValue;
    }
    private int SetOrderProduction(sOrderProduction atom,Int64 OrderID)
    {
        int returnvalue = 0;
        MemeberShipDA myMember = new MemeberShipDA();
       
        DataBase db = new DataBase();
        string sqlString = "insert into order_OrderProduction (OrderID,ProductID,Counter,Hand,Angle,GolfClub,GolfHard)" +
        " values " +
        "(@OrderID,@ProductID,@Counter,@Hand,@Angle,@GolfClub,@GolfHard)" +
        " SELECT @@identity ";
        DbCommand command = db.GetSqlStringCommond(sqlString);
        using (command.Connection)
        {
            db.AddInParameter(command, "@OrderID", DbType.String, OrderID);
            db.AddInParameter(command, "@ProductID", DbType.Int64, atom.ProductionID);
            db.AddInParameter(command, "@Counter", DbType.Int32, atom.ProductionCounter);

            db.AddInParameter(command, "@Hand", DbType.Int16, atom.Hand);
            db.AddInParameter(command, "@Angle", DbType.Int16, atom.Angle);
            db.AddInParameter(command, "@GolfClub", DbType.Int16, atom.GolfClub);
            db.AddInParameter(command, "@GolfHard", DbType.Int16, atom.GolfHand);
            returnvalue = db.ExecuteNonQuery(command);
        }
        
        return returnvalue;
      
    }
    public List<sOrderSelectList> getInvoiceWayList()
    {
        List<sOrderSelectList> returnvalue = new List<sOrderSelectList>();
        sOrderSelectList mySelectList = new sOrderSelectList();
        DataBase db = new DataBase();
        string sqlString = "select * from order_InvoiceWayList";
        DbCommand command = db.GetSqlStringCommond(sqlString);
        using (command.Connection)
        {
            DbDataReader dr = db.ExecuteReader(command);
            while (dr.Read())
            {
                mySelectList.ID = dr["ID"].ToString();
                mySelectList.Name = dr["InvoiceWay"].ToString();
                returnvalue.Add(mySelectList);
            }
            dr.Close();
        }
        return returnvalue;
    }
    public List<sOrderSelectList> getPaymentTimeZone()
    {
        List<sOrderSelectList> returnvalue = new List<sOrderSelectList>();
        sOrderSelectList mySelectList = new sOrderSelectList();
        DataBase db = new DataBase();
        string sqlString = "select * from order_PaymentTimeZone";
        DbCommand command = db.GetSqlStringCommond(sqlString);
        using (command.Connection)
        {
            DbDataReader dr = db.ExecuteReader(command);
            while (dr.Read())
            {
                mySelectList.ID = dr["ID"].ToString();
                mySelectList.Name = dr["PaymentTimeZone"].ToString();
                returnvalue.Add(mySelectList);
            }
            dr.Close();
        }
        return returnvalue;
    }
    public List<sOrderSelectList> getPaymentList()
    {
        List<sOrderSelectList> returnvalue = new List<sOrderSelectList>();
        sOrderSelectList mySelectList = new sOrderSelectList();
        DataBase db = new DataBase();
        string sqlString = "select * from order_PaymentList";
        DbCommand command = db.GetSqlStringCommond(sqlString);
        using (command.Connection)
        {
            DbDataReader dr = db.ExecuteReader(command);
            while (dr.Read())
            {
                mySelectList.ID = dr["ID"].ToString();
                mySelectList.Name = dr["PaymentName"].ToString();
                returnvalue.Add(mySelectList);
            }
            dr.Close();
        }
        return returnvalue;
    }
    public List<sOrderSelectList> getOrderStatus()
    {
        List<sOrderSelectList> returnvalue = new List<sOrderSelectList>();
        sOrderSelectList mySelectList = new sOrderSelectList();
        DataBase db = new DataBase();
        string sqlString = "select * from order_OrderStatus";
        DbCommand command = db.GetSqlStringCommond(sqlString);
        using (command.Connection)
        {
            DbDataReader dr = db.ExecuteReader(command);
            while (dr.Read())
            {
                mySelectList.ID = dr["ID"].ToString();
                mySelectList.Name = dr["OrderStatus"].ToString();
                returnvalue.Add(mySelectList);
            }
            dr.Close();
        }
        return returnvalue;
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
