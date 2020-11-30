using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace ThiKetThucHanhMVC.Models
{
    public class DBConnect
    {
        //chuỗi kết nối

        //   public static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;

        public static readonly string ConnectionString = @"Data Source=DESKTOP-DCMU7ET;Initial Catalog=DeThiKetBanGiayTheThao;Integrated Security=True";
        public static int ExecuteNonQuery(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {

            SqlCommand cmd = new SqlCommand();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
        }


        public static SqlDataReader getallLsp(string connectionString, string cmdtext)
        {

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(cmdtext, conn);
            SqlDataReader read = cmd.ExecuteReader();
            return read;

        }


        public static DataTable log(string cmdtxt)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            SqlDataAdapter cmd = new SqlDataAdapter(cmdtxt, conn);


            DataTable dt = new DataTable();

            cmd.Fill(dt);
            return dt;
        }





        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
        {

            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = cmdText;

            if (trans != null)
                cmd.Transaction = trans;

            cmd.CommandType = cmdType;

            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }
    }
}