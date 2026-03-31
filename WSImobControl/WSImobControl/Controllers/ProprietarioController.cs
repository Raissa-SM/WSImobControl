using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSImobControl.Data;
using WSImobControl.Model;

namespace WSImobControl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProprietarioController(PostgresDbContext context) : ControllerBase
    {
        [HttpGet]
        public List<Proprietario> Get()
        {
            var lista = context.Proprietario
                               .OrderBy(prop => prop.Nome)
                               .ToList();
            return lista;
        }

        [HttpPost]
        public string Post(Proprietario prop)
        {
            context.Proprietario.Add(prop);
            context.SaveChanges();
            return "Inclusão realizada com sucesso!";
        }

        [HttpPut]
        public string Put(Proprietario proprietario)
        {
            var existe = context.Proprietario
                         .Where(prop => prop.Id == proprietario.Id)
                         .FirstOrDefault();
            if (existe != null)
            {
                existe.Nome = proprietario.Nome;
                existe.Status = proprietario.Status;
                context.Proprietario.Update(existe);
                context.SaveChanges();
                return "Alteração realizada com sucesso!";
            }
            else
            {
                return "Erro! Proprietario não encontrado!";
            }
        }

        [HttpDelete]
        public string Delete(Proprietario proprietario)
        {
            var existe = context.Proprietario
                         .Where(prop => prop.Id == proprietario.Id)
                         .FirstOrDefault();
            if (existe != null)
            {
                context.Proprietario.Remove(existe);
                context.SaveChanges() ;
                return "Exclusão realizada com sucesso!";
            }
            else
            {
                return "Erro! Proprietario não encontrado!";
            }
        }

        [HttpDelete("{id}")]
        public string Delete2(string id)
        {
            var existe = context.Proprietario
                         .Where(prop => prop.Id.ToString() == id)
                         .FirstOrDefault();
            if (existe != null)
            {
                context.Proprietario.Remove(existe);
                context.SaveChanges();
                return "Exclusão realizada com sucesso!";
            }
            else
            {
                return "Erro! Proprietario não encontrado!";
            }
        }

        [HttpGet("{id}")]
        public Proprietario Get2([FromRoute] string id)
        {
            var prop = context.Proprietario
                       .Where(prop => prop.Id.ToString() == id)
                       .FirstOrDefault();
            //select * from proprietario
            //where Id = ?
            return prop;
        }

        /*[HttpGet("Parametro1")]
        public Proprietario Get([FromQuery] string id)
        {
            var prop = lista.Where(prop => prop.Id.ToString() == id).FirstOrDefault();
            //select * from proprietario
            //where Id = ?
            return prop;
        }

        [HttpGet("Parametro3")]
        public Proprietario Get3([FromHeader] string id)
        {
            var prop = lista.Where(prop => prop.Id.ToString() == id).FirstOrDefault();
            //select * from proprietario
            //where Id = ?
            return prop;
        }

        [HttpGet("Curso")]
        public string GetCurso()
        {
            return "Sistemas de Informação";
        }*/
    }
}
