/*Escribir un programa que almacene las matrices
 a=(1 2 3; 4 5 6) y b=(-1 0; 0 1; 1 1)
 en una lista y muestre por pantalla su producto.
Nota: Para representar matrices mediante listas usar
listas anidadas, representando cada vector fila en una lista.*/

using System;
using System.Collections.Generic;

class Ejercicio1
{
    public static void Ejecutar()
    {
        // Definimos las matrices A y B como listas anidadas
        List<List<int>> A = new List<List<int>> {
            new List<int> {1, 2, 3},
            new List<int> {4, 5, 6}
        };

        List<List<int>> B = new List<List<int>> {
            new List<int> {-1, 0},
            new List<int> {0, 1},
            new List<int> {1, 1}
        };
        // Mostramos las matrices A y B
        Console.WriteLine("Matriz A:");
        MostrarMatriz(A);
        Console.WriteLine("Matriz B:");
        MostrarMatriz(B);

        List<List<int>> resultado = MultiplicarMatrices(A, B);

        Console.WriteLine("Producto de matrices A * B:");
        MostrarMatriz(resultado);
    }
    // Método para multiplicar dos matrices representadas como listas anidadas
    static List<List<int>> MultiplicarMatrices(List<List<int>> A, List<List<int>> B)
    {
        int filasA = A.Count;
        int columnasA = A[0].Count;
        int columnasB = B[0].Count;

        List<List<int>> resultado = new List<List<int>>();
        // Inicializamos la matriz resultado con ceros
        for (int i = 0; i < filasA; i++)
        {
            List<int> fila = new List<int>();
            // Recorremos las columnas para calcular cada elemento de la fila
            for (int j = 0; j < columnasB; j++)
            {
                int suma = 0;
                // Calculamos el producto escalar de la fila de A y la columna de B
                for (int k = 0; k < columnasA; k++)
                {
                    suma += A[i][k] * B[k][j];
                }
                // Añadimos el resultado de la suma a la fila
                fila.Add(suma);
            }
            // Añadimos la fila completa al resultado
            resultado.Add(fila);
        }
        // Devolvemos la matriz resultado
        return resultado;
    }

    static void MostrarMatriz(List<List<int>> matriz)
    {
        // Recorremos cada fila de la matriz y mostramos sus elementos
        foreach (var fila in matriz)
        {
            // Usamos string.Join para unir los elementos de la fila con un espacio
            // Esto permite mostrar la fila de forma legible
            Console.WriteLine(string.Join(" ", fila));
        }
    }
}

