using System;

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
    }
}