using System;

namespace TrabajoMatesPrueba
{
    class Program
    {
       
        /// <summary>
        /// Método que rellena una matriz para poder utilizarla en otros métodos
        /// Utiliza un parametro ref para poder modificar todo tipo de matriz sin la necesidad de hacer return
        /// </summary>
        /// <param name="vs"></param>
        private void RellenarMatriz(ref int[,] vs)
        {
            int valor;
            for (int i = 0; i < vs.GetLength(0); i++)
            {
                for (int j = 0; j < vs.GetLength(1); j++)
                {
                    Console.WriteLine("Introduce un valor en la fila " + i + " columna " + j);
                    valor = PedirNumero();
                    vs[i, j] = valor;
                }
            }
        }

        /// <summary>
        /// Mostramos la matriz para que se puedan hacer verificaciones por el usuario
        /// </summary>
        /// <param name="vs"></param>
        private void MostrarMatriz(int[,] vs)
        {
            for (int i = 0; i < vs.GetLength(0); i++)
            {
                for (int j = 0; j < vs.GetLength(1); j++)
                {
                    Console.Write(vs[i, j] + "  ");
                }
                Console.WriteLine();
            }
        }
        
        /// <summary>
        /// Metodo que calcula un determinante de una matriz 3x3
        /// verifica que la matriz pasada sea de 3x3 sino no ejecuta el programa
        /// </summary>
        /// <param name="vs"></param>
        private void Determinante3x3(int[,] vs)
        {
            if(vs.GetLength(0) == 3 && vs.GetLength(1) == 3)
            {
                int resultado = vs[0, 0] * vs[1, 1] * vs[2, 2] + vs[0, 1] * vs[1, 2] * vs[2, 0]
                        + vs[0, 2] * vs[1, 0] * vs[2, 1] - vs[2, 0] * vs[1, 1] * vs[0, 2]
                        - vs[2, 1] * vs[1, 2] * vs[0, 0] - vs[2, 2] * vs[1, 0] * vs[0, 1];
                Console.WriteLine("El determinante de la matriz es: " + resultado);
            }
            else
            {
                Console.WriteLine("La matriz dada no es de 3 x 3");
            }
        }
        
        /// <summary>
        /// Metodo que pide numero recoge el numero introducido por el usuario
        /// </summary>
        /// <returns>numero si es valido</returns>
        private int PedirNumero()
        {
            int valor;
            while (!int.TryParse(Console.ReadLine(), out valor))
            {
                Console.WriteLine("Error, debe introducir un numero valido");
            }
            return valor;
        }

        /// <summary>
        /// Metodo que utilizamos para poder llenar un vector
        /// </summary>
        /// <param name="vs"></param>
        private void RellenarVector(ref int[] vs)
        {
            Console.WriteLine("Dame los valores del vector");

            for(int i = 0; i<vs.Length; i++)
            {
                vs[i] = PedirNumero();
            }
        }

        /// <summary>
        /// Metodo que calcula el producto escalar entre dos vectores
        /// </summary>
        /// <param name="vs1"></param>
        /// <param name="vs2"></param>
        private void ProductoEscalar(int[] vs1, int[] vs2)
        {
            if (vs1.Length == vs2.Length)
            {
                int resultado = 0;
                for(int i = 0; i<vs1.Length; i++)
                {
                    resultado += vs1[i] * vs2[i];
                }
                Console.WriteLine("El producto escalar de los vectores es: " + resultado);
            }
            else
            {
                Console.WriteLine("Los vectores no son compatibles");
            }
        }

        /// <summary>
        /// Metodo que calcula el producto mixto entre tres vectores
        /// </summary>
        /// <param name="vs1"></param>
        /// <param name="vs2"></param>
        /// <param name="vs3"></param>
        private void ProductoMixto(int[] vs1, int[] vs2, int[] vs3)
        {
            if (vs1.Length == vs2.Length && vs1.Length == vs3.Length && vs1.Length==3)
            {
                int resultado = vs1[0] * vs2[1] * vs3[2] + vs1 [2] * vs2[0] * vs3[1]
                       + vs1[1] * vs2[2] * vs3[0] - vs1[2] * vs2[1] * vs3[0]
                       - vs1[0] * vs2[2] * vs3[1] - vs1[1] * vs2[0] * vs3[2];
                Console.WriteLine("El producto mixto de los vectores es:" + resultado);
            }
            else
            {
                Console.WriteLine("Los vectores no son compatibles");
            }
        }

        /// <summary>
        /// Metodo que pide el numero de la opcion del menu
        /// </summary>
        /// <returns></returns>
        private int EscogerNumeroMenu()
        {
            int opcion;
            Console.WriteLine("Dime la opcion que deseas realizar");
            while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 3)
            {
                Console.WriteLine("Error, debe introducir una opcion valida");
            }
            return opcion;
        }

        private void Menu()
        {
            int[,] matriz = new int[3, 3];
            int[] Vector1 = new int[3];
            int[] Vector2 = new int[3];
            int[] Vector3 = new int[3];

            int opcion = EscogerNumeroMenu();


            #region Determinante de una matriz 3x3
            if (opcion == 1)
            {
                RellenarMatriz(ref matriz);
                Console.WriteLine("Esta es la matriz resultante");
                MostrarMatriz(matriz);
                Determinante3x3(matriz);
            }
            #endregion

            #region Producto Escalar
            else if (opcion == 2)
            {
                Console.WriteLine("Vector 1");
                RellenarVector(ref Vector1);

                Console.WriteLine("Vector2");
                RellenarVector(ref Vector2);

                ProductoEscalar(Vector1, Vector2);
            }
            #endregion

            #region Producto Mixto
            else if (opcion == 3)
            {
                Console.WriteLine("Vector 1");
                RellenarVector(ref Vector1);

                Console.WriteLine("Vector 2");
                RellenarVector(ref Vector2);

                Console.WriteLine("Vector 3");
                RellenarVector(ref Vector3);

                ProductoMixto(Vector1, Vector2, Vector3);
            }
            #endregion
        }

        static void Main(string[] args)
        {
            Program pr = new Program();
            pr.Menu();
        }
    }
}
