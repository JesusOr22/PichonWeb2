
namespace Pichonweb2.Models
{
    public class NuevoContrato
    {
        public int idNuevoContrato { get; set; }
        public int idCliente { get; set; }
        public string NombreCliente { get; set; }
        public int NumeroContacto { get; set; }
        public string FechaEvento { get; set; }
        public string Disponibilidad { get; set; }
        public int HorasRequeridas { get; set; }
        public int Precio { get; set; }
        public int GastosExtra { get; set; }
        public int Anticipo { get; set; }
        public int Restante { get; set; }
        public string HoraEvento { get; set; }
        public string FechaContrato { get; set; }
    
    }
}