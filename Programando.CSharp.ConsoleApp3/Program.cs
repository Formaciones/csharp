using System;
using System.Collections;

namespace Programando.CSharp.ConsoleApp1
{
    internal class Program
    {
        ///<summary>
        ///Método Main inicio del programa
        ///</summary>
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("".PadRight(56, '*'));
                Console.WriteLine("*  DEMO Y EJERCICIOS".PadRight(55) + "*");
                Console.WriteLine("".PadRight(56, '*'));
                Console.WriteLine("*".PadRight(55) + "*");
                Console.WriteLine("*  1. Uso Arrays".PadRight(55) + "*");
				Console.WriteLine("*  2. Uso ArrayList".PadRight(55) + "*");
				Console.WriteLine("*  3. Uso Hashtable".PadRight(55) + "*");
				Console.WriteLine("*  4. Uso List".PadRight(55) + "*");
				Console.WriteLine("*  5. Uso Dictionary".PadRight(55) + "*");
				Console.WriteLine("*  6. Items como Referencia".PadRight(55) + "*");
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
                        Arrays();
                        break;
					case 2:
						ArrayList();
						break;
					case 3:
						Hashtable();
						break;
					case 4:
						List();
						break;
					case 5:
						Dictionary();
						break;
					case 6:
						AddItemReference();
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
        /// Uso de Arrays
        /// </summary>
        static void Arrays()
        {
            // Instanciar, una dimensión
            int[] array1 = new int[5];

            int[] array2a = new int[] { 1, 3, 5, 7, 9 };
            int[] array2b = { 1, 2, 3, 4, 5, 6 };

            // Instanciar, dos dimensión
            int[,] multiDimensionalArray1 = new int[2, 3];
            int[,] multiDimensionalArray2 = { { 1, 2, 3 }, { 4, 5, 6 } };

            // Instanciar, jagged array.
            int[][] jaggedArray = new int[6][];
            jaggedArray[0] = new int[4] { 1, 2, 3, 4 };

            //Eliminar todos los elementos
            int[] numeros = new int[] { 15, -3, 577, 82, 19, 33, 78, 1000, -63 };
            Array.Clear(numeros, 0, numeros.Length);

            //Añadir posiciones y elementos
            string[] frutas = new string[] { "naranja", "limón", "pomelo", "líma" };
            Array.Resize(ref frutas, 5);
            frutas[4] = "manzana";

            //Número de elementos
            Console.WriteLine($"Número de items: {frutas.Length}");

            //Recorrer colección
            foreach (var item in frutas)
            {
                Console.WriteLine("Item: {0}", item);
            }
            Console.WriteLine(Environment.NewLine);

            for (var i = 0; i < frutas.Length; i++)
            {
                Console.WriteLine("Item: {0}", frutas[i]);
            }
        }

		/// <summary>
		/// Uso de ArrayList
		/// </summary>
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

		/// <summary>
		/// Uso de Hashtable
		/// </summary>
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

		/// <summary>
		/// Uso de Listas
		/// </summary>
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

		/// <summary>
		/// Uso de Diccionarios
		/// </summary>
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

		/// <summary>
		/// Añadimos elementos a una colección
		/// </summary>
		static void AddItemReference()
		{
			//Comprobamos que al añadir un mismo elemento varias veces todas la posiciones tiene el mismo elemento
			//Un Objeto es un de tipo referencia

			var alumnos = new List<Alumno>();
			var alumno = new Alumno() { Nombre = "Carlos", Apellidos = "Sánchez", Edad = 24 };

			alumnos.Add(alumno);
			alumnos.Add(alumno);
			alumnos.Add(alumno);
			alumnos.Add(alumno);
			alumnos.Add(alumno);

			Console.WriteLine($"{alumnos.Count} elementos");
			alumnos[1].Nombre = "Borja";
			alumnos[2].Nombre = "Ana";
			alumnos[3].Nombre = "José";
			alumnos[4].Nombre = "Silvia";

			foreach (var item in alumnos)
			{
				Console.WriteLine($"{item.Nombre} {item.Apellidos}");
			}

			Console.ReadKey();


			//Para que cada posición tenga un elemento, necesitamos instanciarlo (crear una nueva copia) antes de añadirlo
			//Ejemplo 1
			var alumnos2 = new List<Alumno>();

			alumnos2.Add(new Alumno() { Nombre = "Carlos", Apellidos = "Sánchez", Edad = 24 });
			alumnos2.Add(new Alumno() { Nombre = "Borja", Apellidos = "Cabeza", Edad = 24 });
			alumnos2.Add(new Alumno() { Nombre = "Ana", Apellidos = "Sanz", Edad = 24 });
			alumnos2.Add(new Alumno() { Nombre = "José", Apellidos = "Rozas", Edad = 24 });

			Console.WriteLine($"{alumnos2.Count} elementos");

			foreach (var item in alumnos2)
			{
				Console.WriteLine($"{item.Nombre} {item.Apellidos}");
			}

			Console.ReadKey();

			//Para que cada posición tenga un elemento, necesitamos instanciarlo (crear una nueva copia) antes de añadirlo
			//Ejemplo 2
			var alumnos3 = new List<Alumno>()
			{
				new Alumno() { Nombre = "Carlos", Apellidos = "Sánchez", Edad = 24 },
				new Alumno() { Nombre = "Borja", Apellidos = "Cabeza", Edad = 24 },
				new Alumno() { Nombre = "Ana", Apellidos = "Sanz", Edad = 24 },
				new Alumno() { Nombre = "José", Apellidos = "Rozas", Edad = 24 }
			};

			Console.WriteLine($"{alumnos3.Count} elementos");

			foreach (var item in alumnos3)
			{
				Console.WriteLine($"{item.Nombre} {item.Apellidos}");
			}

			Console.ReadKey();
		}
	}

	/// <summary>
	/// Objeto Alumno
	/// </summary>
	public class Alumno
	{
		public string Nombre;
		public string Apellidos;
		public int Edad;
	}
}