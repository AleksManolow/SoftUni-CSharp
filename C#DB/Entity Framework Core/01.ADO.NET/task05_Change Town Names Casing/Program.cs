using Microsoft.Data.SqlClient;
using System.Text;

namespace task05_Change_Town_Names_Casing
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            string nameCountry = Console.ReadLine();
            using SqlConnection sqlConnection = new SqlConnection(@"Server=DESKTOP-AJ5FISA\SQLEXPRESS;Database=MinionsDB;Integrated Security = True;TrustServerCertificate=True;");
            sqlConnection.Open();

            SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
            try
            {
                string setTownNameQuery = @"UPDATE Towns
                        SET Name = UPPER(Name)
                     WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";
                SqlCommand setTownNameCmd = new SqlCommand(setTownNameQuery, sqlConnection, sqlTransaction);
                setTownNameCmd.Parameters.AddWithValue("@countryName", nameCountry);

                int rowsAffected = (int)setTownNameCmd.ExecuteNonQuery();
                sqlTransaction.Commit();
                if (rowsAffected > 0)
                {
                    
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine($"{rowsAffected} town names were affected.");


                    string selectTownNameWereChangedQuery = @"SELECT t.Name 
                                                              FROM Towns as t
                                                              JOIN Countries AS c ON c.Id = t.CountryCode
                                                              WHERE c.Name = @countryName";
                    SqlCommand selectTownNameWereChangedCmd = new SqlCommand(selectTownNameWereChangedQuery, sqlConnection);
                    selectTownNameWereChangedCmd.Parameters.AddWithValue("@countryName", nameCountry);

                    SqlDataReader reader = selectTownNameWereChangedCmd.ExecuteReader();
                    List<string> towns = new List<string>();
                    while (reader.Read())
                    {
                        string town = (string)reader["Name"];
                        towns.Add(town);
                    }

                    sb.AppendLine("[" + string.Join(", ", towns) + "]");
                    Console.WriteLine(sb.ToString());
                }
                else
                    Console.WriteLine("No town names were affected.");

            }
            catch (Exception e)
            {
                sqlTransaction.Rollback();
                Console.WriteLine(e.ToString());
            }
            

        }
    }
}