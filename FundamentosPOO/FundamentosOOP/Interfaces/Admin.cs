using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundamentosPOO.Interfaces
{
    internal class Admin : IUsuario
    {
        public string Nombre { get; set ; }
        public string Email { get; set ; }
        public int Nivel { get; set; }

        public bool ActualizaPerfil(string nombre, string Email)
        {
            //actualizar informacion
            return true;
        }

        public void Login()
        {
            //hacer conexion a base de datos y buscar en la tabla de admins
            Console.WriteLine("Usuario logeado");
        }
    }
}
