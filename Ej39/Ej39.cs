using System;
/*38.	Una institución educativa necesita evaluar la evolución  de 5 materias correspondientes a primer, segundo y tercer año de carrera. (1. Matemática, 2. Lengua, 3 Historia, 4 Geografía, 5 Tecnología)
 Para realizar esta tarea se dispone de un listado, ordenado por Número de curso y Código de materiaque contiene la siguiente información:
•	Número de curso (valores de 1 a 3)
•	Código de Materia (valores de 1 a 5)
•	Nota del Examen finalde cada alumno

Se pide informar:
•	Por cada materia se pide saber el promedio de nota de todo el curso
•	La cantidad de alumnos aprobados
•	La cantidad de alumnos desaprobados aprobados
•	La materia con mayor índice de aprobación
•	La materia con menor índice de aprobación
*/
namespace Ej39
{
    class Ej39
    {
        static void Main(string[] args)
        {
            //Inicializamos variables
            String msg1 = "Ingrese un numero para selecionar el curso: \n 1-Primero \n 2-Segundo \n 3-Tercero \n 0 Finalizar";
            String msg2 = "Ingrese un numero para selecionar la materia: \n 1-Matematicas \n 2-Lengua \n 3-Historia \n 4-Geografia \n 5-Tecnologia \n 0-Para Cambiar de curso ";
            String nombreMateria = "";

            //variables indicadoras de corte
            int materia = 0, curso = 0;

            //variable para promedio y nota individual
            double nota = 0;
            double notaFinal = 0;


            //variables contadores
            int contAlu = 0;
            int aprobados = 0, desaprobados = 0;

            //variables comparativas
            int compMateria = 0;

            //indice de aprobacion y desaprovacion
            int indAp = 0, inddesap = 0;
            String matA = "", matD = "";

            //ingresamos el curso
            Console.WriteLine(msg1);
            curso = int.Parse(Console.ReadLine());

            while (curso != 0)
            {
                //ingresamos Materia
                Console.WriteLine(msg2);
                materia = int.Parse(Console.ReadLine());

                //cargamos a la variable comparitiva para poder entrar al ciclo
                compMateria = materia;

                while (curso != 0 && materia == compMateria)
                {

                    //ingresamos nota
                    Console.WriteLine("Ingrese nota final");
                    nota = int.Parse(Console.ReadLine());
                    notaFinal = notaFinal + nota;

                    //contamos alumnos aprobados y desaprovados 
                    if (nota >= 6)
                    {
                        aprobados++;
                    }
                    else
                    {
                        desaprobados++;
                    }

                    //contamos alumno para promediar nota
                    contAlu++;

                    //reingresamos la materia
                    Console.WriteLine(msg2);
                    materia = int.Parse(Console.ReadLine());

                }
                //calculamos promedio
                notaFinal = (double)notaFinal / contAlu;

                //asignamos nombre a la materia
                switch (compMateria)
                {
                    case 1:
                        nombreMateria = "Matematica";
                        break;

                    case 2:
                        nombreMateria = "Lengua";
                        break;

                    case 3:
                        nombreMateria = "Historia";
                        break;

                    case 4:
                        nombreMateria = "Geogafia";
                        break;

                    case 5:
                        nombreMateria = "Tecnologia";
                        break;
                }


                //mostramos el promedio por materia
                Console.WriteLine($"El promedio del curso numero {curso} en la materia {nombreMateria} es de {notaFinal}");

                //mostramos la cantidad de alumnos aprovados y desaprovados
                Console.WriteLine($"La cantidad de alumnos aprobados es: {aprobados}");
                Console.WriteLine($"La cantidad de alumnos desaprobados es: {desaprobados}");

                //mayor indice de aprobacion
                if (indAp < aprobados)
                {
                    matA = nombreMateria;
                    indAp = aprobados;
                }

                //menor indice de aprovacion
                if (inddesap == 0)
                {
                    inddesap = indAp;
                    matD = nombreMateria;
                }
                else
                {
                    if (inddesap > aprobados)
                    {
                        matD = nombreMateria;
                        inddesap = aprobados;

                    }
                }


                //reestablecemos variables
                compMateria = materia;
                aprobados = 0;
                desaprobados = 0;
                notaFinal = 0;
                contAlu = 0;

                //Reingresamos el curso
                if (materia == 0)
                {
                    Console.WriteLine(msg1);
                    curso = int.Parse(Console.ReadLine());
                }
            }

            //mostramos indice de aprobacion
            Console.WriteLine($"La materia con mayor indice de aprobacion es {matA} con {indAp} alumnos aprobados");
            Console.WriteLine($"La materia con menor indice de aprobacion es {matD} con {inddesap} alumnos aprobados");

            //reiniciamos variables
            indAp = 0;
            inddesap = 0;
        }
    }
}
