using System;
using System.Collections.Generic;

namespace TorresDeHanoiConPOO
{
    // Definición de la clase Disco
    class Disco
    {
        // Propiedades de la clase Disco
        public int Tamaño { get; set; }
        // Constructor de la clase Disco
        public Disco(int tamaño)
        {
            Tamaño = tamaño;
        }
        // Convertir a string para imprimir el objeto Disco
        public override string ToString()
        {
            // devuelve un string con el tamaño del disco
            return $"Disco({Tamaño})";
        }
    }
    // Definición de la clase TorreHanoi
    class TorreHanoi
    {
        // Propiedades de la clase TorreHanoi
        private Stack<Disco> torreA;
        private Stack<Disco> torreB;
        private Stack<Disco> torreC;
        private int totalDiscos;
        // Constructor de la clase TorreHanoi
        public TorreHanoi(int n)
        {
            // inicializa las torres y el número de discos
            totalDiscos = n;
            torreA = new Stack<Disco>();
            torreB = new Stack<Disco>();
            torreC = new Stack<Disco>();
            // llena la torre A con los discos
            for (int i = n; i >= 1; i--)
            {
                // llena la torre A con los discos
                torreA.Push(new Disco(i));
            }
        }
        // Métodos de la clase TorreHanoi
        public void Resolver()
        {
            // muestra el estado inicial de las torres
            Console.WriteLine($"\nResolviendo Torres de Hanoi con {totalDiscos} discos:\n");
            // imprime el estado inicial de las torres
            MoverDiscos(totalDiscos, torreA, torreC, torreB, "A", "C", "B");
        }
        // Método para mover los discos
        private void MoverDiscos(int n, Stack<Disco> origen, Stack<Disco> destino, Stack<Disco> auxiliar,
                                 string nombreOrigen, string nombreDestino, string nombreAuxiliar)
        {
            // Si n=1 entonces solo se mueve un disco
            if (n == 1)
            {
                // se mueve el disco de origen a destino
                Disco disco = origen.Pop();
                // se imprime el movimiento
                destino.Push(disco);
                // se imprime el movimiento
                MostrarMovimiento(disco, nombreOrigen, nombreDestino);
            }
            // Si n>1 entonces se mueve n-1 discos de origen a auxiliar
            else
            {
                // se mueve n-1 discos de origen a auxiliar
                MoverDiscos(n - 1, origen, auxiliar, destino, nombreOrigen, nombreAuxiliar, nombreDestino);
                MoverDiscos(1, origen, destino, auxiliar, nombreOrigen, nombreDestino, nombreAuxiliar);
                MoverDiscos(n - 1, auxiliar, destino, origen, nombreAuxiliar, nombreDestino, nombreOrigen);
            }
        }
        // Método para imprimir el movimiento
        private void MostrarMovimiento(Disco disco, string desde, string hacia)
        {
            // imprime el movimiento
            Console.WriteLine($"Mover {disco} de Torre {desde} a Torre {hacia}");
        }
        // Método para imprimir el estado final de las torres
        public void MostrarEstadoFinal()
        {
            // imprime el estado final de las torres
            Console.WriteLine("\nEstado final de las torres:");
            ImprimirTorre(torreA, "A");
            ImprimirTorre(torreB, "B");
            ImprimirTorre(torreC, "C");
        }
        // Método para imprimir una torre
        private void ImprimirTorre(Stack<Disco> torre, string nombre)
        {
            // imprime la torre
            Console.Write($"Torre {nombre}: ");
            // si la torre está vacía se imprime "(vacía)"
            if (torre.Count == 0)
            {
                Console.WriteLine("(vacía)");
                return;
            }
            // si la torre no está vacía se imprime los discos
            Disco[] discos = torre.ToArray();
            for (int i = discos.Length - 1; i >= 0; i--)
            {
                // imprime los discos
                Console.Write($"{discos[i]} ");
            }
            // imprime una línea en blanco
            Console.WriteLine();
        }
    }
}