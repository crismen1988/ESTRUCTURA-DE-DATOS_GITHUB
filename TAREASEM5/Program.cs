using System;

class Program
{
    static void Main()
    {
        int opcion;

        do
        {
            // Limpia la consola y muestra el menú
            Console.Clear();
            Console.WriteLine("MENÚ DE EJERCICIOS");
            Console.WriteLine("1. Producto de matrices");
            Console.WriteLine("2. Menor y mayor de precios");
            Console.WriteLine("3. Abecedario sin letras en posiciones múltiplos de 3");
            Console.WriteLine("4. Números del 1 al 10 en orden inverso");
            Console.WriteLine("5. Lista de asignaturas");
            Console.WriteLine("0. Salir");

            // Este ciclo asegura que la entrada sea válida
            while (true)
            {
                // Solicita al usuario que ingrese una opción
                Console.Write("Seleccione una opción: ");
                string entrada = Console.ReadLine();
                // Intenta convertir la entrada a un número entero
                // Si la conversión falla, se solicita una nueva entrada
                if (int.TryParse(entrada, out opcion))
                {
                    break; // salida del ciclo si la entrada es válida
                }
                else
                {
                    // Si la conversión falla, muestra un mensaje de error
                    Console.WriteLine("Entrada inválida. Por favor, ingrese un número entero.");
                }
            }

            Console.Clear(); // Limpia la pantalla para que se vea mejor
            // Ejecuta el menú
            switch (opcion)
            {
                case 1:
                    Ejercicio1.Ejecutar();
                    break;
                case 2:
                    Ejercicio2.Ejecutar();
                    break;
                case 3:
                    Ejercicio3.Ejecutar();
                    break;
                case 4:
                    Ejercicio4.Ejecutar();
                    break;
                case 5:
                    Ejercicio5.Ejecutar();
                    break;
                case 0:
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
            // Si la opción no es 0, espera a que el usuario presione una tecla antes de volver al menú
            if (opcion != 0)
            {
                Console.WriteLine("\nPresione una tecla para volver al menú...");
                Console.ReadKey();
            }
        // Repite el ciclo hasta que el usuario ingrese 0
        } while (opcion != 0);
    }
}
