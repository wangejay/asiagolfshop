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
/// Summary description for StoreDB
/// </summary>
public struct sProduction
{
    public int ID;
    public string Name;
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
}
public struct sProductionCategory
{
    public int ID;
    public string CategoryName;
    public string isPause;
}
public struct sProduct_List
{
    public string ItemID;
    public string ItemName;
    public string GroupName;
}
public class StoreDB
{
    public const string MessageSuccess = "success";
	public StoreDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public string CreateProduction(sProduction obj)
    {
        string success = "";
        DataBase db = new DataBase();
        string sqlString = "insert into store_Production (Name,Price,Category,ProductLevel,Introduction,HTML)" +
        " values " +
        "(@Name,@Price,@Category,@ProductLevel,@Introduction,@HTML)" +
        " SELECT @@identity ";
        DbCommand command = db.GetSqlStringCommond(sqlString);
        db.AddInParameter(command, "@Name", DbType.String, obj.Name);
        db.AddInParameter(command, "@Price", DbType.Int32, obj.Price);
        db.AddInParameter(command, "@Category", DbType.Int16, obj.ProductionCategory);
        db.AddInParameter(command, "@ProductLevel", DbType.Int16, obj.ProductionLevel);
        db.AddInParameter(command, "@Introduction", DbType.String, obj.Introduction);
        db.AddInParameter(command, "@HTML", DbType.String, obj.FullIntro);

        //db.AddInParameter(command, "@Hand", DbType.Int16, obj.Hand);
        //db.AddInParameter(command, "@Angle", DbType.Int32, obj.Angle);
        //db.AddInParameter(command, "@GolfClub", DbType.Int16, obj.GolfClub);
        //db.AddInParameter(command, "@HardLevel", DbType.Int16, obj.GolfHard);
       
        success = db.ExecuteScalar(command).ToString();
        
        for (int i = 0; i < obj.Angle.Length; i++)
        {
            SetListinDB(success, "angle", obj.Angle[i]);
        }
        for (int i = 0; i < obj.Hand.Length; i++)
        {
            SetListinDB(success, "hand", obj.Hand[i]);
        }
        for (int i = 0; i < obj.GolfClub.Length; i++)
        {
            SetListinDB(success, "golfClub", obj.GolfClub[i]);
        }
        for (int i = 0; i < obj.GolfHard.Length; i++)
        {
            SetListinDB(success, "hardness", obj.GolfHard[i]);
        }

        return success;
    }
    
    private string DeleteListinDB(Int64 ProductID)
    {
        //DELETE FROM store_Production_List where ProductID = @ProductID; 
        string returnvalue = "";
        DataBase db = new DataBase();
        string sqlString = "DELETE FROM store_Production_List where ProductID = @ProductID";
        DbCommand command = db.GetSqlStringCommond(sqlString);
        db.AddInParameter(command, "@ProductID", DbType.Int64, ProductID);
        returnvalue = db.ExecuteNonQuery(command).ToString();
        return returnvalue;
    }
    private string SetListinDB(string ProductID, string GroupName, string ItemID)
    {
        string returnvalue = "";
        DataBase db = new DataBase();
        string sqlString = "insert into store_Production_List (ProductID,GroupName,ItemID) values(@ProductID,@GroupName,@ItemID)";
        DbCommand command = db.GetSqlStringCommond(sqlString);
        db.AddInParameter(command, "@ProductID", DbType.Int64, ProductID);
        db.AddInParameter(command, "@GroupName", DbType.String, GroupName);
        db.AddInParameter(command, "@ItemID", DbType.Int32, ItemID);
        returnvalue = db.ExecuteNonQuery(command).ToString();
        return returnvalue;
    }
    public string UpdateProduction(sProduction obj)
    {
        string success = "";
        DataBase db = new DataBase();
       
        string sqlString = "update store_Production set Name=@Name,Price=@Price,Category=@Category,ProductLevel=@ProductLevel," +
        "Introduction=@Introduction,HTML=@HTML" +
        " where ID=@ID ";
        DbCommand command = db.GetSqlStringCommond(sqlString);
        db.AddInParameter(command, "@ID", DbType.Int32, obj.ID);
        db.AddInParameter(command, "@Name", DbType.String, obj.Name);
        db.AddInParameter(command, "@Price", DbType.Int32, obj.Price);
        db.AddInParameter(command, "@Category", DbType.Int16, obj.ProductionCategory);
        db.AddInParameter(command, "@ProductLevel", DbType.Int16, obj.ProductionLevel);
        db.AddInParameter(command, "@Introduction", DbType.String, obj.Introduction);
        db.AddInParameter(command, "@HTML", DbType.String, obj.FullIntro);
       
        success = db.ExecuteNonQuery(command).ToString();
        //success = db.ExecuteScalar(command).ToString();
        DeleteListinDB(obj.ID);
        for (int i = 0; i < obj.Angle.Length; i++)
        {
            SetListinDB(obj.ID.ToString(), "angle", obj.Angle[i]);
        }
        for (int i = 0; i < obj.Hand.Length; i++)
        {
            SetListinDB(obj.ID.ToString(), "hand", obj.Hand[i]);
        }
        for (int i = 0; i < obj.GolfClub.Length; i++)
        {
            SetListinDB(obj.ID.ToString(), "golfClub", obj.GolfClub[i]);
        }
        for (int i = 0; i < obj.GolfHard.Length; i++)
        {
            SetListinDB(obj.ID.ToString(), "hardness", obj.GolfHard[i]);
        }
        return success;
    }
    
    public List<object> searchProduct(DTParameterModel ParameterModel)
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
        string sqlString = "SELECT A.ID,A.Name,B.CategoryName FROM store_Production A left join store_ProductCategory B on A.Category=B.ID " 
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
                                "<a href='../manage/product.aspx?id=" + dr["ID"].ToString() + "'>檢視</a>" };
            returnvalue.Add(atom);
        }
        dr.Close();
        command.Connection.Close();
        
        return returnvalue;
    }
    public sProduction selectProduction(int pID)
    {
        sProduction myProduction = new sProduction();
        DataBase db = new DataBase();
        string sqlString = "select * from store_Production where ID=@ID";
        DbCommand command = db.GetSqlStringCommond(sqlString);
        db.AddInParameter(command, "@ID", DbType.Int32, pID);
        DbDataReader dr = db.ExecuteReader(command);
        while (dr.Read())
        {
            myProduction.ID = int.Parse(dr["ID"].ToString());
            myProduction.Name = dr["Name"].ToString();
            myProduction.Price = dr["Price"].ToString();
            myProduction.ProductionCategory = dr["Category"].ToString();
            myProduction.ProductionLevel = dr["ProductLevel"].ToString();
            myProduction.Introduction = dr["Introduction"].ToString();
            myProduction.FullIntro = dr["HTML"].ToString();
            //myProduction.Hand = dr["Hand"].ToString();
            //myProduction.Angle = dr["Angle"].ToString();
            //myProduction.GolfClub = dr["GolfClub"].ToString();
            //myProduction.GolfHard = dr["HardLevel"].ToString();
            //myProduction.ProductionPhoto = dr["ProductionPhoto"].ToString();
            myProduction.ProductionPhoto = new List<string>();
            myProduction.ProductionPhoto.Add(dr["ProductionPhoto0"].ToString());
            myProduction.ProductionPhoto.Add(dr["ProductionPhoto1"].ToString());
            myProduction.ProductionPhoto.Add(dr["ProductionPhoto2"].ToString());
            myProduction.ProductionPhoto.Add(dr["ProductionPhoto3"].ToString());
            myProduction.ProductionPhoto.Add(dr["ProductionPhoto4"].ToString());
           

        }
        dr.Close();
        List<sProduct_List> totalListItem = getHandInfo(myProduction.ID);
        myProduction.Hand = getMultiSettingItemID(totalListItem, "hand");
        myProduction.HandName = getMultiSettingItemName(totalListItem, "hand");
        myProduction.Angle = getMultiSettingItemID(totalListItem, "angle");
        myProduction.AngleName = getMultiSettingItemName(totalListItem, "angle");
        myProduction.GolfClub = getMultiSettingItemID(totalListItem, "golfclub");
        myProduction.GolfClubName = getMultiSettingItemName(totalListItem, "golfclub");
        myProduction.GolfHard = getMultiSettingItemID(totalListItem, "hardness");
        myProduction.GolfHardName = getMultiSettingItemName(totalListItem, "hardness");

        return myProduction;
    }

    private string[] getMultiSettingItemID(List<sProduct_List> totalListItem,string name)
    {
    //string[] returnvalue= new string[10];
        List<string> tempString = new List<string>();
        foreach(sProduct_List atom in totalListItem)
        {
            if (atom.GroupName.Trim().ToLower() == name)
                tempString.Add(atom.ItemID);
        }
        string[] returnvalue = new string[tempString.Count];
        int counter=0;
        foreach (string atom in tempString)
        {
            returnvalue[counter] = atom;
            counter++;
        }
        return returnvalue;
    }
    private List<sProduct_List> getMultiSettingItemName(List<sProduct_List> totalListItem, string name)
    {
        //string[] returnvalue= new string[10];
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
    private List<string> getProductionPhoto(Int64 ProductID)
    {
        List<string> returnvalue = new List<string>();
        DataBase db = new DataBase();
        string sqlString = "select ProductionPhoto from store_Production_Photo where ProductID=@ProductID";
        DbCommand command = db.GetSqlStringCommond(sqlString);
        db.AddInParameter(command, "@ProductID", DbType.Int64, ProductID);
        DbDataReader dr = db.ExecuteReader(command);
        while (dr.Read())
        {
            returnvalue.Add(dr["ProductionPhoto"].ToString());
        }
        dr.Close();
        return returnvalue;
    }
    private List<sProduct_List> getHandInfo(Int64 ProductID)
    {
        List<sProduct_List> returnvalue = new List<sProduct_List>();
        sProduct_List myList = new sProduct_List();
        DataBase db = new DataBase();
        string sqlString = "select A.ItemID,A.GroupName,B.ItemName from store_Production_List A left join system_List B on "+
            "(A.ItemID=B.ItemID and A.GroupName=B.GroupName)  where ProductID=@ProductID";
        DbCommand command = db.GetSqlStringCommond(sqlString);
        db.AddInParameter(command, "@ProductID", DbType.Int64, ProductID);
        DbDataReader dr = db.ExecuteReader(command);
        while (dr.Read())
        {
            myList.ItemID = dr["ItemID"].ToString();
            myList.GroupName = dr["GroupName"].ToString();
            myList.ItemName = dr["ItemName"].ToString();
            returnvalue.Add(myList);
        }
        return returnvalue;
    }
    public List<sProduction> searchProductionbyCateogry(string category)
    {
        List<sProduction> returnValue = new List<sProduction>();
        List<sProduction> temp = new List<sProduction>();
        sProduction myProduction = new sProduction();
        DataBase db = new DataBase();
        string sqlString;
        if(category.Length==0)
            sqlString = "select * from store_Production  order by ID desc";
        else
            sqlString = "select * from store_Production where Category=@Category order by ID desc";
        DbCommand command = db.GetSqlStringCommond(sqlString);
        if (category.Length != 0)
            db.AddInParameter(command, "@Category", DbType.Int16, category);
        DbDataReader dr = db.ExecuteReader(command);
        while (dr.Read())
        {
            myProduction.ID = int.Parse(dr["ID"].ToString());
            myProduction.Name = dr["Name"].ToString();
            myProduction.Price = dr["Price"].ToString();
            myProduction.ProductionCategory = dr["Category"].ToString();
            myProduction.ProductionLevel = dr["ProductLevel"].ToString();
            myProduction.Introduction = dr["Introduction"].ToString();
            myProduction.FullIntro = dr["HTML"].ToString();
            //myProduction.Hand = dr["Hand"].ToString();
            //myProduction.Angle = dr["Angle"].ToString();
            //myProduction.GolfClub = dr["GolfClub"].ToString();
            //myProduction.GolfHard = dr["HardLevel"].ToString();
            //myProduction.ProductionPhoto = dr["ProductionPhoto"].ToString();
            myProduction.ProductionPhoto = new List<string>();
            myProduction.ProductionPhoto.Add(dr["ProductionPhoto0"].ToString());
            myProduction.ProductionPhoto.Add(dr["ProductionPhoto1"].ToString());
            myProduction.ProductionPhoto.Add(dr["ProductionPhoto2"].ToString());
            myProduction.ProductionPhoto.Add(dr["ProductionPhoto3"].ToString());
            myProduction.ProductionPhoto.Add(dr["ProductionPhoto4"].ToString());
            returnValue.Add(myProduction);
        }
        dr.Close();
        
        return returnValue;
    }
    public sProduction searchProductionbyID(string id)
    {
        
        sProduction myProduction = new sProduction();
        DataBase db = new DataBase();
        string sqlString = "select * from store_Production where ID=@ID order by ID desc";
        DbCommand command = db.GetSqlStringCommond(sqlString);
        db.AddInParameter(command, "@ID", DbType.Int32, id);
        DbDataReader dr = db.ExecuteReader(command);
        while (dr.Read())
        {
            myProduction.ID = int.Parse(dr["ID"].ToString());
            myProduction.Name = dr["Name"].ToString();
            myProduction.Price = dr["Price"].ToString();
            myProduction.ProductionCategory = dr["Category"].ToString();
            myProduction.ProductionLevel = dr["ProductLevel"].ToString();
            myProduction.Introduction = dr["Introduction"].ToString();
            myProduction.FullIntro = dr["HTML"].ToString();
            //myProduction.Hand = dr["Hand"].ToString();
            //myProduction.Angle = dr["Angle"].ToString();
            //myProduction.GolfClub = dr["GolfClub"].ToString();
            //myProduction.GolfHard = dr["HardLevel"].ToString();
            //myProduction.ProductionPhoto = dr["ProductionPhoto"].ToString();
            List<sProduct_List> totalListItem = getHandInfo(myProduction.ID);
            myProduction.Hand = getMultiSettingItemID(totalListItem, "hand");
            myProduction.HandName = getMultiSettingItemName(totalListItem, "hand");
            myProduction.Angle = getMultiSettingItemID(totalListItem, "angle");
            myProduction.AngleName = getMultiSettingItemName(totalListItem, "angle");
            myProduction.GolfClub = getMultiSettingItemID(totalListItem, "golfclub");
            myProduction.GolfClubName = getMultiSettingItemName(totalListItem, "golfclub");
            myProduction.GolfHard = getMultiSettingItemID(totalListItem, "hardness");
            myProduction.GolfHardName = getMultiSettingItemName(totalListItem, "hardness");
            myProduction.ProductionPhoto = new List<string>();
            myProduction.ProductionPhoto.Add(dr["ProductionPhoto0"].ToString());
            myProduction.ProductionPhoto.Add(dr["ProductionPhoto1"].ToString());
            myProduction.ProductionPhoto.Add(dr["ProductionPhoto2"].ToString());
            myProduction.ProductionPhoto.Add(dr["ProductionPhoto3"].ToString());
            myProduction.ProductionPhoto.Add(dr["ProductionPhoto4"].ToString());

          
        }
        dr.Close();
        return myProduction;
    }
    public List<sProduction> searchProduction(int counter)
    {
        List<sProduction> returnValue = new List<sProduction>();
        List<sProduction> temp = new List<sProduction>();
        sProduction myProduction = new sProduction();
        DataBase db = new DataBase();
        string sqlString = "select top " + counter.ToString() + " * from store_Production order by ID desc";
        DbCommand command = db.GetSqlStringCommond(sqlString);
        DbDataReader dr = db.ExecuteReader(command);
        while (dr.Read())
        {
            myProduction.ID = int.Parse(dr["ID"].ToString());
            myProduction.Name = dr["Name"].ToString();
            myProduction.Price = dr["Price"].ToString();
            myProduction.ProductionCategory = dr["Category"].ToString();
            myProduction.ProductionLevel = dr["ProductLevel"].ToString();
            myProduction.Introduction = dr["Introduction"].ToString();
            myProduction.FullIntro = dr["HTML"].ToString();
            //myProduction.Hand = dr["Hand"].ToString();
            //myProduction.Angle = dr["Angle"].ToString();
            //myProduction.GolfClub = dr["GolfClub"].ToString();
            //myProduction.GolfHard = dr["HardLevel"].ToString();
            //myProduction.ProductionPhoto = dr["ProductionPhoto"].ToString();
            //myProduction.ProductionPhoto = getProductionPhoto(myProduction.ID);
            myProduction.ProductionPhoto = new List<string>();
            myProduction.ProductionPhoto.Add(dr["ProductionPhoto0"].ToString());
            myProduction.ProductionPhoto.Add(dr["ProductionPhoto1"].ToString());
            myProduction.ProductionPhoto.Add(dr["ProductionPhoto2"].ToString());
            myProduction.ProductionPhoto.Add(dr["ProductionPhoto3"].ToString());
            myProduction.ProductionPhoto.Add(dr["ProductionPhoto4"].ToString());
            returnValue.Add(myProduction);
        }
        dr.Close();
        return returnValue;
    }
    public List<sProduction> searchProduction()
    {
        List<sProduction> returnValue = new List<sProduction>();
        List<sProduction> temp = new List<sProduction>();
        sProduction myProduction = new sProduction();
        DataBase db = new DataBase();
        string sqlString = "select  * from store_Production order by ID desc";
        DbCommand command = db.GetSqlStringCommond(sqlString);
        DbDataReader dr = db.ExecuteReader(command);
        while (dr.Read())
        {
            myProduction.ID = int.Parse(dr["ID"].ToString());
            myProduction.Name = dr["Name"].ToString();
            myProduction.Price = dr["Price"].ToString();
            myProduction.ProductionCategory = dr["Category"].ToString();
            myProduction.ProductionLevel = dr["ProductLevel"].ToString();
            myProduction.Introduction = dr["Introduction"].ToString();
            myProduction.FullIntro = dr["HTML"].ToString();
            //myProduction.Hand = dr["Hand"].ToString();
            //myProduction.Angle = dr["Angle"].ToString();
            //myProduction.GolfClub = dr["GolfClub"].ToString();
            //myProduction.GolfHard = dr["HardLevel"].ToString();
            //myProduction.ProductionPhoto = dr["ProductionPhoto"].ToString();
            //myProduction.ProductionPhoto = getProductionPhoto(myProduction.ID);
            myProduction.ProductionPhoto = new List<string>();
            myProduction.ProductionPhoto.Add(dr["ProductionPhoto0"].ToString());
            myProduction.ProductionPhoto.Add(dr["ProductionPhoto1"].ToString());
            myProduction.ProductionPhoto.Add(dr["ProductionPhoto2"].ToString());
            myProduction.ProductionPhoto.Add(dr["ProductionPhoto3"].ToString());
            myProduction.ProductionPhoto.Add(dr["ProductionPhoto4"].ToString());
            returnValue.Add(myProduction);
        }
        dr.Close();
        return returnValue;
    }
    public string updateProductionPhoto(string PhotoName, string ProductID,int idx)
    {
        string success = "";
        DataBase db = new DataBase();
        string sqlString = "update store_Production set ProductionPhoto" + idx + "=@ProductionPhoto where ID=@ID";
        DbCommand command = db.GetSqlStringCommond(sqlString);
        db.AddInParameter(command, "@ProductionPhoto", DbType.String, PhotoName);
        db.AddInParameter(command, "@ID", DbType.Int32, ProductID);
        success = db.ExecuteNonQuery(command).ToString();
        if (int.Parse(success) > 0)
            success = MessageSuccess;
        return success;
        /*
        string returnvalue = "";
        DataBase db = new DataBase();
        string sqlString = "insert into store_Production_Photo (ProductID,ProductionPhoto) values(@ProductID,@ProductionPhoto)";
        DbCommand command = db.GetSqlStringCommond(sqlString);
        db.AddInParameter(command, "@ProductID", DbType.Int64, ProductID);
        db.AddInParameter(command, "@ProductionPhoto", DbType.String, PhotoName);
        returnvalue = db.ExecuteNonQuery(command).ToString();
        return returnvalue;
         * */
    }

    public string CreateProductionCategory(string category)
    {
        string returnValue = MessageSuccess;
        int totalCounter = getTotalCategoryCounter() + 1;
        DataBase db = new DataBase();
        string sqlString = "insert into store_ProductCategory (CategoryName,Sequence) values " +
        "(@CategoryName,@Sequence) SELECT @@identity ";
        DbCommand command = db.GetSqlStringCommond(sqlString);
        db.AddInParameter(command, "@CategoryName", DbType.String, category);
        db.AddInParameter(command, "@Sequence", DbType.Int16, totalCounter);
        returnValue = db.ExecuteScalar(command).ToString();
        
        return returnValue;
    }
    public string PauseCategory(string CategoryID,bool isPause)
    {
        string success = "";
        DataBase db = new DataBase();
        string sqlString = "update store_ProductCategory set isPause=@isPause where ID=@ID";
        DbCommand command = db.GetSqlStringCommond(sqlString);
        db.AddInParameter(command, "@isPause", DbType.Boolean, isPause);
        db.AddInParameter(command, "@ID", DbType.Int32, CategoryID);
        success = db.ExecuteNonQuery(command).ToString();
        if (int.Parse(success) > 0)
            success = MessageSuccess;
        return success;
    }
    public string DeleteCategory(string CategoryID)
    {
        string success = "";
        DataBase db = new DataBase();
        string sqlString = "update store_ProductCategory set isDelete=@isDelete where ID=@ID";
        DbCommand command = db.GetSqlStringCommond(sqlString);
        db.AddInParameter(command, "@isDelete", DbType.Boolean, 1);
        db.AddInParameter(command, "@ID", DbType.Int32, CategoryID);
        success = db.ExecuteNonQuery(command).ToString();
        if (int.Parse(success) > 0)
            success = MessageSuccess;
        return success;
    }
    
    private int getTotalCategoryCounter()
    {
        int returnvalue = 0;
        DataBase db = new DataBase();
        string sqlString = "select count(*) from store_ProductCategory";
        DbCommand command = db.GetSqlStringCommond(sqlString);
        returnvalue = (int)db.ExecuteScalar(command);
        //returnvalue = command.ExecuteNonQuery();
        return returnvalue;

    }
    public string updateProductionCategory(string category, string ID)
    {
        string success = MessageSuccess;
        try
        {
            
            DataBase db = new DataBase();
            string sqlString = "update store_ProductCategory set CategoryName=@CategoryName where ID=@ID";
            DbCommand command = db.GetSqlStringCommond(sqlString);
            db.AddInParameter(command, "@CategoryName", DbType.String, category);
            db.AddInParameter(command, "@ID", DbType.Int32, ID);
            db.ExecuteNonQuery(command).ToString();
        }
        catch (Exception e)
        {
            success = e.Message;
        }
        return success;
    }
    public List<sProductionCategory> searchProductionCategory()
    {
        List<sProductionCategory> returnValue = new List<sProductionCategory>();
        sProductionCategory myCategory = new sProductionCategory();
        DataBase db = new DataBase();
        string sqlString = "select * from store_ProductCategory where isDelete=0 order by Sequence";
        DbCommand command = db.GetSqlStringCommond(sqlString);
        DbDataReader dr = db.ExecuteReader(command);
        while (dr.Read())
        {
            myCategory.ID = int.Parse(dr["ID"].ToString());
            myCategory.CategoryName = dr["CategoryName"].ToString();
            myCategory.isPause = dr["isPause"].ToString();
            returnValue.Add(myCategory);
        }
        return returnValue;
    }
    public string searchProductionCategoryName(string id)
    {
        string returnValue = "";
       
        DataBase db = new DataBase();
        string sqlString = "select * from store_ProductCategory where ID=@ID order by Sequence";
        DbCommand command = db.GetSqlStringCommond(sqlString);
        db.AddInParameter(command, "@ID", DbType.Int32, id);
        DbDataReader dr = db.ExecuteReader(command);
        while (dr.Read())
        {
            returnValue = dr["CategoryName"].ToString();
        }
        return returnValue;
    }
}
