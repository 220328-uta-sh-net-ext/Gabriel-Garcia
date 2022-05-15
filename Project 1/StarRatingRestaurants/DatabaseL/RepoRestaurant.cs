using Models;
using Microsoft.Data.SqlClient;
namespace DatabaseL
{
    public class RepoRestaurant : IRepositoryR
    {
        private readonly string sConnectToDatabase;
        public RepoRestaurant(string sConnectToDatabase)
        {
            this.sConnectToDatabase = sConnectToDatabase;
        }
        public Restaurant AddRestaurant(Restaurant rest)
        {
            string sCommand ="INSERT INTO Restaurants (Id,Name) VALUES (@id,@name)";
            using SqlConnection sConectionToRest= new(sConnectToDatabase);
            using SqlCommand sSqlCommandR = new(sCommand, sConectionToRest);
            sSqlCommandR.Parameters.AddWithValue("@name", rest.Name);
            sSqlCommandR.Parameters.AddWithValue("@id", rest.Id);
            sConectionToRest.Open();
            sSqlCommandR.ExecuteNonQuery();
            sConectionToRest.Close();

            sCommand = "INSERT INTO Location  (Id,Country,State,City,Zipcode) VALUES" +
                                            " (@id,@country,@state,@city,@zipcode)";
            using SqlConnection connection = new(sConnectToDatabase);
            using SqlCommand command = new(sCommand, connection);
            sSqlCommandR.Parameters.AddWithValue("@id", rest.Name);
            sSqlCommandR.Parameters.AddWithValue("@country", rest.Name);
            sSqlCommandR.Parameters.AddWithValue("@state", rest.Name);
            sSqlCommandR.Parameters.AddWithValue("@city", rest.Name);
            sSqlCommandR.Parameters.AddWithValue("@zipcode", rest.Id);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

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
        public List<Restaurant> DisplayRestaurants(string table,string type, string val)
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