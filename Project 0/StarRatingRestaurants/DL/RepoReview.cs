using Models;
using System.Data.SqlClient;

namespace DL
{
    public class RepoReview : IRepositoryRev
    {
        private readonly string sConnectToDatabase;
        public RepoReview(string sConnectToDatabase)
        {
            this.sConnectToDatabase = sConnectToDatabase;
        }
        public Reviews AddReviews(Reviews Reviews)
        {
            string selectCommandString = "INSERT INTO Review (Id,ReviewerId,Rate,Review) VALUES" +
                                "(@id,@rid,@rate,@review);";

            using SqlConnection connection = new(sConnectToDatabase);
            using SqlCommand command = new(selectCommandString, connection);
            command.Parameters.AddWithValue("@id", Reviews.Id);
            command.Parameters.AddWithValue("@rid", Reviews.ReviewerId);
            command.Parameters.AddWithValue("@rate", Reviews.Rate);
            command.Parameters.AddWithValue("@review", Reviews.Review);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            return Reviews;
        }

        public void DeleteReviews(string WhereIt, string equalsTo)
        {
            string command = $"DELETE FROM Reviews WHERE {WhereIt} = '{equalsTo}';";
            using SqlConnection conection = new(sConnectToDatabase);
            using SqlCommand sqlCommand = new(command, conection);
            conection.Open();
            sqlCommand.ExecuteReader();
            conection.Close();
        }

        public List<Reviews> DisplayReviews(string WhereIt, string equalsTo)
        {
            string selectCommandString = $"SELECT * FROM Reviews WHERE {WhereIt} = '{equalsTo}';";
            using SqlConnection connection = new(sConnectToDatabase);
            using SqlCommand command = new(selectCommandString, connection);
            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();
            var review = new List<Reviews>();
            while (reader.Read())
            {
                review.Add(new Reviews
                {
                    Id = reader.GetString(0),
                    ReviewerId = reader.GetString(1),
                    Rate = reader.GetInt32(2),
                    Review = reader.GetString(3)
                });
            }
            return review;
        }
    }
}
