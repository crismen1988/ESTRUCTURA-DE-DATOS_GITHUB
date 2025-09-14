using System;
// Clase ArbolRevistas que representa un árbol binario de búsqueda para gestionar revistas.
namespace CatalogoRevistas
{
    public class ArbolRevistas
    {
        // Raíz del árbol.
        private Nodo raiz;
        // Constructor que inicializa el árbol con una raíz nula.
        public ArbolRevistas()
        {
            raiz = null;
        }

        // Inserta la revista en el árbol
        public void Insertar(Revista revista)
        {
            raiz = InsertarRecursivo(raiz, revista);
        }
        // Método recursivo para insertar una revista en el árbol
        private Nodo InsertarRecursivo(Nodo nodo, Revista revista)
        {
            // Si el nodo es nulo, crea un nuevo nodo con la revista
            if (nodo == null)
                return new Nodo(revista);
            // Compara los títulos para decidir si ir a la izquierda o a la derecha
            if (string.Compare(revista.Titulo, nodo.Revista.Titulo, StringComparison.OrdinalIgnoreCase) < 0)
                nodo.Izquierdo = InsertarRecursivo(nodo.Izquierdo, revista);
            // Si el nodo del titulo es mayor, irá a la derecha
            else if (string.Compare(revista.Titulo, nodo.Revista.Titulo, StringComparison.OrdinalIgnoreCase) > 0)
                nodo.Derecho = InsertarRecursivo(nodo.Derecho, revista);

            return nodo;
        }

        // Busca el título en el árbol
        public bool Buscar(string titulo)
        {
            return BuscarRecursivo(raiz, titulo);
        }
        // Método recursivo para buscar una revista por título en el árbol
        private bool BuscarRecursivo(Nodo nodo, string titulo)
        {
            // Si el nodo es nulo, la revista no se encuentra
            if (nodo == null)
                return false;
            // Si el título coincide, la revista se encuentra
            if (string.Equals(titulo, nodo.Revista.Titulo, StringComparison.OrdinalIgnoreCase))
                return true;
            // Compara los títulos para decidir si buscar a la izquierda o a la derecha
            if (string.Compare(titulo, nodo.Revista.Titulo, StringComparison.OrdinalIgnoreCase) < 0)
                return BuscarRecursivo(nodo.Izquierdo, titulo);
            else
                return BuscarRecursivo(nodo.Derecho, titulo);
        }
    }
}
