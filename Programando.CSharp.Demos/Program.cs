using System.Collections;
using System.Collections.Generic;

namespace Programando.CSharp.Demos
{
	public class Program
	{
		public static void Main(string[] args)
		{

		}


		public static void ArrayList()
		{
			// Instanciar
			ArrayList array = new ArrayList();

			// Limpiar y eliminar los elementos
			array.Clear();

			// Añadir elementos
			array.Add(1);
			array.Add("Borja");
			array.Add(new { Nombre = "Borja", Apellidos = "Cabeza" });
			array.Add(new Alumno());

			// Añadir elementos en una posición
			array.Insert(4, "blanco");

			// Añadir todos los elementos de otra colección
			var colores = new string[] { "azul", "rojo", "verde", "amarillo" };
			array.AddRange(colores);

			// Número de elementos del ArrayList
			Console.WriteLine($"Número de elementos: {array.Count}");

			// Eliminar elementos
			array.Remove("azul");
			array.RemoveAt(4);
			array.RemoveRange(2, 2);

			// Saber si un elemento esta contenido
			Console.WriteLine($"Contiene el item rojo: {array.Contains("rojo")}");

			// Orderna los elementos
			array.Sort();

			// Invertir el orden
			array.Reverse();

			// Convertir en un array de object -> object[] array = new array[10]
			var nuevoArray = array.ToArray();

			// Recorrer el ArrayList
			foreach (var item in array)
				Console.WriteLine($"Item: {item.GetType().ToString()}");

			for (var i = 0; i < array.Count; i++)
				Console.WriteLine($"{i}# {array[i].GetType().ToString()}");

		}

		public static void Hashtable()
		{
			// Instanciar
			var ht = new Hashtable();

			// Eliminar todos los elementos
			ht.Clear();

			// Añadir elementos
			ht.Add(1200, "Borja Cabeza");
			ht.Add("ANATR", "Ana Trujillo");
			ht.Add(412, new Alumno());


			// Número de elementos
			Console.WriteLine($"Número de elementos: {ht.Count}");

			// Eliminar un elemento
			ht.Remove(1200);

			// Recorrer el HashTable
			foreach (var clave in ht.Keys)
				Console.WriteLine($"{clave}: {ht[clave]}");
		}

		public static void List()
		{
			// Instanciar
			List<string> list = new List<string>();

			List<string> list1 = new();
			var list2 = new List<string>();

			// Eliminar los elementos
			list.Clear();

			// Añadir elementos
			list.Add("azul");
			list.Add("verde");
			list.Add("rosa");
			list.Add("amarillo");

			// Añadir elementos en una posición
			list.Insert(4, "blanco");

			// Añadir todos los elementos de otra colección
			var colores = new string[] { "marron", "naranja", "negro", "violeta" };
			list.AddRange(colores);

			// Número de elementos del List
			Console.WriteLine($"Número de elementos: {list.Count}");

			// Eliminar elementos
			list.Remove("azul");
			list.RemoveAt(4);
			list.RemoveRange(2, 2);

			// Saber si un elemento esta contenido
			Console.WriteLine($"Contiene el item rojo: {list.Contains("rojo")}");

			// Orderna los elementos
			list.Sort();

			// Invertir el orden
			list.Reverse();

			// Convertir en un array de object -> object[] array = new array[10]
			var nuevoArray = list.ToArray();

			// Recorrer el List
			foreach (var item in list)
				Console.WriteLine($"{list.IndexOf(item)}# Item: {item}");

			for (var i = 0; i < list.Count; i++)
				Console.WriteLine($"{i}# {list[i]}");

		}

		public static void Dictionary()
		{
			// Instanciar
			Dictionary<int, string> dic = new Dictionary<int, string>();

			Dictionary<int, string> dic1 = new();
			var dic2 = new Dictionary<int, string>();

			// Eliminar todos los elementos
			dic.Clear();

			// Añadir elementos
			dic.Add(1200, "Borja Cabeza");
			dic.Add(1300, "Ana Trujillo");
			dic.Add(1412, "José Guzman");

			// Modificar un valor
			dic[1300] = "Antonio Trujillo";

			// Número de elementos
			Console.WriteLine($"Número de elementos: {dic.Count}");

			// Eliminar un elemento
			dic.Remove(1200);

			// Recorrer el diccionario
			foreach (var clave in dic.Keys)
				Console.WriteLine($"{clave}: {dic[clave]}");
		}
	}

	public class Alumno
	{
		public string Nombre { get; set; }
		public int Edad { get; set; }
	}

}