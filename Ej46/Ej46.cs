using System;

namespace Ej46
{
    class Ej46
    {
        public static void inicializarCajas(Boolean[] caja)
        {
            for (int i = 0; i < 24; i++)
            {
                caja[i] = true;
            }
        }

        public static void inicializarProductos(string[] productos, double[] precios, int[] codigo)
        {
            int cod = 0;
            string corte = "s";

            for (int i = 0; i < 1000; i++)
            {
                codigo[i] = i;
                productos[i] = " ";
                precios[i] = 0;
            }

            do
            {
                Console.WriteLine("Ingrese codigo del producto a registrar");
                cod = int.Parse(Console.ReadLine());

                Console.WriteLine("Ingrese decripcion del producto");
                productos[cod] = Console.ReadLine();

                Console.WriteLine("Ingrese precio del producto");
                precios[cod] = double.Parse(Console.ReadLine());

                Console.WriteLine("¿Desea Continuar cargando productos? ingrese S para continuar N para finalizar");
                corte = Console.ReadLine();

            } while (corte.Equals("S", StringComparison.InvariantCultureIgnoreCase));
        }

        private static void mayorFacturacion(string[] productos, int[] codigo, int[] codProd, int[] cantVen, double[] precios, int cantidadVendida)
        {
            double[] aux = new double[1000];
            bool mayor = true;
            double mayorV = 0;
            int coPro = 0;
            string desPro = " ";

            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < cantidadVendida; j++)
                {
                    if (codigo[i] == codProd[j])
                    {
                        aux[i] += (cantVen[j] * precios[i]);
                    }
                }
            }

            for (int i = 0; i < 1000; i++)
            {
                if (mayor)
                {
                    mayorV = aux[i];
                    coPro = codigo[i];
                    desPro = productos[i];
                    mayor = false;
                }
                else if (mayorV < aux[i])
                {
                    mayorV = aux[i];
                    coPro = codigo[i];
                    desPro = productos[i];
                }
            }
            Console.Write("\nLos productos ");
            for (int i = 0; i < 1000; i++)
            {
                if (mayorV == aux[i])
                {
                    Console.Write($"{productos[i]}, ");
                }
            }
            Console.Write($"registraron la mayor facturación por un importe de ${mayorV}.\n");

        }

        private static void listaVentas(string[] productos, Boolean[] caja, int[] codProd, int[] cantVen, int cantidadVen)
        {

            int pos = 0;
            int posCaja = 0;
            do
            {
                Console.WriteLine("Ingrese numero de caja");
                posCaja = int.Parse(Console.ReadLine());
                caja[posCaja-1] = false;
                Console.WriteLine("Ingrese codigo de producto");
                for (int i = 0; i < 1000; i++)
                {
                    if (!productos[i].Equals(" "))
                    {
                        Console.WriteLine($"codigo:{i} {productos[i]}");
                    }
                }
                codProd[pos] = int.Parse(Console.ReadLine());
                Console.WriteLine($"Ingrese cantidad vendida del producto {productos[codProd[pos]]}");
                cantVen[pos] = int.Parse(Console.ReadLine());
                pos++;
                cantidadVen--;
            } while (cantidadVen > 0);
        }

        private static void cajaSinVentas(Boolean[] cajaVent)
        {
            
            int cont = 0;
            
                for (int j = 0; j < 24; j++)
                {
                    if (cajaVent[j])
                    {
                         cont++;
                    }
                }
            

            /*for (int i = 0; i < 25; i++)
            {
                if (sinVent[i] == 0)
                {
                    cont++;
                }
            }*/
            Console.WriteLine($"{cont} cajas no realizaron ventas");
        }


        static void Main(string[] args)
        {
            //productos
            string[] vProd = new string[1000];
            double[] vPrecio = new double[1000];
            int[] vCodProducto = new int[1000];
            //fin productos

            //ventas
            //int[] vCajas = new int[25];
            Boolean[] vCajasVenta=new Boolean[24];
            int[] vCodProdVenta;
            int[] vCantVentas;
            int cantidadVen = 0;
            //fin ventas

            inicializarCajas(vCajasVenta);

            int opcion = 0;

            inicializarProductos(vProd, vPrecio, vCodProducto);

            Console.WriteLine("Indique la cantidad de ventas a procesar");
            cantidadVen = int.Parse(Console.ReadLine());
            //vCajasVenta = new int[cantidadVen];
            vCodProdVenta = new int[cantidadVen];
            vCantVentas = new int[cantidadVen];

            do
            {

                Console.WriteLine("1_Cargar registro de ventas\n2_Informe de mayor facturación.\n3_Informe de Cajas sin ventas\n0_para finalizar");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        listaVentas(vProd, vCajasVenta, vCodProdVenta, vCantVentas, cantidadVen);
                        break;
                    case 2:
                        mayorFacturacion(vProd, vCodProducto, vCodProdVenta, vCantVentas, vPrecio, cantidadVen);
                        break;
                    case 3:
                        cajaSinVentas(vCajasVenta);
                        break;

                }
            } while (opcion != 0);
        }
    }
}