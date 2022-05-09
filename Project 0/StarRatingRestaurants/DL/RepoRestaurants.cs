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
            string command = $"DELETE FROM Location WHERE Id = '{id}';";
            using SqlConnection conectionTwo = new(sConnectToDatabase);
            using SqlCommand commandTwo = new(command, conectionTwo);
            conectionTwo.Open();
            commandTwo.ExecuteReader();
            conectionTwo.Close();

            command = $"DELETE FROM Restaurants WHERE Id = '{id}';";
            using SqlConnection conectionOne = new(sConnectToDatabase);
            using SqlCommand commandOne = new(command, conectionOne);
            conectionOne.Open();
            commandOne.ExecuteReader();
            conectionOne.Close();


        }

        public List<Restaurant> DisplayAllRestLocation()
        {
            string selectCommandString = $"SELECT * FROM Restaurants;";
            using SqlConnection connection = new(sConnectToDatabase);
            using SqlCommand command = new(selectCommandString, connection);
            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();
            var vRestaurant = new List<Restaurant>();
            while (reader.Read())
            {
                vRestaurant.Add(new Restaurant
                {
                    Id = reader.GetString(0),
                    Name = reader.GetString(1)
                });
            }
            connection.Close();
            return vRestaurant;
        }

        public List<Restaurant> SearchRestaurants( string WhereIt, string equalsTo)
        {
            string selectCommandString = $"SELECT * FROM Restaurants WHERE {WhereIt} = '{equalsTo}'";
            using SqlConnection connection = new(sConnectToDatabase);
            using SqlCommand command = new(selectCommandString, connection);
            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();
            var vRestaurant = new List<Restaurant>();
            while (reader.Read())
            {
                vRestaurant.Add(new Restaurant
                {
                    Id = reader.GetString(0),
                    Name = reader.GetString(1)
                });
            }
            connection.Close();
            return vRestaurant;
        }
        public List<Restaurant> SearchRestLocation(string WhereIt, string equalsTo)
        {
            string selectCommandString = $"SELECT * FROM Location WHERE {WhereIt} = '{equalsTo}'";
            using SqlConnection connection = new(sConnectToDatabase);
            using SqlCommand command = new(selectCommandString, connection);
            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();
            var vRestaurant = new List<Restaurant>();
            while (reader.Read())
            {
                vRestaurant.Add(new Restaurant
                {
                    Country = reader.GetString(1),
                    State = reader.GetString(2),
                    City = reader.GetString(3),
                    Zipcode = reader.GetString(4)
                });
            }
            connection.Close();
            return vRestaurant;
        }
    }
}