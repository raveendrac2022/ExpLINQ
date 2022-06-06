using System;
using System.Data;
using System.Configuration;
using System.Data.Common;
using System.Reflection.Metadata;
using Microsoft.Data.SqlClient;

public class DBManagement
{
    string connectionStr;
    DbConnection con;
    DbCommand cmd;
    DbDataAdapter AD;
    DataSet ds;
    DbParameter[] sp;
    public DBManagement()
    {
        this.Initialize();
    }

    void Initialize()
    {
        try
        {

            switch (ConfigurationManager.AppSettings["ActiveDatabase"].ToUpper())
            {
                case "MSSQL":
                    connectionStr = ConfigurationManager.ConnectionStrings["MSSQLConnectionString"].ConnectionString;
                    con = new SqlConnection();
                    cmd = new SqlCommand();
                    AD = new SqlDataAdapter();
                    break;
            }

            con.ConnectionString = connectionStr;
            cmd.Connection = con;
        }
        catch (Exception ex)
        {

        }
    }

    public DataSet ExecuteProcedure(string procName, CommandType cmdType, Parameter[] DBParameters = null)
    {
        try
        {
            cmd.CommandText = procName;
            cmd.CommandType = cmdType;

            cmd.Parameters.Clear();

            if (DBParameters != null && DBParameters.Length > 0)
            {
                sp = DBParameters.ToParamerArray(cmd);
                cmd.Parameters.AddRange(sp);
            }
            ds = new DataSet();
            AD.SelectCommand = cmd;
            AD.Fill(ds);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}