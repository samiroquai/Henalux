using com.rusanu.DBUtil;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDAL.Tests
{
    public class Helper
    {
        public static void CreerBaseDeDonnees()
        {
            
            using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLOCALDB;Integrated Security=True;"))
            {
                conn.Open();
                var tempPath=Path.GetTempFileName();
                File.WriteAllText(tempPath,Properties.Resources.CreateDatabase);
                //SqlCmd est une classe définie dans la librairie DbUtil, dont le code a été récupéré
                //du repository GitHub https://github.com/rusanu/DbUtilSqlCmd
                SqlCmd.ExecuteFile(conn,tempPath);
                conn.Close();
            }
        }
    }
}
