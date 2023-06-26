using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using TicketsProxApi.Controllers;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketsProxApi.Models
{
    public class Eventos
    {
        [Key]
        public int IdEventos { get; set; }
        public string? NombreEvento { get; set; }
        public string? Descripcion { get; set; }
        public string? Image { get; set; }
        public string? LugarEvento { get; set; }
        public string? TipoEvento { get; set; }
        public int CapacidadTotal { get; set; }
        public DateTime FechaEvento { get; set; }
        public string? Hora { get; set; }



    }
}
