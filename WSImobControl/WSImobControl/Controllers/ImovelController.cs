using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WSImobControl.Data;
using WSImobControl.Model;

namespace WSImobControl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImovelController : ControllerBase
    {
        //private static List<Imovel> lista = new List<Imovel>();
        private readonly PostgresDbContext _context;

        public ImovelController(PostgresDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var lista = await _context.Imovel
                            .Include(imo => imo.Proprietario)
                            .OrderBy(imo => imo.Descricao)
                            .ToListAsync();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Imovel imo)
        {
            try
            {
                await _context.Imovel.AddAsync(imo);
                await _context.SaveChangesAsync();
                return Ok("Inclusão realizada com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(Imovel imovel)
        {
            try
            {
                var existe = await _context.Imovel
                             .Where(imo => imo.Id == imovel.Id)
                             .FirstOrDefaultAsync();
                if (existe != null)
                {
                    existe.Titulo = imovel.Titulo;
                    existe.Descricao = imovel.Descricao;
                    existe.Preco = imovel.Preco;
                    existe.Endereco = imovel.Endereco;
                    existe.Status = imovel.Status;
                    existe.ProprietarioId = imovel.ProprietarioId;
                    _context.Imovel.Update(existe);
                    await _context.SaveChangesAsync();
                    return Ok("Alteração realizada com sucesso!");
                }
                else
                {
                    return NotFound("Erro, imóvel não encontrado!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Imovel imovel)
        {
            try
            {
                var existe = await _context.Imovel
                             .Where(imo => imo.Id == imovel.Id)
                             .FirstOrDefaultAsync();
                if (existe != null)
                {
                    _context.Imovel.Remove(existe);
                    await _context.SaveChangesAsync();
                    return Ok("Exclusão realizada com sucesso!");
                }
                else
                {
                    return NotFound("Erro, imóvel não encontrado!");
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
                var existe = await _context.Imovel
                             .Where(imo => imo.Id.ToString() == id)
                             .FirstOrDefaultAsync();
                if (existe != null)
                {
                    _context.Imovel.Remove(existe);
                    await _context.SaveChangesAsync();
                    return Ok("Exclusão realizada com sucesso!");
                }
                else
                {
                    return NotFound("Erro, imóvel não encontrado!");
                }
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
                var imo = await _context.Imovel
                           .Where(imo => imo.Id.ToString() == id)
                           .FirstOrDefaultAsync();
                return Ok(imo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}