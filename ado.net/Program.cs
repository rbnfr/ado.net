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
            var connection = new SqlConnection("Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            try
            {
                connection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
                connection.Dispose(); // Dispose es una interfaz de tipo idisposable --> Interfaz de marcado, dice al sistema "se va a ejecutar esto, consume tanto". Se usa para hacer algo que va a consumir recursos. Responsable de que cualquier cosa que consuma un recurso. Connection.dispose cierra y libera los recursos.
            }
        }
    }
}
