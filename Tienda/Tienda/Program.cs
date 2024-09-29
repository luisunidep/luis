using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Carrito carrito = new Carrito(); // Crear una instancia del carrito
            while (true)
            {
                Console.WriteLine("Selecciona el artículo (o escribe 'salir' para terminar):");
                Catalogo.MostrarCatalogo();
                string input = Console.ReadLine();
                // Permitir salir del bucle
                if (input.ToLower() == "s")
                {
                    break;
                }
                if (int.TryParse(input, out int artID))
                {
                    Articulo articuloSeleccionado = Catalogo.BuscarArticuloporID(artID);
                    if (articuloSeleccionado != null)
                    {
                        carrito.AgregarArticulo(articuloSeleccionado);
                        Console.WriteLine($"{articuloSeleccionado.Nombre} ha sido agregado al carrito.");
                    }
                    else
                    {
                        Console.WriteLine("Artículo no encontrado.");
                    }
                }
                else
                {
                    Console.WriteLine("Entrada no válida. Por favor, introduce un número de ID.");
                }
            }
            // Mostrar el contenido del carrito al finalizar
            Console.WriteLine("\nContenido del carrito:");
            carrito.MostrarArticulos();
            Console.WriteLine($"Total: {carrito.CalcularTotal():C}");
            Console.ReadLine();
        }
    }
}