
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class EmployeeDAL
    {
        static string _connection = "Data Source=LAPTOP-D2U4JDN5;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False";
        public DataTable GetEmployees()
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                var sql = "Select * from Employees";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(table);
                    }
                }
            }
            return table;
        }
    }
}
