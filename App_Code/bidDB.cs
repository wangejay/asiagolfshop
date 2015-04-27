using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Common;
using System.Data;

/// <summary>
/// Summary description for bidDB
/// </summary>
public struct sBidItem
{
    public int ID;
    public string Name;
    public string StartPrice;
    public string Price;
    public string ProductionCategory;
    public string ProductionLevel;
    public string[] Hand;
    public string[] Angle;
    public string[] GolfClub;
    public string[] GolfHard;
    public List<sProduct_List> HandName;
    public List<sProduct_List> AngleName;
    public List<sProduct_List> GolfClubName;
    public List<sProduct_List> GolfHardName;
    public string Introduction;
    public string FullIntro;
    public List<string> ProductionPhoto;

    public string RecordCounter;
    public int MaxBidPrice;
    public string StartTime;
    public DateTime EndTime;
    //public string EndTime;
    public List<sBidRecord> lBidRecord;
    public string addPrice;
    public string isDelete;


}
public struct sBidRecord
{
    public string BidPrice;
    public string BidUserID;
    public string BidTime;
}

public class bidDB
{
    public List<object> searchBid(DTParameterModel ParameterModel)
    {
        List<object> returnvalue = new List<object>();
        string wheresql = " where 1=1";
        foreach(DTCondition myCondition in ParameterModel.Condition)
        {
            switch (myCondition.Name)
            {
                case "search_account":
                    if (myCondition.Value.Length > 0)
                    {
                        wheresql += " and A.ID = @" + myCondition.Name + " ";
                    }
                    break;
                case "search_name":
                    if (myCondition.Value.Length > 0)
                    {
                        wheresql += " and Name like @" + myCondition.Name + " ";
                    }
                    break;
                case "search_category":
                    if (myCondition.Value.Length > 0)
                    {
                        wheresql += " and Category = @" + myCondition.Name + " ";
                    }
                    break;
            }
        }
        DataBase db = new DataBase();
        string sqlString = "SELECT A.ID,A.Name,B.CategoryName FROM bid_Items A left join store_ProductCategory B on A.Category=B.ID " 
            + wheresql;
        DbCommand command = db.GetSqlStringCommond(sqlString);
        foreach (DTCondition myCondition in ParameterModel.Condition)
        {
            switch (myCondition.Name)
            {
                case "search_account":
                    if (myCondition.Value.Length > 0)
                    {
                        db.AddInParameter(command, "@" + myCondition.Name, DbType.Int64,  myCondition.Value );
                    }
                    break;
                case "search_name":
                    if (myCondition.Value.Length > 0)
                    {
                        db.AddInParameter(command, "@" + myCondition.Name, DbType.String, "%" + myCondition.Value + "%");
                    }
                    break;
                case "search_category":
                    if (myCondition.Value.Length > 0)
                    {
                        db.AddInParameter(command, "@" + myCondition.Name, DbType.Int16,  myCondition.Value);
                    }
                    break;
            }
        }
        
        DbDataReader dr= db.ExecuteReader(command);
        while (dr.Read())
        {
            string[] atom = { dr["ID"].ToString(), dr["Name"].ToString(), dr["CategoryName"].ToString(), 
                                "<a href='../manage/bid.aspx?id=" + dr["ID"].ToString() + "'>檢視</a>" };
            returnvalue.Add(atom);
        }
        dr.Close();
        command.Connection.Close();
        
        return returnvalue;
    }

    public List<sBidItem> searchBidItembyCateogry(string category)
    {
        List<sBidItem> returnValue = new List<sBidItem>();
        List<sBidItem> temp = new List<sBidItem>();
        sBidItem myBidItem = new sBidItem();
        DataBase db = new DataBase();
        string sqlString;
        if (category.Length == 0)
            sqlString = "select * from bid_Items where isDelete=0 order by ID desc";
        else
            sqlString = "select * from bid_Items where Category=@Category and isDelete=0 order by ID desc";

        DbCommand command = db.GetSqlStringCommond(sqlString);

        if (category.Length != 0)
            db.AddInParameter(command, "@Category", DbType.Int16, category);

        DbDataReader dr = db.ExecuteReader(command);

        while (dr.Read())
        {
            myBidItem.ID = int.Parse(dr["ID"].ToString());
            myBidItem.Name = dr["Name"].ToString();
            myBidItem.Price = dr["Price"].ToString();
            myBidItem.ProductionCategory = dr["Category"].ToString();
            myBidItem.ProductionLevel = dr["ProductLevel"].ToString();
            myBidItem.Introduction = dr["Introduction"].ToString();
            myBidItem.FullIntro = dr["HTML"].ToString();
            //myBidItem.Hand = dr["Hand"].ToString();
            //myBidItem.Angle = dr["Angle"].ToString();
            //myBidItem.GolfClub = dr["GolfClub"].ToString();
            //myBidItem.GolfHard = dr["HardLevel"].ToString();
            //myBidItem.ProductionPhoto = dr["ProductionPhoto"].ToString();
            myBidItem.ProductionPhoto = new List<string>();
            myBidItem.ProductionPhoto.Add(dr["ProductionPhoto0"].ToString());
            myBidItem.ProductionPhoto.Add(dr["ProductionPhoto1"].ToString());
            myBidItem.ProductionPhoto.Add(dr["ProductionPhoto2"].ToString());
            myBidItem.ProductionPhoto.Add(dr["ProductionPhoto3"].ToString());
            myBidItem.ProductionPhoto.Add(dr["ProductionPhoto4"].ToString());

            myBidItem.StartTime = dr["StartTime"].ToString();
            //myBidItem.EndTime = dr["EndTime"].ToString();
            myBidItem.EndTime = Convert.ToDateTime(dr["EndTime"]);
            myBidItem.isDelete = dr["isDelete"].ToString();

            temp.Add(myBidItem);
        }

        dr.Close();

        foreach (sBidItem atom in temp)
        {
            myBidItem.ID = atom.ID;
            myBidItem.Name = atom.Name;
            myBidItem.Price = atom.Price;
            myBidItem.ProductionCategory = atom.ProductionCategory;
            myBidItem.ProductionLevel = atom.ProductionLevel;
            myBidItem.Introduction = atom.Introduction;
            myBidItem.FullIntro = atom.FullIntro;
            myBidItem.ProductionPhoto = atom.ProductionPhoto;
            
            myBidItem.EndTime = atom.EndTime;

            myBidItem.RecordCounter = getRecordCounter(atom.ID);
            myBidItem.MaxBidPrice = getMaxBidPrice(atom.ID);

            if (myBidItem.MaxBidPrice <= 0){
                myBidItem.MaxBidPrice = int.Parse(atom.Price);
            }

            myBidItem.isDelete = atom.isDelete;

            returnValue.Add(myBidItem);
        }

        return returnValue;
    }

    private string getRecordCounter(int ID)
    {
        string sqlString;
        DataBase db = new DataBase();

        sqlString = "SELECT COUNT(ProductID) FROM bid_Record WHERE ProductID=@ID";
        DbCommand command = db.GetSqlStringCommond(sqlString);
        db.AddInParameter(command, "@ID", DbType.Int16, ID);
        int dr =(int) db.ExecuteScalar(command);
  
        return dr.ToString();
    }


    private int getMaxBidPrice(int ID)
    {
        string sqlString;
        DataBase db = new DataBase();

        sqlString = "SELECT MAX(BidPrice) FROM bid_Record WHERE ProductID=@ID";
        DbCommand command = db.GetSqlStringCommond(sqlString);
        db.AddInParameter(command, "@ID", DbType.Int16, ID);
        int dr = (int) db.ExecuteNonQuery(command);

        return dr;
    }

    public sBidItem searchBitItembyID(string id)
    {
        List<sBidItem> returnValue = new List<sBidItem>();
        List<sBidItem> temp = new List<sBidItem>();
        sBidItem myBidItem = new sBidItem();
        DataBase db = new DataBase();
        string sqlString = "select * from bid_Items where ID=@ID order by ID desc";
        DbCommand command = db.GetSqlStringCommond(sqlString);
        db.AddInParameter(command, "@ID", DbType.Int32, id);
        DbDataReader dr = db.ExecuteReader(command);
        while (dr.Read())
        {
            myBidItem.ID = int.Parse(dr["ID"].ToString());
            myBidItem.Name = dr["Name"].ToString();
            myBidItem.Price = dr["Price"].ToString();
            myBidItem.ProductionCategory = dr["Category"].ToString();
            myBidItem.ProductionLevel = dr["ProductLevel"].ToString();
            myBidItem.Introduction = dr["Introduction"].ToString();
            myBidItem.FullIntro = dr["HTML"].ToString();
            //myBidItem.Hand = dr["Hand"].ToString();
            //myBidItem.Angle = dr["Angle"].ToString();
            //myBidItem.GolfClub = dr["GolfClub"].ToString();
            //myBidItem.GolfHard = dr["HardLevel"].ToString();
            //myBidItem.ProductionPhoto = dr["ProductionPhoto"].ToString();
            
            List<sProduct_List> totalListItem = getHandInfo(myBidItem.ID);
            myBidItem.Hand = getMultiSettingItemID(totalListItem, "hand");
            myBidItem.HandName = getMultiSettingItemName(totalListItem, "hand");
            myBidItem.Angle = getMultiSettingItemID(totalListItem, "angle");
            myBidItem.AngleName = getMultiSettingItemName(totalListItem, "angle");
            myBidItem.GolfClub = getMultiSettingItemID(totalListItem, "golfclub");
            myBidItem.GolfClubName = getMultiSettingItemName(totalListItem, "golfclub");
            myBidItem.GolfHard = getMultiSettingItemID(totalListItem, "hardness");
            myBidItem.GolfHardName = getMultiSettingItemName(totalListItem, "hardness");

            myBidItem.ProductionPhoto = new List<string>();
            myBidItem.ProductionPhoto.Add(dr["ProductionPhoto0"].ToString());
            myBidItem.ProductionPhoto.Add(dr["ProductionPhoto1"].ToString());
            myBidItem.ProductionPhoto.Add(dr["ProductionPhoto2"].ToString());
            myBidItem.ProductionPhoto.Add(dr["ProductionPhoto3"].ToString());
            myBidItem.ProductionPhoto.Add(dr["ProductionPhoto4"].ToString());

            myBidItem.StartTime = dr["StartTime"].ToString();
            //myBidItem.EndTime = dr["EndTime"].ToString();
            myBidItem.EndTime = Convert.ToDateTime(dr["EndTime"].ToString());
            myBidItem.isDelete = dr["isDelete"].ToString();

            
            temp.Add(myBidItem);
        }

        dr.Close();

        foreach (sBidItem atom in temp)
        {
            myBidItem.ID = atom.ID;
            myBidItem.Name = atom.Name;
            myBidItem.Price = atom.Price;
            myBidItem.ProductionCategory = atom.ProductionCategory;
            myBidItem.ProductionLevel = atom.ProductionLevel;
            myBidItem.Introduction = atom.Introduction;
            myBidItem.FullIntro = atom.FullIntro;
            myBidItem.ProductionPhoto = atom.ProductionPhoto;

            myBidItem.Hand = atom.Hand;
            myBidItem.HandName = atom.HandName;
            myBidItem.Angle = atom.Angle;
            myBidItem.AngleName = atom.AngleName;
            myBidItem.GolfClub = atom.GolfClub;
            myBidItem.GolfClubName = atom.GolfClubName;
            myBidItem.GolfHard = atom.GolfHard;
            myBidItem.GolfHardName = atom.GolfHardName;
            myBidItem.ProductionPhoto = atom.ProductionPhoto;

            myBidItem.StartTime = atom.StartTime;
            myBidItem.EndTime = atom.EndTime;

            myBidItem.RecordCounter = getRecordCounter(atom.ID);
            myBidItem.MaxBidPrice = getMaxBidPrice(atom.ID);

            myBidItem.isDelete = atom.isDelete;

            returnValue.Add(myBidItem);
        }
        command.Connection.Close();
        return myBidItem;
    }



    private List<sProduct_List> getHandInfo(Int64 BidID)
    {
        List<sProduct_List> returnvalue = new List<sProduct_List>();
        sProduct_List myList = new sProduct_List();
        DataBase db = new DataBase();
        string sqlString = "select A.ItemID,A.GroupName,B.ItemName from bid_Item_List A left join system_List B on " +
                           "(A.ItemID=B.ItemID and A.GroupName=B.GroupName) where A.BidID=@BidID";
        DbCommand command = db.GetSqlStringCommond(sqlString);
        db.AddInParameter(command, "@BidID", DbType.Int64, BidID);
        DbDataReader dr = db.ExecuteReader(command);
        while (dr.Read())
        {
            myList.ItemID = dr["ItemID"].ToString();
            myList.GroupName = dr["GroupName"].ToString();
            myList.ItemName = dr["ItemName"].ToString();
            returnvalue.Add(myList);
        }
        dr.Close();
        command.Connection.Close();
        return returnvalue;
    }
    private string[] getMultiSettingItemID(List<sProduct_List> totalListItem, string name)
    {
        List<string> tempString = new List<string>();
        foreach (sProduct_List atom in totalListItem)
        {
            if (atom.GroupName.Trim().ToLower() == name)
                tempString.Add(atom.ItemID);
        }
        string[] returnvalue = new string[tempString.Count];
        int counter = 0;
        foreach (string atom in tempString)
        {
            returnvalue[counter] = atom;
            counter++;
        }
        return returnvalue;
    }
    private List<sProduct_List> getMultiSettingItemName(List<sProduct_List> totalListItem, string name)
    {
        List<sProduct_List> returnvalue = new List<sProduct_List>();
        foreach (sProduct_List atom in totalListItem)
        {
            if (atom.GroupName.Trim().ToLower() == name)
            {
                returnvalue.Add(atom);
            }
        }

        return returnvalue;
    }
}
