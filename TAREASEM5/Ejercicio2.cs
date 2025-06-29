/*Escribir un programa que almacene en una lista los siguientes precios,
50, 75, 46, 22, 80, 65, 8, y muestre por pantalla el menor y el mayor de
los precios.*/

using System;
using System.Collections.Generic;

class Ejercicio2
{
    public static void Ejecutar()
    {
        // Definimos una lista de precios
        List<int> precios = new List<int> { 50, 75, 46, 22, 80, 65, 8 };
        // Inicializamos las variables menor y mayor con valores extremos
        int menor = int.MaxValue;
        int mayor = int.MinValue;
        // Recorremos la lista de precios para encontrar el menor y el mayor
        foreach (int precio in precios)
        {
            // Actualizamos menor y mayor si encontramos un precio más bajo o más alto
            if (precio < menor) menor = precio;
            if (precio > mayor) mayor = precio;
        }
        Console.WriteLine("Lista de precios:");
        // Mostramos los precios en la lista
        foreach (int precio in precios)
        {
            Console.Write($"{precio}, ");
        }   
        // Mostramos el menor y el mayor precio encontrados
        Console.WriteLine();
        Console.WriteLine($"El precio menor es: {menor}");
        Console.WriteLine($"El precio mayor es: {mayor}");
    }
}
