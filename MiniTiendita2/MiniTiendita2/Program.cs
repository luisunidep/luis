using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTiendita2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Carrito carrito = new Carrito();
            bool continuar = true;
            while (continuar)
            {
                string nombre = "";
                int cantidad = 0;
                decimal precio = 0;
                Console.WriteLine("Ingresa nombre del producto");
                nombre = Console.ReadLine();
                Console.WriteLine("Ingresa cantidad");
                cantidad = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ingresa precio");
                precio = Convert.ToDecimal(Console.ReadLine());

                if (continuar)
                {
                    Console.WriteLine("Desea realizar otra operacion?");
                    Console.WriteLine("S- SI");
                    Console.WriteLine("N- NO");
                    continuar = char.ToUpper(Console.ReadKey().KeyChar) == 'S';
                    Console.Clear();
                }

                Producto prod = new Producto();
                prod.Nombre = nombre;
                prod.Cantidad = cantidad;
                prod.Precio = precio;
                carrito.AgregarProducto(prod);

                Caja Caja = new Caja();
                Caja.Cobrar(carrito);

                carrito.MostrarCarrito();
                Console.ReadLine();
            }
        }
    }
}