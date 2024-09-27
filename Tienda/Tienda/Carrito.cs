using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda
{
    class Carrito
    {
        public List<Articulo> Lista { get; set; }

        public Carrito()
        {
            Lista = new List<Articulo>();
        }

        public void AgregarArticulo(Articulo articulo)
        {
            // Puedes buscar si el artículo ya está en el carrito y actualizar la cantidad
            var articuloExistente = Lista.Find(a => a.ID == articulo.ID);
            if (articuloExistente != null)
            {
                articuloExistente.Cantidad++;
            }
            else
            {
                articulo.Cantidad = 1; // Inicializamos la cantidad
                Lista.Add(articulo);
            }
        }

        public void MostrarArticulos()
        {
            if (Lista.Count == 0)
            {
                Console.WriteLine("El carrito está vacío.");
                return;
            }

            foreach (var articulo in Lista)
            {
                Console.WriteLine($"{articulo.Nombre} - Cantidad: {articulo.Cantidad} - Precio: {articulo.Precio:C}");
            }
        }

        public float CalcularTotal()
        {
            float total = 0;
            foreach (var articulo in Lista)
            {
                total += articulo.Precio * articulo.Cantidad;
            }
            return total;
        }
    }
}
