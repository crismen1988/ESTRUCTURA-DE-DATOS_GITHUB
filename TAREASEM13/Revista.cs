// Clase Revista que representa una revista con un título.
namespace CatalogoRevistas
{
    public class Revista
    {
        // Título de la revista.
        public string Titulo { get; set; }

        public Revista(string titulo)
        {
            // Inicializa el título de la revista.
            Titulo = titulo;
        }
    }
}
