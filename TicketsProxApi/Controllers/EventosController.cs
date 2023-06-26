using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using TicketsProxApi.Data;
using TicketsProxApi.Models;
using Microsoft.AspNetCore.Mvc;


namespace TicketsProxApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : ControllerBase
    {

        private readonly Contexto _contexto;

        public EventosController(Contexto contexto)
        {
            _contexto = contexto;
        }

        // GET: api/<Eventos>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Eventos>>> GetEventoCliente()
        {

            return await _contexto.Eventos.ToListAsync();
        }

        // GET api/<Eventos>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Eventos>>> GetEvento(int id)
        {
            var evento = await _contexto.Eventos.FindAsync(id);

            if (evento == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(evento);
            }
        }

        // POST api/<Eventos>
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Eventos>>> PostEventoCliente(Eventos evento)
        {
            _contexto.Eventos.Add(evento);
            await _contexto.SaveChangesAsync();

            return CreatedAtAction("GetEvento", new { id = evento.IdEventos }, evento);
        }

        // PUT api/<Eventos>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvento(int id, Eventos evento)
        {
            if (id != evento?.IdEventos)
            {
                return BadRequest();
            }

            _contexto.Entry(evento).State = EntityState.Modified;

            try
            {
                await _contexto.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return NoContent();
        }

        // DELETE api/<Eventos>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var evento = await _contexto.Eventos.FindAsync(id);

            if (evento == null)
            {
                return NotFound();
            }

            _contexto.Eventos.Remove(evento);
            await _contexto.SaveChangesAsync();

            return NoContent();
        }
    }
}
