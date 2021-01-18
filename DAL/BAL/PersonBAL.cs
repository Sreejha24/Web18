using DAL;
using System;
using System.Data;

namespace BAL
{
    public class PersonBAL
    {
        public DataSet ReadPerson()
        {
            DataSet set = new DataSet();
            PersonDAL dAL = new PersonDAL();
            var table = dAL.GetPerson();

            
            set.Tables.Add(table);
            return set;
        }

    }
}
