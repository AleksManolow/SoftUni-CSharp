using Microsoft.Data.SqlClient;

namespace task07_Print_All_Minion_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using SqlConnection sqlConnection =
                new SqlConnection(@"Server=DESKTOP-AJ5FISA\SQLEXPRESS;Database=MinionsDB;Integrated Security = True;TrustServerCertificate=True;");
            sqlConnection.Open();

            string getMinionsNameQuery = @"SELECT Name FROM Minions";
            SqlCommand getMinionsNameCmd = new SqlCommand(getMinionsNameQuery, sqlConnection);

            SqlDataReader reader = getMinionsNameCmd.ExecuteReader();
            List<string> minionsName = new List<string>();
            while (reader.Read())
            {
                minionsName.Add((string)reader["Name"]);
            }

            int firstIt = 0;
            int secondIt = minionsName.Count() - 1;    
            while (firstIt < secondIt)
            {
                Console.WriteLine(minionsName[firstIt]);
                Console.WriteLine(minionsName[secondIt]);


                if (firstIt + 1 == secondIt)
                {
                    break;  
                }

                firstIt++;
                secondIt--;
                if (firstIt == secondIt)
                {
                    Console.WriteLine(minionsName[firstIt]);
                }
            }
        }
    }
}