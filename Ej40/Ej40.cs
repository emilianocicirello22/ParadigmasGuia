using System;
/*40.	Una gran cadena de electrodoméstico recibe mensualmente un informe consolidado de todas sus sucursales  conteniendo la siguiente información:
•	Código de sucursal (alfabético 3 caracteres) 
•	Producto vendido (alfabético 5 caracteres)
•	Cantidad vendida (numérico entero)

El listado se encuentra ordenado por código de sucursal, producto y cantidad vendida.

Se pide informar:
	Cantidad total vendida por cada sucursal Respetando la siguiente leyenda “La sucursal XXX vendióyyyyyy productos”
	Sucursal con la mejor venta, se debe respetar la siguiente leyenda: “La sucursal con mejor venta fue XXX y vendióyyyyy  productos”
 */
namespace Ej40
{
    class Ej40
    {
        static void Main(string[] args)
        {
            //declaracion de variables
            String codigoSucursal = "";
            String productoVendido = "";
            int cantidadVendida = 0;
            String codigoSucAux = "";
            int cantVsucursal = 0;
            String sucMasVentas = "";

            //ingresamos codigo de sucursal
            Console.WriteLine("Ingrese codigo de sucursal");
            codigoSucursal = Console.ReadLine();
            //asignamos a la variable auxiliar el codigo de sucursal para realizar el corte de control mas adelante
            codigoSucAux = codigoSucursal;

            //este while nos permitira salir del programa
            while (!codigoSucursal.Equals("y"))
            {
                //este sirve para ingresar los datos y ralizar el primer corte de control              
                while (codigoSucursal.Equals(codigoSucAux) && !codigoSucursal.Equals("y"))
                {
                    //ingresamos productos
                    Console.WriteLine("Ingrese Producto");
                    productoVendido = Console.ReadLine();

                    //ingresamos y acumulamos cantidad
                    Console.WriteLine("Ingrese cantidad vendida");
                    cantidadVendida += int.Parse(Console.ReadLine());

                    //en este punto ingresamos una nueva sucursal o finalizamos el programa
                    Console.WriteLine("Ingrese codigo de sucursal, Para finalizar ingrese Y");
                    codigoSucursal = Console.ReadLine();
                }
                //mostramos venta por sucursal
                Console.WriteLine($"La Sucursal: {codigoSucAux} Vendio {cantidadVendida} Productos");

                //en este if vamos a calcular que sucusal vendio mas
                if (cantVsucursal < cantidadVendida)
                {

                    sucMasVentas = codigoSucAux;
                    cantVsucursal = cantidadVendida;

                }


                //reiniciamos variables para ingresar una nueva sucursal si es necesario
                codigoSucAux = codigoSucursal;
                cantidadVendida = 0;

            }

            //mostramos que sucursal fue la que mas vendio
            Console.WriteLine($"La sucursal con mejor venta fue {sucMasVentas} y vendió {cantVsucursal} productos");
        }
    }
}
