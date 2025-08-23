using System;
using System.Collections.Generic;

namespace VacunacionCOVID
{
    // Clase Ciudadano
    public class Ciudadano
    {
        // Propiedades
        public int Id { get; set; }
        // Nombre del ciudadano
        public string Nombre { get; set; }
        // Constructor
        public Ciudadano(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }
        // Método para mostrar información del ciudadano
        public override string ToString() => $"{Nombre}";
    }

    // Clase CampaniaVacunacion
    public class CampaniaVacunacion
    {
        // Propiedades
        private HashSet<string> conjuntoUniverso;   // Conjunto Universal
        private HashSet<string> conjuntoPfizer;   // Vacunados Pfizer
        private HashSet<string> conjuntoAstraZeneca;   // Vacunados AstraZeneca
        // Constructor
        public CampaniaVacunacion()
        {
            // Inicializamos los conjuntos
            conjuntoUniverso = new HashSet<string>();
            conjuntoPfizer = new HashSet<string>();
            conjuntoAstraZeneca = new HashSet<string>();
            // Generamos los ciudadanos vacunados
            GenerarCiudadanos();
            conjuntoPfizer = GenerarVacunados();
            conjuntoAstraZeneca = GenerarVacunados();
        }

        // Generamos 500 ciudadanos
        private void GenerarCiudadanos()
        {
            // Creamos los 500 ciudadanos
            for (int i = 1; i <= 500; i++)
            {
                // Creamos un nuevo ciudadano
                conjuntoUniverso.Add("Ciudadano " + i);
            }
        }

        // Generamos vacunados de forma aleatoria (75)
        private HashSet<string> GenerarVacunados()
        {
            // Creamos un conjunto para los vacunados
            HashSet<string> vacunados = new HashSet<string>();
            // Generamos números aleatorios
            Random random = new Random();
            // Seleccionamos 75 ciudadanos aleatoriamente
            while (vacunados.Count < 75)
            {
                // Seleccionamos un ciudadano aleatorio
                int numero = random.Next(1, 501);
                // Agregamos al conjunto de vacunados
                vacunados.Add("Ciudadano " + numero);
            }
            // Devolvemos el conjunto de vacunados
            return vacunados;
        }

        // Métodos de teoría de conjuntos
        public HashSet<string> GetVacunados()
        {
            // Unimos los conjuntos de vacunados
            var vacunados = new HashSet<string>(conjuntoPfizer);
            // Agregamos los vacunados de AstraZeneca
            vacunados.UnionWith(conjuntoAstraZeneca);
            // Devolvemos el conjunto de vacunados
            return vacunados;
        }
        // Ciudadanos no vacunados
        public HashSet<string> GetNoVacunados()
        {
            // Obtenemos el conjunto de no vacunados
            var noVacunados = new HashSet<string>(conjuntoUniverso);
            // Restamos los vacunados
            noVacunados.ExceptWith(GetVacunados());
            // Devolvemos el conjunto de no vacunados
            return noVacunados;
        }
        // Ciudadanos con ambas dosis
        public HashSet<string> GetAmbasDosis()
        {
            // Obtenemos el conjunto de ambas dosis
            var ambas = new HashSet<string>(conjuntoPfizer);
            // Intersecamos con el conjunto de AstraZeneca
            ambas.IntersectWith(conjuntoAstraZeneca);
            // Devolvemos el conjunto de ambas dosis
            return ambas;
        }
        // Ciudadanos solo con Pfizer
        public HashSet<string> GetSoloPfizer()
        {
            // Obtenemos el conjunto de solo Pfizer
            var soloPfizer = new HashSet<string>(conjuntoPfizer);
            // Restamos los vacunados de AstraZeneca
            soloPfizer.ExceptWith(conjuntoAstraZeneca);
            // Devolvemos el conjunto de solo Pfizer
            return soloPfizer;
        }
        // Ciudadanos solo con AstraZeneca
        public HashSet<string> GetSoloAstra()
        {
            // Obtenemos el conjunto de solo AstraZeneca
            var soloAstra = new HashSet<string>(conjuntoAstraZeneca);
            // Restamos los vacunados de Pfizer
            soloAstra.ExceptWith(conjuntoPfizer);
            // Devolvemos el conjunto de solo AstraZeneca
            return soloAstra;
        }

        // Mostramos los resultados
        public void MostrarResultados()
        {
            Console.WriteLine("\n=== Campaña de Vacunación COVID-19 ===");
            Console.WriteLine("Total ciudadanos (ConjuntoUniverso): " + conjuntoUniverso.Count);
            Console.WriteLine("Vacunados con Pfizer (ConjuntoPfizer): " + conjuntoPfizer.Count);
            Console.WriteLine("Vacunados con AstraZeneca (ConjuntoAstraZeneca): " + conjuntoAstraZeneca.Count);

            Console.WriteLine("\n--- RESULTADOS ---");
            Console.WriteLine("Vacunados (ConjuntoPfizer ∪ ConjuntoAstraZeneca): " + GetVacunados().Count);
            Console.WriteLine("No vacunados (ConjuntoUniverso - (ConjuntoPfizer ∪ ConjuntoAstraZeneca)): " + GetNoVacunados().Count);
            Console.WriteLine("Ambas dosis (ConjuntoPfizer ∩ ConjuntoAstraZeneca): " + GetAmbasDosis().Count);
            Console.WriteLine("Solo Pfizer (ConjuntoPfizer - ConjuntoAstraZeneca): " + GetSoloPfizer().Count);
            Console.WriteLine("Solo AstraZeneca (ConjuntoAstraZeneca - ConjuntoPfizer): " + GetSoloAstra().Count);
        }
    }

    // Programa principal
    class Program
    {
        static void Main()
        {
            // Mostramos la lista de personas vacunadas y no vacunadas
            Console.WriteLine("Lista de Personas Vacunadas y no Vacunadas");
            // Creamos la campaña de vacunación
            CampaniaVacunacion campania = new CampaniaVacunacion();
            // Mostramos los resultados
            campania.MostrarResultados();

            Console.ReadKey();
        }
    }
}

