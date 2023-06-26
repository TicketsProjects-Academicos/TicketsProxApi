using System.ComponentModel.DataAnnotations;

namespace TicketsProxApi.Models
{
    public class Reservas
    {
        [Key]
        public int Id { get; set; }
        public string? Cliente { get; set; }
        public string? Evento { get; set; }
        public string? Seccion { get; set; }
        public string? Asiento { get; set; }
    }
}
