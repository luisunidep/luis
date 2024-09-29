using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSuper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Carrito cart = new Carrito();
                bool agregarMasArticulos = true;

                while (agregarMasArticulos)
                {
                    Console.WriteLine("Selecciona el articulo:");
                    Catalogo.MostrarCatalogo();
                    int artID = Convert.ToInt32(Console.ReadLine());

                    Articulo articuloSeleccionado = Catalogo.BuscarArticuloPorID(artID);
                    Console.WriteLine("¿Cuántos va a comprar?");
                    articuloSeleccionado.Cantidad = Convert.ToInt32(Console.ReadLine());

                    // Agregar el artículo al carrito
                    cart.AgregarArticulo(articuloSeleccionado);

                    Console.WriteLine("¿Desea agregar otro artículo? (s/n)");
                    agregarMasArticulos = Console.ReadLine().ToLower() == "s";
                }

                // Ir a la caja
                Caja caja = new Caja(1);
                // Mostrar total
                caja.IngresarCarrito(cart);
                // Cobrar y Pagar
                caja.Cobrar();

                Console.WriteLine("¿Desea realizar otra compra? (s/n)");
            } while (Console.ReadLine().ToLower() == "s");

            Console.ReadLine();
        }
    }
}
