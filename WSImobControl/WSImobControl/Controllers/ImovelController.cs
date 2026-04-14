using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WSImobControl.Data;
using WSImobControl.Model;

namespace WSImobControl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImovelController(PostgresDbContext context) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var lista = await context.Imovel
                                   .OrderBy(imob => imob.Titulo)
                                   .ToListAsync();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get2([FromRoute] string id)
        {
            try
            {
                var imov = await context.Imovel
                                 .Where(imov => imov.Id.ToString() == id)
                                 .FirstOrDefaultAsync();
                return Ok(imov);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post(Imovel imov)
        {
            try
            {
                context.Imovel.Add(imov);
                await context.SaveChangesAsync();
                return Ok("Inclusão realizada com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(Imovel Imovel)
        {
            try
            {
                var existe = await context.Imovel
                         .Where(imov => imov.Id == Imovel.Id)
                         .FirstOrDefaultAsync();
                if (existe != null)
                {
                    existe.Titulo = Imovel.Titulo;
                    existe.Descricao = Imovel.Descricao;
                    existe.Preco = Imovel.Preco;
                    existe.Endereco = Imovel.Endereco;
                    existe.Status = Imovel.Status;
                    context.Imovel.Update(existe);
                    await context.SaveChangesAsync();
                    return Ok("Alteração realizada com sucesso!");
                }
                else
                {
                    return NotFound("Erro! Imovel não encontrado!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Imovel Imovel)
        {
            try
            {
                var existe = await context.Imovel
                         .Where(imov => imov.Id == Imovel.Id)
                         .FirstOrDefaultAsync();
                if (existe != null)
                {
                    context.Imovel.Remove(existe);
                    await context.SaveChangesAsync();
                    return Ok("Exclusão realizada com sucesso!");
                }
                else
                {
                    return NotFound("Erro! Imovel não encontrado!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete2(string id)
        {
            try
            {
                var existe = await context.Imovel
                         .Where(imov => imov.Id.ToString() == id)
                         .FirstOrDefaultAsync();
                if (existe != null)
                {
                    context.Imovel.Remove(existe);
                    await context.SaveChangesAsync();
                    return Ok("Exclusão realizada com sucesso!");
                }
                else
                {
                    return NotFound("Erro! Imovel não encontrado!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
