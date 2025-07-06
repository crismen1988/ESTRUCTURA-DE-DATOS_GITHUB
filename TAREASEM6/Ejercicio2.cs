using System;

// Nodo de vehículo
class NodoVehiculo
{
    // Representa un vehículo en la lista enlazada
    public Vehiculo Datos;
    public NodoVehiculo Siguiente;

    // Constructor que inicializa los datos del vehículo y el enlace al siguiente nodo
    public NodoVehiculo(Vehiculo datos)
    {
        Datos = datos;
        Siguiente = null;
    }
}

// Clase Vehiculo que representa un vehículo con sus propiedades
class Vehiculo
{
    public string Placa;
    public string Marca;
    public string Modelo;
    public int Anio;
    public double Precio;
}

// Lista enlazada de vehículos
class ListaVehiculos
{
    // Cabeza de la lista que apunta al primer nodo
    public NodoVehiculo Head;

    // Constructor que inicializa la lista vacía
    public ListaVehiculos()
    {
        // Inicializa la cabeza de la lista como nula
        Head = null;
    }
    // Métodos para manipular la lista de vehículos
    public void Agregar(Vehiculo v)
    {
        // Agrega un nuevo vehículo al final de la lista
        NodoVehiculo nuevo = new NodoVehiculo(v);
        // Si la lista está vacía, el nuevo nodo se convierte en la cabeza
        if (Head == null)
        {
            // Asigna el nuevo nodo como la cabeza de la lista
            Head = nuevo;
        }
        // Si la lista no está vacía, recorre hasta el final y agrega el nuevo nodo
        else
        {
            // Recorre la lista hasta el último nodo
            NodoVehiculo actual = Head;
            // Mientras el siguiente nodo no sea nulo, avanza al siguiente nodo
            while (actual.Siguiente != null)
                actual = actual.Siguiente;
            actual.Siguiente = nuevo;
        }
    }
    // Busca un vehículo por su placa
    public Vehiculo BuscarPorPlaca(string placa)
    {
        // Recorre la lista desde la cabeza hasta encontrar el vehículo con la placa especificada
        NodoVehiculo actual = Head;
        // Mientras haya nodos en la lista
        while (actual != null)
        {
            // Si el vehículo actual tiene la placa buscada, retorna sus datos
            if (actual.Datos.Placa.Equals(placa, StringComparison.OrdinalIgnoreCase))
                return actual.Datos;
            actual = actual.Siguiente;
        }
        // Si no se encuentra el vehículo, retorna nulo
        return null;
    }
    // Muestra los vehículos del año especificado
    public void VerPorAnio(int anio)
    {
        // Recorre la lista y muestra los vehículos que coinciden con el año especificado
        NodoVehiculo actual = Head; 
        bool encontrado = false;
        // Si la lista está vacía, informa al usuario
        while (actual != null)
        {
            // Si el año del vehículo actual coincide con el año buscado, muestra sus datos
            if (actual.Datos.Anio == anio)
            {
                Mostrar(actual.Datos);
                encontrado = true;
            }
            actual = actual.Siguiente;
        }
        // Si no se encontraron vehículos con el año especificado, informa al usuario
        if (!encontrado)
            Console.WriteLine("No se encontraron vehículos con ese año.");
    }
// Muestra todos los vehículos registrados en la lista
    public void VerTodos()
    {
        // Recorre la lista desde la cabeza y muestra los datos de cada vehículo
        NodoVehiculo actual = Head;
        // Si la lista está vacía, informa al usuario
        if (actual == null)
        {
            // Informa que no hay vehículos registrados
            Console.WriteLine("No hay vehículos registrados.");
            return;
        }
        // Mientras haya nodos en la lista, muestra los datos de cada vehículo
        while (actual != null)
        {
            Mostrar(actual.Datos);
            actual = actual.Siguiente;
        }
    }
    // Elimina un vehículo de la lista por su placa
    public bool Eliminar(string placa)
    {
        // Recorre la lista para encontrar el vehículo con la placa especificada
        NodoVehiculo actual = Head, anterior = null;
        // Si la lista está vacía, no se puede eliminar
        while (actual != null)
        {
            // Si el vehículo actual tiene la placa buscada
            if (actual.Datos.Placa.Equals(placa, StringComparison.OrdinalIgnoreCase))
            {
                // Si es el primer nodo, actualiza la cabeza de la lista
                if (anterior == null)
                    Head = actual.Siguiente;
                // Si no es el primer nodo, enlaza el nodo anterior con el siguiente del nodo actual
                else
                    anterior.Siguiente = actual.Siguiente;
                // Libera el nodo actual
                return true;
            }
            // Avanza al siguiente nodo
            anterior = actual;
            actual = actual.Siguiente;
        }
        // Si no se encontró el vehículo con la placa especificada, retorna falso
        return false;
    }
    // Muestra los datos de un vehículo
    private void Mostrar(Vehiculo v)
    {
    // Muestra los datos del vehículo en un formato legible
        Console.WriteLine($"Placa: {v.Placa}, Marca: {v.Marca}, Modelo: {v.Modelo}, Año: {v.Anio}, Precio: ${v.Precio}");
    }
}

// Clase principal del ejercicio 2
class Ejercicio2
{
    // Método para ejecutar el ejercicio de registro de vehículos
    public static void Ejecutar()
    {
        // Crea una nueva lista de vehículos
        ListaVehiculos lista = new ListaVehiculos();
        int opcion;
        // Bucle para mostrar el menú al usuario
        do
        {
            Console.Clear();
            Console.WriteLine("===== REGISTRO DE VEHÍCULOS =====");
            Console.WriteLine("1. Agregar vehículo");
            Console.WriteLine("2. Buscar por placa");
            Console.WriteLine("3. Buscar por año");
            Console.WriteLine("4. Ver todos los vehículos");
            Console.WriteLine("5. Eliminar vehículo");
            Console.WriteLine("6. Volver al menú principal");
            Console.Write("Seleccione una opción: ");
            // Lee la opción del usuario y verifica si es un número válido
            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                // Si la entrada no es válida, informa al usuario y vuelve a mostrar el menú
                Console.WriteLine("Entrada inválida.");
                Console.ReadKey();
                continue;
            }
            // Ejecuta la acción correspondiente según la opción seleccionada
            switch (opcion)
            {
                case 1:
                    Vehiculo v = new Vehiculo();
                    Console.Write("Placa: "); v.Placa = Console.ReadLine();
                    Console.Write("Marca: "); v.Marca = Console.ReadLine();
                    Console.Write("Modelo: "); v.Modelo = Console.ReadLine();

                    Console.Write("Año: ");
                    // Convierte la entrada del usuario a un entero para el año
                    if (!int.TryParse(Console.ReadLine(), out v.Anio))
                    {
                        // Si la entrada no es un número válido, informa al usuario y sale del caso
                        Console.WriteLine("Año inválido.");
                        break;
                    }
                    // Convierte la entrada del usuario a un número decimal para el precio
                    Console.Write("Precio: ");
                    // Verifica si la entrada es un número decimal válido
                    if (!double.TryParse(Console.ReadLine(), out v.Precio))
                    {
                        // Si la entrada no es un número válido, informa al usuario y sale del caso
                        Console.WriteLine("Precio inválido.");
                        break;
                    }
                    // Agrega el vehículo a la lista
                    lista.Agregar(v);
                    Console.WriteLine("Vehículo agregado.");
                    break;

                case 2:
                    // Busca un vehículo por su placa
                    Console.Write("Ingrese placa: ");
                    string placaBuscar = Console.ReadLine();
                    // Llama al método BuscarPorPlaca de la lista para encontrar el vehículo
                    var encontrado = lista.BuscarPorPlaca(placaBuscar);
                    // Si se encuentra el vehículo, muestra sus datos; si no, informa al usuario
                    if (encontrado != null)
                    {
                        // Muestra los datos del vehículo encontrado
                        Console.WriteLine("\nVehículo encontrado:");
                        Console.WriteLine($"Placa: {encontrado.Placa}, Marca: {encontrado.Marca}, Modelo: {encontrado.Modelo}, Año: {encontrado.Anio}, Precio: ${encontrado.Precio}");
                    }
                    // Si no se encuentra el vehículo, informa al usuario
                    else
                        Console.WriteLine("Vehículo no encontrado.");
                    break;

                case 3:
                    // Busca vehículos por año
                    Console.Write("Ingrese el año: ");
                    // Convierte la entrada del usuario a un entero para el año
                    if (int.TryParse(Console.ReadLine(), out int anio))
                    {
                        // Llama al método VerPorAnio de la lista para mostrar los vehículos del año                    
                        lista.VerPorAnio(anio);
                    }
                    else
                        // Si la entrada no es un número válido, informa al usuario
                        Console.WriteLine("Año inválido.");
                    break;

                case 4:
                    // Muestra todos los vehículos registrados en la lista
                    lista.VerTodos();
                    break;

                case 5:
                    // Elimina un vehículo por su placa
                    Console.Write("Ingrese placa a eliminar: ");
                    string placa = Console.ReadLine();
                    // Llama al método Eliminar de la lista para eliminar el vehículo
                    if (lista.Eliminar(placa))
                        Console.WriteLine("Vehículo eliminado.");
                    // Si no se encuentra el vehículo, informa al usuario
                    else
                        Console.WriteLine("Vehículo no encontrado.");
                    break;

                case 6:
                    break;

                default:
                    // Si la opción no es válida, informa al usuario
                    Console.WriteLine("Opción inválida.");
                    break;
            }
            // Si la opción no es salir, espera a que el usuario presione una tecla antes de continuar
            if (opcion != 6)
            {
                // Informa al usuario que la acción se ha completado y espera a que presione una tecla
                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadKey();
            }
        // Repite el bucle hasta que el usuario seleccione la opción de salir
        } while (opcion != 6);
    }
}
