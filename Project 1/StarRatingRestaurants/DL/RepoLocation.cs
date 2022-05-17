using Microsoft.Data.SqlClient;
using Models;

namespace DL
{
    public class RepoLocation : IRepositoryLoc
    {
        private readonly string sConnectToDatabase;
        public RepoLocation(string sConnectToDatabase)
        {
            this.sConnectToDatabase = sConnectToDatabase;
        }
        /// <summary>
        /// this gets a model of a Location and add it to the database
        /// </summary>
        /// <param name="location"></param>
        /// <returns>a new location to the database</returns>
        public Location AddRestLocation(Location location)
        {
            string command = "INSERT INTO Location  (Id,Country,State,City,Zipcode) VALUES" +
                                            " (@id,@country,@state,@city,@zipcode);";
            using SqlConnection connectionTwo = new(sConnectToDatabase);
            using SqlCommand commandTwo = new(command, connectionTwo);
            commandTwo.Parameters.AddWithValue("@id", location.Id);
            commandTwo.Parameters.AddWithValue("@country", location.Country);
            commandTwo.Parameters.AddWithValue("@state", location.State);
            commandTwo.Parameters.AddWithValue("@city", location.City);
            commandTwo.Parameters.AddWithValue("@zipcode", location.Zipcode);
            connectionTwo.Open();
            commandTwo.ExecuteNonQuery();
            connectionTwo.Close();
            return location;
        }
        /// <summary>
        /// Deletes the Locations using the Restaurant id as the 
        /// locaiton is using restaurant's id as a forenkey
        /// </summary>
        /// <param name="id"></param>
        public void DeleteRestLocation(string id)
        {
            string command = $"DELETE FROM Location WHERE Id = '{id}';";
            using SqlConnection conectionTwo = new(sConnectToDatabase);
            using SqlCommand commandTwo = new(command, conectionTwo);
            conectionTwo.Open();
            commandTwo.ExecuteReader();
            conectionTwo.Close();
        }
        /// <summary>
        /// get's the location of all Restaurant locaiton
        /// and send it in a list of locaitons
        /// </summary>
        /// <returns>A list of locaiton</returns>
        public List<Location> DisplayAllRestLocation()
        {
            string selectCommandString = $"SELECT * FROM Location";
            using SqlConnection connection = new(sConnectToDatabase);
            using SqlCommand command = new(selectCommandString, connection);
            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();
            var vLocation = new List<Location>();
            while (reader.Read())
            {
                vLocation.Add(new Location
                {
                    Country = reader.GetString(1),
                    State = reader.GetString(2),
                    City = reader.GetString(3),
                    Zipcode = reader.GetString(4)
                });
            }
            connection.Close();
            return vLocation;
        }
        /// <summary>
        /// we get a locaiton using a fexable input 
        /// where we can get something from the database
        /// when it equals to a value
        /// </summary>
        /// <param name="WhereIt"></param>
        /// <param name="equalsTo"></param>
        /// <returns>A list of locaiton </returns>
        public List<Location> SearchRestLocation(string WhereIt, string equalsTo)
        {
            string selectCommandString = $"SELECT * FROM Location WHERE {WhereIt} = '{equalsTo}'";
            using SqlConnection connection = new(sConnectToDatabase);
            using SqlCommand command = new(selectCommandString, connection);
            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();
            var vLocation = new List<Location>();
            while (reader.Read())
            {
                vLocation.Add(new Location
                {
                    Country = reader.GetString(1),
                    State = reader.GetString(2),
                    City = reader.GetString(3),
                    Zipcode = reader.GetString(4)
                });
            }
            connection.Close();
            return vLocation;
        }
        //-----------------Async----------------

        /// <summary>
        /// All of this are Async copies of the function above
        /// </summary>
        /// 

        public async Task<Location> AddRestLocationAsync(Location loc)
        {
            string command = "INSERT INTO Location  (Id,Country,State,City,Zipcode) VALUES" +
                                            " (@id,@country,@state,@city,@zipcode);";
            using SqlConnection connectionTwo = new(sConnectToDatabase);
            using SqlCommand commandTwo = new(command, connectionTwo);
            commandTwo.Parameters.AddWithValue("@id", loc.Id);
            commandTwo.Parameters.AddWithValue("@country", loc.Country);
            commandTwo.Parameters.AddWithValue("@state", loc.State);
            commandTwo.Parameters.AddWithValue("@city", loc.City);
            commandTwo.Parameters.AddWithValue("@zipcode", loc.Zipcode);
            await connectionTwo.OpenAsync();
            await commandTwo.ExecuteNonQueryAsync();
            await connectionTwo.CloseAsync();
            return loc;
        }

        public async Task<List<Location>> DisplayAllRestLocationAsync()
        {
            string selectCommandString = $"SELECT * FROM Location";
            using SqlConnection connection = new(sConnectToDatabase);
            using SqlCommand command = new(selectCommandString, connection);
            await connection.OpenAsync();
            using SqlDataReader reader = await command.ExecuteReaderAsync();
            var vLocation = new List<Location>();
            while (await reader.ReadAsync())
            {
                vLocation.Add(new Location
                {
                    Country = reader.GetString(1),
                    State = reader.GetString(2),
                    City = reader.GetString(3),
                    Zipcode = reader.GetString(4)
                });
            }
            await connection.CloseAsync();
            return vLocation;
        }

        public async Task<List<Location>> SearchRestLocationAsync(string WhereIt, string equalsTo)
        {
            string selectCommandString = $"SELECT * FROM Location WHERE {WhereIt} = '{equalsTo}'";
            using SqlConnection connection = new(sConnectToDatabase);
            using SqlCommand command = new(selectCommandString, connection);
            await connection.OpenAsync();
            using SqlDataReader reader = await command.ExecuteReaderAsync();
            var vLocation = new List<Location>();
            while (await reader.ReadAsync())
            {
                vLocation.Add(new Location
                {
                    Country = reader.GetString(1),
                    State = reader.GetString(2),
                    City = reader.GetString(3),
                    Zipcode = reader.GetString(4)
                });
            }
            await connection.CloseAsync();
            return vLocation;
        }
    }
}
