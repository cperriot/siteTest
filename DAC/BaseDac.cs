using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;

namespace DAC
{
    public class BaseDac
    {
        public Database GetDatabase()
        {            // Configure the DatabaseFactory to read its configuration from the .config file
            DatabaseProviderFactory factory = new DatabaseProviderFactory();

            // Create the default Database object from the factory.
            // The actual concrete type is determined by the configuration settings.
            Database defaultDB = factory.CreateDefault();

            // Create a Database object from the factory using the connection string name.
            Database namedDB = factory.Create("ExampleDatabase");
            return namedDB;
        }

        public string GetConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["test"].ConnectionString;
        }


        protected static T GetDataValue<T>(IDataReader dr, string columnName)
        {
            // NOTE: GetOrdinal() is used to automatically determine where the column
            //       is physically located in the database table. This allows the
            //       schema to be changed without affecting this piece of code.
            //       This of course sacrifices a little performance for maintainability.
            int i = dr.GetOrdinal(columnName);

            if (!dr.IsDBNull(i))
                return (T)dr.GetValue(i);
            else
                return default(T);
        }
    }
}