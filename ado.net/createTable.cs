using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace ado.net
{
    public class createTable
    {
        public void CreateTable(string tableName, string connectionString)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Connection state:");
                    Console.WriteLine(connection.State);

                    using (SqlCommand command = new SqlCommand(@"CREATE TABLE [dbo].['" + tableName + "']([ID] INT IDENTITY(1,1) NOT NULL CONSTRAINT pkPizzaId PRIMARY KEY)", connection)) { command.ExecuteNonQuery(); }
                    Console.WriteLine("Connection state:");
                    Console.WriteLine(connection.State);
                    Console.ReadLine();
                    connection.Close();
                    Console.WriteLine(connection.State);
                    Console.ReadLine();

                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
