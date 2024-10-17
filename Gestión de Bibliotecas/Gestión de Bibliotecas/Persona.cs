using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestión_de_Bibliotecas
{
    // Clase Persona (abstracta) que implementa la interfaz IPersona
    public abstract class Persona : IPersona
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public string ObtenerNombreCompleto()
        {
            return $"{Nombre} {Apellido}";
        }
    }
}
