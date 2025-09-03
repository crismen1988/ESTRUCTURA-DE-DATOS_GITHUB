using System;

// Representa un libro en la biblioteca.
public class Libro // Clase que representa un libro
{
    public string ID { get; private set; } // Identificador único del libro
    public string Titulo { get; private set; } // Título del libro
    public string Autor { get; private set; } // Autor del libro
    public int AñoPublicacion { get; private set; } // Año de publicación del libro

    // Constructor para crear una nueva instancia de Libro.
    public Libro(string id, string titulo, string autor, int añoPublicacion)
    {
        ID = id; // Identificador único
        Titulo = titulo; // Título del libro
        Autor = autor; // Autor del libro
        AñoPublicacion = añoPublicacion; // Año de publicación
    }

    // Sobrescribe el método ToString() para proporcionar una representación legible del libro.
    public override string ToString()
    {
        // Muestra la información del libro
        return $"ID: {ID}, Título: \"{Titulo}\", Autor: {Autor}, Año: {AñoPublicacion}";
    }
}