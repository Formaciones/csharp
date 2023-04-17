using Programando.CSharp.ConsoleEF.Model;
using Programando.CSharp.Objects;

namespace Programando.CSharp.ConsoleApp4
{
    internal class Program
    {
        /// <summary>
        /// Inicio del programa
        /// </summary>
        /// <param name="args"></param>
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
                Console.WriteLine("*  1. Crear Tareas".PadRight(55) + "*");
                Console.WriteLine("*  2. Ejecutar métodos en paralelo".PadRight(55) + "*");
                Console.WriteLine("*  3. Ejecutar un FOR en paralelo".PadRight(55) + "*");
                Console.WriteLine("*  4. Ejecutar un FOREACH en paralelo".PadRight(55) + "*");
                Console.WriteLine("*  5. Ejecutar comandos de LINQ en paralelo".PadRight(55) + "*");
                Console.WriteLine("*  6. Utilizar async/await".PadRight(55) + "*");
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
                        CrearTareas();
                        break;
                    case 2:
                        ParallelInvoke();
                        break;
                    case 3:
                        ParallelFor();
                        break;
                    case 4:
                        ParallelForeach();
                        break;
                    case 5:
                        ParallelLinq();
                        break;
                    case 6:
                        Console.WriteLine("INICIO DEL MAIN");
                        DemoAsync();
                        Console.WriteLine("FIN DEL MAIN");
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
        /// Creación de Tareas
        /// </summary>
        static void CrearTareas()
        {
            // Tarea creada con un método estático
            Task tarea1 = new Task(new Action(Demos.MetodoTest));

            // Tarea creada con delegate
            Task tarea2 = new Task(delegate {
                Console.WriteLine($"Método anónimo creado con delegate.");
            });

            // Tarea creada con un método anónimo y expresión lambda
            Task tarea3 = new Task(() => {
                Console.WriteLine($"Método anónimo creado con expresión lambda.");
            });

            // Tarea que llama a un método estático
            Task tarea4 = new Task(() => Demos.MetodoTest());

            // Tarea que comienza automáticamente a ejecutarse
            Task tarea5 = Task.Run(() => {
                Console.WriteLine($"Método Anónimo, tarea 5.");
            });

            // Tarea que comienza automáticamente a ejecutarse y retorna un STRING
            Task<string> tarea6 = Task<string>.Run(() => {
                Thread.Sleep(3000);     // Retardo de 3s para test
                return $"Método Anónimo, tarea 6.";
            });

            // Tarea que comienza automáticamente a ejecutarse y retorna un INT
            // La tarea tiene un token de cancelación que nos permite parar la ejecución del código si fuese necesario
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken ct = cts.Token;
            Task<int> tarea7 = Task<int>.Run(() => {
                return Demos.MetodoTest(ct);
            });

            // La propiedad .Status muestra el estado de la tarea
            Console.WriteLine($"Estado 1: {tarea1.Status}");
            Console.WriteLine($"Estado 7: {tarea7.Status}");

            // El método .Start() inicia la ejecución de una tarea
            tarea1.Start();
            tarea2.Start();

            // La propiedad .Status muestra el estado de la tarea
            Console.WriteLine($"Estado 1: {tarea1.Status}");
            Console.WriteLine($"Estado 7: {tarea7.Status}");

            // El método .Wait() paraliza la ejecución del hilo actual hasta que la tarea finaliza
            // Se puede fijar un limite de espera en milisegundos
            // Consultar la propiedad .Result tiene el mismo efecto que ejecutar el método .Wait()
            tarea6.Wait();
            tarea6.Wait(2000);
            Console.WriteLine(tarea6.Result);

            Task[] tareas = { tarea1, tarea2, tarea6 };

            // El método estático .WaitAll() paralizan la ejecución del hilo actual hasta que todas las tareas de un array finalizan
            Task.WaitAll(tareas);
            Task.WaitAll(tareas, 1000);

            // El método estático .WaitAny() paralizan la ejecución del hilo actual hasta que alguna de las tareas de un array finaliza
            Task.WaitAny(tareas);
            Task.WaitAny(tareas, 2000);

            // El método .Start() inicia la ejecución de una tarea
            tarea3.Start();
            tarea4.Start();

            // Al ejecutar el método .Cancel() del token de calcelación finaliza la ejecución de la tarea
            cts.Cancel();
            Console.WriteLine(tarea7.Result);

            // La propiedad .Status muestra el estado de la tarea
            Console.WriteLine($"Estado 1: {tarea1.Status}");
            Console.WriteLine($"Estado 7: {tarea7.Status}");


            ///////////////////////////////////////////////////////////////////////////////////////
            // Tareas anidadas, que contiene otras tareas
            // Las tarea externa puede finalizar sin que las tareas internas hayan finalizado
            ///////////////////////////////////////////////////////////////////////////////////////

            Task externa = Task.Run(() =>
            {
                Console.WriteLine("Tarea Externa Comienza");
                Task interna = Task.Run(() =>
                {
                    Console.WriteLine("Tarea Interna Comienza");
                    Thread.SpinWait(10000);
                    Console.WriteLine("Tarea Interna Finaliza");
                });
            });
            externa.Wait();
            Console.WriteLine("Tarea Externa Finaliza");


            ///////////////////////////////////////////////////////////////////////////////////////
            // Tareas hijas, que contiene otras tareas
            // Las tarea padre no puede finalizar hasta que las tareas hijas hayan finalizado
            ///////////////////////////////////////////////////////////////////////////////////////

            Task padre = Task.Run(() =>
            {
                Console.WriteLine("Tarea Padre Comienza");
                Task hijo = Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("Tarea Hija Comienza");
                    Thread.SpinWait(10000);
                    Console.WriteLine("Tarea Hija Finaliza");
                }, TaskCreationOptions.AttachedToParent);
            });
            padre.Wait();
            Console.WriteLine("Tarea Padre Finaliza");
        }

        /// <summary>
        /// Ejecutar método en paralelo
        /// </summary>
        static void ParallelInvoke()
        {
            Parallel.Invoke(
                () => Demos.MetodoTest(),
                () => Demos.MetodoTest(),
                () => Demos.MetodoTest("testing"),
                () => { Console.WriteLine("Método ejecutado en paralelo."); }
            );
        }

        /// <summary>
        /// Ejecutar un FOR en paralelo
        /// </summary>
        static void ParallelFor()
        {
            double[] array = new double[50000000];

            // Calculamos la raíz cuadrada de 50.000.000 número mediante un FOR y un FOR en paralelo
            var f1 = DateTime.Now;
            for (int i = 1; i < array.Length; i++)
            {
                array[i] = Math.Sqrt(i);
            }
            var f2 = DateTime.Now;
            Parallel.For(1, 49999999, (i) => {
                array[i] = Math.Sqrt(i);
            });
            var f3 = DateTime.Now;

            // Mostramos costes de proceso en milisegundos
            Console.WriteLine($"         FOR -> {f2.Subtract(f1).TotalMilliseconds} ms.");
            Console.WriteLine($"PARALLEL FOR -> {f3.Subtract(f2).TotalMilliseconds} ms.");
        }

        /// <summary>
        /// Ejecutar un FOREACH en paralelo
        /// </summary>
        static void ParallelForeach()
        {
            var context = new ModelNorthwind();

            // Buscar clientes en una base de datos utilizando LINQ
            var clientes = context.Customers
                .Where(r => r.Country == "USA")
                .ToList();

            // Recorremos la colección mediante FOREACH
            foreach (var item in clientes) Console.WriteLine($"{item.CustomerID} {item.CompanyName}");
            Console.WriteLine("");

            // Recorremos la colección mediante FOREACH en paralelo
            Parallel.ForEach(clientes, item => Console.WriteLine($"{item.CustomerID} {item.CompanyName}"));

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            // Buscar clientes en una base de datos utilizando LINQ
            clientes = context.Customers
                .ToList();

            // Realizamos cambios recorriendo la colección mediante un FOREACH
            var f1 = DateTime.Now;
            foreach (var item in clientes)
            {
                item.City = "";
                item.Country = "";
            }
            var f2 = DateTime.Now;


            // Buscar clientes en una base de datos utilizando LINQ
            clientes = context.Customers
                .ToList();

            // Realizamos cambios recorriendo la colección mediante un FOREACH en paralelo
            var f3 = DateTime.Now;
            Parallel.ForEach(clientes, item => {
                item.City = "";
                item.Country = "";
            });
            var f4 = DateTime.Now;

            // Mostramos costes de proceso en milisegundos
            Console.WriteLine($"         FOREACH -> {f2.Subtract(f1).TotalMilliseconds} ms.");
            Console.WriteLine($"PARALLEL FOREACH -> {f4.Subtract(f3).TotalMilliseconds} ms.");
        }

        /// <summary>
        /// Ejecutar consultas de LINQ en paralelo
        /// </summary>
        static void ParallelLinq()
        {
            var context = new ModelNorthwind();

            // Lanzamos dos consultas iguales una en paralelo
            var f1 = DateTime.Now;
            var clientes = context.Customers
                .Where(r => r.Country == "USA")
                .ToList();
            var f2 = DateTime.Now;
            var clientes2 = context.Customers
                .AsParallel()
                .Where(r => r.Country == "USA")
                .ToList();
            var f3 = DateTime.Now;

            // Mostramos costes de proceso en milisegundos
            Console.WriteLine($" LINQ -> {f2.Subtract(f1).TotalMilliseconds} ms.");
            Console.WriteLine($"PLINQ -> {f3.Subtract(f2).TotalMilliseconds} ms.");

            // Los datos recuperados tienen siempre el mismo orden
            foreach (var item in clientes) Console.WriteLine($"{item.CustomerID} {item.CompanyName}");
            Console.WriteLine("");

            // Los datos recuperados en paralelo no tienen siempre el mismo orden
            foreach (var item in clientes2) Console.WriteLine($"{item.CustomerID} {item.CompanyName}");
        }

        /// <summary>
        /// Utilizar async y await
        /// </summary>
        static async void DemoAsync()
        {
            // PROBAR CADA TEST POR SEPARADO COMENTANDO LAS LÍNEAS DE OTROS BLOQUES DE TEST //

            Console.WriteLine(" Inicio DemoAsync");

            var obj = new Calculate();

            ///////////////////////////////////////////////////////////////////////////
            // Test 1 - Ejecutar el método síncrono
            ///////////////////////////////////////////////////////////////////////////

            obj.Start();
            for (var i = 49000000; i < 49000011; i++) Console.WriteLine(obj.Array[i]);


            ///////////////////////////////////////////////////////////////////////////
            // Test 2a - Ejecutar el método asíncrono (equivalente al síncrono)
            ///////////////////////////////////////////////////////////////////////////

            var task = obj.StartAsync();
            task.Wait();
            for (var i = 49000000; i < 49000011; i++) Console.WriteLine(obj.Array[i]);


            ///////////////////////////////////////////////////////////////////////////
            // Test 2b - Ejecutar el método asíncrono (equivalente al síncrono)
            ///////////////////////////////////////////////////////////////////////////

            _ = obj.StartAsync().Result;
            for (var i = 49000000; i < 49000011; i++) Console.WriteLine(obj.Array[i]);


            ///////////////////////////////////////////////////////////////////////////
            // Test 2c - Ejecutar el método asíncrono (sin bloquear el hilo principal)
            ///////////////////////////////////////////////////////////////////////////

            await obj.StartAsync();
            for (var i = 49000000; i < 49000011; i++) Console.WriteLine(obj.Array[i]);


            ///////////////////////////////////////////////////////////////////////////
            // Test 3 - Ejecutar el método asíncrono
            ///////////////////////////////////////////////////////////////////////////

            obj.EndCalculations += (sender, e) => {
                for (var i = 49000000; i < 49000011; i++) Console.WriteLine(((Calculate)sender).Array[i]);
            };
            obj.StartAsync();

            Console.WriteLine(" Fin DemoAsync");

        }
    }
}

namespace Programando.CSharp.Objects
{
    /// <summary>
    /// Objeto para demostraciones
    /// </summary>
    public static class Demos
    {
        /// <summary>
        /// Método para Test
        /// </summary>
        public static void MetodoTest()
        {
            Console.WriteLine($"Método Test");
        }

        /// <summary>
        /// Método para Test
        /// </summary>
        /// <param name="data">Datos</param>
        public static void MetodoTest(string data)
        {
            Console.WriteLine($"Método Test, datos: {data}");
        }

        /// <summary>
        /// Método para Test
        /// </summary>
        /// <param name="token">Token de Cancelación</param>
        /// <returns></returns>
        public static int MetodoTest(CancellationToken token)
        {
            int result = 0;
            while (true)
            {
                result++;

                // Cuando se ejecuta el método .Cancel() de token de cancelación (ver línea 153)
                // la propiedad .IsCancellationRequested toma el valor TRUE
                if (token.IsCancellationRequested) return result;
            }
        }
    }

    /// <summary>
    /// Objeto Calcular, implementa métodos síncronos y asíncronos
    /// </summary>
    public class Calculate
    {
        private double[] array = new double[50000000];
        public event EventHandler<string> EndCalculations;

        public double[] Array
        {
            get => array; set => array = value;
        }

        /// <summary>
        /// Método síncrono
        /// </summary>
        /// <returns></returns>
        public bool Start()
        {
            for (int i = 1; i < array.Length; i++) array[i] = Math.Sqrt(i);
            Console.WriteLine("FIN DEL CALCULO");

            return true;
        }

        /// <summary>
        /// Método asíncrono
        /// </summary>
        /// <returns></returns>
        public Task<bool> StartAsync()
        {
            return Task<bool>.Run(() => {
                for (int i = 1; i < array.Length; i++) array[i] = Math.Sqrt(i);
                Console.WriteLine("FIN DEL CALCULO");

                return true;
            });
        }

        /// <summary>
        /// Método asíncrono con control de eventos
        /// </summary>
        /// <returns></returns>
        public Task<bool> StartAsyncWithEvent()
        {
            return Task<bool>.Run(() => {
                for (int i = 1; i < array.Length; i++) array[i] = Math.Sqrt(i);
                Console.WriteLine("FIN DEL CALCULO");

                EndCalculations?.Invoke(this, DateTime.Now.ToString("dd-MM-yyyy HH:MM"));

                return true;
            });
        }
    }
}