using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WSImobControl.Data;
using WSImobControl.Model;

namespace WSImobControl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelefoneController : ControllerBase
    {
        private readonly PostgresDbContext _context;

        public TelefoneController(PostgresDbContext context)
        {
            _context = context;
        }

        // GET: api/Telefone
        [HttpGet]
        public async Task<IActionResult> GetTelefone()
        {
            try
            {
                var lista = await _context.Telefone
                    .Include(tel => tel.Proprietario)
                    .ToListAsync();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Telefone/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTelefone(Guid id)
        {
            try
            {
                var telefone = await _context.Telefone
                    .Include(tel => tel.Proprietario)
                    .Where(tel => tel.Id == id)
                    .FirstOrDefaultAsync();

                if (telefone == null)
                {
                    return NotFound();
                }

                return Ok(telefone);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // PUT: api/Telefone/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTelefone(Guid id, Telefone telefone)
        {
            if (id != telefone.Id)
            {
                return BadRequest();
            }

            _context.Entry(telefone).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TelefoneExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Telefone
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostTelefone(Telefone telefone)
        {
            try
            {
                _context.Telefone.Add(telefone);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetTelefone", new { id = telefone.Id }, telefone);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Telefone/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTelefone(Guid id)
        {
            try
            {
                var telefone = await _context.Telefone.FindAsync(id);
                if (telefone == null)
                {
                    return NotFound();
                }

                _context.Telefone.Remove(telefone);
                await _context.SaveChangesAsync();

                return Ok("telefone excluído com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private bool TelefoneExists(Guid id)
        {
            return _context.Telefone.Any(e => e.Id == id);
        }
    }
}