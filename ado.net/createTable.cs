using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace ado.net
{
    public class CreateTable
    {
        /// <summary>
        /// Crea una tabla nueva.
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="connectionString"></param>
        public void createTable(string tableName, string connectionString)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(@"if not exists CREATE TABLE [" + tableName + "]([ID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, [Name] NVARCHAR(max) NOT NULL, [Price] DECIMAL NOT NULL)", connection)) { command.ExecuteNonQuery(); }
                    connection.Close();
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
