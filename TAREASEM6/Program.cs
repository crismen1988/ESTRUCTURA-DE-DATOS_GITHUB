using System;

class Program
{
    static void Main(string[] args)
    {
        int opcion;
        // Muestra el menú principal y permite al usuario seleccionar una opción
        do
        {
            Console.Clear();
            Console.WriteLine("===== MENÚ PRINCIPAL =====");
            Console.WriteLine("1. Números primos y Armstrong");
            Console.WriteLine("2. Registro de vehículos");
            Console.WriteLine("3. Salir");
            Console.Write("Seleccione una opción: ");
            //  Lee la opción del usuario y la convierte en entero
            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Ingrese un número válido.");
                Console.ReadKey();
                continue;
            }
            // Ejecuta la opción seleccionada
            switch (opcion)
            {
                case 1:
                    Ejercicio1.Ejecutar();
                    break;
                case 2:
                    Ejercicio2.Ejecutar();
                    break;
                case 3:
                    Console.WriteLine("Saliendo...");
                    break;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
            // Si la opción no es 3, espera a que el usuario presione una tecla antes de continuar
            if (opcion != 3)
            {
                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadKey();
            }
        // Repite el bucle hasta que el usuario seleccione la opción 3
        } while (opcion != 3);
    }
}
