using System.Linq;

namespace Programando.CSharp.Ejercicios.ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.Clear();
			Ejercicios();
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

			// Otros Ejemplos

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
		}

		static void Ejercicios()
		{
			// Listado de clientes mayores de 40 años
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


			// Listado de productos que comiencen por la letra C ordenador por precio

			var productos = DataLists.ListaProductos
				.Where(r => r.Descripcion.ToLower().StartsWith("c"))
				.Select(r => r);

			foreach (var item in productos) Console.WriteLine($"{item.Id}# {item.Descripcion}");
			Console.WriteLine(Environment.NewLine);


			// Preguntar por el id de un pedido y listar el contenido
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


			// Preguntar por el id de un pedido y mostrar el total
			
			Console.Write("Número de Pedido: ");
			int idPedido2 = Convert.ToInt32(Console.ReadLine());

			var total = DataLists.ListaLineasPedido
				.Where(r => r.IdPedido == idPedido)
				.Sum(r => r.Cantidad * DataLists.ListaProductos
											.Where(s => s.Id == r.IdProducto)
											.Select(s => s.Precio)
											.FirstOrDefault());

			Console.WriteLine($"Importe Total: {total.ToString("N2")}");
			Console.WriteLine(Environment.NewLine);


			// Listado de pedidos que contengan Lapicero (11)

			var ids = DataLists.ListaProductos
				.Where(r => r.Descripcion.ToLower().Contains("lapicero"))
				.Select(r => r.Id);



			var idPedidos = DataLists.ListaLineasPedido
				.Where(r => ids.Contains(r.IdProducto))
				.Select(r => r.IdPedido)
				.Distinct();

			foreach (var item in idPedidos) Console.WriteLine($"ID Pedido: {item}  (contiene Lapicero)");
			Console.WriteLine(Environment.NewLine);


			// Cantidad de pedidos que contengan Cuaderno Grande

			var idCuaderno = DataLists.ListaProductos
				.Where(r => r.Descripcion.ToLower() == "cuaderno grande")
				.Select(s => s.Id)
				.FirstOrDefault();

			var numPedidos = DataLists.ListaLineasPedido
				.Where(r => idCuaderno == r.IdProducto)
				.Count();

			Console.WriteLine($"{numPedidos} pedidos contienen Cuaderno Grande");
			Console.WriteLine(Environment.NewLine);


			// Unidad vendidas de Cuaderno Pequeño

			var unidades = DataLists.ListaLineasPedido
				.Where(r => DataLists.ListaProductos
								.Where(s => s.Descripcion.ToLower() == "cuaderno pequeño")
								.Select(s => s.Id)
								.FirstOrDefault() == r.IdProducto)
				.Sum(s => s.Cantidad);


			Console.WriteLine($"{unidades} Cuadernos Pequeños vendidos");
			Console.WriteLine(Environment.NewLine);

			// El pedido que más unidades contiene

			var pedido = DataLists.ListaLineasPedido
				.GroupBy(r => r.IdPedido)
				.Select(r => new { r.Key, Unidades = r.Sum(s => s.Cantidad) })
				.OrderByDescending(r => r.Unidades)
				.FirstOrDefault();

			Console.WriteLine($"ID Pedido: {pedido.Key} (mayor número de unidades ({pedido.Unidades}))");
			Console.WriteLine(Environment.NewLine);

			// Listado de pedidos orderna por fecha 

			var pedidos = DataLists.ListaPedidos
				.OrderBy(r => r.FechaPedido)
				.Select(r => r);

			foreach (var item in pedidos) 
			Console.WriteLine($"Fecha: {item.FechaPedido.ToShortDateString()}  -> {item.Id.ToString().PadLeft(3)}");
			Console.WriteLine(Environment.NewLine);

		}

		static void Soluciones()
		{















			int id = 2;

			var lineas = DataLists.ListaLineasPedido
				.Where(r => r.IdPedido == id)
				.Select(r => r);


			float total = 0;
			foreach (var item in lineas)
			{
				var producto = DataLists.ListaProductos
					.Where(r => r.Id == item.IdProducto)
					.Select(r => new { r.Descripcion, r.Precio })
					.FirstOrDefault();

				total = total + (item.Cantidad * producto.Precio);
					
			}
			Console.WriteLine($"Total: {total.ToString("N2")}");

			var lineas2 = DataLists.ListaLineasPedido
				.Where(r => r.IdPedido == id)
				.Select(r => new { 
					r.IdProducto,
					r.Cantidad,
					Descripcion = DataLists.ListaProductos
									.Where(s => s.Id == r.IdProducto)
									.Select(s => s.Descripcion)
									.FirstOrDefault(),
					Precio = DataLists.ListaProductos
								.Where(s => s.Id == r.IdProducto)
								.Select(s => s.Precio)
								.FirstOrDefault() });

			var lineas3 = from r in DataLists.ListaLineasPedido
						  where r.IdPedido == id
						  select new
						  {
							  r.IdProducto,
							  r.Cantidad,
							  Descripcion = (from s in DataLists.ListaProductos
											 where s.Id == r.IdProducto
											 select s.Descripcion).FirstOrDefault(),
							  Precio = (from s in DataLists.ListaProductos
										where s.Id == r.IdProducto
										select s.Precio).FirstOrDefault()
						  };

			foreach (var item in lineas2) Console.WriteLine($"{item.Descripcion}");

		}
	}
}