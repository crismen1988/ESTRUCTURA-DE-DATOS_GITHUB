using System;

class Program
{
    static void Main()
    {
        // Menú principal
        while (true)
        {
            // Limpiar la consola
            Console.Clear();
            // Mostrar el menú
            Console.WriteLine("=== Menú Principal ===");
            Console.WriteLine("1. Resolver Torres de Hanoi");
            Console.WriteLine("2. Verificar fórmula balanceada");
            Console.WriteLine("3. Salir");
            Console.Write("Seleccione una opción: ");
            // Leer la opción seleccionada
            string opcion = Console.ReadLine();
            // Se ejecuta la opción seleccionada
            switch (opcion)
            {
                case "1":
                    EjecutarTorresDeHanoi();
                    break;
                case "2":
                    EjecutarVerificadorDeSimbolos();
                    break;
                case "3":
                    Console.WriteLine("Saliendo del programa...");
                    return;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
            // Pausa para continuar
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }

    static void EjecutarTorresDeHanoi()
    {
        Console.Clear();
        // Resolver la Torre de Hanoi
        Console.WriteLine("=== Torres de Hanoi ===");
        // Leer el número de discos
        Console.Write("Ingrese el número de discos: ");
        // Verificar si el dato ingresado es un número válido
        if (int.TryParse(Console.ReadLine(), out int cantidad) && cantidad > 0)
        {
            // Crear una instancia de la clase TorreHanoi
            TorresDeHanoiConPOO.TorreHanoi hanoi = new TorresDeHanoiConPOO.TorreHanoi(cantidad);
            hanoi.Resolver();
            hanoi.MostrarEstadoFinal();
        }
        // Dato Ingresado no es un número válido
        else
        {
            Console.WriteLine("Número inválido.");
        }
    }

    static void EjecutarVerificadorDeSimbolos()
    {
        Console.Clear();
        // Verificar fórmula balanceada
        Console.WriteLine("=== Verificador de Símbolos ===");
        // Leer la fórmula
        Console.Write("Ingrese la fórmula: ");
        string entrada = Console.ReadLine();
        // Crear una instancia de la clase VerificadorDeSimbolos
        VerificadorDeSimbolosPOO.VerificadorDeSimbolos verificador = new VerificadorDeSimbolosPOO.VerificadorDeSimbolos(entrada);
        verificador.EstaBalanceada();
    }
}