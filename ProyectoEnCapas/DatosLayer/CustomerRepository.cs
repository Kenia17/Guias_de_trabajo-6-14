using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DatosLayer
{
    public class CustomerRepository
    {
        public List<Customers> obtenerTodos()
        {
            using (var conexion = DataBase.GetSqlConnection())
            {
                string selectFrom = "";
                selectFrom = selectFrom + "SELECT [CompanyName] " + "\n";
                selectFrom = selectFrom + "      ,[ContactName] " + "\n";
                selectFrom = selectFrom + "      ,[ContactTitle] " + "\n";
                selectFrom = selectFrom + "      ,[Address] " + "\n";
                selectFrom = selectFrom + "      ,[City] " + "\n";
                selectFrom = selectFrom + "      ,[Region] " + "\n";
                selectFrom = selectFrom + "      ,[PostalCode] " + "\n";
                selectFrom = selectFrom + "      ,[Country] " + "\n";
                selectFrom = selectFrom + "      ,[Phone] " + "\n";
                selectFrom = selectFrom + "      ,[Fax] " + "\n";
                selectFrom = selectFrom + "  FROM [dbo].[Customers]";

                using (SqlCommand comando = new SqlCommand(selectFrom, conexion))
                {
                    SqlDataReader leer = comando.ExecuteReader();

                    List<Customers> customerR = new List<Customers>();

                    while (leer.Read())
                    {
                        Customers customers = new Customers();
                        customers.CompanyName = leer["CompanyName"] == DBNull.Value ? "" : (string)leer["CompanyName"];
                        customers.ContactName = leer["ContactName"] == DBNull.Value ? "" : (string)leer["ContactName"];
                        customers.ContactTitle = leer["ContactTitle"] == DBNull.Value ? "" : (string)leer["ContactTitle"];
                        customers.Address = leer["Address"] == DBNull.Value ? "" : (string)leer["Address"];
                        customers.City = leer["City"] == DBNull.Value ? "" : (string)leer["City"];
                        customers.Region = leer["Region"] == DBNull.Value ? "" : (string)leer["Region"];
                        customers.PostalCode = leer["PostalCode"] == DBNull.Value ? "" : (string)leer["PostalCode"];
                        customers.Country = leer["Country"] == DBNull.Value ? "" : (string)leer["Country"];
                        customers.Phone = leer["Phone"] == DBNull.Value ? "" : (string)leer["Phone"];
                        customers.Fax = leer["Fax"] == DBNull.Value ? "" : (string)leer["Fax"];

                        customerR.Add(customers);
                    }
                    return customerR;
                }
            }
        }
    }
}
