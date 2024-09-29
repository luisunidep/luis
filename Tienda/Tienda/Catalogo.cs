using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda
{
    class Catalogo
    {
        public static List<Articulo> Inventario { get; set; }

        private static void LlenarCatalogo()
        {
            Inventario = new List<Articulo>
            {
                new Articulo {Nombre="Jabon", Precio=10.9f,ID=1 },
                new Articulo {Nombre="Mayonesa", Precio=15.13f,ID=2 },
                new Articulo {Nombre="Tomate", Precio=49.12f,ID=3 },
                new Articulo {Nombre="Carne", Precio=120.9f,ID=4 },
                new Articulo {Nombre="Huevos", Precio=99.99f,ID=5 },
                new Articulo {Nombre="Refresco", Precio=58f,ID=6 },
            };
        }
        public static void MostrarCatalogo()
        {
            LlenarCatalogo();
            foreach (Articulo art in Inventario)
            {
                Console.Write($"{art.ID}-{art.Nombre}-{art.Precio:C}\n");
            }
        }
        public static Articulo BuscarArticuloporID(int artID)
        {
            return Inventario.Find(x => x.ID.Equals(artID));
        }
    }
}
