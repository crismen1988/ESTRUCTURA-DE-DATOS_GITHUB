// Clase Nodo que representa un nodo en un árbol binario de búsqueda.
namespace CatalogoRevistas
{
    public class Nodo
    {
        // Revista almacenada en el nodo.
        public Revista Revista { get; set; }
        public Nodo Izquierdo { get; set; }
        public Nodo Derecho { get; set; }
        // Constructor que inicializa el nodo con una revista.
        public Nodo(Revista revista)
        {
            // Inicializa el nodo con la revista proporcionada.
            Revista = revista;
            // Inicializa los nodos izquierdo y derecho como nulos.
            Izquierdo = null;
            Derecho = null;
        }
    }
}
