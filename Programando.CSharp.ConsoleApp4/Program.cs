using Programando.CSharp.ConsoleEF.Model;

namespace Programando.CSharp.ConsoleApp4
{
    internal class Program
    {
        public class Alumno { }

        static void Main(string[] args)
        {
            Console.WriteLine("INICIO MAIN");
            Adicionar<int>(30, 40);
            Adicionar<string>("Hola", "Mundo");
            Adicionar<decimal>(30.5M, 33.16M);

            var obj = new DemoObject2<int>();
            obj.a = 20;
            obj.b = 30;
            obj.Adicionar();

            Console.WriteLine("FIN MAIN");

            Console.ReadKey();
            Console.WriteLine("FIN MAIN despues del ReadKey");
        }

        static void Adicionar<T>(T a, T b)
        {
            if (typeof(T) == typeof(string)) 
            {
                string n1 = Convert.ToString(a);
                string n2 = Convert.ToString(b);

                Console.WriteLine($"{n1 + n2}");
            }
            else if (typeof(T) == typeof(int)) 
            {
                int n1 = Convert.ToInt32(a);
                int n2 = Convert.ToInt32(b);

                Console.WriteLine($"{n1 + n2}");
            }
            else 
            {
                Console.WriteLine("No se puede procesar");
            }
        }

        static void Adicionar1(int a, int b)
        { 
            Console.WriteLine($"{a + b}");
        }

        static void Adicionar2(string a, string b)
        {
            Console.WriteLine($"{a + b}");
        }

        static void ParallelFor()
        {
            double[] array = new double[50000000];

            var f1 = DateTime.Now;
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Math.Sqrt(i);
            }
            var f2 = DateTime.Now;
            Parallel.For(0, 49999999, (i) =>
            {
                array[i] = Math.Sqrt(i);
            });
            var f3 = DateTime.Now;

            Console.WriteLine($"         FOR -> {f2.Subtract(f1).TotalMilliseconds} ms.");
            Console.WriteLine($"PARALLEL FOR -> {f3.Subtract(f2).TotalMilliseconds} ms.");
        }

        static void ParallelForeach()
        {
            var db = new ModelNorthwind();

            var clientes = db.Customers
                .Where(r => r.Country == "USA")
                .OrderBy(r => r.City)
                .ToList();

            foreach (var item in clientes) 
                Console.WriteLine($"{item.CustomerID} {item.CompanyName} - {item.City}");

            Console.WriteLine(Environment.NewLine);

            var clientes2 = db.Customers
                 .Where(r => r.Country == "USA")
                 .ToList()
                 .AsParallel();

            Parallel.ForEach(clientes2,
                item => Console.WriteLine($"{item.CustomerID} {item.CompanyName} - {item.City}"));
        }

        static void CrearTareas()
        {
            Task tarea1 = new Task(new Action(() => { Console.WriteLine("Método con un Action"); }));
            Task tarea2 = new Task(new Action(MetodoTest));
            Task tarea3 = new Task(delegate { Console.WriteLine("Tarea 3"); });
            Task tarea4 = new Task(() => { Console.WriteLine("Tarea 4"); }); 
            Task tarea5 = new Task(() => MetodoTest());

            ////////////////////////////////////////////////////////////

            Task tarea6 = Task.Run(() => { Console.WriteLine("Tarea 6"); });

            Task<string> tarea7 = Task.Run(() => { 
                Thread.Sleep(15000);
                Console.WriteLine("Tarea 7");
                return "Tarea 7";
            });

            Console.WriteLine($"Estado tarea 1: {tarea1.Status}");
            Console.WriteLine($"Estado tarea 7: {tarea7.Status}");

            tarea7.Wait(2000);
            var resultado = tarea7.Result;

            Task[] tareas = { tarea6, tarea7 };
            Task.WaitAll(tareas);
            Task.WaitAll(tareas, 2000);
            Task.WaitAny(tareas);
            Task.WaitAny(tareas, 3000);

            tarea1.Start();
            tarea2.Start(); 
            tarea3.Start();
            tarea4.Start();
            tarea5.Start();

            Console.WriteLine($"Estado tarea 1: {tarea1.Status}");
            Console.WriteLine($"Estado tarea 7: {tarea7.Status}");

            //////////////////////////////////////////////////////////////////

            Parallel.Invoke(
                () => Console.WriteLine("Demo Paralelo"),
                () => { Console.WriteLine("Demo Paralelo2"); },
                () => MetodoTest(),
                () => MetodoTest()
            );
        }

        static async void DemoAsync()
        {
            var obj = new DemoObject();
            string resultado = await obj.MetodoAsync();
        }

        static void MetodoTest()
        {
            Console.WriteLine("Método Test");
        }

        static void Procesar(IVehiculo item)
        { 
            Console.WriteLine(item.Nombre);
            item.Iniciar();

            Console.WriteLine(item.GetType());

            if (typeof(Avion) == item.GetType())
            {
                ((Avion)item).Despegar();                
            }
            else if (typeof(Coche) == item.GetType())
            {
                ((Coche)item).Test();
            }
        }

        static void EjemploHerencia1()
        {
            var list = new List<string>();
            list.Add("Adios");
            list.Add("Mundo");

            var col = new Coleccion<string>();
            col.Add("Hola");
            col.Add("Mundo");
            col.OutputAll();
        }

        static void EjemploHerencia2()
        {
            var animal = new Animal();
            animal.MetodoA();
            animal.MetodoB();
            Console.WriteLine(Environment.NewLine);

            var mamifero = new Mamifero();
            mamifero.MetodoA();
            mamifero.MetodoB();
            Console.WriteLine(Environment.NewLine);

        }

        static void EjemploPoliformismo1()
        {
            Coche coche = new Coche()
            {
                Nombre = "Hunday Tucson",
                Ruedas = 4,
                Color = "Rojo"
            };
            Console.WriteLine("COCHE ============================");
            coche.Iniciar();
            coche.Test();


            Avion avion = new Avion()
            {
                Nombre = "Jumbo 787",
                Ruedas = 8
            };
            Console.WriteLine("AVIÓN ============================");
            avion.Iniciar();
            avion.Despegar();

            Console.WriteLine("VEHÍCULO COCHE ===================");
            IVehiculo vehiculo = coche;
            vehiculo.Iniciar();

            Console.WriteLine("VEHÍCULO AVIÓN ===================");
            vehiculo = avion;
            vehiculo.Iniciar();

            Console.WriteLine("PROCESAR =========================");
            Procesar(coche);
        }

        static void EjemploPoliformismo2()
        {
            var formas = new List<Forma>();

            formas.Add(new Forma());
            formas.Add(new Circulo());
            formas.Add(new Cuadrado());
            formas.Add(new Triangulo());

            foreach(var item in formas) item.Dibujar();
        }

        static void EjemploClasesAbstractas()
        { 
            var nevera = new Nevera() 
                { Nombre = "Nevera Demo", Color = "Rojo", Consumo = "200W" };

            nevera.MetodoA();
            nevera.MetodoB();
            nevera.MetodoC();
        }
    }

    public class Lista<T>
    {
        T[] Items = new T[2];

        public void Add(T item)
        {
            Items[0] = item;    
        }
    }

    public class DemoObject2<T>
    {
        public T a { get; set; }
        public T b { get; set; }

        public void Adicionar()
        {
            if (typeof(T) == typeof(string))
            {
                string n1 = Convert.ToString(a);
                string n2 = Convert.ToString(b);

                Console.WriteLine($"{n1 + n2}");
            }
            else if (typeof(T) == typeof(int))
            {
                int n1 = Convert.ToInt32(a);
                int n2 = Convert.ToInt32(b);

                Console.WriteLine($"{n1 + n2}");
            }
            else
            {
                Console.WriteLine("No se puede procesar");
            }
        }
    }

    public class DemoObject
    {
        public string MetodoSync()
        {            
            Task<string> tarea = Task.Run(() => {
                Console.WriteLine("INICIO TAREA");
                Thread.Sleep(3000);
                Console.WriteLine("Tarea");                
                Console.WriteLine("FIN TAREA");

                return "Tarea";
            });
           
            return tarea.Result;
        }

        public Task<string> MetodoAsync2()
        {
            return Task<string>.Run(() => {
                Console.WriteLine("INICIO TAREA");
                Thread.Sleep(3000);
                Console.WriteLine("Tarea");
                Console.WriteLine("FIN TAREA");

                return "Tarea";
            });
        }

        public async Task<string> MetodoAsync()
        {
            return await Task<string>.Run(() => {
                Console.WriteLine("INICIO TAREA");
                Thread.Sleep(3000);
                Console.WriteLine("Tarea");
                Console.WriteLine("FIN TAREA");

                return "Tarea";                
            });
        }
    }

    public class Coleccion<T> : List<T>
    {
        public void OutputAll()
        {
            foreach (var item in this) Console.WriteLine($"{item.ToString()}");
        }
    }

    public class Animal
    { 
        public string Nombre { get; set; }
        public string Familia { get; set; }

        public virtual void MetodoA()
        {
            Console.WriteLine($"Método A, implementado en Animal.");            
        }
        public void MetodoB()
        {
            Console.WriteLine($"Método B, implementado en Animal.");
        }
    }

    public sealed class Mamifero : Animal
    {
        public override void MetodoA()
        {
            Console.WriteLine($"Método A, implementado en Mamifero.");
            base.MetodoA();
        }
    }

    // No se puede heredar de Mamifero cuando la clase esta sellada con SEALED
    //public class Oso : Mamifero
    //{ 
    //}

    public interface IVehiculo
    { 
        public string Nombre { get; set; }
        public int Ruedas { get; set; }

        public void Iniciar();
        public void Parar();
    }

    public class Coche : IVehiculo
    {
        public string Nombre { get; set; }
        public int Ruedas { get; set; }
        public string Color { get; set; }

        public void Iniciar() => Console.WriteLine($"Coche {Color} en marcha.");
        public void Parar() => Console.WriteLine("Coche parado.");
        public void Test() => Console.WriteLine("Coche chequeandose.");

        void IVehiculo.Iniciar() => Console.WriteLine("Vehículo en marcha.");
        void IVehiculo.Parar() => Console.WriteLine("Vehículo parado.");
    }

    public class Avion : IVehiculo
    {
        public string Nombre { get; set; }
        public int Ruedas { get; set; }
        public void Iniciar() => Console.WriteLine("Avión en marcha.");
        public void Parar() => Console.WriteLine("Avión parado.");
        public void Despegar() => Console.WriteLine("Avión despengado.");
        public void Aterrizar() => Console.WriteLine("Avión aterrizando.");
    }

    public class Forma
    { 
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public virtual void Dibujar() => Console.WriteLine("Método Dibujar en Forma");
    }

    public class Circulo : Forma
    {
        public override void Dibujar() => Console.WriteLine("Método Dibujar en Cirulo");
    }

    public class Cuadrado : Forma
    {
        public override void Dibujar() => Console.WriteLine("Método Dibujar en Cuadrado");
    }

    public class Triangulo : Forma
    {
        public override void Dibujar() => Console.WriteLine("Método Dibujar en Triangulo");
        public void Tipo() => Console.WriteLine("Muestra el tipo del triangulo.");
    }

    public abstract class Electrodomestico
    { 
        public string Nombre { get; set; }
        public abstract string Color { get; set; }

        public void MetodoA() => Console.WriteLine("Método A en Electrodomestico.");
        public abstract void MetodoB();
    }

    public class Nevera : Electrodomestico
    {
        public override string Color { get ; set; }
        public string Consumo { get; set; }

        public override void MetodoB() => Console.WriteLine("Método B en Nevera.");
        public void MetodoC() => Console.WriteLine("Método C en Nevera.");
    }
}