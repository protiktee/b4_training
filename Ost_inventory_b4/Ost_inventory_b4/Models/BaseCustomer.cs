using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Ost_inventory_b4.Models
{
    public class BaseCustomer
    {
        public static DataTable ListCustomer()
        {
            DataTable dataTable1 = new DataTable();
            string ConnString = ConfigurationManager.ConnectionStrings["ConnString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(ConnString);

            try
            {
                sqlConnection.Open();
                string Query = "spOST_LstCustomer";
                SqlCommand cmd = new SqlCommand(Query, sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.CommandTimeout = 0;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);    //fetch mode table data  
                adapter.Fill(dataTable1);
                cmd.Dispose();
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                sqlConnection.Close();
            }
            return dataTable1;
        }
    }
}