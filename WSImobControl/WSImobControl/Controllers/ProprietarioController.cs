using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WSImobControl.Data;
using WSImobControl.Model;

namespace WSImobControl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProprietarioController(PostgresDbContext context) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var lista = await context.Proprietario
                                   .OrderBy(prop => prop.Nome)
                                   .ToListAsync();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Proprietario prop)
        {
            try
            {
                context.Proprietario.Add(prop);
                await context.SaveChangesAsync();
                return Ok("Inclusão realizada com sucesso!");
            }
            catch(Exception ex)
            {
                 return BadRequest("Erro, iclusão não realizada." + ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(Proprietario proprietario)
        {
            try
            {
                var existe = await context.Proprietario
                         .Where(prop => prop.Id == proprietario.Id)
                         .FirstOrDefaultAsync();
                if (existe != null)
                {
                    existe.Nome = proprietario.Nome;
                    existe.Status = proprietario.Status;
                    context.Proprietario.Update(existe);
                    await context.SaveChangesAsync();
                    return Ok("Alteração realizada com sucesso!");
                }
                else
                {
                    return NotFound("Erro! Proprietario não encontrado!");
                }
            }
            catch(Exception ex)
            {
                return BadRequest("Erro ao alterar" + ex.Message);
            }
            
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Proprietario proprietario)
        {
            try
            {
                var existe = await context.Proprietario
                         .Where(prop => prop.Id == proprietario.Id)
                         .FirstOrDefaultAsync();
                if (existe != null)
                {
                    context.Proprietario.Remove(existe);
                    await context.SaveChangesAsync();
                    return Ok("Exclusão realizada com sucesso!");
                }
                else
                {
                    return NotFound("Erro! Proprietario não encontrado!");
                }
            }
            catch (Exception ex) 
            {
                return BadRequest("Erro ao deketar" + ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete2(string id)
        {
            try
            {
                var existe = await context.Proprietario
                             .Where(prop => prop.Id.ToString() == id)
                             .FirstOrDefaultAsync();
                if (existe != null)
                {
                    context.Proprietario.Remove(existe);
                    await context.SaveChangesAsync();
                    return Ok("Exclusão realizada com sucesso!");
                }
                else
                {
                    return NotFound("Erro! Proprietario não encontrado!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao deletar" + ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get2([FromRoute] string id)
        {
            var prop = await context.Proprietario
                       .Where(prop => prop.Id.ToString() == id)
                       .FirstOrDefaultAsync();
            return Ok(prop);
        }
    }
}
