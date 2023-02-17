using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using System.Text;

namespace task02_Villain_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            using SqlConnection sqlConnection =
                new SqlConnection(@"Server=DESKTOP-AJ5FISA\SQLEXPRESS;Database=MinionsDB;Integrated Security = True;TrustServerCertificate=True;");
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand(
                  @"SELECT 
                        v.Name, 
                        COUNT(mv.VillainId) AS MinionsCount  
                    FROM Villains AS v 
                    JOIN MinionsVillains AS mv ON v.Id = mv.VillainId 
                    GROUP BY v.Id, v.Name 
                    HAVING COUNT(mv.VillainId) > 3 
                    ORDER BY COUNT(mv.VillainId)"
                , sqlConnection);

            StringBuilder sb = new StringBuilder();

            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                string villainName = (string)reader["Name"];
                int minionsCount = (int)reader["MinionsCount"];

                sb.AppendLine($"{villainName} - {minionsCount}");
            }
            sqlConnection.Close();
            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}
