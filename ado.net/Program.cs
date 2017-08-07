using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace ado.net
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=pizzeria;Integrated Security=True;  Connect Timeout=30;encrypt = false;trustservercertificate = true;  applicationintent = readwrite; multisubnetfailover = false";
            //// Crear tabla
            //var table = new CreateTable();
            //table.createTable("Pizzas", connectionString);

            // Insertar en tabla
            using (SqlConnection connection = new SqlConnection (connectionString))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();

                SqlTransaction beginTransaction = connection.BeginTransaction("Transaction");

                command.Connection = connection;
                command.Transaction = beginTransaction;
                try
                {
                    command.CommandText = "INSERT into Pizzas (Name, Price) VALUES ('Barbacoa', 5)";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT into Pizzas (Name, Price) VALUES ('Marinera', 2)";
                    command.ExecuteNonQuery();

                    beginTransaction.Commit();
                    Console.WriteLine("Success");
                    //Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Commit Exception Type: {0}", e.GetType());
                    Console.WriteLine("  Message: {0}", e.Message);
                    Console.ReadLine();
                }
            }
            //var fields = "Name, Price";
            //var values = "'Barbacoa', 8";
            //var insert = new Insert();
            //insert.InsertData("Pizzas", fields, values);
            //Console.WriteLine("Success");
            //Console.ReadLine();


        }

    }

}
