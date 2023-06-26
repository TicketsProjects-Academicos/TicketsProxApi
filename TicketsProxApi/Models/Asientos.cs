using System.ComponentModel.DataAnnotations;
namespace TicketsProxApi.Models
{
    public class Asientos
    {
        [Key]
        public int Id { get; set; }
        public int IdSecciones { get; set; }
        public string? Numero { get; set; }
        public bool Reservado { get; set; }

    
    }
}
