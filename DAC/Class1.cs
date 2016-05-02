using Entities;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAC
{
    public class PersonDAC : BaseDac


    {
        public Person GetPerson(int Id)
        {
            Database db = GetDatabase();
            const string SQL_STATEMENT =
               "SELECT [ID], [Name], [DOB], [DOD], [age] " +
               "FROM Person.personne  " +
               "WHERE [ID]=@ID ";

            Person personne = null;

            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@ID", DbType.Int32, Id);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        // Create a new personne
                        personne = new Person();

                        // Read values.
                        personne.Id = GetDataValue<int>(dr, "ID");
                        personne.FirstName = GetDataValue<string>(dr, "FirstName");
                        personne.LastName = GetDataValue<string>(dr, "LastName");

                    }
                }
            }
            return personne;
        }
    }
}
