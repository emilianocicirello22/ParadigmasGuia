using System;

namespace Ej44
{
    class Ej44
    {
        //metodo de inicializacion de vector tipo numeros enteros
        private static void InicializacionInt(ref int[] aux)
        {
            for (int i = 0; i < aux.Length; i++)
            {
                aux[i] = 0;
            }
        }

        //metodo de inicializacion de vector tipo numeros decimales
        private static void InicializacionDouble(ref double[] aux)
        {
            for (int i = 0; i < aux.Length; i++)
            {
                aux[i] = 0;
            }
        }

        //metodo de ordenamiento tipo burbuja modificado 
        private static void OrdenarVentasMes(ref double[] v, ref int[] m, int c)
        {
            int actual = 0;
            bool perm = true;
            int ite = 0;

            while (perm)
            {
                perm = false;
                ite++;

                for (actual = 0; actual < c-ite; actual++)
                {
                    if((v[actual] >= v[actual + 1])) 
                    {

                        perm = true;
                        double temp = v[actual];
                        v[actual] = v[actual + 1];
                        v[actual + 1] = temp;
                        int tempM = m[actual];
                        m[actual] = m[actual + 1];
                        m[actual + 1] = tempM;
                    }/*else if (m[actual] > m[actual + 1])
                    {
                        perm = true;
                        double temp = v[actual];
                        v[actual] = v[actual + 1];
                        v[actual + 1] = temp;
                        int tempM = m[actual];
                        m[actual] = m[actual + 1];
                        m[actual + 1] = tempM;
                    }  */
                
                }
            }
        }

        //metodo para mostrar los datos
        private static void MostrarVentasMes(double[] v, int[] m, string[] n, int nM)
        {
            for (int i = 0; i < nM; i++)
            {
                Console.WriteLine($"En el mes {n[m[i] - 1]} la venta fue de {v[i]}\n");
            }
        }

        static void Main(string[] args)
        {
            String[] vNomMes = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
            int[] vMeses = new int[12];
            double[] vVentasMes = new double[12];
            int pos = 0;
            string corte = "S";
            int cont = 0;
            int nMeses = 0;

            InicializacionInt(ref vMeses);
            InicializacionDouble(ref vVentasMes);

            Console.WriteLine("Ingrese cantidad de meses a cargar");
            nMeses = int.Parse(Console.ReadLine());

            do
            {
                Console.WriteLine("Ingrese numero de mes a cargar");
                pos = int.Parse(Console.ReadLine());

                vMeses[cont] = pos;

                do
                {
                    Console.WriteLine("Ingrese cantidad vendida");
                    vVentasMes[cont] += double.Parse(Console.ReadLine());

                    Console.WriteLine("¿Desea seguir cargando ventas para este mes?Presione S para continuar N para finalizar");
                    corte=Console.ReadLine();

                } while (corte.Equals("S", StringComparison.InvariantCultureIgnoreCase));

                
                cont++;

            } while (nMeses > cont);

            OrdenarVentasMes(ref vVentasMes,ref vMeses, nMeses);

            MostrarVentasMes(vVentasMes, vMeses, vNomMes, nMeses);
        }
    }
}
