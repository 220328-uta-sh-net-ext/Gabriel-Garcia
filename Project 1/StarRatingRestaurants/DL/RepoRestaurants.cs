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
            using SqlConnection connectionOne = new(sConnectToDatabase);
            using SqlCommand commandOne = new(command, connectionOne);
            commandOne.Parameters.AddWithValue("@name", rest.Name);
            commandOne.Parameters.AddWithValue("@id", rest.Id);
            connectionOne.Open();
            commandOne.ExecuteNonQuery();
            connectionOne.Close();
            return rest;
        }
        public void DeleteRestaurant(string id)
        {
            string command = $"DELETE FROM Restaurants WHERE Id = '{id}';";
            using SqlConnection conectionOne = new(sConnectToDatabase);
            using SqlCommand commandOne = new(command, conectionOne);
            conectionOne.Open();
            commandOne.ExecuteReader();
            conectionOne.Close();
        }
        public List<Restaurant> DisplayAllRestaurant()
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
        //---------------Async----------------
        public async Task<Restaurant> AddRestaurantAsync(Restaurant rest)
        {
            string command = "INSERT INTO Restaurants (Id,Name) VALUES (@id,@name);";
            using SqlConnection connectionOne = new(sConnectToDatabase);
            using SqlCommand commandOne = new(command, connectionOne);
            commandOne.Parameters.AddWithValue("@name", rest.Name);
            commandOne.Parameters.AddWithValue("@id", rest.Id);
            try
            {
                await connectionOne.OpenAsync();
                await commandOne.ExecuteNonQueryAsync();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            await connectionOne.CloseAsync();
            return rest;
        }
        public async Task<List<Restaurant>> DisplayAllRestaurantAsync()
        {
            string selectCommandString = $"SELECT * FROM Restaurants;";
            using SqlConnection connection = new(sConnectToDatabase);
            using SqlCommand command = new(selectCommandString, connection);
            try
            {
                await connection.OpenAsync();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            using SqlDataReader reader = await command.ExecuteReaderAsync();
            var vRestaurant = new List<Restaurant>();
            while (await reader.ReadAsync())
            {
                vRestaurant.Add(new Restaurant
                {
                    Id = reader.GetString(0),
                    Name = reader.GetString(1)
                });
            }
            await connection.CloseAsync();
            return vRestaurant;
        }
        public async Task<List<Restaurant>> SearchRestaurantsAsync(string WhereIt, string equalsTo)
        {
            string selectCommandString = $"SELECT * FROM Restaurants WHERE {WhereIt} = '{equalsTo}'";
            using SqlConnection connection = new(sConnectToDatabase);
            using SqlCommand command = new(selectCommandString, connection);
            try
            {
                await connection.OpenAsync();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            using SqlDataReader reader = await command.ExecuteReaderAsync();
            var vRestaurant = new List<Restaurant>();
            while (await reader.ReadAsync())
            {
                vRestaurant.Add(new Restaurant
                {
                    Id = reader.GetString(0),
                    Name = reader.GetString(1)
                });
            }
            await connection.CloseAsync();
            return vRestaurant;
        }

    }
}