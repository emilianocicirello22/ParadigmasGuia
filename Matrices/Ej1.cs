using System;

namespace Matrices
{

    class Ej1
    {
        /*Metodo que cargara la matriz con las ventas, por cada columna de dia recorrera las filas de los productos
         el usuario debera ingresar las ventas manualmente*/
        private static void CargarVentasDias(ref double[,] ventas, string[] dias, string[] productos)
        {
            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine($"\nIngrese ventas del dia {dias[i]}");
                for (int j = 0; j < 4; j++)
                {
                    Console.WriteLine($"Ingrese la cantidad vendida del producto: {productos[j]}");
                    ventas[j, i] = double.Parse(Console.ReadLine());
                }
            }
        }

        /*Metodo que cargara la matriz con las ventas, por cada producto se ingresara las ventas diarias
         el usuario debera ingresar las ventas manualmente*/
        private static void CargarVentasProductos(ref double[,] ventas, string[] dias, string[] productos)
        {
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"\nIngrese ventas del producto {productos[i]}");
                for (int j = 0; j < 7; j++)
                {
                    Console.WriteLine($"Ingrese la cantidad vendida el dia: {dias[j]}");
                    ventas[i, j] = double.Parse(Console.ReadLine());
                }
            }
        }

        /*Metodo que recorre las filas de productos por dia(Columnas) almacenando en una variable el valor de las ventas
         al final de cada  iteraccion muestra las ventas realizadas por dia de todos los productos*/
        private static void ListarVentasDias(ref double[,] ventas, string[] dias)
        {
            double ventasAcum = 0;

            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    ventasAcum += ventas[j, i];
                }
                Console.WriteLine($"\nPara el dia {dias[i]} la venta fue: {ventasAcum}");
                ventasAcum = 0;
            }
        }

        /*Metodo que recorre las columnas de los dias por la filas de los productos almacenando en una variable 
         el valor de las ventas al final de cada  iteraccion muestra las ventas realizadas por productos todos los dias*/
        private static void ListarVentasProductos(ref double[,] ventas, string[] productos)
        {
            double ventasAcum = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    ventasAcum += ventas[i, j];
                }
                Console.WriteLine($"\nPara el producto {productos[i]} la venta fue: {ventasAcum}");
                ventasAcum = 0;
            }
        }

        /*Metodo para el menu*/
        private static void MenuApp(ref double[,] ventas, string[] dias, string[] productos)
        {
            int referencia = 0;

            do
            {
                Console.WriteLine("\n\n1_Ingresar ventas por dias\n2_Cargar ventas por productos\n3_Listado de ventas por producto\n4_Listado de ventas por dia\n0_Para finalizar");
                referencia = int.Parse(Console.ReadLine());

                switch (referencia)
                {
                    case 1:
                        CargarVentasDias(ref ventas, dias, productos);
                        break;
                    case 2:
                        CargarVentasProductos(ref ventas, dias, productos);
                        break;

                    case 3:
                        ListarVentasProductos(ref ventas, productos);
                        break;

                    case 4:
                        ListarVentasDias(ref ventas, dias);
                        break;

                    default:
                        Console.WriteLine("Hasta la proxima!!");
                        break;

                }

            } while (referencia > 0 && referencia < 5);
        }

        static void Main(string[] args)
        {
            string[] vDias = { "Lunes", "Martes", "Miercoles", "Jueves", "Viernes", "Sabado", "Domingo" };
            string[] vProductos = { "Tornillos", "Tuercas", "Clavos", "Arandelas" };
            double[,] mVentas = new double[4, 7];

            MenuApp(ref mVentas, vDias, vProductos);
        }
    }
}