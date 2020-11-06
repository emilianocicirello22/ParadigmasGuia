using System;

namespace Matrices4
{
    class Ej4
    {

        //Metodo para cargar ventas y contabilizar ventas por bimestre
        private static void registrosDeVentas(ref double[,] ventas, string[] sucursal)
        {
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine($"Bimestre {i + 1}");
                for (int j = 0; j < 4; j++)
                {
                    Console.WriteLine($"Ingrese la venta para la sucursal: {sucursal[j]}");
                    ventas[i, j] = double.Parse(Console.ReadLine());
                    ventas[i, 4] += ventas[i, j];
                }
            }
        }

        //Metodo que informa la venta de X sucursal en un bimestre X
        private static void ventaSucBim(ref double[,] ventas, string[] sucursal)
        {
            int fila = 0;
            int col = 0;

            Console.WriteLine($"Ingrese numero de sucursal\n1_{sucursal[0]}\n2_{sucursal[1]}\n3_{sucursal[2]}\n4_{sucursal[3]}");
            col = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese Bimestre a consultar");
            fila = int.Parse(Console.ReadLine());

            Console.WriteLine($"La sucursal {sucursal[col - 1]} vendio {ventas[fila - 1, col - 1]} en el bimestre {fila} ");
        }

        //Metodo que informa las ventas totales ce un bimestre X
        private static void ventaBimestral(ref double[,] ventas)
        {
            int fila = 0;

            Console.WriteLine("Ingrese Bimestre a consultar");
            fila = int.Parse(Console.ReadLine());

            Console.WriteLine($"En el bimestre {fila} se vendio {ventas[fila - 1, 4]}.");
        }

        //Metodo que informa las ventas totales de las sucursales
        private static void ventaTotSucursal(ref double[,] ventas, string[] sucursal)
        {
            int col = 0;
            double acum = 0;

            Console.WriteLine($"Ingrese numero de sucursal\n1_{sucursal[0]}\n2_{sucursal[1]}\n3_{sucursal[2]}\n4_{sucursal[3]}");
            col = int.Parse(Console.ReadLine());
            col--;

            for (int i = 0; i < 6; i++)
            {
                acum += ventas[i, col];
            }
            Console.WriteLine($"La venta total de la sucursal {sucursal[col]} es de {acum} pesos");
        }

        static void Main(string[] args)
        {
            string[] vSucursal = { "Liniers", "Boedo", "Caballito", "Flores" };
            double[,] mVentas = new double[6, 5];
            int opcion = 0;
            
            do
            {
                Console.WriteLine("\n\n1_Ingresar ventas\n2_Venta bimestral de una sucursal\n3_Total de ventas bimestrales\n4_Total de ventas por sucursal\n0_Para finalizar");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        registrosDeVentas(ref mVentas, vSucursal);
                        break;

                    case 2:
                        ventaSucBim(ref mVentas, vSucursal);
                        break;

                    case 3:
                        ventaBimestral(ref mVentas);
                        break;

                    case 4:
                        ventaTotSucursal(ref mVentas, vSucursal);
                        break;

                    default :
                        Console.WriteLine("Hasta la proxima!!");
                        break;
                }

            } while (opcion > 0 && opcion < 5);
        }
    }
}