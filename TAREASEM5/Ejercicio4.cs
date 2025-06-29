/*Escribir un programa que almacene en una lista los números del 1 al 10 
y los muestre por pantalla en orden inverso separados por comas.*/

using System;
using System.Collections.Generic;

class Ejercicio4
{
    public static void Ejecutar()
    {
        // Creamos una lista para almacenar los números del 1 al 10
        List<int> numeros = new List<int>();
        // Llenamos la lista con los números del 1 al 10
        // Usamos un bucle for para añadir los números a la lista
        for (int i = 1; i <= 10; i++)
        {
            // Añadimos cada número a la lista
            numeros.Add(i);
        }
        // Mostramos los números en orden inverso
        numeros.Reverse();
        // Usamos string.Join para unir los elementos de la lista con una coma
        // y mostramos el resultado en la consola
        Console.WriteLine("Números del 1 al 10 en orden inverso:");
        Console.WriteLine(string.Join(", ", numeros));
    }
}
