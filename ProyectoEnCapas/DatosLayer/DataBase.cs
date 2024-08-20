using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosLayer
{
    public class DataBase
    {
        public static int ConnetionTimeout { get; set; }
        public static string ApplicationName { get; set; }

        public static string ConecctionString
        {
            get
            {
                string CADENA= ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
                SqlConnectionStringBuilder conexionBuilder = new SqlConnectionStringBuilder(CADENA);

                conexionBuilder.ApplicationName = ApplicationName ?? conexionBuilder.ApplicationName;
                conexionBuilder.ConnectTimeout = (ConnetionTimeout > 0)
                    ? ConnetionTimeout : conexionBuilder.ConnectTimeout;

                return conexionBuilder.ToString();

            }

        }

        public static SqlConnection GetSqlConnection()
        {
            SqlConnection conexion = new SqlConnection(ConecctionString);
            conexion.Open();
            return conexion;
        }
    }
}
