/* Escribir un programa que almacene las asignaturas de un curso (por ejemplo Matemáticas, 
Física, Química, Historia y Lengua) en una lista, pregunte al usuario la nota que ha sacado 
en cada asignatura, y después las muestre por pantalla con el mensaje En <asignatura> has 
sacado <nota> donde <asignatura> es cada una des las asignaturas de la lista y <nota> 
cada una de las correspondientes notas introducidas por el usuario.*/

using System;
using System.Collections.Generic;

class Ejercicio5
{
    public static void Ejecutar()
    {
        Console.WriteLine("Bienvenido al programa de notas del curso.");
        // Definimos las asignaturas y una lista para las notas
        List<string> asignaturas = new List<string> { "Matemáticas", "Física", "Química", "Historia", "Lengua" };
        List<float> notas = new List<float>();
        // Recorremos la lista de asignaturas y solicitamos la nota para cada una
        foreach (string asignatura in asignaturas)
        {
            Console.Write($"Introduce la nota de {asignatura}: ");
            float nota = float.Parse(Console.ReadLine());
            // Validamos que la nota esté entre 0 y 10
            while (nota < 0 || nota > 10)
            {
                Console.WriteLine("Nota inválida. Debe estar entre 0 y 10.");
                Console.Write($"Introduce la nota de {asignatura} nuevamente: ");
                nota = float.Parse(Console.ReadLine());
            }
            // Añadimos la nota a la lista de notas
            notas.Add(nota);
        }
        // Mostramos los resultados
        Console.WriteLine("\nResultados:");
        // Recorremos las asignaturas y sus correspondientes notas
        for (int i = 0; i < asignaturas.Count; i++)
        {
            Console.WriteLine($"En {asignaturas[i]} has sacado {notas[i]}");
        }
        // Calculamos el promedio de las notas
        float promedio = 0;
        foreach (float nota in notas)
        {
            promedio += nota;
        }
        // Dividimos la suma de las notas por la cantidad de asignaturas
        promedio /= notas.Count;
        // Mostramos el promedio
        Console.WriteLine($"El promedio de las notas es: {promedio}");
    }
}
