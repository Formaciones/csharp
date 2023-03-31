using Programando.CSharp.ConsoleEF.Model;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Data.Common;

namespace Programando.CSharp.ConsoleEF
{
	internal class Program
	{
        /// <summary>
        /// Inicio de la aplicación
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("".PadRight(56, '*'));
                Console.WriteLine("*  DEMOS CON EF + LINQ".PadRight(55) + "*");
                Console.WriteLine("".PadRight(56, '*'));
                Console.WriteLine("*".PadRight(55) + "*");
                Console.WriteLine("*  1. Consultas con ADO.NET".PadRight(55) + "*");
                Console.WriteLine("*  2. Operaciones con EntityFramework".PadRight(55) + "*");
                Console.WriteLine("*  9. Salir".PadRight(55) + "*");
                Console.WriteLine("*".PadRight(55) + "*");
                Console.WriteLine("".PadRight(56, '*'));

                Console.WriteLine(Environment.NewLine);
                Console.Write("   Opción: ");

                Console.ForegroundColor = ConsoleColor.Cyan;

                int.TryParse(Console.ReadLine(), out int opcion);
                switch (opcion)
                {
                    case 1:
                        ConsultaConADONET();
                        break;
                    case 2:
                        TrabajandoConEF();
                        break;
                    case 9:
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(Environment.NewLine + $"La opción {opcion} no es valida.");
                        break;
                }

                Console.WriteLine(Environment.NewLine);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Pulsa una tecla para continuar...");
                Console.ReadKey();
            }

        }

        /// <summary>
        /// Ejecutar una consulta contra una base de datos utilizando ADO.NET
        /// </summary>
        static void ConsultaConADONET()
		{
            /////////////////////////////////////////////////////////////////////////////////
            // ADO.NET Access Data Object (manejamos la base de datos con Transat-SQL)
            /////////////////////////////////////////////////////////////////////////////////
            // Consulta de Datos - SELECT
            // Equivalente a: SELECT * FROM Customers
            /////////////////////////////////////////////////////////////////////////////////

            //Creamos un objeto para definir la cadena de conexión
            var connectionString = new SqlConnectionStringBuilder()
            {
                DataSource = "LOCALHOST",
                InitialCatalog = "NORTHWIND",
                UserID = "",
                Password = "",
                IntegratedSecurity = true,
                ConnectTimeout = 60
            };

            //Muestra la cadena de conexión resultante con los datos introducidos
            Console.WriteLine("Cadena de Conexión: {0}", connectionString.ToString());

            //Creamos un objeto conexión, representa la conexión con la base de datos
            var connect = new SqlConnection()
            {
                ConnectionString = connectionString.ToString()
            };

            //Comprobamos el estado de la conexión antes y después de conectarnos con la Base de Datos
            Console.WriteLine($"Estado: {connect.State.ToString()}");
            connect.Open();
            Console.WriteLine($"Estado: {connect.State.ToString()}");

            //Creamos un objeto Command que nos permite lanzar comando contra la base de datos
            var command = new SqlCommand()
            {
                Connection = connect,
                CommandText = "SELECT * FROM dbo.Customers"
            };

            //Creamos un objeto que funcione como curso, permitiendo recorrer los datos retornados por la base de datos
            var reader = command.ExecuteReader();

            if (reader.HasRows == false) Console.WriteLine("Registros no encontrados.");
            else
            {
                while (reader.Read() == true)
                {
                    Console.WriteLine($"ID: {reader["CustomerID"]}");
                    Console.WriteLine($"Empresa: {reader.GetValue(1)}");
                    Console.WriteLine($"Pais: {reader["Country"]}" + Environment.NewLine);
                }
            }

            //Cerramos conexiones y destruimos variables
            reader.Close();
            command.Dispose();
            connect.Close();
            connect.Dispose();
        }

        /// <summary>
        /// Ejercutas consultas, inserciones, actualizaciones y borrado de datos utilizando EntityFrameworkCore
        /// </summary>
        static void TrabajandoConEF()
		{
            ////////////////////////////////////////////////////////////////////////////////
            // EntityFramework (manejamos las base de datos como colecciones)
            /////////////////////////////////////////////////////////////////////////////////

            //Declaración de la variable de contexto
            var context = new ModelNorthwind();


            /////////////////////////////////////////////////////////////////////////////////
            // Consulta de Datos - SELECT
            // Equivalente a: SELECT * FROM Customers
            /////////////////////////////////////////////////////////////////////////////////

            var clientes = context.Customers
                .ToList();

            var clientes2 = from c in context.Customers
                            select c;


            //Equivalente a: SELECT * FROM Customers WHERE Country = 'Spain' ORDER BY City

            var clientes3 = context.Customers
                .Where(r => r.Country == "Spain")
                .OrderBy(r => r.City)
                .ToList();

            var clientes4 = from c in context.Customers
                            where c.Country == "Spain"
                            orderby c.City
                            select c;

            foreach (var c in clientes3)
            {
                Console.WriteLine($"ID: {c.CustomerID}");
                Console.WriteLine($"Empresa: {c.CompanyName}");
                Console.WriteLine($"Pais: {c.Country}" + Environment.NewLine);
            }

            /////////////////////////////////////////////////////////////////////////////////
            // Insertar Datos - INSERT
            // Equivalente a: INSERT INTO Customers VALUES(..., ..., )
            /////////////////////////////////////////////////////////////////////////////////

            var cliente = new Customer();

            cliente.CustomerID = "DEMO1";
            cliente.CompanyName = "Empresa Uno, SL";
            cliente.ContactName = "Borja Cabeza";
            cliente.ContactTitle = "Gerente";
            cliente.Address = "Avenida del Mediterraneo, 10";
            cliente.PostalCode = "28010";
            cliente.City = "Madrid";
            cliente.Country = "Spain";
            cliente.Phone = "910 000 001";
            cliente.Fax = "910 000 002";

            context.Customers.Add(cliente);
            context.SaveChanges();


            /////////////////////////////////////////////////////////////////////////////////
            // Modificar Datos - UPDATE
            // Equivalente a: UPDATE Customers SET CompanyName = 'nuevo valor' WHERE CustomerID = 'DEMO1'
            /////////////////////////////////////////////////////////////////////////////////

            var cliente2a = context.Customers
                .Where(r => r.CustomerID == "DEMO1")
                .FirstOrDefault();

            cliente2a.CompanyName = "Empresa Uno Dos y Tres, SL";
            cliente2a.PostalCode = "28014";


            var cliente2b = (from c in context.Customers
                             where c.CustomerID == "DEMO1"
                             select c).FirstOrDefault();

            cliente2b.CompanyName = "Empresa Uno Dos y Tres, SL";
            cliente2b.PostalCode = "28014";

            context.SaveChanges();


            /////////////////////////////////////////////////////////////////////////////////
            // Eliminar Datos - DELETE
            // Equivalente a: DELETE Customers WHERE CustomerID = 'DEMO1'
            /////////////////////////////////////////////////////////////////////////////////

            var cliente3a = context.Customers
                .Where(r => r.CustomerID == "DEMO1")
                .FirstOrDefault();

            context.Customers.Remove(cliente3a);
            context.SaveChanges();

            //Elimina el registro con CustomerID igual a DEMO1
            context.Customers.Remove(context.Customers.Where(r => r.CustomerID == "DEMO1").FirstOrDefault());
            context.SaveChanges();

            //Elimina todos los registros donde País es igual a Spain
            context.Customers.RemoveRange(context.Customers.Where(r => r.Country == "Spain").ToList());
            context.SaveChanges();
        }
    }
}