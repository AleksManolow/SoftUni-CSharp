using Microsoft.Data.SqlClient;
using System.Text;

namespace task09_Increase_Age_Stored_Procedure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int minionId = int.Parse(Console.ReadLine());
            using SqlConnection sqlConnection =
               new SqlConnection(@"Server=DESKTOP-AJ5FISA\SQLEXPRESS;Database=MinionsDB;Integrated Security = True;TrustServerCertificate=True;");
            sqlConnection.Open();

            StringBuilder output = new StringBuilder();

            string increaseAgeQuery = @"EXEC [dbo].[usp_GetOlder] @MinionId";
            SqlCommand increaseAgeCmd = new SqlCommand(increaseAgeQuery, sqlConnection);
            increaseAgeCmd.Parameters.AddWithValue("@MinionId", minionId);

            increaseAgeCmd.ExecuteNonQuery();

            string minionInfoQuery = @"SELECT [Name],
                                              [Age]
                                         FROM [Minions]
                                        WHERE [Id] = @MinionId";
            SqlCommand minionInfoCmd = new SqlCommand(minionInfoQuery, sqlConnection);
            minionInfoCmd.Parameters.AddWithValue("@MinionId", minionId);

            using SqlDataReader infoReader = minionInfoCmd.ExecuteReader();
            while (infoReader.Read())
            {
                output.AppendLine($"{infoReader["Name"]} – {infoReader["Age"]} years old");
            }

            Console.WriteLine(output.ToString().TrimEnd());

        }
    }
}