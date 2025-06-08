using System;

namespace FigurasGeometricas
{
    // Clase para representar un Círculo
    class Circulo
    {
        private double radio;

        public Circulo(double radio)
        {
            this.radio = radio;
        }

        public double CalcularArea()
        {
            return Math.PI * radio * radio;
        }

        public double CalcularPerimetro()
        {
            return 2 * Math.PI * radio;
        }
    }

    // Clase para representar un Rectángulo
    class Rectangulo
    {
        private double ancho;
        private double alto;

        public Rectangulo(double ancho, double alto)
        {
            this.ancho = ancho;
            this.alto = alto;
        }

        public double CalcularArea()
        {
            return ancho * alto;
        }

        public double CalcularPerimetro()
        {
            return 2 * (ancho + alto);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Pedir al usuario el radio del círculo
            Console.Write("Ingresa el radio del círculo: ");
            double radio = Convert.ToDouble(Console.ReadLine());

            Circulo miCirculo = new Circulo(radio);
            Console.WriteLine("\nCírculo:");
            Console.WriteLine("Área: " + miCirculo.CalcularArea());
            Console.WriteLine("Perímetro: " + miCirculo.CalcularPerimetro());

            Console.WriteLine();

            // Pedir al usuario el ancho y alto del rectángulo
            Console.Write("Ingresa el ancho del rectángulo: ");
            double ancho = Convert.ToDouble(Console.ReadLine());

            Console.Write("Ingresa el alto del rectángulo: ");
            double alto = Convert.ToDouble(Console.ReadLine());

            Rectangulo miRectangulo = new Rectangulo(ancho, alto);
            Console.WriteLine("\nRectángulo:");
            Console.WriteLine("Área: " + miRectangulo.CalcularArea());
            Console.WriteLine("Perímetro: " + miRectangulo.CalcularPerimetro());
        }
    }
}
