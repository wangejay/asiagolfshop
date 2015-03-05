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

/// <summary>
/// Summary description for DataBase
/// </summary>
public class DataBase
{
    private static string dbProviderName = ConfigurationManager.ConnectionStrings["LocalSqlServer"].ProviderName;
    private static string dbConnectionString = ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString;
    private DbConnection connection;
 
    #region 初始化
    public DataBase()
	{
		this.connection = CreateConnection(DataBase.dbConnectionString);
	}

    public DataBase(string connectionString)
    {
        this.connection = CreateConnection(connectionString);
    }
 
    public static DbConnection CreateConnection()
    {
        DbProviderFactory dbfactory = DbProviderFactories.GetFactory(DataBase.dbProviderName);
        DbConnection dbconn = dbfactory.CreateConnection();
        dbconn.ConnectionString = DataBase.dbConnectionString;
        return dbconn;
    }
 
    public static DbConnection CreateConnection(string connectionString)
    {
        DbProviderFactory dbfactory = DbProviderFactories.GetFactory(DataBase.dbProviderName);
        DbConnection dbconn = dbfactory.CreateConnection();
        dbconn.ConnectionString = connectionString;
        return dbconn;
    }
 
    #endregion
 
    #region 命令
 
    public DbCommand GetStoredProcCommond(string storedProcedure)
    {
        DbCommand dbCommand = connection.CreateCommand();
        dbCommand.CommandText = storedProcedure;
        dbCommand.CommandType = CommandType.StoredProcedure;
        return dbCommand;
    }
 
    public DbCommand GetSqlStringCommond(string sqlQuery)
    {
        DbCommand dbCommand = connection.CreateCommand();
        dbCommand.CommandText = sqlQuery;
        dbCommand.CommandType = CommandType.Text;
        return dbCommand;
    }
 
    #endregion
 
    #region 參數
 
    public void AddInParameter(DbCommand cmd, string parameterName, DbType dbType, object value)
    {
        DbParameter dbParameter = cmd.CreateParameter();
        dbParameter.DbType = dbType;
        dbParameter.ParameterName = parameterName;
        dbParameter.Value = value;
        dbParameter.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(dbParameter);
    }
 
    #endregion
 
    #region 執行
 
    public DataTable ExecuteDataTable(DbCommand cmd)
    {
        DbProviderFactory dbfactory = DbProviderFactories.GetFactory(DataBase.dbProviderName);
        DbDataAdapter dbDataAdapter = dbfactory.CreateDataAdapter();
        dbDataAdapter.SelectCommand = cmd;
        DataTable dataTable = new DataTable();
        dbDataAdapter.Fill(dataTable);
        return dataTable;
    }
 
    public DbDataReader ExecuteReader(DbCommand cmd)
    {
        DbDataReader reader = null;
 
        try
        {
            cmd.Connection.Open();
            reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
        catch (Exception)
        {
            throw;
        }
 
        return reader;
    }
 
    public int ExecuteNonQuery(DbCommand cmd)
    {
        try
        {
            cmd.Connection.Open();
            int ret = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return ret;
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            cmd.Connection.Close();
        }
 
        return -1;
    }
 
    public object ExecuteScalar(DbCommand cmd)
    {
        try
        {
            cmd.Connection.Open();
            object ret = cmd.ExecuteScalar();
            cmd.Connection.Close();
            return ret;
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            cmd.Connection.Close();
        }
 
        return -1;
    }
 
    #endregion       
}
//public class SqlOperateInfo
//{

//    //Suppose your ServerName is "aa",DatabaseName is "bb",UserName is "cc", Password is "dd"

//    private string sqlConnectionCommand = "Data Source=aa;Initial Catalog=bb;User ID=cc;Pwd=dd";

//    //This table contains two columns:KeywordID int not null,KeywordName varchar(100) not null

//    private string dataTableName = "Basic_Keyword_Test";

//    private string storedProcedureName = "Sp_InertToBasic_Keyword_Test";

//    private string sqlSelectCommand = "Select KeywordID, KeywordName From Basic_Keyword_Test";

//    //sqlUpdateCommand could contain "insert" , "delete" , "update" operate

//    private string sqlUpdateCommand = "Delete From Basic_Keyword_Test Where KeywordID = 1";

//    public void UseSqlReader()
//    {

//        SqlConnection sqlConnection = new SqlConnection(sqlConnectionCommand);

//        SqlCommand sqlCommand = new SqlCommand();

//        sqlCommand.CommandType = System.Data.CommandType.Text;

//        sqlCommand.Connection = sqlConnection;

//        sqlCommand.CommandText = sqlSelectCommand;

//        sqlConnection.Open();

//        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

//        while (sqlDataReader.Read())
//        {

//            //Get KeywordID and KeywordName , You can do anything you like. Here I just output them.

//            int keywordid = (int)sqlDataReader[0];

//            //the same as: int keywordid = (int)sqlDataReader["KeywordID"]

//            string keywordName = (string)sqlDataReader[1];

//            //the same as: string keywordName = (int)sqlDataReader["KeywordName"]

//            Console.WriteLine("KeywordID = " + keywordid + " , KeywordName = " + keywordName);

//        }

//        sqlDataReader.Close();

//        sqlCommand.Dispose();

//        sqlConnection.Close();

//    }

//    public void UseSqlStoredProcedure()
//    {

//        SqlConnection sqlConnection = new SqlConnection(sqlConnectionCommand);

//        SqlCommand sqlCommand = new SqlCommand();

//        sqlCommand.CommandType = CommandType.StoredProcedure;

//        sqlCommand.Connection = sqlConnection;

//        sqlCommand.CommandText = storedProcedureName;

//        sqlConnection.Open();

//        sqlCommand.ExecuteNonQuery();

//        //you can use reader here,too.as long as you modify the sp and let it like select * from ....

//        sqlCommand.Dispose();

//        sqlConnection.Close();

//    }

//    public void UseSqlDataSet()
//    {

//        SqlConnection sqlConnection = new SqlConnection(sqlConnectionCommand);

//        SqlCommand sqlCommand = new SqlCommand();

//        sqlCommand.CommandType = System.Data.CommandType.Text;

//        sqlCommand.Connection = sqlConnection;

//        sqlCommand.CommandText = sqlSelectCommand;

//        sqlConnection.Open();

//        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();

//        sqlDataAdapter.SelectCommand = sqlCommand;

//        DataSet dataSet = new DataSet();

//        //sqlCommandBuilder is for update the dataset to database

//        SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(sqlDataAdapter);

//        sqlDataAdapter.Fill(dataSet, dataTableName);

//        //Do something to dataset then you can update it to 　Database.Here I just add a row

//        DataRow row = dataSet.Tables[0].NewRow();

//        row[0] = 10000;

//        row[1] = "new row";

//        dataSet.Tables[0].Rows.Add(row);

//        sqlDataAdapter.Update(dataSet, dataTableName);

//        sqlCommand.Dispose();

//        sqlDataAdapter.Dispose();

//        sqlConnection.Close();

//    }

//}
