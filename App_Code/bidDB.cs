﻿using System;
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
    public string MaxBidPrice;
    public string StartTime;
    public string EndTime;
    public List<sBidRecord> lBidRecord;


}
public struct sBidRecord
{
    public string BidPrice;
    public string BidUserID;
    public string BidTime;
}

public class bidDB
{
    public List<sBidItem> searchBidItembyCateogry(string category)
    {
        List<sBidItem> returnValue = new List<sBidItem>();
        List<sBidItem> temp = new List<sBidItem>();
        sBidItem myBidItem = new sBidItem();
        DataBase db = new DataBase();
        string sqlString;
        if (category.Length == 0)
            sqlString = "select * from bid_Items  order by ID desc";
        else
            sqlString = "select * from bid_Items where Category=@Category order by ID desc";

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

            myBidItem.EndTime = dr["endTime"].ToString();
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


    private string getMaxBidPrice(int ID)
    {
        string sqlString;
        DataBase db = new DataBase();

        sqlString = "SELECT MAX(Price) FROM bid_Record WHERE ProductID=@ID";
        DbCommand command = db.GetSqlStringCommond(sqlString);
        db.AddInParameter(command, "@ID", DbType.Int16, ID);
        int dr = (int)db.ExecuteNonQuery(command);

        return dr.ToString();
    }
}