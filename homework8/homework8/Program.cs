using System;
using Microsoft.Data.SqlClient;

namespace homework8
{
    class Program
    {
        static void Main(string[] args)
        {
            var connection = GetConnection();
            var cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO Training (Name, StartDate, FinishDate) " +
                "VALUES " +
                "(Modern JavaScript, 01-09-2015, 25-09-2015), " +
                "(Modern JavaScript, 01-09-2015, 25-09-2015)";
            cmd.Connection = connection;

            using (connection)
            {
                connection.Open();
                var result = cmd.ExecuteScalar();
                Console.WriteLine($"{result}");
            }
        }

        private static SqlConnection GetConnection()
        {
            const string connectionString = "Data Source=DESKTOP-0VUTNS6;" +
                                            "Initial Catalog=myBd;" +
                                            "Integrated Security=True";
            return new SqlConnection(connectionString);
        }
    }
}
