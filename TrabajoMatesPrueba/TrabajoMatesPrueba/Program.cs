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
        private int Determinante3x3(int[,] vs)
        {
            if(vs.GetLength(0) == 3 && vs.GetLength(1) == 3)
            {
                int resultado = vs[0, 0] * vs[1, 1] * vs[2, 2] + vs[0, 1] * vs[1, 2] * vs[2, 0]
                        + vs[0, 2] * vs[1, 0] * vs[2, 1] - vs[2, 0] * vs[1, 1] * vs[0, 2]
                        - vs[2, 1] * vs[1, 2] * vs[0, 0] - vs[2, 2] * vs[1, 0] * vs[0, 1];
                Console.WriteLine("El determinante de la matriz es: " + resultado);
                return resultado;
            }
            else
            {
                Console.WriteLine("La matriz dada no es de 3 x 3");
                return 0;
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
        /// Metodo que calcula el producto vectorial entre dos vectores
        /// </summary>
        /// <param name="vs1"></param>
        /// <param name="vs2"></param>
        /// <returns></returns>
        private double[] ProductoVectorial(int[] vs1, int[] vs2)
        {
            double[] producto = new double[3];
            producto[0] = vs1[1] * vs2[2] - vs1[2] * vs2[1];
            producto[1] = vs1[2] * vs2[0] - vs1[0] * vs2[2];
            producto[2] = vs1[0] * vs2[1] - vs1[1] * vs2[0];

            Console.WriteLine("El producto vectorial es: " + producto[0]);
            Console.WriteLine("El producto vectorial es: " + producto[1]);
            Console.WriteLine("El producto vectorial es: " + producto[2]);
            return producto;
        }

        /// <summary>
        /// Metodo que calcula la distancia entre un punto y una recta
        /// </summary>
        /// <param name="vs1"></param>
        /// <param name="vs2"></param>
        /// <param name="vs3"></param>
        private void DistanciaPuntoRecta(int[] vs1, int[] vs2, int[] vs3)
        {
            double resultado;
            int[] vector = new int[3];
            vector[0] = vs1[0] - vs2[0];
            vector[1] = vs1[1] - vs2[1];
            vector[2] = vs1[2] - vs2[2];
            double[] vectorial = ProductoVectorial(vector, vs3); 

            double denominador = Math.Sqrt(MathF.Pow(vs3[0], 2) + MathF.Pow(vs3[1], 2) + MathF.Pow(vs3[2], 2));

            //verificacion para no dividir entre 0
            if(denominador==0)
                Console.WriteLine("La distancia entre el punto y la recta es infinito");
            else
            {
                resultado = Math.Sqrt((vectorial[0] * vectorial[0]) + (vectorial[1] * vectorial[1]) + (vectorial[2] * vectorial[2])) / denominador;
                Console.WriteLine("La distancia del punto a la recta es : " + resultado);
            }


        }

        /// <summary>
        /// Metodo que calcula la distancia entre un punto y una recta
        /// </summary>
        /// <param name="vs1"></param>
        /// <param name="vs4"></param>
        private void DistanciaPuntoPlano(int[] vs1, int[] vs4)
        {
            double denominador = Math.Sqrt(MathF.Pow(vs4[0], 2) + MathF.Pow(vs4[1], 2) + MathF.Pow(vs4[2], 2));

            //verificar para no dividir entre 0
            if (denominador == 0)
                Console.WriteLine("La distancia entre el punto y el plano es infinito");
            else
            {
                double resultado = Math.Abs((vs1[0] * vs4[0]) + (vs1[1] * vs4[1]) + (vs1[2] * vs4[2]) + vs4[3]) / denominador;
                Console.WriteLine("La distancia del punto al plano es : " + resultado);
            }

        }

        /// <summary>
        /// metodo que rellena una matriz de 3x3 utilizando 3 vectores.
        /// </summary>
        /// <param name="vs1"></param>
        /// <param name="vs2"></param>
        /// <param name="vs3"></param>
        /// <param name="matriz"></param>
        private void RellenarMatriz(int[] vs1, int[] vs2, int[] vs3, ref int[,] matriz)
        {
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                matriz[0, i] = vs1[i];
            }
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                matriz[1, i] = vs2[i];
            }
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                matriz[2, i] = vs3[i];
            }
        }


        /// <summary>
        /// Método para calcular la distacia entre la recta y el plano
        /// utilizamos la formula general y no verificamos casos en particulares ya que igual van a dar 0
        /// </summary>
        /// <param name="vs1"></param>
        /// <param name="vs2"></param>
        private void DistanciaRectaPlano(int[] vs1, int[] vs2)
        {
            double denominador = Math.Sqrt(MathF.Pow(vs2[0], 2) + MathF.Pow(vs2[1], 2) + MathF.Pow(vs2[2], 2));

            //verificacion para no dividir entre 0
            if (denominador == 0)
            {
                Console.WriteLine("La distancia de la recta al plano es infinito");
            }
            else
            {
                double resultado = Math.Abs((vs1[0] * vs2[0]) + (vs1[1] * vs2[1]) + (vs1[2] * vs2[2]) + vs2[3]) / denominador;
                Console.WriteLine("La distancia de la recta al plano es : " + resultado);
            }

           
            //Pedir punto de la recta y ecuacion general del plano

        }

        /// <summary>
        /// Metodo que pide el numero de la opcion del menu
        /// </summary>
        /// <returns></returns>
        private int EscogerNumeroMenu()
        {
            int opcion;
            Console.WriteLine("Dime la opcion que deseas realizar");
            while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 7)
            {
                Console.WriteLine("Error, debe introducir una opcion valida");
            }
            return opcion;
        }

        /// <summary>
        /// Metodo que imprime el menu
        /// </summary>
        private void ImprimirMenu()
        {
            Console.WriteLine("1 - Determinante de una matriz 3x3");
            Console.WriteLine("2 - Producto escalar");
            Console.WriteLine("3 - Producto mixto");
            Console.WriteLine("4 - Producto vectorial");
            Console.WriteLine("5 - Distancia Punto-Recta 3D");
            Console.WriteLine("6 - Distancia Punto-Plano 3D");
            Console.WriteLine("7 - Distancia Recta y Plano");
            Console.WriteLine("8 - Salir");
        }



        /// <summary>
        /// Metodo que gestiona lo que se hace una vez escogemos una opcion del menu
        /// </summary>
        private void Menu()
        {
            int[,] matriz = new int[3, 3];
            int[] Vector1 = new int[3];
            int[] Vector2 = new int[3];
            int[] Vector3 = new int[3];
            int[] Vector4 = new int[4];

            ImprimirMenu();
            int opcion = EscogerNumeroMenu();

            do
            {
                switch (opcion)
                {
                    #region Determinante de una Matriz
                    case 1:
                        RellenarMatriz(ref matriz);
                        Console.WriteLine("Esta es la matriz resultante");
                        MostrarMatriz(matriz);
                        Determinante3x3(matriz);
                        break;
                    #endregion
                    #region Producto escalar
                    case 2:
                        Console.WriteLine("Vector 1");
                        RellenarVector(ref Vector1);

                        Console.WriteLine("Vector2");
                        RellenarVector(ref Vector2);

                        ProductoEscalar(Vector1, Vector2);
                        break;
                    #endregion
                    #region Producto mixto
                    case 3:
                        Console.WriteLine("Vector 1");
                        RellenarVector(ref Vector1);

                        Console.WriteLine("Vector 2");
                        RellenarVector(ref Vector2);

                        Console.WriteLine("Vector 3");
                        RellenarVector(ref Vector3);

                        ProductoMixto(Vector1, Vector2, Vector3);
                        break;
                    #endregion
                    #region Producto Vectorial
                    case 4:
                        Console.WriteLine("Vector 1");
                        RellenarVector(ref Vector1);

                        Console.WriteLine("Vector 2");
                        RellenarVector(ref Vector2);

                        ProductoVectorial(Vector1, Vector2);
                        break;
                    #endregion
                    #region Distancia Punto Recta
                    case 5:
                        Console.WriteLine("Punto 1");
                        RellenarVector(ref Vector1);

                        Console.WriteLine("Punto 2");
                        RellenarVector(ref Vector2);

                        Console.WriteLine("Vector director de la recta");
                        RellenarVector(ref Vector3);


                        DistanciaPuntoRecta(Vector1, Vector2, Vector3);
                        break;
                    #endregion
                    #region Distancia Punto Plano
                    case 6:
                        Console.WriteLine("Coordenadas del punto");
                        RellenarVector(ref Vector1);

                        Console.WriteLine("Coordenadas x,y,z y el termino independiente");
                        RellenarVector(ref Vector4);


                        DistanciaPuntoPlano(Vector1, Vector4);
                        break;
                    #endregion
                    #region Distancia Recta Plano
                    case 7:
                        Console.WriteLine("Dame el punto de la recta");
                        RellenarVector(ref Vector1);

                        Console.WriteLine("Escribe la ecuacion general del plano");
                        RellenarVector(ref Vector4);

                        DistanciaRectaPlano(Vector1, Vector4);
                        break;
                        #endregion
                }
                if (opcion != 6)
                {
                    Console.ReadKey();
                    Console.Clear();
                    ImprimirMenu();
                    opcion = EscogerNumeroMenu();
                }
            } while (opcion < 7);
        }

        static void Main(string[] args)
        {
            Program pr = new Program();
            pr.Menu();
        }
    }
}
