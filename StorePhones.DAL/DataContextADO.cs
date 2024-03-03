
using Microsoft.Data.SqlClient;

namespace StorePhones.DAL
{
    public class DataContextADO
    {
        private string _connectionString;
        public DataContextADO(string connectionString)
        {
            _connectionString = connectionString;
        }

        public SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        //private void InitDatabase()
        //{
        //    using (var db = CreateConnection())
        //    {
        //        db.Open();
        //        var cmd = new SqlCommand("SELECT COUNT(Name) FROM master.sys.databases WHERE Name='storephonesdb'",db);
        //        int count = Convert.ToInt32(cmd.ExecuteScalar());

        //        if (count == 0)
        //        {
        //            var cmdCreateDB = new SqlCommand("CRETAE DATABASE storephonesdb",db);
        //            cmdCreateDB.ExecuteNonQuery();
        //        }
        //    }
        //}

        //private void InitTable()
        //{
        //    using (var db = CreateConnection())
        //    {
        //        db.Open();
        //        var cmd = new SqlCommand("SELECT COUNT(Name) FROM storephonesdb.sys.tables WHERE Name='phones'", db);
        //        int count = Convert.ToInt32(cmd.ExecuteScalar());
        //        if (count == 0)
        //        {
        //            var cmdCreateTable = new SqlCommand(@"CREATE TABLE phones(
        //                                                  Id INT IDENTITY PRIMARY KEY,
        //                                                  Name NVARCHAR(100) NOT NULL,
        //                                                  Description NVARCHAR(255),
        //                                                  Price DECIMAL DEFAULT 0)");
        //            cmdCreateTable.ExecuteNonQuery();
        //        }
        //    }
        //}
    }
}
