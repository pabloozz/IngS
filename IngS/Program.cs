using System;

class Persona
{
    public string Nombre { get; }
    public int Edad { get; }

    public Persona(string nombre, int edad)
    {
        Nombre = nombre.Trim();
        Edad = edad;
    }

    public virtual bool PuedeEntrar() => false; 
}

class HombreLobo : Persona
{
    public HombreLobo(string nombre, int edad) : base(nombre, edad) { }
}

class Vampiro : Persona
{
    public Vampiro(string nombre, int edad) : base(nombre, edad) { }
}

class HombreNormal : Persona
{
    public HombreNormal(string nombre, int edad) : base(nombre, edad) { }

    public override bool PuedeEntrar() => true; 
}

class DetectorDeCriaturas
{
    public static Persona ClasificarPersona(string nombre, int edad)
    {
        if (edad > 200)
            return new Vampiro(nombre, edad);
        if (edad < 200 && nombre.Length > 0 && char.ToLower(nombre[0]) == 'h')
            return new HombreLobo(nombre, edad);
        if (edad < 200 && nombre.Length > 0 && char.ToLower(nombre[0]) == 'v')
            return new HombreNormal(nombre, edad);
        return new Persona(nombre, edad); 

    }
}

class Programa
{
    static void Main()
    {
        Console.Write("Ingrese el nombre: ");
        string nombre = Console.ReadLine();

        Console.Write("Ingrese la edad: ");
        if (!int.TryParse(Console.ReadLine(), out int edad))
        {
            Console.WriteLine("Edad inválida.");
            return;
        }

        Persona persona = DetectorDeCriaturas.ClasificarPersona(nombre, edad);

        if (persona.PuedeEntrar())
            Console.WriteLine("Acceso permitido. Bienvenido a la convención.");
        else
            Console.WriteLine("Acceso denegado. No se permiten vampiros ni hombres lobo.");
    }
}
