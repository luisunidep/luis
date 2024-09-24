using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTiendita2
{
    class Caja
    {
        //mostrar la lista de productos y el total del carrito
        public void Cobrar(Carrito carrito)
        {
            decimal total = 0;

            foreach (Producto producto in carrito.Lista)
            {
                total += producto.Cantidad * producto.Precio;
            }
            Console.WriteLine($"El total a pagar es:{total:c}");
        }
    }
}
