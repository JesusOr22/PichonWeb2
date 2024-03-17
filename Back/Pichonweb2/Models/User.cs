using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pichonweb2.Models
{
    public class User
    {
        public int idUsuarios { get; set; }
        public string Nombre { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public string Teléfono { get; set; }
        public bool Activo { get; set; }
    }
}