using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Buen día, por favor, ingrese su nombre o escriba 'salir' para terminar: ");
                    string nombre = Console.ReadLine().Trim(); // Eliminamos los espacios en blanco

                    if (nombre.ToLower() == "salir")
                    {
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    }

                    Console.WriteLine("Buen día, por favor, ingrese su edad: ");
                    if (!int.TryParse(Console.ReadLine(), out int edad) || edad < 0)
                    {
                        Console.WriteLine("Edad no válida. Intente de nuevo.");
                        continue;
                    }

                    if (string.IsNullOrEmpty(nombre))
                    {
                        Console.WriteLine("El nombre no puede estar vacío.");
                        continue;
                    }

                    if (edad >= 200)
                        Console.WriteLine($"Acceso denegado a {nombre}. Tenga mucho cuidado, puede ser un Vampiro.");
                    else if (nombre.ToLower().StartsWith("h"))
                        Console.WriteLine($"Acceso denegado a {nombre}. Tenga mucho cuidado, puede ser un Hombre Lobo.");
                    else if (nombre.ToLower().StartsWith("v") && edad < 120)
                        Console.WriteLine($"Acceso permitido a {nombre}. Es un humano.");
                    else if (edad > 120 && edad < 200)
                        Console.WriteLine($"Acceso denegado a {nombre}. Lo más probable es que sea un Hombre Lobo.");
                    else
                        Console.WriteLine($"Acceso permitido a {nombre}. Es probable que sea un humano.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ocurrió un error en el programa: " + ex.Message);
                }
            }
        }
    }
}
