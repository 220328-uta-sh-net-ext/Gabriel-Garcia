using Microsoft.Data.SqlClient;
using Models;

namespace DL
{
    public class RepoUsers : IRepositoryU
    {
        private readonly string sConnectToDatabase;
        public RepoUsers(string sConnectToDatabase)
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
            connection.Close();
            return user;
        }
        public void DeleteUser(string user)
        {
            string command = $"DELETE FROM Users WHERE UserName = '{user}';";
            using SqlConnection connection = new(sConnectToDatabase);
            using SqlCommand sqlCommand = new(command, connection);
            connection.Open();
            sqlCommand.ExecuteReader();
            connection.Close();
        }
        public List<User> DisplayAllUser()
        {
            string command = $"SELECT * FROM Users WHERE UserName != 'Admin'";
            using SqlConnection connection = new(sConnectToDatabase);
            using SqlCommand sqlCommand = new(command, connection);
            connection.Open();
            using SqlDataReader reader = sqlCommand.ExecuteReader();
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
            connection.Close();
            return user;
        }
        public List<User> SearchUser(string WhereIt, string equalsTo)
        {
            string command = $"SELECT * FROM Users WHERE {WhereIt} = '{equalsTo}'";
            using SqlConnection connection = new(sConnectToDatabase);
            using SqlCommand sqlCommand = new(command, connection);
            connection.Open();
            using SqlDataReader reader = sqlCommand.ExecuteReader();
            var user = new List<User>();
            while (reader.Read())
            {
                user.Add(new User
                {
                    FirstName = reader.GetString(0),
                    LastName = reader.GetString(1),
                    Email = reader.GetString(2),
                    UserName = reader.GetString(3),
                    Password = reader.GetString(4),
                    ReviewerId = reader.GetString(5)
                });
            }
            connection.Close();
            return user;
        }
        //--------------Async-----------------
        public async Task<User> AddUserAsync(User user)
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
            try
            {
                await connection.OpenAsync();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            await command.ExecuteNonQueryAsync();
            await connection.CloseAsync();
            return user;
        }
        public async Task<List<User>> DisplayAllUserAsync()
        {
            string command = $"SELECT * FROM Users WHERE UserName != 'Admin'";
            using SqlConnection connection = new(sConnectToDatabase);
            using SqlCommand sqlCommand = new(command, connection);
            try
            {
                await connection.OpenAsync();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            using SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
            var user = new List<User>();
            while (await reader.ReadAsync())
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
            await connection.CloseAsync();
            return user;
        }
        public async Task<List<User>> SearchUserAsync(string WhereIt, string equalsTo)
        {
            string command = $"SELECT * FROM Users WHERE {WhereIt} = '{equalsTo}' AND UserName != 'Admin'";
            using SqlConnection connection = new(sConnectToDatabase);
            using SqlCommand sqlCommand = new(command, connection);
            try
            {
                await connection.OpenAsync();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            using SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
            var user = new List<User>();
            while (await reader.ReadAsync())
            {
                user.Add(new User
                {
                    FirstName = reader.GetString(0),
                    LastName = reader.GetString(1),
                    Email = reader.GetString(2),
                    UserName = reader.GetString(3),
                    Password = reader.GetString(4),
                    ReviewerId = reader.GetString(5)
                });
            }
            await connection.CloseAsync();
            return user;
        }
    }
}
