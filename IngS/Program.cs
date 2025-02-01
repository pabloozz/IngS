using System;
using System.IO;

class Persona
{
    public string Nombre { get; }
    public int Edad { get; }

    public Persona(string nombre, int edad)
    {
        Nombre = nombre.Trim();
        Edad = edad;
    }

    public virtual bool PuedeEntrar() => true; // Por defecto, los humanos pueden entrar
}

class HombreLobo : Persona
{
    public HombreLobo(string nombre, int edad) : base(nombre, edad) { }

    public override bool PuedeEntrar() => false;
}

class Vampiro : Persona
{
    public Vampiro(string nombre, int edad) : base(nombre, edad) { }

    public override bool PuedeEntrar() => false;
}

class DetectorDeCriaturas
{
    public static Persona ClasificarPersona(string nombre, int edad)
    {
        if (edad >= 200)
            return new Vampiro(nombre, edad);
        if (edad >= 120 || nombre.ToLower().StartsWith("h"))
            return new HombreLobo(nombre, edad);

        return new Persona(nombre, edad); // En cualquier otro caso, es humano
    }
}

class Programa
{
    static void Main()
    {
        string archivoHistorial = "historial_accesos.txt";

        while (true)
        {
            Console.Write("Ingrese el nombre (o escriba 'salir' para terminar): ");
            string nombre = Console.ReadLine().Trim();

            if (nombre.ToLower() == "salir")
            {
                Console.WriteLine("📌 Saliendo del programa...");
                break;
            }

            if (string.IsNullOrEmpty(nombre))
            {
                Console.WriteLine("⚠ El nombre no puede estar vacío. Intente de nuevo.");
                continue;
            }

            int edad;
            while (true) // Bucle para validar la edad
            {
                Console.Write("Ingrese la edad: ");
                if (int.TryParse(Console.ReadLine(), out edad) && edad >= 0)
                    break;
                Console.WriteLine("⚠ Edad inválida. Intente de nuevo.");
            }

            Persona persona = DetectorDeCriaturas.ClasificarPersona(nombre, edad);
            string resultado;

            if (persona.PuedeEntrar())
                resultado = $"✅ Acceso permitido a {nombre}. Bienvenido.";
            else
                resultado = $"❌ Acceso denegado a {nombre}. Puede ser una criatura peligrosa.";

            Console.WriteLine(resultado);
            GuardarHistorial(archivoHistorial, nombre, edad, resultado);

            Console.WriteLine(new string('-', 50)); // Línea divisoria para mejor lectura
        }
    }

    static void GuardarHistorial(string archivo, string nombre, int edad, string resultado)
    {
        try
        {
            using (StreamWriter sw = new StreamWriter(archivo, true))
            {
                sw.WriteLine($"{DateTime.Now} | Nombre: {nombre}, Edad: {edad} - {resultado}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("⚠ No se pudo guardar el historial: " + ex.Message);
        }
    }
}
