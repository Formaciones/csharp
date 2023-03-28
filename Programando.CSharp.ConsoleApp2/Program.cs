using Programando.CSharp.ConsoleApp2.Model;

namespace Programando.CSharp.ConsoleApp2;

public class Programando
{
    /// <summary>
    /// Los tipos de valor y los tipos de referencia son las dos categorías principales de tipos de C#. 
    /// Una variable de un tipo de valor contiene una instancia del tipo (una copia). 
    /// Una variable de un tipo de referencia, que contiene una referencia a una instancia(un puntero a la dirección de memoria). 
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
        //Variable de tipo referencia. Objeto definido con Class.
        var alumno = new Alumno() { Nombre = "Ana", Apellidos = "Sanz" };

        var alumnoA = new Alumno();
        var alumnoB = new Alumno("Borja", "Cabeza");

        int a = 10;

        Console.WriteLine($"{alumno.Nombre} {alumno.Apellidos} - {a}");
        Transformar(alumno, ref a);
        Console.WriteLine($"{alumno.Nombre} {alumno.Apellidos} - {a}" + Environment.NewLine);

        //Variable de tipo valor. Objeto definico con Struct.
        var alumno2 = new Alumno2() { nombre = "Ana", apellidos = "Sanz" };

        Console.WriteLine($"{alumno2.nombre} {alumno2.apellidos}");
        Transformar(alumno2);
        Console.WriteLine($"{alumno2.nombre} {alumno2.apellidos}" + Environment.NewLine);
    }

    /// <summary>
    /// Método que recibe dos parámetros
    /// </summary>
    /// <param name="a">Representa un objeto Alumno creado con Class, es de referencia</param>
    /// <param name="numero">Representa un número entero que es de tipo valor, se comporta como de referencia cuando añadimos ref</param>
    static void Transformar(Alumno a, ref int numero)
    {
        a.Nombre = "Borja";
        a.Apellidos = "Cabeza";
        numero = 1100;
    }

    /// <summary>
    /// Método que recibe un parámetros
    /// </summary>
    /// <param name="a">Representa un objeto Alumno creado con Struct, es de valor</param>
    static void Transformar(Alumno2 a)
    {
        a.nombre = "Borja";
        a.apellidos = "Cabeza";
    }

    /// <summary>
    /// Otro método
    /// </summary>
    static void Transformar()
    {
    }

    /// <summary>
    /// Otro método
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    static void Transformar(Alumno a, Alumno2 b)
    {
    }

}