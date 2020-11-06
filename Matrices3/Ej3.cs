using System;

namespace Matrices3
{
    class Ej3
    {
        /*Metodo para inicializar matriz*/
        private static void inicializarMatriz(ref double[,] ventas)
        {
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    ventas[i, j] = 0;
                }
            }
        }
        /*Metodo para cargar las ventas por producto y por dia. Tambien almacena en un vector la cantidad de productos vendidos*/
        private static void CargarVentas(ref double[,] ventas, string[] productos, int[] ventaPorProducto)
        {
            int col = 0;
            int fil = 0;
            int cont = 0;

            do
            {
                do
                {
                    cont++;

                    Console.WriteLine($"Ingrese numero de producto\n1_{productos[0]}\n2_{productos[1]}\n3_{productos[2]}\n4_{productos[3]}\n");
                    col = int.Parse(Console.ReadLine());

                    Console.WriteLine($"Ingrese venta para el dia {fil + 1}");
                    ventas[fil, col - 1] = double.Parse(Console.ReadLine());

                    ventaPorProducto[col - 1]++;

                    Console.WriteLine($"para registrar otra venta en este dia ingrese 1 para finalizar ingrese 0");
                    col = int.Parse(Console.ReadLine());

                } while (cont < 4 && col != 0);

                cont = 0;
                fil++;


                Console.WriteLine($"ingrese 1 para continuar o 0000 para finalizar");
                col = int.Parse(Console.ReadLine());

            } while (fil < 30 && col != 0000);
        }

        /*Metodo que cuenta y muestra la cantidad de los productos vendidos*/
        private static void totalProdVendidos(int[] prodVendidos)
        {
            int prod = 0;

            for (int i = 0; i < 4; i++)
            {
                prod += prodVendidos[i];
            }

            Console.WriteLine($"el total de productos vendidos es: {prod}");
        }

        /*Metodo que calcula el producto que mas se vendio*/
        private static void masVendido(int[] prodVend, string[] productos)
        {
            int mayorProd = 0;
            string prod = " ";
            bool primVal = true;

            for (int i = 0; i < 4; i++)
            {
                if (primVal)
                {
                    mayorProd = prodVend[i];
                    prod = productos[i];
                    primVal = false;
                }
                else if (mayorProd < prodVend[i])
                {
                    mayorProd = prodVend[i];
                    prod = productos[i];
                }
            }
            Console.WriteLine($"El producto mas vendido fue {prod} con un total de {mayorProd} ventas");
        }

        /*Metodo que muestra la mejor venta realizada*/
        private static void mejorVenta(double[,] ventas, string[] productos)
        {
            double acum = 0;
            double mayorVen = 0;
            string prod = " ";
            bool primVal = true;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    acum += ventas[j, i];
                }

                if (primVal)
                {
                    mayorVen = acum;
                    prod = productos[i];
                    primVal = false;
                }
                else if (mayorVen < acum)
                {
                    mayorVen = acum;
                    prod = productos[i];
                }
                acum = 0;
            }

            Console.WriteLine($"La mejor venta la registro el producto {prod} Por un monto de {mayorVen}");
        }

        /*Metodo que muestra el cuadro de ventas*/
        private static void cuadroVentasProductos(ref double[,] ventas, string[] productos)
        {
            int i = 0;

            Console.WriteLine($"Dia\t {productos[0]}\t {productos[1]}\t {productos[2]}\t\t {productos[3]}");

            for (i = 0; i < 30; i++)
            {
                Console.Write($"Dia{i + 1}\t");

                for (int j = 0; j < 4; j++)
                {
                    if (ventas[i, j] == 0)
                    {
                        Console.Write("XXX\t\t");
                    }
                    else
                    {
                        Console.Write($"{ventas[i, j]}\t\t");
                    }
                }
                Console.Write("\n");
            }
        }

        private static void MenuApp(ref double[,] ventas, string[] productos, int[] ventaPorProducto)
        {
            int referencia = 0;

            do
            {
                Console.WriteLine("\n\n1_Ingresar ventas \n2_Total de productos Vendidos\n3_Producto mas vendido\n4_Producto con la mejor venta\n5_cuadro con todas las ventas\n0_Para finalizar");
                referencia = int.Parse(Console.ReadLine());

                switch (referencia)
                {
                    case 1:
                        CargarVentas(ref ventas, productos, ventaPorProducto);
                        break;
                    case 2:
                        totalProdVendidos(ventaPorProducto);
                        break;

                    case 3:
                        masVendido(ventaPorProducto, productos);
                        break;

                    case 4:
                        mejorVenta(ventas, productos);
                        break;

                    case 5:
                        cuadroVentasProductos(ref ventas, productos);
                        break;

                    default:
                        Console.WriteLine("Hasta la proxima!!");
                        break;

                }

            } while (referencia > 0 && referencia < 6);
        }

        static void Main(string[] args)
        {
            string[] vProductos = { "Tornillos", "Tuercas", "Clavos", "Arandelas" };
            double[,] mVentas = new double[30, 4];
            int[] vprodVend = { 0, 0, 0, 0 };

            MenuApp(ref mVentas, vProductos, vprodVend);
        }
    }
}
