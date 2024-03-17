using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pichonweb2.Models
{
    public class Dirección
    {
        public string idDirección { get; set; }
        public string idCliente { get; set; }
        public string Calle { get; set; }
        public string Numero { get; set; }
        public int CP { get; set; }
        public string idMunicipio { get; set; }
        public string idEstado { get; set; }                      
    }
}