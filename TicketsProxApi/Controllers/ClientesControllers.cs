using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketsProxApi.Data;
using TicketsProxApi.Models;

namespace TicketsProxApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesControllers : ControllerBase
    {
        private readonly Contexto? _contexto;

        public ClientesControllers(Contexto? contexto)
        {
            _contexto = contexto;
        }

        //GET: api/Clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clientes>>> GetClientes()
        {
            return await _contexto.Clientes.ToListAsync();
        }

        //GET: api/Clientes/id

        [HttpGet("{id}")]
        public async Task<ActionResult<Clientes>> GetClientes(int id)
        {
            var cliente = await _contexto.Clientes.FindAsync(id);

            if(cliente == null)
            {
                return NotFound();
            }else
            {
                return Ok(cliente);
            }
        }

        //PUT: api/Clientes/

        [HttpPut("{id}")]
        public async Task<IActionResult> putClientes(int id, Clientes clientes)
        {
            if(id != clientes.IdCliente)
            {
                return BadRequest();
            }

            _contexto.Entry(clientes).State = EntityState.Modified;

            try
            {
                await _contexto.SaveChangesAsync();

            }catch (DbUpdateConcurrencyException) 
            {
               
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Clientes>> PostClientes(Clientes clientes)
        {
            _contexto.Clientes.Add(clientes);
            await _contexto.SaveChangesAsync();

            return CreatedAtAction("GetClientes", new { id = clientes.IdCliente }, clientes);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClientes(int id)
        {
            var cliente = await _contexto.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            _contexto.Clientes.Remove(cliente);
            await _contexto.SaveChangesAsync();

            return NoContent();
        }
    }
}
