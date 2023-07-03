using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using TicketsProxApi.Data;
using TicketsProxApi.Models;

//using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace TicketsProxApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesControllers : ControllerBase
    {
        private readonly Contexto _contexto;
        private readonly IConfiguration _config;

        public ClientesControllers(Contexto contexto, IConfiguration configuration)
        {
            _config = configuration;
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
        public dynamic LoginUser([FromBody] object dataUser)
        {
            var data = JsonConvert.DeserializeObject<dynamic>(dataUser.ToString());
            string email = data.email;
            string password = data.password;
            Clientes clientes = _contexto.Clientes.Where(c => c.Correo == email && c.Password == password).FirstOrDefault();

            if(clientes == null)
            {
                return new
                {
                    success = false,
                    message = "Credenciales Incorrectas",
                    result = ""
                };
            }

            var jwt = _config.GetSection("Jwt").Get<Jwt>();

            //Encapsular los token: especifico
            var claims = new[]
            {
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub, jwt.Subject),
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("Id", clientes.IdCliente.ToString()),
                new Claim("Password", clientes.Password)
                 
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.key));

            var singIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                jwt.Issuer,
                jwt.Audience,
                claims,
                expires: DateTime.Now.AddMinutes(60)

             );

            return new
            {
                succes = true,
                message = "Exito",
                Nombre = clientes.Nombre,
                Correo = clientes.Correo,
                result = new JwtSecurityTokenHandler().WriteToken(token)
            };


        }

        [HttpPost]
        [Route("signin")]
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
