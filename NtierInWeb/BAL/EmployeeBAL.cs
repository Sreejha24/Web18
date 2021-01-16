using DAL;
using System;
using System.Data;

namespace BAL
{
    public class EmployeeBAL
    {
        public DataSet ReadEmployee()
        {
            DataSet set = new DataSet();

            EmployeeDAL employee = new EmployeeDAL();
            var data = employee.GetEmployees();
            
            set.Tables.Add(data);
            return set;
        }
    }
}
