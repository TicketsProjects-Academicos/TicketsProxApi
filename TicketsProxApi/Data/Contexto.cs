using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TicketsProxApi.Models;
namespace TicketsProxApi.Data
{
    public class Contexto:DbContext
    {
        public Contexto(DbContextOptions<Contexto> options): base(options)
        {

        }

        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<CompraTickets> CompraTickets { get; set; }
        public DbSet<Eventos> Eventos { get; set; }
        public DbSet<EventosCliente> EventosClientes { get; set; }
        public DbSet<Tickets> Tickets { get; set; }

    }
}
