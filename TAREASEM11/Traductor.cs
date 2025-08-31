using System;
using System.Collections.Generic;
using System.Linq;

namespace TraductorBasico
{
    public class Traductor
    {
        // Diccionario para almacenar las traducciones
        private Dictionary<string, string> diccionario;
        //Constructor
        public Traductor()
        {
            // Inicialización del diccionario
            diccionario = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            // Palabras iniciales 
            AgregarPalabra("time", "tiempo");
            AgregarPalabra("person", "persona");
            AgregarPalabra("year", "año");
            AgregarPalabra("way", "camino");
            AgregarPalabra("day", "día");
            AgregarPalabra("thing", "cosa");
            AgregarPalabra("man", "hombre");
            AgregarPalabra("world", "mundo");
            AgregarPalabra("life", "vida");
            AgregarPalabra("hand", "mano");
            AgregarPalabra("part", "parte");
            AgregarPalabra("child", "niño");
            AgregarPalabra("eye", "ojo");
            AgregarPalabra("woman", "mujer");
            AgregarPalabra("place", "lugar");
            AgregarPalabra("work", "trabajo");
            AgregarPalabra("week", "semana");
            AgregarPalabra("case", "caso");
            AgregarPalabra("point", "punto");
            AgregarPalabra("government", "gobierno");
            AgregarPalabra("company", "empresa");
        }

        // Traducción parcial de frases
        public string TraducirFrase(string frase)
        {
            // Eliminar acentos y caracteres especiales
            string[] palabras = frase.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            // Normalizamos las palabras
            List<string> traducidas = new List<string>();
            // Recorrer las palabras y aplicar limpieza
            foreach (string palabra in palabras)
            {
                // Eliminar acentos y caracteres especiales
                string limpia = new string(palabra.Where(char.IsLetter).ToArray());
                string puntuacion = palabra.Replace(limpia, "");
                // Normalizamos la palabra
                if (diccionario.ContainsKey(limpia.ToLower()))
                {
                    // Si la palabra está en el diccionario, la traducimos
                    traducidas.Add(diccionario[limpia.ToLower()] + puntuacion);
                }
                else
                {
                    // Si la palabra no está en el diccionario, la dejamos tal cual
                    traducidas.Add(palabra);
                }
            }
            // Fin de la depuración
            return string.Join(" ", traducidas);
        }

        // Agregar palabras en ambos sentidos con validación
        public void AgregarPalabra(string ingles, string español)
        {
            // Verificamos que las palabras no estén vacías
            if (string.IsNullOrWhiteSpace(ingles) || string.IsNullOrWhiteSpace(español))
            {
                // Si las palabras están vacías, mostramos un mensaje de error
                Console.WriteLine("Las palabras no pueden estar vacías.");
                return;
            }
            // Normalizamos las palabras
            string eng = ingles.ToLower();
            string esp = español.ToLower();

            // Verificamos si ya existe la relación en inglés → español
            if (diccionario.ContainsKey(eng) && diccionario[eng] == esp)
            {
                // Si ya existe la relación, no hacemos nada
                Console.WriteLine($"La palabra '{ingles}' ya está registrada como '{esp}'.");
                return;
            }

            // Verificamos si ya existe la relación en español → inglés
            if (diccionario.ContainsKey(esp) && diccionario[esp] == eng)
            {
                // Si ya existe la relación, no hacemos nada
                Console.WriteLine($"La palabra '{español}' ya está registrada como '{ingles}'.");
                return;
            }

            // Agregamos en ambas direcciones
            if (!diccionario.ContainsKey(eng))
                diccionario.Add(eng, esp);
            // Agregamos la relación inversa
            if (!diccionario.ContainsKey(esp))
                diccionario.Add(esp, eng);
            // Imprimimos el resultado
            Console.WriteLine($"Palabra '{ingles} ↔ {español}' agregada correctamente.");
        }

    }
}
