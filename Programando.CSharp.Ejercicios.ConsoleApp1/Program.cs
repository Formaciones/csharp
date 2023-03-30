using System.Linq;

namespace Programando.CSharp.Ejercicios.ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			while(true)

			{
				Console.Clear();
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine("".PadRight(56, '*'));
				Console.WriteLine("*  DEMO Y EJERCICIOS".PadRight(55) + "*");
				Console.WriteLine("".PadRight(56, '*'));
				Console.WriteLine("*".PadRight(55) + "*");
				Console.WriteLine("*  1. Consultas Básicas".PadRight(55) + "*");
				Console.WriteLine("*  2. Otros Ejemplos".PadRight(55) + "*");
				Console.WriteLine("*  3. Cliente mayores de 45 años".PadRight(55) + "*");
				Console.WriteLine("*  4. Productos que comienza C ordenador por precio".PadRight(55) + "*");
				Console.WriteLine("*  5. Listar detalle de un pedido".PadRight(55) + "*");
				Console.WriteLine("*  6. Mostrar el importe total de un pedido".PadRight(55) + "*");
				Console.WriteLine("*  7. Mostrar pedidos con Lapicero".PadRight(55) + "*");
				Console.WriteLine("*  8. Número de pedidos con Cuaderno Grande".PadRight(55) + "*");
				Console.WriteLine("*  9. Unidades vendidas de Cuaderno Pequeño".PadRight(55) + "*");
				Console.WriteLine("* 10. El pedido con más unidades".PadRight(55) + "*");
				Console.WriteLine("* 11. Listado de pedidos ordernados por fecha ".PadRight(55) + "*");
				Console.WriteLine("* 90. Salir".PadRight(55) + "*");
				Console.WriteLine("*".PadRight(55) + "*");
				Console.WriteLine("".PadRight(56, '*'));

				Console.WriteLine(Environment.NewLine);
				Console.Write("   Opción: ");

				Console.ForegroundColor = ConsoleColor.Cyan;

				int.TryParse(Console.ReadLine(), out int opcion);
				switch (opcion)
				{
					case 1:
						ConsultasBasicas();
						break;
					case 2:
						OtrosEjemplos();
						break;
					case 3:
						Ejercicio1();
						break;
					case 4:
						Ejercicio2();
						break;
					case 5:
						Ejercicio3();
						break;
					case 6:
						Ejercicio4();
						break;
					case 7:
						Ejercicio5();
						break;
					case 8:
						Ejercicio6();
						break;
					case 9:
						Ejercicio7();
						break;
					case 10:
						Ejercicio8();
						break;
					case 11:
						Ejercicio9();
						break;
					case 90:
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

		static void ConsultasBasicas()
		{
			// T-SQL: SELECT * FROM dbo.ListaProductos

			// Métodos de LINQ
			var r1a = DataLists.ListaProductos
				.Select(r => r);

			// Expresión LINQ
			var r1b = from r in DataLists.ListaProductos
					  select r;

			foreach(Producto item in r1b) Console.WriteLine($"{item.Id} {item.Descripcion}");
			Console.WriteLine(Environment.NewLine);


			// T-SQL: SELECT Nombre FROM dbo.ListaClientes

			// Métodos de LINQ
			var r2a = DataLists.ListaClientes
				.Select(r => r.Nombre);

			// Expresión LINQ
			var r2b = from r in DataLists.ListaClientes
					  select r.Nombre;

			foreach (string item in r2b) Console.WriteLine($"{item}");
			Console.WriteLine(Environment.NewLine);

			// T-SQL: SELECT Id, Nombre FROM dbo.ListaClientes

			// Métodos de LINQ
			var r3a = DataLists.ListaClientes
				.Select(r => new { r.Id, r.Nombre });

			// Expresión LINQ
			var r3b = from r in DataLists.ListaClientes
					  select new { r.Id, r.Nombre };

			foreach (var item in r3b) Console.WriteLine($"{item.Id} {item.Nombre}");
			Console.WriteLine(Environment.NewLine);

			// T-SQL: SELECT Id AS Code, Nombre AS NombreCompleto FROM dbo.ListaClientes

			var r3c = DataLists.ListaClientes
				.Select(r => new { Code = r.Id, NombreCompleto = r.Nombre });

			foreach (var item in r3c) Console.WriteLine($"{item.Code} {item.NombreCompleto}");
			Console.WriteLine(Environment.NewLine);

			// T-SQL: SELECT Descripcion FROM dbo.ListaProductos WHERE precio < 0.90

			// Métodos de LINQ
			var r4a = DataLists.ListaProductos
				.Where(r => r.Precio < 0.90)
				.Select(r => r.Descripcion);

			// Expresión LINQ
			var r4b = from r in DataLists.ListaProductos
					  where r.Precio < 0.90
					  select r.Descripcion;

			foreach (var item in r4b) Console.WriteLine($"{item}");
			Console.WriteLine(Environment.NewLine);

			// T-SQL: SELECT Descripcion FROM dbo.ListaProductos WHERE precio < 0.90 ORDER BY Descripcion


			// Métodos de LINQ
			var r5a = DataLists.ListaProductos				//Ordenando DB
				.Where(r => r.Precio < 0.90)
				.OrderBy(r => r.Descripcion)
				.Select(r => r.Descripcion);

			var r5c = DataLists.ListaProductos				//Ordenando DB
				.Where(r => r.Precio < 0.90)
				.OrderByDescending(r => r.Descripcion)
				.Select(r => r.Descripcion);

			var r5e = DataLists.ListaProductos				//Ordernando PC
				.Where(r => r.Precio < 0.90)
				.Select(r => r.Descripcion)
				.OrderBy(r => r);

			// Expresión LINQ
			var r5b = from r in DataLists.ListaProductos
					  where r.Precio < 0.90
					  orderby r.Descripcion
					  select r.Descripcion;

			var r5d = from r in DataLists.ListaProductos
					  where r.Precio < 0.90
					  orderby r.Descripcion descending
					  select r.Descripcion;

			var r5f = (from r in DataLists.ListaProductos
					   where r.Precio < 0.90
					   select r.Descripcion).ToList().OrderBy(r => r);


			foreach (var item in r5d) Console.WriteLine($"{item}");
			Console.WriteLine(Environment.NewLine);
		}

		static void OtrosEjemplos()
		{
			////////////////////////////////////////////////////////////
			// CONTIENE, COMIENZA O FINALIZA
			////////////////////////////////////////////////////////////

			//	Contains -> Contiene; StartsWith -> Comienza; EndsWith -> Finaliza

			var r6a = DataLists.ListaProductos
				.Where(r => r.Descripcion.ToLower().Contains("boli"))
				.Select(r => r);

			var r6b = from r in DataLists.ListaProductos
					  where r.Descripcion.ToLower().Contains("boli")
					  select r;

			var producto = DataLists.ListaProductos
				.Where(r => r.Id == 4)
				.FirstOrDefault();



			////////////////////////////////////////////////////////////
			// AGREGACIÓN
			////////////////////////////////////////////////////////////

			// Count -> Cuenta los elmentos
			// Distinct -> Valor distinto
			// Max -> valor máximo;
			// Min -> valor minimo
			// Sum -> suma de valores;
			// Average -> media de los valores
			// Aggregate -> Aplicar formula o métod de Agregación

			var r7a = DataLists.ListaProductos
				.Where(r => r.Precio < 0.90)
				.Count();

			var r7b = DataLists.ListaProductos
				.Count(r => r.Precio < 0.90);

			var r7c = (from r in DataLists.ListaProductos
					   where r.Precio < 0.90
					   select r.Descripcion).Count();



			////////////////////////////////////////////////////////////
			// PAGINACIÓN
			////////////////////////////////////////////////////////////
			
			// Páginación en DB
			var lista = DataLists.ListaProductos
				.OrderBy(r => r.Descripcion)
				.Skip(5)
				.Take(5)
				.Select(r => r);

			// Paginación en PC
			var lista2 = DataLists.ListaProductos
				.OrderBy(r => r.Descripcion)
				.Select(r => r)
				.Skip(5)
				.Take(5);
		}

		static void Ejercicio1()
		{
			var clientes = DataLists.ListaClientes
				.Where(r => (DateTime.Now.Subtract(r.FechaNac).TotalDays / 365) > 40)
				.ToList();

			var clientes2 = DataLists.ListaClientes
				.Where(r => (DateTime.Now.Year - r.FechaNac.Year) > 40)
				.ToList();

			var clientes3 = DataLists.ListaClientes
				.Where(r => r.FechaNac < DateTime.Now.AddYears(-40))
				.ToList();

			foreach (var item in clientes) Console.WriteLine($"{item.Id}# {item.Nombre}");
			Console.WriteLine(Environment.NewLine);
		}

		static void Ejercicio2()
		{
			var productos = DataLists.ListaProductos
				.Where(r => r.Descripcion.ToLower().StartsWith("c"))
				.Select(r => r);

			foreach (var item in productos) Console.WriteLine($"{item.Id}# {item.Descripcion}");
			Console.WriteLine(Environment.NewLine);
		}

		static void Ejercicio3()
		{
			// Listar Id, Descripción, Cantidad y Precio de los productos de un pedido
			
			Console.Write("Número de Pedido: ");
			int idPedido = Convert.ToInt32(Console.ReadLine());

			var lineas = DataLists.ListaLineasPedido
				.Where(r => r.IdPedido == idPedido)
				.Select(r => new {
					r.Id,
					Producto = DataLists.ListaProductos
						.Where(s => s.Id == r.IdProducto)
						.Select(s => s.Descripcion)
						.FirstOrDefault(),
					Precio = DataLists.ListaProductos
						.Where(s => s.Id == r.IdProducto)
						.Select(s => s.Precio)
						.FirstOrDefault(),
					r.Cantidad });

			foreach (var item in lineas) 
				Console.WriteLine($"{item.Id}# " +
					$"{item.Producto.PadRight(20)} " +
					$"{item.Cantidad.ToString("N0").PadLeft(6)}" +
					$"{item.Precio.ToString("N2").PadLeft(8)}" +
					$"{(item.Precio * item.Cantidad).ToString("N2").PadLeft(8)}");

			Console.WriteLine(Environment.NewLine);
		}

		static void Ejercicio4()
		{
			Console.Write("Número de Pedido: ");
			int idPedido = Convert.ToInt32(Console.ReadLine());

			var total = DataLists.ListaLineasPedido
				.Where(r => r.IdPedido == idPedido)
				.Sum(r => r.Cantidad * DataLists.ListaProductos
											.Where(s => s.Id == r.IdProducto)
											.Select(s => s.Precio)
											.FirstOrDefault());

			Console.WriteLine($"Importe Total: {total.ToString("N2")}");
			Console.WriteLine(Environment.NewLine);
		}

		static void Ejercicio5()
		{
			var ids = DataLists.ListaProductos
				.Where(r => r.Descripcion.ToLower().Contains("lapicero"))
				.Select(r => r.Id);

			var idPedidos = DataLists.ListaLineasPedido
				.Where(r => ids.Contains(r.IdProducto))
				.Select(r => r.IdPedido)
				.Distinct();

			foreach (var item in idPedidos) Console.WriteLine($"ID Pedido: {item}  (contiene Lapicero)");
			Console.WriteLine(Environment.NewLine);
		}

		static void Ejercicio6()
		{
			var idCuaderno = DataLists.ListaProductos
				.Where(r => r.Descripcion.ToLower() == "cuaderno grande")
				.Select(s => s.Id)
				.FirstOrDefault();

			var numPedidos = DataLists.ListaLineasPedido
				.Where(r => idCuaderno == r.IdProducto)
				.Count();

			Console.WriteLine($"{numPedidos} pedidos contienen Cuaderno Grande");
			Console.WriteLine(Environment.NewLine);
		}

		static void Ejercicio7()
		{
			var unidades = DataLists.ListaLineasPedido
				.Where(r => DataLists.ListaProductos
								.Where(s => s.Descripcion.ToLower() == "cuaderno pequeño")
								.Select(s => s.Id)
								.FirstOrDefault() == r.IdProducto)
				.Sum(s => s.Cantidad);


			Console.WriteLine($"{unidades} Cuadernos Pequeños vendidos");
			Console.WriteLine(Environment.NewLine);
		}

		static void Ejercicio8()
		{
			var pedido = DataLists.ListaLineasPedido
				.GroupBy(r => r.IdPedido)
				.Select(r => new { r.Key, Unidades = r.Sum(s => s.Cantidad) })
				.OrderByDescending(r => r.Unidades)
				.FirstOrDefault();

			Console.WriteLine($"ID Pedido: {pedido.Key} (mayor número de unidades ({pedido.Unidades}))");
			Console.WriteLine(Environment.NewLine);
		}

		static void Ejercicio9()
		{
			var pedidos = DataLists.ListaPedidos
				.OrderBy(r => r.FechaPedido)
				.Select(r => r);

			foreach (var item in pedidos) 
			Console.WriteLine($"Fecha: {item.FechaPedido.ToShortDateString()}  -> {item.Id.ToString().PadLeft(3)}");
			Console.WriteLine(Environment.NewLine);
		}
	}
}