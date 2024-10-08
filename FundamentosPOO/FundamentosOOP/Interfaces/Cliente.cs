using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundamentosPOO.Interfaces
{
    internal class Cliente : IUsuario
    {
        public string Nombre { get; set; }
        public string Email { get; set; }

        public bool ActualizaPerfil(string nombre, string Email)
        {
            throw new NotImplementedException();
        }

        public void Login()
        {
            throw new NotImplementedException();
        }
    }
}
