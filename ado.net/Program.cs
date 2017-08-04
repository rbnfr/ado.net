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
            // Con "using" nos ahorramos el finally, que lo usábamos para llamar a dispose o a close, pero using llama a dispose automáticamente. El try catch es necesario porque using no controla excepciones.
            /*using (var connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;
                                                Initial Catalog=mister;
                                                Integrated Security=True;
                                                Connect Timeout=30;
                                                Encrypt=False;
                                                TrustServerCertificate=True;
                                                ApplicationIntent=ReadWrite;
                                                MultiSubnetFailover=False"))
            {
                connection.Open(); // Si no se puede conectar, hay una excepción no controlada, es necesario el try catch.
            }
            /*
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
            }*/

            using (var person = new Person()) // Using crea una instancia de using y la última linea, cuando se sale d ela llave, llama a dispose y no nos deja compilar porque la clase no es disposable, es decir, no usa recursos ni abre conexiones, entonces no es "cerrable". Habría que implementarle la interfaz disposable a la clase person.
            {

            }
        }
    }
    class Person : IDisposable // Ahora la clae sí es disposable. Al llegar a la última llave se irá automáticamente al método dispose de la clase person, donde en teoría estarán las órdenes de cerrado de conexiones y liberación de recursos.
    {
        public int Id { get; set; }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
