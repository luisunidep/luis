using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundamentosPOO.abstractas
{
    internal class Circulo : Figura
    {
        public int Radio { get; set; }

        public Circulo()
        {
            Nombre = "Círculo";
        }

        public override void CalculaArea()
        {
            Area = (int)(Math.PI * Radio * Radio);
        }

        public override void CalcularPerimetro()
        {
            Perimetro = (int)(2 * Math.PI * Radio);
        }
    }
}