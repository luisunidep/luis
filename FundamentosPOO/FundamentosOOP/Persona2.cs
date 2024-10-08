using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundamentosPOO
{
    //Herda de clase Persona
    internal class Persona2 : Persona
    {
        public Persona2(string nombre, string email, int id)
        {
            Nombre = nombre;
            Email = email;
            ID = id;
            ImprimeID();
            ImprimeNombre();
            ImprimeEmail();
            ImprimeFecha();
        }

        public void ImprimeEmail()
        {
            Console.WriteLine(Email);
        }

    }
}
