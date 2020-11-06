using System;

namespace Ej45
{
    class Ej45
    {
        /*Funcion que inicializa y permite almacenar en los vectores tanto codigo como la descripcion del producto.
          Tambien devuelve un valor entero que representa cuantos productos fueron cargados*/
        private static int InicializacionCodigoModelo(ref int[] c, ref string[] m)
        {
            string corte = "S";
            int cont = 0;
            for (int i = 0; i < 49; i++)
            {
                c[i] = i + 1;
                m[i] = " ";
            }
            
            do
            {
                Console.WriteLine($"ingrese descripcion para el codigo {c[cont]}");
                m[cont] = Console.ReadLine();
                cont++;
                Console.WriteLine("\n\nIngrese S para continuar cargando, si desea finalizar ingrese N\n");
                corte = Console.ReadLine();
            } while (cont < 49 && corte.Equals("S", StringComparison.InvariantCultureIgnoreCase));

            return cont;
        }//fin Funcion

        /*Metodo que permite cargar las ventas por modelo de producto utilizando el codigo de producto.
          Deben pasarse como referencia los vectores de codigo de producto, ventas, la cantidad de ventas a realizar
           y la cantidad de modelos cargados*/
        private static void CargarVenta(ref int[] c, ref double[] v, int t, int m)
        {
            Console.WriteLine($"Tiene un total de {m} modelos de autos cargados");

            for (int i = 0; i < t; i++)
            {
                do
                {
                    Console.WriteLine("\nIngrese el codigo del producto");
                    c[i] = int.Parse(Console.ReadLine());

                } while (c[i] < 1 || c[i] > m);

                Console.WriteLine("\nIngrese el monto de la venta");
                v[i] = double.Parse(Console.ReadLine());
            }
        }//fin metodo

        /*Metodo que calcula cual fue la mayor venta individual e imprime modelo de producto e importe*/
        private static void MayorVenta(int[] c, string[] m, double[] v, int t)
        {
            int codigo = 0;
            double montoVenta = 0;
            bool primVent = true;

            for (int i = 0; i < t; i++)
            {
                if (primVent)
                {
                    codigo = c[i]-1;
                    montoVenta = v[i];
                    primVent = false;
                }
                else if (v[i] > montoVenta)
                {
                    codigo = c[i]-1;
                    montoVenta = v[i];
                }
            }
            
            Console.WriteLine($"El modelo que registro la mejor venta fue {m[codigo]} por {montoVenta} pesos.");
        }//fin metodo

        /*Metodo que muestra las ventas acumuladas por modelo de productos exceptuando aquellos modelos que no registraron ventas*/
        private static void VentasTotModelos(int[] cv, int[] cp, string[] m, double[] v, int p, int coV)
        {
            int codigo = 0;
            string descripcion = " ";
            double ventasAcum = 0;

            Console.WriteLine("Codigo\t\t Descripcion\t\t Monto");
            for(int i = 0; i < p; i++)
            {
                codigo = cp[i];
                descripcion = m[i];

                for(int j = 0; j < coV; j++)
                {
                    if(cp[i] == cv[j])
                    {
                        ventasAcum += v[j];
                    }
                }
                if(ventasAcum != 0)
                {
                    Console.WriteLine($"{codigo}\t\t {descripcion}\t\t {ventasAcum}");
                }

                ventasAcum = 0;
            }
        }//fin metodo

        static void Main(string[] args)
        {
            int[] codigoProducto = new int[49];
            string[] modeloProducto = new string[49];
            double[] montoVentas;
            int[] codProdVent;
            int contProd = 0;
            int cantVent = 0;
            int opcion = 0;

            Console.WriteLine("Antes de inicializar el programa se procederá con la carga de productos");

            contProd = InicializacionCodigoModelo(ref codigoProducto, ref modeloProducto);

            Console.WriteLine("Ingrese la cantidad de ventas a ingresar");
            cantVent = int.Parse(Console.ReadLine());
            codProdVent = new int[cantVent];
            montoVentas = new double[cantVent];

            CargarVenta(ref codProdVent, ref montoVentas, cantVent, contProd);

            do
            {
                do
                {
                    Console.WriteLine("\n\n1_Modelo con mas ventas\n2_Mostrar lista de ventas totales por modelos\n0_para finalizar");
                    opcion = int.Parse(Console.ReadLine());

                } while (opcion < 0 || opcion > 3);

                switch (opcion)
                {
                    case 1:
                        MayorVenta(codProdVent, modeloProducto, montoVentas, cantVent);
                        break;
                    case 2:
                        VentasTotModelos(codProdVent, codigoProducto, modeloProducto, montoVentas, contProd, cantVent);
                        break;
                    default:
                        Console.WriteLine("Muchas gracias!! Hasta luego");
                        break;
                }

            } while (opcion > 0 && opcion < 3);
        }
    }
}