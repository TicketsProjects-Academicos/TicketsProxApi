using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using TicketsProxApi.Controllers;

namespace TicketsProxApi.Models
{
    public class CompraTickets
    {
        [Key]
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int EventoId { get; set; }
        public int TaquillaId { get; set; }
        public int CantidadTickets { get; set; }
        public decimal PrecioTotal { get; set; }
        public DateTime FechaCompra { get; set; }

        public Clientes? Cliente { get; set; }
        public Eventos? Evento { get; set; }
        public List<Tickets>? Taquilla { get; set; }
    }
}
