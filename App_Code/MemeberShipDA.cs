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
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections.Generic;

/// <summary>
/// Summary description for MemeberShipDA
/// </summary>
public class MemeberShipDA
{
	public MemeberShipDA()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public string setUserProfile(createUser StructureData)
    {
        string returnValue = "";
        //DataBase Base = new DataBase();
        //SqlConnection Sqlconn = new SqlConnection(Base.GetConnString());
        //using (Sqlconn)
        //{
        //    try
        //    {
        //        Sqlconn.Open();
        //        string sql = "UPDATE UserProfile SET TrueName=@userName, Sex=@userSex, Birthday=@userBirthday, Phone=@userPhone, " +
        //            "School=@School, College=@College, Company=@Company, Department=@Department, JobTitle=@JobTitle, Residence=@Residence, " +
        //            "Skill=@Skill, Domain=@Domain, SkillOther=@Other, Priority=@Priority, DomainSub1=@DomainSub1, DomainSub2=@DomainSub2, " +
        //            "DomainSub3=@DomainSub3, Interview1=@Interview1, Interview2=@Interview2, " +
        //            "Interview3=@Interview3, Avatar=@Avatar, Introduction=@Introduction, Website=@Website, updateDateTime=createDateTime " +
        //            "WHERE UserName=@userEmail AND isDeleted=0";
        //        SqlCommand cmd = new SqlCommand(sql, Sqlconn);
        //        cmd.Parameters.Add("@userEmail", SqlDbType.NVarChar).Value = StructureData.Email;
        //        cmd.Parameters.Add("@userName", SqlDbType.NVarChar).Value = StructureData.Name;
        //        cmd.Parameters.Add("@userSex", SqlDbType.TinyInt).Value = int.Parse(StructureData.Sex);
        //        cmd.Parameters.Add("@userBirthday", SqlDbType.DateTime).Value = DateTime.Parse(StructureData.Birthday);
        //        cmd.Parameters.Add("@userPhone", SqlDbType.NVarChar).Value = StructureData.Phone;
        //        cmd.Parameters.Add("@School", SqlDbType.NVarChar).Value = StructureData.School;
        //        cmd.Parameters.Add("@College", SqlDbType.NVarChar).Value = StructureData.College;
        //        cmd.Parameters.Add("@Company", SqlDbType.NVarChar).Value = StructureData.Company;
        //        cmd.Parameters.Add("@Department", SqlDbType.NVarChar).Value = StructureData.Department;
        //        cmd.Parameters.Add("@JobTitle", SqlDbType.NVarChar).Value = StructureData.JobTitle;
        //        cmd.Parameters.Add("@Residence", SqlDbType.NVarChar).Value = StructureData.Residence;
        //        cmd.Parameters.Add("@Skill", SqlDbType.NVarChar).Value = StructureData.Skill;
        //        cmd.Parameters.Add("@Domain", SqlDbType.NVarChar).Value = StructureData.Domain;
        //        cmd.Parameters.Add("@Other", SqlDbType.NVarChar).Value = StructureData.Other;
        //        cmd.Parameters.Add("@Priority", SqlDbType.TinyInt).Value = int.Parse(StructureData.Priority);
        //        cmd.Parameters.Add("@DomainSub1", SqlDbType.NVarChar).Value = StructureData.DomainSub1;
        //        cmd.Parameters.Add("@DomainSub2", SqlDbType.NVarChar).Value = StructureData.DomainSub2;
        //        cmd.Parameters.Add("@DomainSub3", SqlDbType.NVarChar).Value = StructureData.DomainSub3;
        //        cmd.Parameters.Add("@Interview1", SqlDbType.NVarChar).Value = StructureData.Interview1;
        //        cmd.Parameters.Add("@Interview2", SqlDbType.NVarChar).Value = StructureData.Interview2;
        //        cmd.Parameters.Add("@Interview3", SqlDbType.NVarChar).Value = StructureData.Interview3;
        //        cmd.Parameters.Add("@Avatar", SqlDbType.NVarChar).Value = StructureData.Avatar;
        //        cmd.Parameters.Add("@Introduction", SqlDbType.NVarChar).Value = StructureData.Introduction;
        //        cmd.Parameters.Add("@Website", SqlDbType.NVarChar).Value = StructureData.Website;
        //        returnValue = cmd.ExecuteNonQuery().ToString();

                
        //    }
        //    catch (Exception e)
        //    {
        //        returnValue = e.Message;
        //    }
        //}
        return returnValue;
    }
    public List<object> searchMemberData(DTParameterModel ParameterModel)
    {
        //DataBase db = new DataBase();
        //string sqlString = "SELECT * FROM table";
        //DbCommand command = db.GetSqlStringCommond(sqlString);
        //db.ExecuteDataTable(command);
        List<object> returnvalue = new List<object>();

        string wheresql = " where 1=1";

        foreach(DTCondition myCondition in ParameterModel.Condition)
        {
            switch (myCondition.Name)
            {
                case "search_account":
                    if (myCondition.Value.Length > 0)
                    {
                        wheresql += " and Email like @" + myCondition.Name + " ";
                    }
                    break;
            }
        }

        DataBase db = new DataBase();
        string sqlString = "SELECT Email,Password FROM aspnet_Membership " + wheresql;
        DbCommand command = db.GetSqlStringCommond(sqlString);
        foreach (DTCondition myCondition in ParameterModel.Condition)
        {
            switch (myCondition.Name)
            {
                case "search_account":
                    if (myCondition.Value.Length > 0)
                    {
                        db.AddInParameter(command, "@" + myCondition.Name, DbType.String, "%" + myCondition.Value + "%");
                    }
                    break;
            }
        }
        
        DbDataReader dr= db.ExecuteReader(command);
        while (dr.Read())
        {
            string[] atom = { dr["Email"].ToString(),dr["Password"].ToString(),"","","<button>檢視</button>" };
            returnvalue.Add(atom);
        }
        dr.Close();
        command.Connection.Close();
        
        return returnvalue;
    }
    public string getUserID(string UserName)
    {
        
        string returnvalue = "";
        DataBase db = new DataBase();
        string sqlString = "SELECT UserId FROM aspnet_Users where UserName=@UserName";
        DbCommand command = db.GetSqlStringCommond(sqlString);
        db.AddInParameter(command, "@UserName", DbType.String, UserName);
        using (command.Connection)
        {
            returnvalue=db.ExecuteScalar(command).ToString();
            return returnvalue;
        }
    }
}
