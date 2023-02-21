using Microsoft.Data.SqlClient;
using System.Text;

namespace task08_Increase_Minion_Age
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] minionsId = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            SqlConnection sqlConnection =
                new SqlConnection(@"Server=DESKTOP-AJ5FISA\SQLEXPRESS;Database=MinionsDB;Integrated Security = True;TrustServerCertificate=True;");
            sqlConnection.Open();

            SqlTransaction sqlTransaction= sqlConnection.BeginTransaction();
            try
            {
                string incrementMinionAgeQuery = @"UPDATE Minions
                                                       SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
                                                       WHERE Id = @Id";
                for (int i = 0; i < minionsId.Length; i++)
                {                
                    SqlCommand incrementMinionAgeCmd = new SqlCommand(incrementMinionAgeQuery, sqlConnection, sqlTransaction);

                    incrementMinionAgeCmd.Parameters.AddWithValue("@Id", minionsId[i]);
                    incrementMinionAgeCmd.ExecuteNonQuery();
                }
                sqlTransaction.Commit();
            }
            catch (Exception e)
            {
                sqlTransaction.Rollback();
                Console.WriteLine(e.Message);
            }
            
            StringBuilder sb = new StringBuilder(); 

            string selectAllMinionsQuery = @"SELECT Name, Age FROM Minions";
            SqlCommand selectAllMinionsCmd = new SqlCommand(selectAllMinionsQuery, sqlConnection);
            SqlDataReader reader = selectAllMinionsCmd.ExecuteReader();
            while (reader.Read())
            {
                sb.AppendLine($"{reader["Name"]} {reader["Age"]}");
            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}