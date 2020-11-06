using System;

namespace Ej43
{
    class Ej43
    {
        /*Funcion que calcula y retorna el promedio de ventas por los meses ingresados*/
        private static double PromVentas(double[] vent, int mes)
        {
            double prom = 0;
            for (int i = 0; i < mes; i++)
            {
                prom = prom + vent[i];
            }
            return (prom / mes);
        }

        /*Metodo que muestra los meses que superaron el promedio de ventas*/
        private static void MostrarVentas(double[] vent, int mes, string[] mNom, double prom)
        {
            double v = 0;
            int c = 0;
            Console.WriteLine($"Los meses que superaron el promedio fueron:\n");

            for (int i = mes-1; i >= 0; i--)
            {
                if (vent[i] > prom)
                {
                    Console.WriteLine($"{mNom[i]} con {vent[i]} ventas");
                    c++;
                    v += vent[i];
                }

            }
            Console.WriteLine($"\n\nEl promedio de las mejores ventas es {(v / c)}");
        }

        /*Este metodo muestra las ventas por mes y al final su promedio*/
        private static void MostrarVenProm(double[] vent, int mes, string[] mNom, double prom)
        {
            for (int i = 0; i < mes; i++)
            {
                Console.WriteLine($"el mes {mNom[i]} registró {vent[i]} ventas");
            }
            Console.WriteLine($"\nLa venta promedio fue de {prom}\n");
        }

        //Metodo para inicializar vector
        private static void InicializacionDouble(ref double[] aux)
        {
            for (int i = 0; i < aux.Length; i++)
            {
                aux[i] = 0;
            }
        }

        static void Main(string[] args)
        {
            String[] vNomMes = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
            double[] vTotalVentas = new double[12];
            int numMes = 0;
            char corte = 's';
            double promedio = 0;

            InicializacionDouble(ref vTotalVentas);

            Console.WriteLine("Ingrese numero de meses a procesar");
            numMes = int.Parse(Console.ReadLine());

            while ((numMes > 0 && numMes <= 12) && corte.Equals('s'))
            {
                for (int i = 0; i < numMes; i++)
                {
                    Console.WriteLine($"Ingrese ventas para el mes de {vNomMes[i]}");
                    vTotalVentas[i] = double.Parse(Console.ReadLine());

                }
                Console.Clear();
                promedio = PromVentas(vTotalVentas, numMes);

                MostrarVenProm(vTotalVentas, numMes, vNomMes, promedio);

                MostrarVentas(vTotalVentas, numMes, vNomMes, promedio);

                corte = 'n';
            }
        }
    }
}