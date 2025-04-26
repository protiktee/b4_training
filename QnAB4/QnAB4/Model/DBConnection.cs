using Microsoft.Data.SqlClient;
using System.Data; 

namespace QnAB4.Model
{
    public class DBConnection
    {
        public static IConfiguration Configuration { get; set; }
        public static string GetDBConstring()
        {
            string strConnection = "";
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            Configuration = builder.Build();
            strConnection = Configuration["ConnString"].ToString();
            return strConnection;
            //return Configuration["ConnString"].ToString();
        }

        public static void SaveErrorLog(string fromScreen, string ErrorDescription)
        {
            string ConnString = GetDBConstring();
            //ApplciationName
            SqlConnection connection = new SqlConnection(ConnString);
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "dbo.spOst_InsErrorLog";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add(new SqlParameter("@EventRaiseScreen", fromScreen));
            cmd.Parameters.Add(new SqlParameter("@ErrorDescription", ErrorDescription));
            cmd.CommandTimeout = 0;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            connection.Close();
        }
    }
}
