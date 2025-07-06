using System;

// Nodo básico para enteros
class Nodo
{
    // Propiedades del nodo
    public int Valor;
    // Referencia al siguiente nodo
    public Nodo Siguiente;
    // Constructor que inicializa el nodo con un valor y establece Siguiente como null
    public Nodo(int valor)
    {
        // Asigna el valor al nodo y establece Siguiente como null
        Valor = valor;
        Siguiente = null;
    }
}

// Lista enlazada para almacenar números enteros
class ListaEnlazada
{
    // Referencia al primer nodo de la lista
    public Nodo Head;
    // Constructor que inicializa la lista vacía
    public ListaEnlazada()
    {
        // Inicializa la lista enlazada con Head como null
        Head = null;
    }
    // Métodos para agregar nodos a la lista
    public void AgregarFinal(int valor)
    {
        // Crea un nuevo nodo con el valor proporcionado
        Nodo nuevo = new Nodo(valor);
        // Si la lista está vacía, el nuevo nodo se convierte en Head
        if (Head == null)
        {
            // Asigna el nuevo nodo como el primer nodo de la lista
            Head = nuevo;
        }
        // Si la lista no está vacía, recorre hasta el final y agrega el nuevo nodo
        else
        {
            // Recorre la lista hasta el último nodo
            Nodo actual = Head;
            // Mientras el nodo actual tenga un siguiente, avanza al siguiente nodo
            while (actual.Siguiente != null)
            {
                // Avanza al siguiente nodo
                actual = actual.Siguiente;
            }
            // Asigna el nuevo nodo al final de la lista
            actual.Siguiente = nuevo;
        }
    }
    // Método para agregar un nodo al inicio de la lista
    public void AgregarInicio(int valor)
    {
        // Crea un nuevo nodo con el valor proporcionado
        Nodo nuevo = new Nodo(valor);
        // Establece el siguiente del nuevo nodo como el actual Head
        nuevo.Siguiente = Head;
        Head = nuevo;
    }
    // Método para contar los nodos en la lista
    public int Contar()
    {
        // Inicializa un contador y un nodo actual para recorrer la lista
        int contador = 0;
        Nodo actual = Head;
        // Recorre la lista hasta que no haya más nodos
        while (actual != null)
        {
            contador++;
            actual = actual.Siguiente;
        }
        // Devuelve el número total de nodos en la lista
        return contador;
    }
    // Método para mostrar los valores de la lista
    public void Mostrar()
    {
        // Si la lista está vacía, informa al usuario
        Nodo actual = Head;
        // Si la lista está vacía, informa al usuario
        while (actual != null)
        {
            // Imprime el valor del nodo actual
            Console.Write(actual.Valor + " ");
            actual = actual.Siguiente;
        }
        // Imprime una nueva línea al final de la lista
        Console.WriteLine();
    }
}
// Clase que contiene el método principal para ejecutar el ejercicio
class Ejercicio1
{
    // Método que ejecuta el ejercicio
    public static void Ejecutar()
    {
        // Crea dos listas enlazadas: una para números primos y otra para números Armstrong
        ListaEnlazada listaPrimos = new ListaEnlazada();
        ListaEnlazada listaArmstrong = new ListaEnlazada();
        // Variable para almacenar la opción del usuario
        string opcion;
        do
        {
            // Limpia la consola y solicita al usuario que ingrese un número entero
            Console.Clear();
            Console.Write("Ingrese un número entero: ");
            // Convierte la entrada del usuario a un entero
            if (int.TryParse(Console.ReadLine(), out int num))
            {
                // Verifica si el número es primo y Armstrong
                if (EsPrimo(num))
                {
                    // Si es primo, lo agrega al final de la lista de primos
                    listaPrimos.AgregarFinal(num);
                    Console.WriteLine("→ Número primo agregado al final.");
                }
                // Si no es primo, informa al usuario
                else
                {
                    Console.WriteLine("El número ingresado no es primo.");
                }
                // Verifica si el número es Armstrong
                if (EsArmstrong(num))
                {
                    // Si es Armstrong, lo agrega al inicio de la lista de Armstrong
                    listaArmstrong.AgregarInicio(num);
                    Console.WriteLine("→ Número Armstrong agregado al inicio.");
                }
            }
            // Si la entrada no es un número válido, informa al usuario
            else
            {
                Console.WriteLine("Entrada inválida.");
            }
            // Pregunta al usuario si desea ingresar otro número
            Console.Write("¿Desea ingresar otro número? (s/n): ");
            opcion = Console.ReadLine().ToLower();
        // Repite el bucle mientras la opción sea 's'
        } while (opcion == "s");
        // Muestra la cantidad de números primos y Armstrong en las listas
        int countPrimos = listaPrimos.Contar();
        int countArmstrong = listaArmstrong.Contar();
        // Informa al usuario sobre la cantidad de números primos y Armstrong
        Console.WriteLine($"\nCantidad de números primos: {countPrimos}");
        Console.WriteLine($"Cantidad de números Armstrong: {countArmstrong}");
        // Compara las cantidades
        if (countPrimos > countArmstrong)
            Console.WriteLine("→ La lista de primos tiene más elementos.");
        // Si la lista de primos tiene más elementos, informa al usuario
        else if (countArmstrong > countPrimos)
            Console.WriteLine("→ La lista de Armstrong tiene más elementos.");
        // Si ambas listas tienen la misma cantidad, informa al usuario    
        else
            Console.WriteLine("→ Ambas listas tienen la misma cantidad.");
        // Muestra los números primos y Armstrong en sus respectivas listas
        Console.WriteLine("\nLista de primos:");
        listaPrimos.Mostrar();
        // Muestra los números primos en la lista
        Console.WriteLine("Lista de Armstrong:");
        listaArmstrong.Mostrar();
    }
    // Métodos para verificar si un número es primo o Armstrong
    static bool EsPrimo(int n)
    {
        // Verifica si el número es menor o igual a 1, en cuyo caso no es primo
        if (n <= 1) return false;
        // Verifica si el número es 2, en cuyo caso es primo
        for (int i = 2; i <= Math.Sqrt(n); i++)
            if (n % i == 0) return false;
        return true;
    }
    // Método para verificar si un número es Armstrong
    static bool EsArmstrong(int n)
    {
        // Verifica si el número es negativo, en cuyo caso no es Armstrong
        int original = n, suma = 0, digitos = n.ToString().Length;
        // Convierte el número a su representación de cadena para contar los dígitos
        // Calcula la suma de las potencias de sus dígitos
        // Repite el proceso mientras haya dígitos en el número
        while (n > 0)
        {
            int d = n % 10;
            suma += (int)Math.Pow(d, digitos);
            n /= 10;
        }
        return suma == original;
    }
}
