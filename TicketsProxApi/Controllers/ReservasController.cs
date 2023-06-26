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
    public class ReservasController : ControllerBase
    {
        private readonly Contexto _contexto;

        public  ReservasController(Contexto contexto)
        {
            _contexto = contexto;
        }
        // GET: api/<ReservasController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservas>>> GetReservas()
        {

           return await _contexto.Reservas.ToListAsync();
        }

        // GET api/<ReservasController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Reservas>>> GetReservas(int id)
        {
           var compra = await _contexto.Reservas.FindAsync(id);

           if(compra == null)
            {
                return NotFound();
            }else
            {
                return Ok(compra);
            }
        }

        // POST api/<ReservasController>
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Reservas>>> PostReservas(Reservas reservas)
        {
            _contexto.Reservas.Add(reservas);
            await _contexto.SaveChangesAsync();

            return CreatedAtAction("GetReservas", new { id = reservas.Id }, reservas);
        }

        // PUT api/<ReservasController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReservas(int id, Reservas reservas)
        {
            if(id != reservas?.Id)
            {
                return BadRequest();
            }

            _contexto.Entry(reservas).State = EntityState.Modified;

            try
            {
                await _contexto.SaveChangesAsync();
            }catch (DbUpdateConcurrencyException)
            {

            }

            return NoContent();
        }

        // DELETE api/<ReservasController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var compra = await _contexto.Reservas.FindAsync(id);

            if (compra == null)
            {
                return NotFound();  
            }

            _contexto.Reservas.Remove(compra);   
            await _contexto.SaveChangesAsync();

            return NoContent();
        }
    }
}
