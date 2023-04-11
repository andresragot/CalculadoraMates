using System;

namespace TrabajoMatesPrueba
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int[,] matriz = new int[3, 3];
            int opcion = 0;
            int valor;
            int resultado;
            int x1, x2, x3, y1, y2, y3, z1, z2, z3;
            Console.WriteLine("Dime la opcion que deseas realizar");
            while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 3)
            {
                Console.WriteLine("Error, debe introducir una opcion valida");
            }
            if (opcion == 1)
            {
                for(int i = 0; i < matriz.GetLength(0); i++)
                {
                    for(int j = 0; j < matriz.GetLength(1); j++)
                    {
                        Console.WriteLine("Introduce un valor en la fila " + i + " columna " + j);
                        while (!int.TryParse(Console.ReadLine(), out valor))
                        {
                            Console.WriteLine("Error, debe introducir un numero valido");
                        }
                        matriz[i, j] = valor;
                    }
                }
                Console.WriteLine("Esta es la matriz resultante");
                for (int i = 0; i < matriz.GetLength(0); i++)
                {
                    for (int j = 0; j < matriz.GetLength(1); j++)
                    {
                        Console.Write(matriz[i, j] + "  ");
                    }
                    Console.WriteLine();
                }
                resultado = matriz[0, 0] * matriz[1, 1] * matriz[2, 2] + matriz[0, 1] * matriz[1, 2] * matriz[2, 0] + matriz[0, 2] * matriz[1, 0] * matriz[2, 1] - matriz[2, 0] * matriz[1, 1] * matriz[0, 2] - matriz[2, 1] * matriz[1, 2] * matriz[0, 0] - matriz[2, 2] * matriz[1, 0] * matriz[0, 1];
                Console.WriteLine("El determinante de la matriz es: " + resultado);
                resultado = 0;
            } //Determinante de una matriz 3x3
            else if(opcion == 2)
            {
                Console.WriteLine("Dime los valores de la primera coordenada");
                while (!int.TryParse(Console.ReadLine(), out x1))
                {
                    Console.WriteLine("Error, debe introducir un numero valido");
                }
                while (!int.TryParse(Console.ReadLine(), out y1))
                {
                    Console.WriteLine("Error, debe introducir un numero valido");
                }
                while (!int.TryParse(Console.ReadLine(), out z1))
                {
                    Console.WriteLine("Error, debe introducir un numero valido");
                }
                Console.WriteLine("Dime los valores de la segunda coordenada");
                while (!int.TryParse(Console.ReadLine(), out x2))
                {
                    Console.WriteLine("Error, debe introducir un numero valido");
                }
                while (!int.TryParse(Console.ReadLine(), out y2))
                {
                    Console.WriteLine("Error, debe introducir un numero valido");
                }
                while (!int.TryParse(Console.ReadLine(), out z2))
                {
                    Console.WriteLine("Error, debe introducir un numero valido");
                }
                resultado = (x1 * x2) + (y1 * y2) + (z1 * z2);
                Console.WriteLine("El producto escalar de estas dos coordenadas es: " + resultado);
                resultado = 0;
            } //Producto escalar
            else if(opcion == 3)
            {
                Console.WriteLine("Dime los valores de la primera coordenada");
                while (!int.TryParse(Console.ReadLine(), out x1))
                {
                    Console.WriteLine("Error, debe introducir un numero valido");
                }
                while (!int.TryParse(Console.ReadLine(), out y1))
                {
                    Console.WriteLine("Error, debe introducir un numero valido");
                }
                while (!int.TryParse(Console.ReadLine(), out z1))
                {
                    Console.WriteLine("Error, debe introducir un numero valido");
                }
                Console.WriteLine("Dime los valores de la segunda coordenada");
                while (!int.TryParse(Console.ReadLine(), out x2))
                {
                    Console.WriteLine("Error, debe introducir un numero valido");
                }
                while (!int.TryParse(Console.ReadLine(), out y2))
                {
                    Console.WriteLine("Error, debe introducir un numero valido");
                }
                while (!int.TryParse(Console.ReadLine(), out z2))
                {
                    Console.WriteLine("Error, debe introducir un numero valido");
                }
                Console.WriteLine("Dime los valores de la tercera coordenada");
                while (!int.TryParse(Console.ReadLine(), out x3))
                {
                    Console.WriteLine("Error, debe introducir un numero valido");
                }
                while (!int.TryParse(Console.ReadLine(), out y3))
                {
                    Console.WriteLine("Error, debe introducir un numero valido");
                }
                while (!int.TryParse(Console.ReadLine(), out z3))
                {
                    Console.WriteLine("Error, debe introducir un numero valido");
                }
                resultado = x1 * y2 * z3 + y1 * z2 * x3 + z1 * x2 * y3 - x3 * y2 * z1 - y3 * z2 * x1 - z3 * x2 * y1;
                Console.WriteLine("El producto mixto de estos 3 vectores es: " + resultado);
            } //Producto mixto
        }
    }
}
