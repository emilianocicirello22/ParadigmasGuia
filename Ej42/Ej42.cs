using System;
/*42) Se tienen los montos de ventas totales de los n primeros meses (definidos por el usuario), correspondiente a un mismo año de un comercio. 
Se quiere calcular e informar la venta promedio de esos meses, así como el nombre del mes y el monto de la venta de aquellos meses en que la venta 
superó a la venta promedio calculada. Las ventas se encuentras ordenadas por mes ascendente (enero al mes indicado por el usuario). 
El usuario podría no requerir ningún informe indicando 0 como número de meses a procesar.*/
namespace Ej42
{
    class Ej42
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
            Console.WriteLine($"Los meses que superaron el promedio fueron:\n");

            for (int i = 0; i < mes; i++)
            {
                if (vent[i] > prom)
                {
                    Console.WriteLine($"{mNom[i]} con {vent[i]} ventas");
                }
                
            }
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
