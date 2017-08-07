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
            

            // Con la @ que hay delante de las comillas se permite un string multilinea apra que sea más claro de leer. También se usa para poder poner caracteres de escape.
            // Con "using" nos ahorramos el finally, que lo usábamos para llamar a dispose o a close, pero using llama a dispose automáticamente. El try catch es necesario porque using no controla excepciones.
            using (var connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;
                                                Initial Catalog=pizzeria;
                                                Integrated Security=True;
                                                Connect Timeout=30;
                                                Encrypt=False;
                                                TrustServerCertificate=True;
                                                ApplicationIntent=ReadWrite;
                                                MultiSubnetFailover=False"))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(@"CREATE TABLE [Pizzas]
                                                                ([ID] INT IDENTITY(1,1) NOT NULL CONSTRAINT pkPizzaId PRIMARY KEY, [Nombre] NVARCHAR(max) NOT NULL, [Precio] DECIMAL NOT NULL)", connection)) { command.ExecuteNonQuery(); }
                    Console.WriteLine("Connection state:");
                    Console.WriteLine(connection.State);
                    Console.ReadLine();
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
