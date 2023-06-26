using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketsProxApi.Data;
using TicketsProxApi.Models;


namespace TicketsProxApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsientosController : ControllerBase
    {
        private readonly Contexto _contexto;

        public AsientosController(Contexto contexto)
        {
            _contexto = contexto;
        }

        //GET: api/Asientos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Asientos>>> GetAsientos()
        {
            return await _contexto.Asientos.ToListAsync();
        }

        //GET: api/Asientos/id

        [HttpGet("{id}")]
        public async Task<ActionResult<Asientos>> GetAsientos(int id)
        {
            var asiento = await _contexto.Asientos.FindAsync(id);

            if (asiento == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(asiento);
            }
        }

        //PUT: api/Asientos/

        [HttpPut("{id}")]
        public async Task<IActionResult> putAsientos(int id, Asientos asientos)
        {
            if (id != asientos.Id)
            {
                return BadRequest();
            }

            _contexto.Entry(asientos).State = EntityState.Modified;

            try
            {
                await _contexto.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Asientos>> PostAsientos(Asientos asientos)
        {
            _contexto.Asientos.Add(asientos);
            await _contexto.SaveChangesAsync();

            return CreatedAtAction("GetAsientos", new { id = asientos.Id }, asientos);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsientos(int id)
        {
            var asiento = await _contexto.Asientos.FindAsync(id);
            if (asiento == null)
            {
                return NotFound();
            }

            _contexto.Asientos.Remove(asiento);
            await _contexto.SaveChangesAsync();

            return NoContent();
        }

    }
}
