using System;
using System.Collections.Generic;
using System.Linq; // Necesario para métodos como Any()
using System.Text.RegularExpressions; // Para validación del ID en la entrada del usuario

public class Program
{
    private static Biblioteca miBiblioteca = new Biblioteca(); // Instancia de la biblioteca

    public static void Main(string[] args)
    {
        bool salir = false; // Controla el ciclo del menú principal
        while (!salir) // Repite hasta que el usuario decida salir
        {
            MostrarMenu(); // Muestra el menú principal
            string opcion = Console.ReadLine(); // Lee la opción del usuario

            switch (opcion) // Controla la opción seleccionada por el usuario
            {
                case "1":
                    IngresarLibro();
                    break;
                case "2":
                    ConsultarLibroPorId();
                    break;
                case "3":
                    EliminarLibroPorId();
                    break;
                case "4":
                    MostrarTodosLosLibros();
                    break;
                case "5":
                    salir = true;
                    Console.WriteLine("\nSaliendo de la aplicación. ¡Hasta pronto!");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Por favor, intente de nuevo.");
                    break;
            }
            if (!salir) // Si el usuario no ha decidido salir continúa
            {
                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
                Console.Clear(); // Limpia la consola para el siguiente menú
            }
        }
    }

    // Muestra el menú principal de la aplicación.
    private static void MostrarMenu()
    {
        Console.WriteLine("--- SISTEMA DE REGISTRO DE LIBROS DE BIBLIOTECA ---");
        Console.WriteLine("1. Ingresar libro");
        Console.WriteLine("2. Consultar libro por ID");
        Console.WriteLine("3. Eliminar libro por ID");
        Console.WriteLine("4. Mostrar todos los libros");
        Console.WriteLine("5. Salir");
        Console.Write("Seleccione una opción: ");
    }

    // Permite al usuario ingresar los datos de un nuevo libro y agregarlo a la biblioteca.
    private static void IngresarLibro()
    {
        Console.WriteLine("\n--- INGRESAR NUEVO LIBRO ---");

        Console.Write("Ingrese el ID del libro (solo letras y números, ej: LIB001, C2023): ");
        string id = Console.ReadLine();

        // Valida el ID antes de pasarlo a la biblioteca
        if (string.IsNullOrWhiteSpace(id) || !Regex.IsMatch(id, @"^[a-zA-Z0-9]+$"))
        {
            // Muestra un mensaje de error y termina la función si el ID no es válido
            Console.WriteLine("Error: El ID solo puede contener letras y números, no puede estar vacío ni contener caracteres especiales.");
            return;
        }

        Console.Write("Ingrese el título del libro: ");
        string titulo = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(titulo))
        {
            // Muestra un mensaje de error y termina la función si el título no es válido
            Console.WriteLine("Error: El título del libro no puede estar vacío.");
            return;
        }

        Console.Write("Ingrese el autor del libro: ");
        string autor = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(autor))
        {
            // Muestra un mensaje de error y termina la función si el autor no es válido
            Console.WriteLine("Error: El autor del libro no puede estar vacío.");
            return;
        }

        int añoPublicacion;
        Console.Write("Ingrese el año de publicación: ");
        // Valida que el año sea un número válido, positivo y no futuro
        while (!int.TryParse(Console.ReadLine(), out añoPublicacion) || añoPublicacion <= 0 || añoPublicacion > DateTime.Now.Year)
        {
            // Muestra un mensaje de error y vuelve a pedir el año de publicación
            Console.WriteLine($"Año de publicación inválido. Por favor, ingrese un número entero positivo y no mayor a {DateTime.Now.Year}.");
            Console.Write("Ingrese el año de publicación: ");
        }
        
        Libro nuevoLibro = new Libro(id, titulo, autor, añoPublicacion); // Crea una nueva instancia de Libro
        string mensaje;
        if (miBiblioteca.AgregarLibro(nuevoLibro, out mensaje)) // Intenta agregar el libro a la biblioteca
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(mensaje); // Muestra el mensaje de éxito
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(mensaje); // Muestra el mensaje de error
            Console.ResetColor();
        }
    }

    // Permite al usuario consultar un libro por su ID.
    private static void ConsultarLibroPorId()
    {
        Console.WriteLine("\n--- CONSULTAR LIBRO POR ID ---");
        Console.Write("Ingrese el ID del libro a consultar: ");
        string id = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(id)) // Valida el ID ingresado
        {
            Console.WriteLine("Error: El ID no puede estar vacío.");
            return;
        }

        Libro libroEncontrado = miBiblioteca.ConsultarLibroPorId(id);
        if (libroEncontrado != null) // Si se encuentra el libro muestra el libro
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nLibro encontrado:");
            Console.WriteLine(libroEncontrado);
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            // Muestra un mensaje de error si no se encuentra el libro
            Console.WriteLine($"No se encontró ningún libro con el ID '{id}'.");
            Console.ResetColor();
        }
    }

    // Permite al usuario eliminar un libro por su ID.
    private static void EliminarLibroPorId() // Método para eliminar un libro por su ID
    {
        Console.WriteLine("\n--- ELIMINAR LIBRO POR ID ---");
        Console.Write("Ingrese el ID del libro a eliminar: ");
        string id = Console.ReadLine();

        string mensaje; // Variable para almacenar el mensaje de resultado
        if (miBiblioteca.EliminarLibroPorId(id, out mensaje)) // Intenta eliminar el libro de la biblioteca
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(mensaje); // Muestra el mensaje de éxito
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(mensaje); // Muestra el mensaje de error
            Console.ResetColor();
        }
    }

    // Muestra todos los libros registrados en la biblioteca.
    private static void MostrarTodosLosLibros()
    {
        Console.WriteLine("\n--- LISTA DE TODOS LOS LIBROS ---");
        var todosLosLibros = miBiblioteca.ObtenerTodosLosLibros();

        if (todosLosLibros.Any()) // 'Any()' es un método LINQ para comprobar si la colección tiene elementos.
        {
            foreach (var libro in todosLosLibros) // Itera sobre cada libro en la lista
            {
                Console.WriteLine(libro); // Muestra la información del libro
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            // Muestra un mensaje si no hay libros registrados
            Console.WriteLine("La biblioteca está vacía. No hay libros registrados."); 
            Console.ResetColor();
        }
    }
}