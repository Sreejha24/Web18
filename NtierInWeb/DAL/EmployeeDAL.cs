
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class EmployeeDAL
    {
        static string _connection = "Data Source=192.168.50.95;Initial Catalog=vpadira;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False";
        public DataTable GetEmployees()
        {
            DataTable table = new DataTable();
            using(SqlConnection connection=new SqlConnection(_connection))
            {
                var sql = "Select * from Employees2";
                using(SqlCommand command=new SqlCommand(sql, connection))
                {
                    using(SqlDataAdapter adapter=new SqlDataAdapter(command))
                    {
                        adapter.Fill(table);
                    }
                }
            }
            return table;
        }
    }
}
