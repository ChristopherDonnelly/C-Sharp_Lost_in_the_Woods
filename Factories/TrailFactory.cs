using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using DbConnection;
using MySql.Data.MySqlClient;
using Lost_in_the_Woods.Models;
 
namespace Lost_in_the_Woods.Factory
{
    public class TrailFactory : IFactory<TrailInfo>
    {
        private string connectionString;
        public TrailFactory()
        {
            connectionString = "server=localhost;userid=root;password=root;port=3306;database=lost_in_woods;SslMode=None";
        }
        internal IDbConnection Connection
        {
            get {
                return new MySqlConnection(connectionString);
            }
        }

        public void Add(TrailInfo item)
        {
            using (IDbConnection dbConnection = Connection) {
                string query =  "INSERT INTO `trails` (`Name`, `Description`, `Length`, `Gain`, `Long`, `Lat`, `CreatedAt`, `UpdatedAt`) VALUES (@Name, @Description, @Length, @Gain, @Long, @Lat, NOW(), NOW())";
                dbConnection.Open();
                dbConnection.Execute(query, item);
            }
        }
        public IEnumerable<TrailInfo> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<TrailInfo>("SELECT * FROM trails");
            }
        }
        public TrailInfo FindByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<TrailInfo>("SELECT * FROM trails WHERE id = @Id", new { Id = id }).FirstOrDefault();
            }
        }
    }
}