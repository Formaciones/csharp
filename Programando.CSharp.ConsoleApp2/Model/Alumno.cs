namespace Programando.CSharp.ConsoleApp2.Model;

/// <summary>
/// Objeto creado con CLASS, de tipo referencia
/// </summary>
public class Alumno
{
    //Miembro: Variables
    private string nombre;
    private int edad;

    //Miembro: Propiedad asociada a una variable
    public string Nombre
    {
        //Retornamos la información despues de tranformarla.
        get
        {
            return nombre.Trim().ToLower();
        }

        //Tratamos la información antes de almacenarla en la variable.
        set
        {
            if (value.Length < 2) nombre = "";
            else nombre = value;
        }
    }

    //Miembro: Propiedad sin variable
    public string Apellidos { get; set; }

    //Miembro: Propiedad asociada a una variable
    public int Edad
    {
        get
        {
            return edad;
        }
        set
        {
            if (value < 1 || value > 130) edad = 0;
            else edad = value;
        }
    }

    //Miembro: Propiedad de solo lectura con Get
    public string NombreCompleto
    {
        get
        {
            return $"{this.nombre} {this.Apellidos}";
        }
    }

    //Miembro: Propiedad de solo escritura con Set
    public int CambiaEdad
    {
        set
        {
            edad = value;
        }
    }

    //Miembro: Métodos con tipo VOID, no retorna información
    public void MetodoUno()
    { }

    /// <summary>
    /// Miembros: Métodos con tipo que retornan información.
    /// Todos los parámetros opcionales tiene un valor por defecto y se escriben después de los obligatorios
    /// </summary>
    /// <param name="param1">Parámetro obligatorio</param>
    /// <param name="param2">Parámetro obligatorio</param>
    /// <param name="param3">Parámetro opcional</param>
    /// <param name="param4">Parámetro opcional</param>
    /// <returns></returns>
    public bool MetodoDos(int param1, string param2, float param3 = 0, string param4 = "valor por defecto")
    {
        return true;
    }

    //Miembros: Constructor, es público, no tiene tipo y se llama igual que la clase
    public Alumno()
    {

    }

    //Sobrecarga del método constructor.
    public Alumno(string nombre, string apellidos)
    {
        this.nombre = nombre;
        this.Apellidos = apellidos;
    }

    //Miembros: Destructores, no tiene tipo, comienza por ~ (Alt+0126 o AltGrap+4) más el nombre de la clase
    //No se le puede llamar, se ejecuta automáticamente
    //No tiene parámetros
    ~Alumno()
    {
        System.Diagnostics.Debug.WriteLine("Inicio del destructor de Alumno.");
        this.nombre = null;
        this.Apellidos = null;
    }
}