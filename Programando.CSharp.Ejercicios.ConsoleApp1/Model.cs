using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programando.CSharp.Ejercicios.ConsoleApp1
{
	/// <summary>
	/// Representa el Objeto Cliente
	/// </summary>
	public class Cliente
	{
		public int Id { get; set; }
		public string Nombre { get; set; }
		public DateTime FechaNac { get; set; }
	}

	/// <summary>
	/// Representa el Objeto Producto
	/// </summary>
	public class Producto
	{
		public int Id { get; set; }
		public string Descripcion { get; set; }
		public float Precio { get; set; }
	}

	/// <summary>
	/// Representa el Objeto Pedido
	/// </summary>
	public class Pedido
	{
		public int Id { get; set; }
		public int IdCliente { get; set; }
		public DateTime FechaPedido { get; set; }
	}

	/// <summary>
	/// Representa el Objeto Linea de Pedido
	/// </summary>
	public class LineaPedido
	{
		public int Id { get; set; }
		public int IdPedido { get; set; }
		public int IdProducto { get; set; }
		public int Cantidad { get; set; }
	}

	/// <summary>
	/// Representa una Base de datos en memoria utilizando LIST
	/// </summary>
	public static class DataLists
	{
		private static List<Cliente> _listaClientes = new List<Cliente>()
			{
				new Cliente { Id = 1,   Nombre = "Carlos Gonzalez Rodriguez",   FechaNac = new DateTime(1980, 10, 10) },
				new Cliente { Id = 2,   Nombre = "Luis Gomez Fernandez",        FechaNac = new DateTime(1961, 4, 20) },
				new Cliente { Id = 3,   Nombre = "Ana Lopez Diaz ",             FechaNac = new DateTime(1947, 1, 15) },
				new Cliente { Id = 4,   Nombre = "Fernando Martinez Perez",     FechaNac = new DateTime(1981, 8, 5) },
				new Cliente { Id = 5,   Nombre = "Lucia Garcia Sanchez",        FechaNac = new DateTime(1973, 11, 3) }
			};

		private static List<Producto> _listaProductos = new List<Producto>()
			{
				new Producto { Id = 1,      Descripcion = "Boligrafo",          Precio = 0.35f },
				new Producto { Id = 2,      Descripcion = "Cuaderno grande",    Precio = 1.5f },
				new Producto { Id = 3,      Descripcion = "Cuaderno pequeño",   Precio = 1 },
				new Producto { Id = 4,      Descripcion = "Folios 500 uds.",    Precio = 3.55f },
				new Producto { Id = 5,      Descripcion = "Grapadora",          Precio = 5.25f },
				new Producto { Id = 6,      Descripcion = "Tijeras",            Precio = 2 },
				new Producto { Id = 7,      Descripcion = "Cinta adhesiva",     Precio = 1.10f },
				new Producto { Id = 8,      Descripcion = "Rotulador",          Precio = 0.75f },
				new Producto { Id = 9,      Descripcion = "Mochila escolar",    Precio = 12.90f },
				new Producto { Id = 10,     Descripcion = "Pegamento barra",    Precio = 1.15f },
				new Producto { Id = 11,     Descripcion = "Lapicero",           Precio = 0.55f },
				new Producto { Id = 12,     Descripcion = "Grapas",             Precio = 0.90f }
			};

		private static List<Pedido> _listaPedidos = new List<Pedido>()
			{
				new Pedido { Id = 1,     IdCliente = 1,  FechaPedido = new DateTime(2013, 10, 1) },
				new Pedido { Id = 2,     IdCliente = 1,  FechaPedido = new DateTime(2013, 10, 8) },
				new Pedido { Id = 3,     IdCliente = 1,  FechaPedido = new DateTime(2013, 10, 12) },
				new Pedido { Id = 4,     IdCliente = 1,  FechaPedido = new DateTime(2013, 11, 5) },
				new Pedido { Id = 5,     IdCliente = 2,  FechaPedido = new DateTime(2013, 10, 4) },
				new Pedido { Id = 6,     IdCliente = 3,  FechaPedido = new DateTime(2013, 7, 9) },
				new Pedido { Id = 7,     IdCliente = 3,  FechaPedido = new DateTime(2013, 10, 1) },
				new Pedido { Id = 8,     IdCliente = 3,  FechaPedido = new DateTime(2013, 11, 8) },
				new Pedido { Id = 9,     IdCliente = 3,  FechaPedido = new DateTime(2013, 11, 22) },
				new Pedido { Id = 10,    IdCliente = 3,  FechaPedido = new DateTime(2013, 11, 29) },
				new Pedido { Id = 11,    IdCliente = 4,  FechaPedido = new DateTime(2013, 10, 19) },
				new Pedido { Id = 12,    IdCliente = 4,  FechaPedido = new DateTime(2013, 11, 11) }
			};

		private static List<LineaPedido> _listaLineasPedido = new List<LineaPedido>()
			{
				new LineaPedido() { Id = 1,  IdPedido = 1,  IdProducto = 1,     Cantidad = 9 },
				new LineaPedido() { Id = 2,  IdPedido = 1,  IdProducto = 3,     Cantidad = 7 },
				new LineaPedido() { Id = 3,  IdPedido = 1,  IdProducto = 5,     Cantidad = 2 },
				new LineaPedido() { Id = 4,  IdPedido = 1,  IdProducto = 7,     Cantidad = 2 },
				new LineaPedido() { Id = 5,  IdPedido = 2,  IdProducto = 9,     Cantidad = 1 },
				new LineaPedido() { Id = 6,  IdPedido = 2,  IdProducto = 11,    Cantidad = 15 },
				new LineaPedido() { Id = 7,  IdPedido = 3,  IdProducto = 12,    Cantidad = 2 },
				new LineaPedido() { Id = 8,  IdPedido = 3,  IdProducto = 1,     Cantidad = 4 },
				new LineaPedido() { Id = 9,  IdPedido = 4,  IdProducto = 2,     Cantidad = 3 },
				new LineaPedido() { Id = 10, IdPedido = 5,  IdProducto = 4,     Cantidad = 2 },
				new LineaPedido() { Id = 11, IdPedido = 6,  IdProducto = 1,     Cantidad = 20 },
				new LineaPedido() { Id = 12, IdPedido = 6,  IdProducto = 2,     Cantidad = 7 },
				new LineaPedido() { Id = 13, IdPedido = 7,  IdProducto = 1,     Cantidad = 4 },
				new LineaPedido() { Id = 14, IdPedido = 7,  IdProducto = 2,     Cantidad = 10 },
				new LineaPedido() { Id = 15, IdPedido = 7,  IdProducto = 11,    Cantidad = 2 },
				new LineaPedido() { Id = 16, IdPedido = 8,  IdProducto = 12,    Cantidad = 2 },
				new LineaPedido() { Id = 17, IdPedido = 8,  IdProducto = 3,     Cantidad = 9 },
				new LineaPedido() { Id = 18, IdPedido = 9,  IdProducto = 5,     Cantidad = 11 },
				new LineaPedido() { Id = 19, IdPedido = 9,  IdProducto = 6,     Cantidad = 9 },
				new LineaPedido() { Id = 20, IdPedido = 9,  IdProducto = 1,     Cantidad = 4 },
				new LineaPedido() { Id = 21, IdPedido = 10, IdProducto = 2,     Cantidad = 7 },
				new LineaPedido() { Id = 22, IdPedido = 10, IdProducto = 3,     Cantidad = 2 },
				new LineaPedido() { Id = 23, IdPedido = 10, IdProducto = 11,    Cantidad = 10 },
				new LineaPedido() { Id = 24, IdPedido = 11, IdProducto = 12,    Cantidad = 2 },
				new LineaPedido() { Id = 25, IdPedido = 12, IdProducto = 1,     Cantidad = 20 }
			};

		// Propiedades de los elementos privados
		public static List<Cliente> ListaClientes { get { return _listaClientes; } }
		public static List<Producto> ListaProductos { get { return _listaProductos; } }
		public static List<Pedido> ListaPedidos { get { return _listaPedidos; } }
		public static List<LineaPedido> ListaLineasPedido { get { return _listaLineasPedido; } }
	}
}
