using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TicketsProxApi.Models
{
    public class Tickets
    {
        [Key]
        public int Id { get; set; }
        public string? Tipo { get; set; }
        public int Cantidad { get; set; }

        public int EventoId { get; set; }  
        public Eventos? Evento { get; set; }  
    }
}
