using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSuper
{
    class Caja
    {
        private static int NumCompra = 0;
        public int Numero { get; set; }
        private decimal Pagando { get; set; }
        public float Cambio { get; set; }
        private Carrito Cart { get; set; }
        private float Subtotal = 0;
        private float Total = 0;

        public Caja(int numero)
        {
            Numero = numero;
        }

        public void IngresarCarrito(Carrito cart)
        {
            Cart = cart;
            foreach (Articulo articulo in cart.Lista)
            {
                Subtotal += articulo.Precio * articulo.Cantidad;
            }
            MostrarTotales();
        }

        public void MostrarTotales()
        {
            float iva = Subtotal * .16f;
            Total = Subtotal + iva;

            Console.WriteLine($"Sub total : {Math.Round(Subtotal, 2):0.00}");
            Console.WriteLine($"I.V.A. : {Math.Round(iva, 2):0.00}");
            Console.WriteLine($"Total : {Math.Round(Total, 2):0.00}");
        }

        public void Cobrar()
        {
            Console.WriteLine("Ingrese cantidad a pagar:");
            Pagando = Convert.ToDecimal(Console.ReadLine());
            Cambio = (float)Pagando - Total;

            ImprimirTicket();
        }

        private void ImprimirTicket()
        {
            Console.Clear();
            NumCompra++;
            Ticket ticket = new Ticket
            {
                Fecha = DateTime.Now,
                NumCompra = NumCompra,
                Lista = Cart.Lista,
                Total = (decimal)Total,
                Pagado = Pagando,
                Cambio = (decimal)Cambio,
                IVA = (decimal)(Subtotal * 0.16f)
            };

            // Mostrar el ticket
            Console.WriteLine($"Fecha: {ticket.Fecha}");
            Console.WriteLine($"Caja: {Numero}");
            Console.WriteLine($"N Compra: {ticket.NumCompra}");

            foreach (Articulo articulo in ticket.Lista)
            {
                Console.WriteLine($"{articulo.Nombre} - {Math.Round(articulo.Precio, 2):0.00} - {articulo.Cantidad} - {Math.Round(articulo.Precio * articulo.Cantidad, 2):0.00}");
            }

            Console.WriteLine($"I.V.A.: {Math.Round(ticket.IVA, 2):0.00}");
            Console.WriteLine($"Total: {Math.Round(ticket.Total, 2):0.00}");
            Console.WriteLine($"Pagado: {Math.Round(ticket.Pagado, 2):0.00}");
            Console.WriteLine($"Cambio: {Math.Round(ticket.Cambio, 2):0.00}");
        }
    }
}
