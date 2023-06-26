using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TicketsProxApi.Models
{
    public class Secciones
    {
        [Key]
        public int IdSecciones { get; set; }
        public int IdEventos { get; set; }
        public string? NombreSeccion { get; set; }
        public int Capacidad { get; set; }
        public double Precio { get; set; }



    }
}
