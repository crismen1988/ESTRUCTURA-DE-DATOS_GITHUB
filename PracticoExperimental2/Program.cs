using System;
using System.Collections.Generic;
using System.Threading;

class ProgramaAuditorio
{
    // Variables globales
    static Queue<string> colaAsistentes = new Queue<string>(); // FIFO
    // Almacena los asistentes que llegan al auditorio
    static string[] asientos = new string[100]; // Guarda el nombre del asistente
    // en cada asiento, hasta un máximo de 100
    static int asientoActual = 0;
    static int rechazados = 0; // Personas que no consiguieron asiento
    static object bloqueo = new object(); // Evita que los asignadores asignen el mismo asiento al mismo tiempo
    // Función que simula el registro de asistentes
    // Cada registrador asigna un asiento a un asistente de la cola
    static void RegistrarAsistente(string registrador)
    {
        // Simula el proceso de registro de asistentes
        while (true)
        {
            // Bloquea el acceso a la cola y a los asientos para evitar condiciones de carrera
            string asistente;
            lock (bloqueo)
            {
                // Si no hay más asistentes, termina el hilo
                if (colaAsistentes.Count == 0)
                {
                    return; // No hay más personas en la fila
                }
                // Si hay asistentes, asigna un asiento
                asistente = colaAsistentes.Dequeue();
                // Verifica si hay asientos disponibles
                if (asientoActual >= asientos.Length)
                {
                    // Si no hay asientos, incrementa el contador de rechazados
                    rechazados++;
                    Console.WriteLine($" {registrador}: No hay asientos para {asistente} (auditorio lleno).");
                    continue;
                }
                // Si hay asientos disponibles, asigna el asiento al asistente
                asientos[asientoActual] = asistente;
                // Incrementa el contador de asientos ocupados
                asientoActual++;
                // Imprime el mensaje de éxito
                Console.WriteLine($" {registrador} asignó el asiento #{asientoActual} a {asistente}.");
            }
            // Simula el tiempo que toma registrar al asistente
            Thread.Sleep(100); // Simula el tiempo de registro
        }
    }

    static void Main(string[] args)
    {
        Console.WriteLine("=== Simulación de Registro en Auditorio ===");

        // Simulación de asistentes
        Console.Write("Ingrese cuántas personas llegan al congreso: ");
        // Lee la cantidad de personas
        int totalPersonas = int.Parse(Console.ReadLine());
        // Agrega a la cola de asistentes
        for (int i = 1; i <= totalPersonas; i++)
        {
            colaAsistentes.Enqueue($"Asistente {i}");
        }

        // Dos registradores (dos hilos), dos filas de asistentes
        Thread registrador1 = new Thread(() => RegistrarAsistente("Registrador 1"));
        Thread registrador2 = new Thread(() => RegistrarAsistente("Registrador 2"));
        // Inicia los hilos o filas de los registradores
        registrador1.Start();
        registrador2.Start();
        // Espera a que ambos registradores terminen
        registrador1.Join();
        registrador2.Join();

        // Resultados finales
        int asientosOcupados = asientoActual;
        int asientosVacios = asientos.Length - asientosOcupados;
        // Imprime la lista de asientos asignados
        Console.WriteLine("\n LISTA FINAL DE ASIENTOS ASIGNADOS:");
        // Recorre la lista de asientos
        for (int i = 0; i < asientoActual; i++)
        {
            // Imprime el número de asiento y el nombre del asistente
            Console.WriteLine($"Asiento #{i + 1}: {asientos[i]}");
        }
        // Imprime el resumen final
        Console.WriteLine("\n=== RESUMEN FINAL ===");
        // Imprime el número de asientos ocupados y vacíos
        Console.WriteLine($" Asientos ocupados: {asientosOcupados}");
        Console.WriteLine($" Asientos vacíos: {asientosVacios}");
        // Imprime el número de personas que no consiguieron asiento
        if (rechazados > 0)
        {
            // Imprime el número de personas que no consiguieron asiento
            Console.WriteLine($" Personas que se quedaron sin asiento: {rechazados}");
        }
        // Imprime el mensaje de finalización
        Console.WriteLine("\n Proceso finalizado.");
    }
}
