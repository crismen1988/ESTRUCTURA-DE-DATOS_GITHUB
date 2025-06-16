using System;

namespace RegistroEstudiantes
{
    // Clase que representa a un estudiante
    class Estudiante
    {
        public int Id;
        public string Nombres;
        public string Apellidos;
        public string Direccion;
        public string[] Telefonos = new string[3];

        // Método para mostrar los datos del estudiante
        public void MostrarDatos()
        {
            Console.WriteLine("\n===== DATOS DEL ESTUDIANTE =====");
            Console.WriteLine("ID: " + Id);
            Console.WriteLine("Nombres: " + Nombres);
            Console.WriteLine("Apellidos: " + Apellidos);
            Console.WriteLine("Dirección: " + Direccion);

            Console.WriteLine("Teléfonos:");
            for (int i = 0; i < Telefonos.Length; i++)
            {
                Console.WriteLine($"Teléfono {i + 1}: {Telefonos[i]}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Estudiante estudiante = new Estudiante();

            Console.WriteLine("Ingrese los datos del estudiante:");

            Console.Write("ID: ");
            estudiante.Id = int.Parse(Console.ReadLine());

            Console.Write("Nombres: ");
            estudiante.Nombres = Console.ReadLine();

            Console.Write("Apellidos: ");
            estudiante.Apellidos = Console.ReadLine();

            Console.Write("Dirección: ");
            estudiante.Direccion = Console.ReadLine();

            // Ingreso y validación de los 3 teléfonos
            for (int i = 0; i < estudiante.Telefonos.Length; i++)
            {
                string telefono;
                bool valido = false;

                do
                {
                    Console.Write($"Teléfono {i + 1} (10 dígitos, solo números): ");
                    telefono = Console.ReadLine();

                    // Verifica si el número tiene exactamente 10 dígitos y son todos números.
                    if (telefono.Length == 10 && long.TryParse(telefono, out _))
                    {
                        // if (telefono.StartsWith("09"))
                        valido = true;
                    }
                    else
                    {
                        Console.WriteLine("⚠️ Teléfono inválido. Debe tener exactamente 10 dígitos numéricos.");
                    }

                } while (!valido);

                estudiante.Telefonos[i] = telefono;
            }

            // Mostrar los datos ingresados
            estudiante.MostrarDatos();

            Console.WriteLine("\nPresione una tecla para salir...");
            Console.ReadKey();
        }
    }
}
