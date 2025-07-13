using System;
using System.Collections.Generic;

namespace VerificadorDeSimbolosPOO
{
    // Definición de la clase VerificadorDeSimbolos
    class VerificadorDeSimbolos
    {
        // Propiedades de la clase VerificadorDeSimbolos
        private string formula;
        // Constructor de la clase VerificadorDeSimbolos
        public VerificadorDeSimbolos(string formula)
        {
            this.formula = formula;
        }
        // Método de la clase VerificadorDeSimbolos
        public bool EstaBalanceada()
        {
            // Se crea una pila para almacenar los símbolos de la fórmula
            Stack<char> pilaSimbolos = new Stack<char>();
            // Se recorre la fórmula
            foreach (char c in formula)
            {
                // Se verifica si el símbolo es un símbolo de apertura
                if (c == '(' || c == '[' || c == '{')
                {
                    // Se agrega el símbolo a la pila
                    pilaSimbolos.Push(c);
                }
                // Se verifica si el símbolo es un símbolo de cierre
                else if (c == ')' || c == ']' || c == '}')
                {
                    // Se verifica si la pila está vacía
                    if (pilaSimbolos.Count == 0)
                    {
                        // Si la pila no está vacía, la fórmula no está balanceada
                        Console.WriteLine("Fórmula NO balanceada");
                        return false;
                    }
                    // Se obtiene el símbolo de la pila    
                    char simbolo = pilaSimbolos.Pop();
                    // Se verifica si el símbolo de la pila es el símbolo de apertura correspondiente
                    if ((c == ')' && simbolo != '(') ||
                        (c == ']' && simbolo != '[') ||
                        (c == '}' && simbolo != '{'))
                    {
                        // Si no es el símbolo de apertura correspondiente, la fórmula no está balanceada
                        Console.WriteLine("Fórmula NO balanceada");
                        return false;
                    }
                }
            }
            // Se verifica si la pila está vacía
            if (pilaSimbolos.Count == 0)
            {
                // Si la pila está vacía, la fórmula está balanceada
                Console.WriteLine("Fórmula balanceada.");
                return true;
            }
            // Si la pila no está vacía, la fórmula no está balanceada
            else
            {
                Console.WriteLine("Fórmula NO balanceada");
                return false;
            }
        }
    }
}