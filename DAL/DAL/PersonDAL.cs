using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class PersonDAL
    {
        static string _connStr = "Data Source=192.168.50.95;Initial Catalog = sprathipati; Integrated Security = True; Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False;MultipleActiveResultSets=True;";
        public DataTable GetPerson()
        {
            DataTable table = new DataTable();
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                var sql = "Select * from Person18";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(table);
                    }
                }
            }
            return table;
        }

        //public DataTable FindPerson(string personId)
        //{
        //    DataTable table = new DataTable();
        //    using (SqlConnection conn = new SqlConnection(_connStr))
        //    {
        //        string sql = "Select * from Person18 Where PersonID = @personId";
        //        using (SqlCommand cmd = new SqlCommand(sql, conn))
        //        {
        //            cmd.Parameters.AddWithValue("@personId", personId);
        //            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
        //            {
        //                adapter.Fill(table);
        //            }
        //        }
        //    }
        //return table;
        //}
    }
}
