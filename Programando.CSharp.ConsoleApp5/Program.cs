using Programando.CSharp.Objects;
using Programando.CSharp.Objects.Genericas;
using Programando.CSharp.Objects.Herencia;
using Programando.CSharp.Objects.Poliformismo;

/********************************************************************************************************************************************************
 *                                                                                                                                                      *
 *   La herencia, junto con la encapsulación y el polimorfismo, es una de las tres características principales de la programación orientada a objetos.  *
 *                                                                                                                                                      *
 *   La herencia permite crear clases que reutilicen, extienden y modifiquen el comportamiento definido en otras clases. La clase cuyos miembros se     *
 *   heredan se denomina clase base y la clase que hereda esos miembros se denomina clase derivada.                                                     *
 *                                                                                                                                                      *
 *   El polimorfismo suele considerarse el tercer pilar de la programación orientada a objetos, después de la encapsulación y la herencia.              *
 *   Polimorfismo es una palabra griega que significa "con muchas formas".                                                                              *
 *                                                                                                                                                      *
 ********************************************************************************************************************************************************/

namespace Programando.CSharp.ConsoleApp5
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
                Console.WriteLine("*  1. Herencia".PadRight(55) + "*");
                Console.WriteLine("*  2. Poliformismo".PadRight(55) + "*");
                Console.WriteLine("*  3. Clases Genéricas".PadRight(55) + "*");
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
                        Herencia();
                        break;
                    case 2:
                        Poliformismo();
                        break;
                    case 3:
                        ClasesGenericas();
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
        /// La herencia permite crear clases que reutilicen, extienden y modifiquen el comportamiento definido en otras clases
        /// </summary>
        static void Herencia()
        {
            // Una lista, no es posible usa el método OutputAll ya que no esta implementado.
            var list = new List<int>() { 1, 2, 3 };
            list.Add(4);
            //list.OutputAll();


            // Mediante la herencia el objeto ListExtend tiene todos los método de una lista como .Add()
            // además tiene los métodos implementados como .OutputAll()
            var listExtend = new ListExtend<int>() { 1, 2, 3 };
            listExtend.Add(4);
            listExtend.OutputAll();

            var listExtend2 = new ListExtend<Alumno>()
            {
                new Alumno() { Nombre = "Julia", Apellidos = "Fernández", Edad = 24 },
                new Alumno() { Nombre = "Rosa", Apellidos = "Perez", Edad = 26 }
            };
            listExtend2.Add(new Alumno() { Nombre = "Ramón", Apellidos = "Coro", Edad = 19 });
            listExtend2.OutputAll();


            // Otros ejemplo de herencia, ver implementación de clases.
            var animal = new Animal();
            animal.MetodoA();
            animal.MetodoB();

            var mamifero = new Mamifero();
            mamifero.MetodoA();
            mamifero.MetodoB();
        }

        /// <summary>
        /// El poliformismo permite trabajar con diferentes formas de objetos que tiene una misma clase base o interfaz
        /// </summary>
        static void Poliformismo()
        {
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            /// Poliformismo mediante herencia
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            // Una lista de Shape puede contener objetos Shape y de cualquiera de sus clases derivadas
            var shapes = new List<Shape>
            {
                new Rectangle(),
                new Triangle(),
                new Circle()
            };

            foreach (var shape in shapes)
            {
                shape.Draw();
            }
            Console.WriteLine(Environment.NewLine);

            // Una variable de Shape puede contener un objeto Shape y de cualquiera de sus clases derivadas
            Shape shapeDemo1 = new Shape();
            shapeDemo1.Draw();

            Shape shapeDemo2 = new Triangle();
            shapeDemo2.Draw();
            Console.WriteLine(Environment.NewLine);

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            /// Poliformismo mediante implementación de una interfaz
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            Car car = new Car() { Name = "Hunday Tucson", Wheels = 4, MotorType = "Diesel" };
            car.Start();
            car.Stop();
            Console.WriteLine($"Motor: {car.MotorType}");       // Propiedad especifica de Coche
            Console.WriteLine(Environment.NewLine);

            Plane plane = new Plane() { Name = "Jumno 747", Wheels = 16 };
            plane.Start();
            plane.Stop();
            plane.Landing();                                    // Método espeficico de Avión
            Console.WriteLine(Environment.NewLine);


            // Las clases de tipo Interfaz puede contener objetos de todas las clases derivas
            // Car además tiene implementaciones especificas de .Start() y .Stop() para cuando el objeto se almacena en una variable de tipo IVehicle

            IVehicle vehicle = car;
            vehicle.Start();
            vehicle.Stop();
            Console.WriteLine(Environment.NewLine);

            vehicle = plane;
            vehicle.Start();
            vehicle.Stop();
            Console.WriteLine(Environment.NewLine);


            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            /// Poliformismo mediante clases abstractas
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            Amphibian amphibian = new Amphibian() { Name = "Rana" };
            amphibian.MethodA();
            amphibian.MethodB();
            Console.WriteLine(Environment.NewLine);

            Reptile reptile = new Reptile() { Name = "Pitón", Color = "Amarillo" };
            reptile.MethodA();
            reptile.MethodB();
            reptile.MethodC();
            Console.WriteLine(Environment.NewLine);

            Animals animal = amphibian;
            animal.MethodA();
            animal.MethodB();
            //animal.MethodC();                     // No es posible, solo accesible desde Reptile
            Console.WriteLine(Environment.NewLine);

            animal = reptile;
            animal.MethodA();
            animal.MethodB();
            //animal.MethodC();                     // No es posible, solo accesible desde Reptile
            Console.WriteLine(Environment.NewLine);
        }

        /// <summary>
        /// Las clases genéricas encapsulan operaciones que no son específicas de un tipo de datos determinado
        /// </summary>
        static void ClasesGenericas()
        {
            Console.Clear();

            // Solo se puede trabajar con String
            DemoString demo1 = new DemoString("Hola Mundo !!!");
            demo1.Metodo();

            // Solo se puede trabajar con Int32
            DemoInt demo2 = new DemoInt(33);
            demo2.Metodo();
            Console.WriteLine(Environment.NewLine);

            // La clase genérica se adapta al tipo que necesitemos procesar
            DemoGeneric<string> demo3 = new DemoGeneric<string>("Hola Mundo !!!");
            demo3.Metodo();

            DemoGeneric<int> demo4 = new DemoGeneric<int>(33);
            demo4.Metodo();

            DemoGeneric<Alumno> demo5 = new DemoGeneric<Alumno>(new Alumno() { Nombre = "Julia", Apellidos = "Fernández", Edad = 24 });
            demo5.Metodo();
            Console.WriteLine(Environment.NewLine);
        }
    }

}

namespace Programando.CSharp.Objects.Herencia
{
    /// <summary>
    /// Creamos una clase que hereda de LIST, y añadimos funcionalidad extra.
    /// Los objetos deltipo ListExtend tiene toda la funcionalidad de una lista y además el métdo OutputAll().
    /// </summary>
    /// <typeparam name="T">Tipo de datos de la lista</typeparam>
    public class ListExtend<T> : List<T>
    {
        public void OutputAll()
        {
            foreach (var item in this) Console.WriteLine($"{item.ToString()}");
        }
    }

    /// <summary>
    /// Las clases marcadas con Sealed no se pueden heredar, se consideran selladas
    /// Las clases selladas no puede tener métodos virtuales
    /// </summary>
    public sealed class Persona
    {
        public string Nombre;
        public string Apellidos;

        //public virtual void MetodoA() { }
    }

    /// <summary>
    /// No se puede heredar de Persona porque es una clase sellada
    /// </summary>
    //public class Profesor : Persona { }

    /// <summary>
    /// Las método de las clases marcados como virtuales se pueden sobreescribir
    /// </summary>
    public class Animal
    {
        public string Nombre;
        public string Familia;
        public virtual void MetodoA()
        {
            Console.WriteLine("Método A, implementado en Animal.");
        }
        public void MetodoB()
        {
            Console.WriteLine("Método B, implementado en Animal.");
        }
    }

    /// <summary>
    /// Clase deriva de Animal que sobreescribe un método marcado como virtual
    /// </summary>
    public class Mamifero : Animal
    {
        public override void MetodoA()
        {
            // Se puede implementar la lógica que sustituye al heredada de la clase base Animal.
            // Se puede llamar a la lógica implementada en la clase base Animal, es opcional.                
            Console.WriteLine("Método A, implementado en Mamifero.");
            base.MetodoA();
        }
    }
}

namespace Programando.CSharp.Objects.Poliformismo
{
    /// <summary>
    /// Clase Shape
    /// </summary>
    public class Shape
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Height { get; set; }
        public int Width { get; set; }

        public virtual void Draw()
        {
            Console.WriteLine("Método Draw en Shape");
        }
    }

    /// <summary>
    /// Clase Circle que hereda de Shape y sobre escribe el método Draw llamando al método de la clase base
    /// </summary>
    public class Circle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Método Draw en Circle");
            base.Draw();
        }
    }

    /// <summary>
    /// Clase Rectangle que hereda de Shape y sobre escribe el método Draw
    /// </summary>
    public class Rectangle : Shape
    {
        public override void Draw() => Console.WriteLine("Método Draw en Rectangle");
    }

    /// <summary>
    /// Clase Triangle que hereda de Shape y sobre escribe el método Draw
    /// </summary>
    public class Triangle : Shape
    {
        public override void Draw() => Console.WriteLine("Método Draw en Triangle");
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    /// <summary>
    /// Interfaz IVehicle
    /// </summary>
    public interface IVehicle
    {
        public string Name { get; set; }
        public int Wheels { get; set; }
        public void Start();
        public void Stop();
    }

    /// <summary>
    /// Clase Car que implementa la Interfaz IVehicle
    /// </summary>
    public class Car : IVehicle
    {
        public string Name { get; set; }
        public int Wheels { get; set; }
        public string MotorType { get; set; }

        public void Start() => Console.WriteLine("Car Start");
        public void Stop() => Console.WriteLine("Car Stop");
        void IVehicle.Start() => Console.WriteLine("Vehicle Start");
        void IVehicle.Stop() => Console.WriteLine("Vehicle Stop");

    }

    /// <summary>
    /// Clase Plane que implementa la Interfaz IVehicle
    /// </summary>
    public class Plane : IVehicle
    {
        public string Name { get; set; }
        public int Wheels { get; set; }

        public void Start() => Console.WriteLine("Plane Start");
        public void Stop() => Console.WriteLine("Plane Stop");

        public void Landing() => Console.WriteLine("Plane Landing");
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    /// <summary>
    /// Clase abstracta Animals
    /// </summary>
    public abstract class Animals
    {
        /// <summary>
        /// Propiedad heredada en las clases derivadas
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Propiedad abstracta que es necesario implementar en las clases derivadas
        /// </summary>
        public abstract string Specie { get; set; }

        /// <summary>
        /// Método que es heredado en las clases derivadas
        /// </summary>
        public void MethodA() => Console.WriteLine("Método A, desde Animal");

        /// <summary>
        /// Método abstracto, necesario implementar en clase derivadas
        /// </summary>
        public abstract void MethodB();
    }

    /// <summary>
    /// Clase Amphibian que implementa la clase abstracta Animals
    /// </summary>
    public class Amphibian : Animals
    {
        protected string specie = "Amphibians";
        public override string Specie { get => specie; set => specie = value; }

        public override void MethodB() => Console.WriteLine("Método B desde Anfibios");
    }

    /// <summary>
    /// Clase Reptile que implementa la clase abstracta Animals
    /// </summary>
    public class Reptile : Animals
    {
        protected string specie = "Reptiles";
        public string Color { get; set; }
        public override string Specie { get => specie; set => specie = value; }

        public override void MethodB() => Console.WriteLine("Método B desde Reptiles");

        public void MethodC() => Console.WriteLine("Método C desde Reptiles");
    }
}

namespace Programando.CSharp.Objects.Genericas
{
    /// <summary>
    /// Clase especializada en trabajar con String
    /// </summary>
    class DemoString
    {
        public string Data { get; set; }

        public void Metodo() => Console.WriteLine($"Alfanumérico: {Data}");
        public DemoString()
        { }
        public DemoString(string data)
        {
            this.Data = data;
        }
    }

    /// <summary>
    /// Clase especializada en trabajar con Int32
    /// </summary>
    class DemoInt
    {
        public int Data { get; set; }

        public void Metodo() => Console.WriteLine($"Numérico: {Data}");
        public DemoInt()
        { }
        public DemoInt(int data)
        {
            this.Data = data;
        }
    }

    /// <summary>
    /// Clase genérica, puede trabajar con cualquier tipo de datos e incluir la lógica para String, Int32, ...
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class DemoGeneric<T>
    {
        public T Data { get; set; }

        public void Metodo()
        {
            switch (typeof(T).Name)
            {
                case "String":
                    Console.WriteLine($"Alfanumérico: {Data}");
                    break;
                case "Int32":
                    Console.WriteLine($"Numérico: {Data}");
                    break;
                default:
                    Console.WriteLine($"{typeof(T).Name}: {Data}");
                    break;
            }
        }
        public DemoGeneric()
        { }
        public DemoGeneric(T data)
        {
            this.Data = data;
        }
    }
}

namespace Programando.CSharp.Objects
{
    /// <summary>
    /// Objeto Alumno para los ejercicios de demostración
    /// </summary>
    public class Alumno
    {
        public string Nombre;
        public string Apellidos;
        public int Edad;

        public override string ToString()
        {
            return $"{Nombre} {Apellidos}";
        }
        public Alumno() { }
    }
}