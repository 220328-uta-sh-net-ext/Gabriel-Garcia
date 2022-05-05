using Microsoft.Data.SqlClient;
using Models;

namespace DL
{
    public class RepoRestaurants : IRepositoryR
    {
        private readonly string sConnectToDatabase;
        public RepoRestaurants(string sConnectToDatabase)
        {
            this.sConnectToDatabase = sConnectToDatabase;
        }
        public Restaurant AddRestaurant(Restaurant rest)
        {
            string command = "INSERT INTO Restaurants (Id,Name) VALUES (@id,@name);";
            using SqlConnection conectionOne = new(sConnectToDatabase);
            using SqlCommand commandOne = new(command, conectionOne);
            commandOne.Parameters.AddWithValue("@name", rest.Name);
            commandOne.Parameters.AddWithValue("@id", rest.Id);
            conectionOne.Open();
            commandOne.ExecuteNonQuery();
            conectionOne.Close();

            command = "INSERT INTO Location  (Id,Country,State,City,Zipcode) VALUES" +
                                            " (@id,@country,@state,@city,@zipcode);";
            using SqlConnection conectionTwo = new(sConnectToDatabase);
            using SqlCommand commandTwo = new(command, conectionTwo);
            commandTwo.Parameters.AddWithValue("@id", rest.Id);
            commandTwo.Parameters.AddWithValue("@country", rest.Country);
            commandTwo.Parameters.AddWithValue("@state", rest.State);
            commandTwo.Parameters.AddWithValue("@city", rest.City);
            commandTwo.Parameters.AddWithValue("@zipcode", rest.Zipcode);
            conectionTwo.Open();
            commandTwo.ExecuteNonQuery();
            conectionTwo.Close();

            return rest;
        }
        public void DeleteRestaurant(string id)
        {
            string sCommand = $"DELETE FROM Restaurants WHERE Id = '{id}';";
            using SqlConnection sConectionToRest = new(sConnectToDatabase);
            using SqlCommand sSqlCommandR = new(sCommand, sConectionToRest);
            sConectionToRest.Open();
            sSqlCommandR.ExecuteNonQuery();
            sConectionToRest.Close();
            sCommand = $"DELETE FROM Location WHERE Id = '{id}';";
            using SqlConnection sConectionLocation = new(sConnectToDatabase);
            using SqlCommand sSqlCommandL = new(sCommand, sConectionLocation);
            sConectionLocation.Open();
            sSqlCommandL.ExecuteNonQuery();
            sConectionLocation.Close();
            sCommand = $"DELETE FROM Reviews WHERE Id = '{id}';";
            using SqlConnection sConectionReview = new(sConnectToDatabase);
            using SqlCommand sSqlCommand = new(sCommand, sConectionReview);
            sConectionReview.Open();
            sSqlCommand.ExecuteNonQuery();
            sConectionReview.Close();
        }
        public List<Restaurant> DisplayRestaurants(string table, string type, string val)
        {
            string selectCommandString = $"SELECT * FROM {table} WHERE {type} = '{val}'";
            using SqlConnection connection = new(sConnectToDatabase);
            using SqlCommand command = new(selectCommandString, connection);
            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();
            var vRestaurant = new List<Restaurant>();
            while (reader.Read())
            {
                vRestaurant.Add(new Restaurant
                {
                    Name = reader.GetString(0),
                    Id = reader.GetString(1),
                    Country = reader.GetString(2),
                    State = reader.GetString(3),
                    City = reader.GetString(4),
                    Zipcode = reader.GetString(4)
                });
            }

            return vRestaurant;
        }
    }
}