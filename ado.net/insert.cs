using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace ado.net
{
    class Insert
    {
        /// <summary>
        /// Inserta un elemento (field) en la tabla (tableName) con el valor (value).
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="connectionString"></param>
        public void InsertData(string tableName, string fields, string values)
        {
            using (var connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=pizzeria;Integrated Security=True;  Connect Timeout=30;encrypt = false;trustservercertificate = true;  applicationintent = readwrite; multisubnetfailover = false"))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(@"INSERT into " + tableName + " (" + fields + ") VALUES (" + values + ") ", connection)) { command.ExecuteNonQuery(); }
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
