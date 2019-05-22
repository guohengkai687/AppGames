using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace PlayAGame
{
    class LoadDataFromDb
    {
        private DataTable LoadData()
        {
            //存储过程名
            string ProcName = "TestProc";

            SqlParameter[] paravalue = {
                                       new SqlParameter("@ID",SqlDbType.Int),
                                       new SqlParameter("@BeginTime",SqlDbType.DateTime),
                                       new SqlParameter("@EndTime",SqlDbType.DateTime),
                                       new SqlParameter("@TestFile",SqlDbType.NVarChar)
                                       };
            paravalue[0].Value = 1;
            paravalue[1].Value = DateTime.Now;
            paravalue[2].Value = DateTime.Now.AddDays(1);
            paravalue[3].Value = @"D:\SourceCode";

            DataTable dt = new DataTable();

            string strconnect = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(strconnect))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = ProcName;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;

                    conn.Open();

                    if (paravalue != null)
                    {
                        cmd.Parameters.AddRange(paravalue);
                    }
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                        return dt;
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print(ex.Message.ToString());
                    return null;
                    //throw;
                }
                finally
                {
                    conn.Close();                    
                }
            }
        }
        private void playOne()
        {
            foreach (var item in ConfigurationManager.AppSettings)
            {
                item.ToString();
            }
            
        }
    }
}
