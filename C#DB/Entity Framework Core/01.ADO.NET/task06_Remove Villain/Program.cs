using Microsoft.Data.SqlClient;
using System.Text;

namespace task06_Remove_Villain
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int villainId = int.Parse(Console.ReadLine());
            using SqlConnection sqlConnection = 
                new SqlConnection(@"Server=DESKTOP-AJ5FISA\SQLEXPRESS;Database=MinionsDB;Integrated Security = True;TrustServerCertificate=True;");
            sqlConnection.Open();

            string villainNameQuery = @"SELECT Name FROM Villains WHERE Id = @villainId";
            SqlCommand villainNameCmd = new SqlCommand(villainNameQuery, sqlConnection); 
            villainNameCmd.Parameters.AddWithValue("@villainId", villainId);

            string villainName = (string)villainNameCmd.ExecuteScalar();

            if (villainName == null)
            {
                Console.WriteLine($"No such villain was found.");
                return;
            }

            StringBuilder sb = new StringBuilder(); 
            SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
            try
            {
                string deleteMinionsVillainQuery = @"DELETE FROM MinionsVillains 
                                                     WHERE VillainId = @villainId";
                SqlCommand deleteMinionsVillainCmd = new SqlCommand(deleteMinionsVillainQuery, sqlConnection, sqlTransaction);

                deleteMinionsVillainCmd.Parameters.AddWithValue("@villainId", villainId);

                int deletedRows = (int)deleteMinionsVillainCmd.ExecuteNonQuery();

                string deleteVillainQuery = @"DELETE FROM Villains
                                              WHERE Id = @villainId";

                SqlCommand deleteVillainCmd = new SqlCommand(deleteVillainQuery, sqlConnection, sqlTransaction);

                deleteVillainCmd.Parameters.AddWithValue("@villainId", villainId);

                int villainsDeleted = (int)deleteVillainCmd.ExecuteNonQuery();

                if (villainsDeleted != 1)
                {
                    sqlTransaction.Rollback();
                }

                deleteVillainCmd.ExecuteNonQuery();
                sb.AppendLine($"{villainName} was deleted.");
                sb.AppendLine($"{deletedRows} minions were released");

                sqlTransaction.Commit();

                Console.WriteLine(sb.ToString().TrimEnd());
            }
            catch (Exception e)
            {
                sqlTransaction.Rollback();
                Console.WriteLine(e.Message);
            }
        }
    }
}