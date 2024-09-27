﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda
{ 
    //lista del articulo
    //IVA
    //total, pagado y cambio
    //fecha
    //numero de compra
    class Ticket
    {
        public List<Articulo>Lista {  get; set; }
        public decimal Total { get; set; }
        public decimal Pagado { get; set; }
        public decimal Cambio { get; set; }
        public DateTime Fecha { get; set; }
        public int NumCompra {  get; set; }
        public decimal IVA { get; set; }


    }
}
