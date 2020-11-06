using System;
/*38.	La misma cadena de electrodomésticos anterior comienza a recibir un informe consolidado de ventas  por productos. Conteniendo la siguiente información”
•	Producto vendido (alfabético 5 caracteres)
•	Código de sucursal(alfabético 3 caracteres)
•	Cantidad vendida (numérico entero)

El listado se encuentra ordenado en la forma que están informados los datos anteriores.
Se pide:
•	Informar código y cantidad del producto más vendido.
•	Informar la cantidad del producto con menor venta.
*/
namespace Ej38
{
    class Ej38
    {
        static void Main(string[] args)
        {
            //declaracion de variables
            String productoVendido = "";
            int cantidadVendida = 0;
            String codigoProdAux = "";
            int cantVProd = 0;
            String ProdMenosVentas = "";
            String prodMasVentas = "";
            int ProdMasVendido = 0;
            int ProdMenosVendido = 0;

            //ingresamos codigo de sucursal
            Console.WriteLine("Ingrese codigo de producto");
            productoVendido = Console.ReadLine();
            //asignamos a la variable auxiliar el codigo de producto para realizar el corte de control mas adelante
            codigoProdAux = productoVendido;

            //este while nos permitira salir del programa
            while (!productoVendido.Equals("000"))
            {
                //este sirve para ingresar los datos y ralizar el primer corte de control              
                while (productoVendido.Equals(codigoProdAux) && !productoVendido.Equals("000"))
                {
                    //ingresamos y acumulamos cantidad
                    Console.WriteLine("Ingrese cantidad vendida");
                    cantidadVendida += int.Parse(Console.ReadLine());

                    //en este punto ingresamos un nuevo producto o finalizamos el programa
                    Console.WriteLine("Ingrese producto, Para finalizar ingrese 000");
                    productoVendido = Console.ReadLine();
                }


                //en este if vamos a calcular que producto se vendio mas
                if (cantidadVendida > ProdMasVendido)
                {

                    prodMasVentas = codigoProdAux;
                    ProdMasVendido = cantidadVendida;

                }
                //en este if calcularemos que producto se vendio menos
                if (ProdMenosVendido == 0)
                {
                    ProdMenosVendido = cantidadVendida;
                    ProdMenosVentas = codigoProdAux;
                }
                else
                {
                    if (cantidadVendida < ProdMenosVendido)
                    {
                        ProdMenosVentas = codigoProdAux;
                        ProdMenosVendido = cantidadVendida;
                    }
                }

                //reiniciamos variables para ingresar una nuevo producto si es necesario
                codigoProdAux = productoVendido;
                cantidadVendida = 0;

            }

            //mostramos que produccto fue el que mas vendio y el que menos vendio
            Console.WriteLine($"El producto con mayor venta fue {prodMasVentas} y vendió {ProdMasVendido} productos");
            Console.WriteLine($"El producto con menor venta fue {ProdMenosVentas} y vendió {ProdMenosVendido} productos");
        }
    }
}
