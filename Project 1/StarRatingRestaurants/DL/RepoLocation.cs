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
        public Location AddRestLocation(Location loc)
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
            connectionTwo.Open();
            commandTwo.ExecuteNonQuery();
            connectionTwo.Close();
            return loc;
        }
        public void DeleteRestLocation(string id)
        {
            string command = $"DELETE FROM Location WHERE Id = '{id}';";
            using SqlConnection conectionTwo = new(sConnectToDatabase);
            using SqlCommand commandTwo = new(command, conectionTwo);
            conectionTwo.Open();
            commandTwo.ExecuteReader();
            conectionTwo.Close();
        }
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
