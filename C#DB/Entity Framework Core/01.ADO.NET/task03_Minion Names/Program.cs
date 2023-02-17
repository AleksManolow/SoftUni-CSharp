using Microsoft.Data.SqlClient;
using System.Text;

namespace task03_Minion_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int Id = int.Parse(Console.ReadLine());
            SqlConnection sqlConnection =
                 new SqlConnection(@"Server=DESKTOP-AJ5FISA\SQLEXPRESS;Database=MinionsDB;Integrated Security = True;TrustServerCertificate=True;");
            sqlConnection.Open();
                
            StringBuilder sb = new StringBuilder();

            SqlCommand sqlCommandGetVillain = new SqlCommand(
                @"SELECT Name FROM Villains WHERE Id = @Id",
                sqlConnection);

            sqlCommandGetVillain.Parameters.AddWithValue("@Id", Id);

            string name = (string)sqlCommandGetVillain.ExecuteScalar();

            if (name == null)
            {
                Console.WriteLine($"No villain with ID {Id} exists in the database.");
                return;
            }

            sb.AppendLine($"Villain: {name}");

            SqlCommand sqlCommandGetAllMinionsForVillainId = new SqlCommand(
                @"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) AS RowNum,
                                         m.Name, 
                                         m.Age
                                    FROM MinionsVillains AS mv
                                    JOIN Minions As m ON mv.MinionId = m.Id
                                   WHERE mv.VillainId = @Id
                                ORDER BY m.Name",
                sqlConnection);

            sqlCommandGetAllMinionsForVillainId.Parameters.AddWithValue("@Id", Id);

            SqlDataReader sqlDataReader = sqlCommandGetAllMinionsForVillainId.ExecuteReader();
            if (!sqlDataReader.HasRows)
            {
                sb.AppendLine("(no minions)");
            }
            else
            {
                while (sqlDataReader.Read())
                {
                    long rowNum = (long)sqlDataReader["RowNum"];
                    string nameMinions = (string)sqlDataReader["Name"];
                    int ageMinions = (int)sqlDataReader["Age"];

                    sb.AppendLine($"{rowNum}. {nameMinions} {ageMinions}");
                }   
            }
            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}