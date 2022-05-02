using MainML;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.IO;
using Microsoft.Data.SqlClient;

namespace MainDL
{
    public class RepositoryR : IRepositoryR
    {
        readonly string connectionString;
        public RepositoryR(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public Restaurant AddRestaurant(Restaurant rest)
        {
            string selectCommandString = "INSERT INTO Restaurant (Name,Id,Review,NReviews,Country,State,Zipcode,TypeOf) VALUES "+
                                         "(@name,@id,@review,@nreview,@country,@state,@zip,@types)";

            using SqlConnection connection = new(connectionString);
            using SqlCommand command = new(selectCommandString, connection);
            command.Parameters.AddWithValue("@name", rest.Name);
            command.Parameters.AddWithValue("@id", rest.ID);
            command.Parameters.AddWithValue("@review", rest.Review);
            command.Parameters.AddWithValue("@nreview", rest.NReview);
            command.Parameters.AddWithValue("@country", rest.Country);
            command.Parameters.AddWithValue("@state", rest.State);
            command.Parameters.AddWithValue("@zip", rest.Zipcode);
            command.Parameters.AddWithValue("@types", rest.TypeOf);
            connection.Open();
            command.ExecuteNonQuery();

            return rest;
        }
        public void AddReview(string id, int rev)
        {
            string selectCommandString = $"UPDATE Restaurant SET Review = Review + @rev, NReviews = NReviews + 1 WHERE Id = '{id}'";
            using SqlConnection connection = new(connectionString);
            using SqlCommand command = new(selectCommandString, connection);
            command.Parameters.AddWithValue("@rev", rev);
            connection.Open();
            command.ExecuteNonQuery();
        }

        public List<Restaurant> GetAllRestaurants()
        {
            string selectCommandString = "SELECT * FROM Restaurant";

            using SqlConnection connection = new(connectionString);
            using SqlCommand command = new(selectCommandString, connection);
            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();
            int temp;
            var vRestaruant = new List<Restaurant>();

            while (reader.Read())
            {
                vRestaruant.Add(new Restaurant
                {
                    Name = reader.GetString(0),
                    ID = reader.GetString(1),

                    Review = reader.GetInt32(2),
                    NReview = reader.GetInt32(3),

                    Country = reader.GetString(4),
                    State = reader.GetString(5),
                    Zipcode = reader.GetString(6),
                    TypeOf = reader.GetString(7)
                });
            }

            return vRestaruant;
        }
    }
    public class RepositoryU : IRepositoryU
    {
        readonly string connectionString;
        public RepositoryU(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public User AddUser(User user)
        {
            string selectCommandString = "INSERT INTO UserData (FName,LName,UserName,Password) VALUES" +
                                         "(@fname,@lname,@user,@pass);";

            using SqlConnection connection = new(connectionString);
            using SqlCommand command = new(selectCommandString, connection);
            command.Parameters.AddWithValue("@fname", user.FName);
            command.Parameters.AddWithValue("@lname", user.LName);
            command.Parameters.AddWithValue("@user", user.UserName);
            command.Parameters.AddWithValue("@pass", user.Password);
            connection.Open();
            command.ExecuteNonQuery();

            return user;
        }

        public List<User> GetAllUser()
        {
            string selectCommandString = "SELECT * FROM UserData";

            using SqlConnection connection = new(connectionString);
            using SqlCommand command = new(selectCommandString, connection);
            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();

            var user = new List<User>();

            while (reader.Read())
            {
                user.Add(new User
                {
                    FName = reader.GetString(0),
                    LName = reader.GetString(1),
                    UserName = reader.GetString(2)
                });
            }
            return user;
        }
        public List<User> GetLogUser()
        {
            string selectCommandString = "SELECT * FROM UserData";

            using SqlConnection connection = new(connectionString);
            using SqlCommand command = new(selectCommandString, connection);
            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();

            var user = new List<User>();

            while (reader.Read())
            {
                user.Add(new User
                {
                    UserName = reader.GetString(2),
                    Password = reader.GetString(3)
                });
            }
            return user;
        }
    }
}