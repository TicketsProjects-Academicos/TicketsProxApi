using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketsProxApi.Data;
using TicketsProxApi.Models;

namespace TicketsProxApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeccionesController : ControllerBase
    {
        private readonly Contexto _contexto;

        public SeccionesController(Contexto contexto)
        {
            _contexto = contexto;
        }
        // GET: api/<SeccionesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Secciones>>> GetSecciones()
        {

            return await _contexto.Secciones.ToListAsync();
        }

        // GET api/<SeccionesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Secciones>>> GetSecciones(int id)
        {
            var seccion = await _contexto.Asientos.FindAsync(id);

            if (seccion == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(seccion);
            }
        }

        // POST api/<SeccionesController>
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Secciones>>> PostSeccion(Secciones secciones)
        {

            _contexto.Secciones.Add(secciones);
            await _contexto.SaveChangesAsync();

            return CreatedAtAction("GetSecciones", new { id = secciones.IdSecciones }, secciones);
        }

      
        // PUT api/<SeccionesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSecciones(int id, Secciones seccion)
        {
            if (id != seccion?.IdSecciones)
            {
                return BadRequest();
            }

            _contexto.Entry(seccion).State = EntityState.Modified;

            try
            {
                await _contexto.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return NoContent();
        }

        // DELETE api/<SeccionesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var seccion = await _contexto.Secciones.FindAsync(id);

            if (seccion == null)
            {
                return NotFound();
            }

            _contexto.Secciones.Remove(seccion);
            await _contexto.SaveChangesAsync();

            return NoContent();
        }

    }
}
