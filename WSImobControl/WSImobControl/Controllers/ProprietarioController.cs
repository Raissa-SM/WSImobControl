using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSImobControl.Model;

namespace WSImobControl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProprietarioController : ControllerBase
    {
        private static List<Proprietario> lista = new List<Proprietario>();

        [HttpGet]
        public List<Proprietario> Get()
        {
            return lista;
        }

        [HttpPost]
        public string Post(Proprietario prop)
        {
            lista.Add(prop);
            return "Inclusão realizada com sucesso!";
        }

        [HttpGet("Parametro1")]
        public Proprietario Get([FromQuery] string id)
        {
            var prop = lista.Where(prop => prop.Id.ToString() == id).FirstOrDefault();
            //select * from proprietario
            //where Id = ?
            return prop;
        }

        [HttpGet("Parametro2/{id}")]
        public Proprietario Get2([FromRoute] string id)
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
        }
    }
}
