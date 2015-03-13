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
using System.Collections.Generic;
using System.Data.Common;

/// <summary>
/// Summary description for List
/// </summary>
public struct sList
{
    public string ID;
    public string ItemName;
}
public class List
{
	public List()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    public List<sList> getList(string ListName)
    {
        List<sList> returnValue = new List<sList>();
        sList myList = new sList();
        DataBase db = new DataBase();
        string sqlString = "select * from system_List where GroupName=@GroupName";
        DbCommand command = db.GetSqlStringCommond(sqlString);
        db.AddInParameter(command, "@GroupName", DbType.String, ListName);
        DbDataReader dr = db.ExecuteReader(command);
        while (dr.Read())
        {
            myList.ID = dr["ItemID"].ToString();
            myList.ItemName = dr["ItemName"].ToString();
            returnValue.Add(myList);
        }
        return returnValue;
    }
}
