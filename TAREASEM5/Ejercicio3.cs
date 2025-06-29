
/*Escribir un programa que almacene el abecedario en una lista, 
elimine de la lista las letras que ocupen posiciones múltiplos de 3, 
y muestre por pantalla la lista resultante.*/


using System;
using System.Collections.Generic;

class Ejercicio3
{
    public static void Ejecutar()
    {
        // Creamos una lista para almacenar el abecedario
        List<char> abecedario = new List<char>();
        // Llenamos la lista con las letras del abecedario de la A a la Z
        for (char letra = 'A'; letra <= 'Z'; letra++)
        {
            // Añadimos cada letra a la lista
            abecedario.Add(letra);
        }
        // Mostramos el abecedario original
        for (int i = abecedario.Count - 1; i >= 0; i--)
        {
            // Mostramos las letras del abecedario en orden inverso
            if ((i + 1) % 3 == 0)
                abecedario.RemoveAt(i);
        }
        // Mostramos el abecedario después de eliminar las letras en posiciones múltiplos de 3
        Console.WriteLine("Abecedario sin letras en posiciones múltiplos de 3:");
        // Usamos string.Join para unir los elementos de la lista con un espacio
        Console.WriteLine(string.Join(" ", abecedario));
    }
}
