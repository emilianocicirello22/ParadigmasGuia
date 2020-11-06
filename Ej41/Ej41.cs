using System;

namespace Ej41
{
    class Ej41
    {
        static void Main(string[] args)
        {
            double peso=0, pesoUno=0, pesoDos=0, pesoTres=0, pesoMin=0, pesoMax = 0;
            int edad, C1=0, C2=0, C3=0, C4 = 0;

            for (int i = 0; i < 300; i++)
            {
                Console.WriteLine("Ingrese edad del niño");
                edad = int.Parse(Console.ReadLine());

                Console.WriteLine("Ingrese peso del niño");
                peso = int.Parse(Console.ReadLine());

                if(edad > 0 && edad <= 1)
                {
                    C1++;
                 
                    pesoUno += peso;

                }else
                {
                    if (edad > 1 && edad <= 3)
                    {
                        C2++;
                        pesoDos += peso;

                    }
                    else
                    {
                        if(edad > 3 && edad <= 5)
                        {
                            C3++;
                            pesoTres += peso;


                        }
                        else
                        {
                            C4++;

                        }
                    }
                        

                }

                if(i == 1)
                {
                    pesoMin = peso;

                }else if (pesoMin > peso) 
                {
                    pesoMin = peso;

                }

                if (pesoMax < peso)
                {
                    pesoMin = peso;

                }
            }
            pesoUno = pesoUno / C1;
            pesoUno = pesoDos / C2;
            pesoUno = pesoTres / C3;

            Console.WriteLine("El peso promedio del rango comprendido de 0 a 1 año es: " + C1);
            Console.WriteLine("El peso promedio del rango comprendido de 1 a 3 años es: " + C2);
            Console.WriteLine("El peso promedio del rango comprendido de 3 a 5 años es: " + C3);
            Console.WriteLine("La cantidad de niños atendidos fuera del rango de edades es: " + C4);
            Console.WriteLine("El peso mínimo de los niños atendidos es: " + pesoMin);
            Console.WriteLine("El peso máximo de los niños atendido es: " + pesoMax);

        }
    }
}
