using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for DataAccessLayer
/// </summary>
public static class DataAccessLayer
{
    public static string connectionString
    {
        get { return WebConfigurationManager.ConnectionStrings["mainconnection"].ConnectionString; }
    }

    public static SqlConnection GetConnection()
    {
        SqlConnection con = new SqlConnection(DataAccessLayer.connectionString);
        if (con.State != ConnectionState.Open)
        {
            con.Open();
        }
        return con;
    }

    public static DataTable getTable(string storProcName, SqlParameter[] param)
    {
        DataTable dt = null;
        using (SqlConnection con = DataAccessLayer.GetConnection())
        {
            using (SqlCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = storProcName;
                cmd.CommandType = CommandType.StoredProcedure;
                if (param != null)
                {
                    cmd.Parameters.AddRange(param);
                }
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    dt = new DataTable();
                    da.Fill(dt);
                }
                return dt;
            }
        }
    }

    public static int ExecuteProc(string storProcName, SqlParameter[] param)
    {
        using (SqlConnection con = DataAccessLayer.GetConnection())
        {
            using (SqlCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = storProcName;
                cmd.CommandType = CommandType.StoredProcedure;
                if (param != null)
                {
                    cmd.Parameters.AddRange(param);
                }
                return cmd.ExecuteNonQuery();
            }
        }
    }

}