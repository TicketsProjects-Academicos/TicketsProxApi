using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TicketsProxApi.Models
{
    public class EventosCliente
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Apellido { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }

        public List<Eventos>? Eventos { get; set; }

    }
}
