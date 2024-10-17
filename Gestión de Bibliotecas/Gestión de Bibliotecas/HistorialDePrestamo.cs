using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestión_de_Bibliotecas
{
    // Clase HistorialDePrestamo para mantener el registro de préstamos anteriores
    public class HistorialDePrestamo
    {
        public FormLibros Libro { get; set; }
        public FormLectores Lector { get; set; }
        public DateTime FechaPrestamo { get; set; }
    }
}
