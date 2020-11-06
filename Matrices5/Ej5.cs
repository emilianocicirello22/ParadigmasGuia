using System;

namespace Matrices5
{
    class Ej5
    {
        /*Metodo para Cargar los socios tambien contara el total de los socios atendidos 
          por dia y por centro y el total de socios atendidos*/
        private static void registrosDeVentas(ref double[,] socioAtendido, string[] centro, string[] dias)
        {
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"{centro[i]}");
                for (int j = 0; j < 6; j++)
                {
                    Console.WriteLine($"Ingrese la cantidad de socios atendidos el dia {dias[j]}");
                    socioAtendido[j, i] = double.Parse(Console.ReadLine());
                    socioAtendido[6, i] += socioAtendido[j, i];
                }
            }

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    socioAtendido[i, 4] += socioAtendido[i, j];
                    socioAtendido[6, 4] += socioAtendido[i, j];
                }
            }
        }

        //metodo que mostrara la atencion de un socio en un dia y centro X en particular
        private static void atencionCenDia(ref double[,] socioAtendido, string[] centro, string[] dias)
        {
            int fila = 0;
            int col = 0;

            Console.WriteLine($"Ingrese centro\n1_{centro[0]}\n2_{centro[1]}\n3_{centro[2]}\n4_{centro[3]}");
            col = int.Parse(Console.ReadLine());

            Console.WriteLine($"Ingrese dia\n1_{dias[0]}\n2_{dias[1]}\n3_{dias[2]}\n4_{dias[3]}\n5_{dias[4]}\n6_{dias[5]}");
            fila = int.Parse(Console.ReadLine());

            Console.WriteLine($"El  {centro[col - 1]} atendio {socioAtendido[fila - 1, col - 1]} en el dia {dias[fila - 1]} ");
        }

        //Metodo que muestra todos los socios que se atendieron en x dia
        private static void atencionDia(ref double[,] socioAtendido, string[] dias)
        {
            int dia = 0;

            Console.WriteLine($"Ingrese dia\n1_{dias[0]}\n2_{dias[1]}\n3_{dias[2]}\n4_{dias[3]}\n5_{dias[4]}\n6_{dias[5]}");
            dia = int.Parse(Console.ReadLine());

            Console.WriteLine($"El dia {dias[dia - 1]} atendio {socioAtendido[dia - 1, 4]} socios");
        }

        //Metodo que muestra todos los socios que se atendieron en x centro
        private static void atencionCentro(ref double[,] socioAtendido, string[] centro)
        {
            int cen = 0;

            Console.WriteLine($"Ingrese centro\n1_{centro[0]}\n2_{centro[1]}\n3_{centro[2]}\n4_{centro[3]}");
            cen = int.Parse(Console.ReadLine());

            Console.WriteLine($"El  {centro[cen - 1]} atendio {socioAtendido[6, cen - 1]} socios");
        }

        static void Main(string[] args)
        {
            string[] vCentro = { "Centro 1", "Centro 2", "Centro 3", "Centro 4" };
            string[] vDias = { "Lunes", "Martes", "Miercoles", "Jueves", "Viernes", "Sabado" };
            double[,] mRegistroDeSocios = new double[7, 5];
            int opcion = 0;

            do
            {
                Console.WriteLine("\n\n1_Ingresar socios\n2_Atencion de socios en un centro y dia especifico\n3_Atencion de socios total por dia\n4_Atencion de socios total por centro\n0_Para finalizar");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        registrosDeVentas(ref mRegistroDeSocios, vCentro, vDias);
                        break;

                    case 2:
                        atencionCenDia(ref mRegistroDeSocios, vCentro, vDias);
                        break;

                    case 3:
                        atencionDia(ref mRegistroDeSocios, vDias);
                        break;

                    case 4:
                        atencionCentro(ref mRegistroDeSocios, vCentro);
                        break;

                    default:
                        Console.WriteLine("Hasta la proxima!!");
                        break;
                }

            } while (opcion > 0 && opcion < 5);
        }
    }
}