using Models;
using Microsoft.Data.SqlClient;
namespace DatabaseL
{
    internal class RepoUser : IRepositoryU
    {
        private readonly string sConnectToDatabase;
        public RepoUser(string sConnectToDatabase)
        {
            this.sConnectToDatabase = sConnectToDatabase;
        }
        public User AddUser(User user)
        {
            string selectCommandString = "INSERT INTO Users (FirstName,LastName,Email,UserName,Password,ReviewerId) VALUES" +
                                         "(@fname,@lname,@email,@uname,@pass,@rid);";

            using SqlConnection connection = new(sConnectToDatabase);
            using SqlCommand command = new(selectCommandString, connection);
            command.Parameters.AddWithValue("@fname", user.FirstName);
            command.Parameters.AddWithValue("@lname", user.LastName);
            command.Parameters.AddWithValue("@email", user.Email);
            command.Parameters.AddWithValue("@uname", user.UserName);
            command.Parameters.AddWithValue("@pass", user.Password);
            command.Parameters.AddWithValue("@rid", user.ReviewerId);
            connection.Open();
            command.ExecuteNonQuery();
            return user;
        }
        public void DeleteUser(string user, string id)
        {
            string sCommand = $"DELETE FROM Restaurants WHERE UserName = '{user}';";
            using SqlConnection sConectionToUser = new(sConnectToDatabase);
            using SqlCommand sSqlCommandU = new(sCommand, sConectionToUser);
            sConectionToUser.Open();
            sSqlCommandU.ExecuteNonQuery();
            sConectionToUser.Close();
            sCommand = $"DELETE FROM Reviews WHERE ReviewerId = '{id}';";
            using SqlConnection sConectionReview = new(sConnectToDatabase);
            using SqlCommand sSqlCommand = new(sCommand, sConectionReview);
            sConectionReview.Open();
            sSqlCommand.ExecuteNonQuery();
            sConectionReview.Close();
        }
        public List<User> DisplayUser(string name)
        {
            string selectCommandString = "SELECT * FROM Users";
            using SqlConnection connection = new(sConnectToDatabase);
            using SqlCommand command = new(selectCommandString, connection);
            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();
            var user = new List<User>();
            while (reader.Read())
            {
                user.Add(new User
                {
                    FirstName = reader.GetString(0),
                    LastName = reader.GetString(1),
                    Email = reader.GetString(2),
                    UserName = reader.GetString(3),
                    ReviewerId = reader.GetString(5)
                });
            }
            return user;
        }
    }
}
