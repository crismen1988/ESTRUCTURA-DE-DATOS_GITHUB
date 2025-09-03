using System;
using System.Collections.Generic;
using System.Linq; // Necesario para métodos como ToList()
using System.Text.RegularExpressions; // Para validar el formato del ID

// Gestiona la colección de libros en la biblioteca.
public class Biblioteca // Clase que representa la biblioteca
{
    // Mapa: Asocia un ID de libro único con su objeto Libro.
    // Permite búsquedas rápidas por ID y asegura la unicidad de IDs.
    private Dictionary<string, Libro> librosPorId;

    // Conjunto: Almacena todos los títulos de libros registrados para asegurar su unicidad.
    // StringComparer.OrdinalIgnoreCase hace que la comparación de títulos no distinga entre mayúsculas y minúsculas.
    private HashSet<string> titulosDeLibros;

    // Constructor para inicializar una nueva instancia de Biblioteca.
    public Biblioteca()
    {
        // Inicializa las colecciones
        librosPorId = new Dictionary<string, Libro>();
        titulosDeLibros = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
    }

    // Valida si un ID cumple con el formato requerido (solo letras y números).
    private bool EsIdValido(string id) // Método privado para validar el ID
    {
        // Verifica que no sea nulo/vacío y que solo contenga letras (a-z, A-Z) y números (0-9).
        return !string.IsNullOrWhiteSpace(id) && Regex.IsMatch(id, @"^[a-zA-Z0-9]+$");
    }

    // Intenta agregar un libro a la biblioteca.
    public bool AgregarLibro(Libro libro, out string mensaje) // Método público para agregar un libro
    {
        if (libro == null) // Verifica si el libro es nulo
        {
            mensaje = "Error: El libro no puede ser nulo.";
            return false;
        }

        // Valida formato del ID
        if (!EsIdValido(libro.ID))
        {
            mensaje = "Error: El ID del libro solo puede contener letras y números, sin caracteres especiales ni espacios.";
            return false;
        }

        // Controla IDs duplicados (uso del mapa librosPorId)
        if (librosPorId.ContainsKey(libro.ID))
        {
            mensaje = $"Error: Ya existe un libro con el ID '{libro.ID}'.";
            return false;
        }

        // Controla títulos duplicados (uso del conjunto titulosDeLibros)
        if (titulosDeLibros.Contains(libro.Titulo))
        {
            mensaje = $"Error: Ya existe un libro con el título '{libro.Titulo}'.";
            return false;
        }

        // Si todas las validaciones pasan, se agrega el libro al mapa y su título al conjunto.
        librosPorId.Add(libro.ID, libro);
        titulosDeLibros.Add(libro.Titulo);
        mensaje = $"Libro \"{libro.Titulo}\" con ID '{libro.ID}' registrado exitosamente.";
        return true;
    }

    // Consulta un libro por su ID.
    public Libro ConsultarLibroPorId(string id) // Método público para consultar un libro por su ID
    {
        if (string.IsNullOrWhiteSpace(id)) // Verifica si el ID es nulo o vacío
        {
            return null;
        }

        // TryGetValue es una forma eficiente de buscar en un diccionario 
        // sin lanzar una excepción si la clave no existe.
        if (librosPorId.TryGetValue(id, out Libro libroEncontrado))
        {
            return libroEncontrado;
        }
        return null; // Libro no encontrado
    }

    // Elimina un libro de la biblioteca por su ID.
    public bool EliminarLibroPorId(string id, out string mensaje)
    {
        if (string.IsNullOrWhiteSpace(id)) // Verifica si el ID es nulo o vacío
        {
            mensaje = "Error: El ID no puede estar vacío.";
            return false;
        }

        // Verificar si el libro existe antes de intentar eliminarlo.
        if (librosPorId.TryGetValue(id, out Libro libroAEliminar))
        {
            librosPorId.Remove(id);
            titulosDeLibros.Remove(libroAEliminar.Titulo); // Remueve también el título del conjunto.
            mensaje = $"Libro con ID '{id}' y título \"{libroAEliminar.Titulo}\" eliminado exitosamente.";
            return true;
        }
        else
        {
            // Si no se encontró el libro, se informa del error.
            mensaje = $"Error: No se encontró ningún libro con el ID '{id}'.";
            return false;
        }
    }

    // Obtiene una lista de todos los libros actualmente en la biblioteca.
    public IEnumerable<Libro> ObtenerTodosLosLibros() // Método público para obtener todos los libros
    {
        // Retorna los valores (objetos Libro) del diccionario como una lista.
        return librosPorId.Values.ToList();
    }
}