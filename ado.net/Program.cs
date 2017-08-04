using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ado.net
{
    class Program
    {
        static void Main(string[] args)
        {
            // Con la @ que hay delante de las comillas se permite un string multilinea apra que sea más claro de leer. También se usa para poder poner caracteres de escape.
            var connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;
                                                Initial Catalog=pizzeria;
                                                Integrated Security=True;
                                                Connect Timeout=30;
                                                Encrypt=False;
                                                TrustServerCertificate=True;
                                                ApplicationIntent=ReadWrite;
                                                MultiSubnetFailover=False");

            try
            {
                connection.Open();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e) // Exception siempre se tiene que poner, pero siempre al final, la más general, por si se ha escapado algo. Antes de ella, poner todas las excepciones más concretas posibles, para informar al usuario.
            {
                Console.WriteLine(e.GetType().Name); // De esta forma nos devuelve qué tipo de exception es, y así yo puedo ponerlas antes de la exception general. Este devuelve sqlexception.
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    //connection.Close();
                    connection.Dispose(); // Con esto se cierra también la conexión, a parte de liberar recursos, estando esta, connection.close no es necesaria.
                    Console.WriteLine(connection.State);
                    Console.ReadLine();
                }
                //connection.Dispose(); // Dispose es una interfaz de tipo idisposable --> Interfaz de marcado, dice al sistema "se va a ejecutar esto, consume tanto". Se usa para hacer algo que va a consumir recursos. Responsable de que cualquier cosa que consuma un recurso. Connection.dispose cierra y libera los recursos.
            }
        }
    }
}
