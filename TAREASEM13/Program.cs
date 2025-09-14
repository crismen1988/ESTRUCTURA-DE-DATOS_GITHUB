using System;

namespace CatalogoRevistas
{
    class Program
    {
        static void Main(string[] args)
        {
            // Crear un catálogo de revistas
            ArbolRevistas catalogo = new ArbolRevistas();
            // Se agregan algunas revistas al catálogo
            string[] revistas = {
                "National Geographic",
                "Time",
                "Forbes",
                "Scientific American",
                "Nature",
                "PC World",
                "Sports Illustrated",
                "Economist",
                "Reader's Digest",
                "Vogue"
            };
            // Se agrega las revistas en el catálogo
            foreach (var titulo in revistas)
            {
                catalogo.Insertar(new Revista(titulo));
            }
            // Menú para buscar revistas
            int opcion;
            do
            {
                Console.WriteLine("\n=== Catálogo de Revistas ===");
                Console.WriteLine("1. Buscar revista");
                Console.WriteLine("2. Salir");
                Console.Write("Elige una opción: ");
                opcion = int.Parse(Console.ReadLine());
                // Realiza la acción según la opción elegida
                switch (opcion)
                {
                    case 1:
                        Console.Write("Ingrese el título de la revista a buscar: ");
                        string titulo = Console.ReadLine();
                        // Busca la revista en el catálogo
                        bool encontrado = catalogo.Buscar(titulo);
                        if (encontrado)
                            Console.WriteLine("Encontrado");
                        else
                            Console.WriteLine("No encontrado");
                        break;

                    case 2:
                        Console.WriteLine("Saliendo...");
                        break;

                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }
            } while (opcion != 2); // Repite hasta que el usuario elija salir
        }
    }
}
