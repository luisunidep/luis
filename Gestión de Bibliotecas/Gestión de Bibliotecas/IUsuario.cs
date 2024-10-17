using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestión_de_Bibliotecas
{
    // Interfaz IUsuario para roles de usuario
    public interface IUsuario
    {
        bool Login(string nombreUsuario, string contraseña);
        void Logout();
    }

    // Interfaz IPersona para características comunes entre Autor y Lector
    public interface IPersona
    {
        string ObtenerNombreCompleto();
    }

}
