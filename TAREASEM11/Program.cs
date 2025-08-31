using System;

namespace TraductorBasico
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declaración del objeto traductor
            Traductor traductor = new Traductor();
            //Declaración de la variable para la opción del menú
            int opcion;
            //Inicio del menú
            do
            {
                Console.WriteLine("\n==================== MENÚ ====================");
                Console.WriteLine("1. Traducir una frase");
                Console.WriteLine("2. Agregar palabras al diccionario");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");

                // Valido la entrada numérica
                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    // Si la entrada no es válida, muestro un mensaje de error
                    Console.WriteLine("Opción inválida, ingrese un número.");
                    continue;
                }
                //Creo el switch para las opciones
                switch (opcion)
                {
                    case 1:
                        Console.Write("\nIngrese una frase: ");
                        string frase = Console.ReadLine();
                        string traduccion = traductor.TraducirFrase(frase);
                        Console.WriteLine($"Traducción: {traduccion}");
                        break;

                    case 2:
                        Console.Write("\nIngrese la palabra en inglés: ");
                        string ingles = Console.ReadLine().Trim();

                        Console.Write("Ingrese la traducción en español: ");
                        string español = Console.ReadLine().Trim();

                        traductor.AgregarPalabra(ingles, español);
                        break;

                    case 0:
                        Console.WriteLine("Saliendo del programa...");
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            // Fin del menú
            } while (opcion != 0);
        }
    }
}

