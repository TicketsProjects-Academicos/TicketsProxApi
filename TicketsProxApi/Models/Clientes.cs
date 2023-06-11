using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TicketsProxApi.Models
{
    public class Clientes
    {
        [Key]
        public int IdCliente { get; set; }
        public string? Nombre { get; set;}
        public string? Apellido { get;set;}
        public string? Identificacion { get; set; }
        public string? Correo { get; set; } 
        public string? Password { get; set; }

        //public List<Tickets>? Tickets { get; set; }
        //public List<CompraTickets>? CompraTickets { get; set; }
    }
}
