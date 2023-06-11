using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using TicketsProxApi.Controllers;

namespace TicketsProxApi.Models
{
    public class Eventos
    {
        [Key]
        public int Id { get; set; }
        public string? NombreEvento { get; set; }
        public string? LugarEvento { get; set; }
        public string? TipoEvento { get; set; }
        public int CapacidadTotal { get; set; }
        public DateTime FechaEvento { get; set; }
        public string? Hora { get; set; }

        public int ClienteId { get; set; }  
        public EventosCliente? Cliente { get; set; }
        public List<Tickets>? Tickets { get; set; }
    }
}
