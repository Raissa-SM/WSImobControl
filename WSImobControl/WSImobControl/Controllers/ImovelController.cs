using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSImobControl.Model;

namespace WSImobControl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImovelController : ControllerBase
    {
        private static List<Imovel> lista = new List<Imovel>();

        [HttpGet]
        public List<Imovel> Get()
        {
            return lista;
        }


        [HttpGet("{id}")]
        public Imovel Get2([FromRoute] string id)
        {
            var imov = lista.Where(imov => imov.Id.ToString() == id)
                            .FirstOrDefault();
            return imov;
        }


        [HttpPost]
        public string Post(Imovel imov)
        {
            lista.Add(imov);
            return "Inclusão realizada com sucesso!";
        }

        [HttpPut]
        public string Put(Imovel Imovel)
        {
            var existe = lista.Where(imov => imov.Id == Imovel.Id)
                              .FirstOrDefault();
            if (existe != null)
            {
                existe.Titulo = Imovel.Titulo;
                existe.Descricao = Imovel.Descricao;
                existe.Preco = Imovel.Preco;
                existe.Endereco = Imovel.Endereco;
                existe.Status = Imovel.Status;
                return "Alteração realizada com sucesso!";
            }
            else
            {
                return "Erro! Imovel não encontrado!";
            }
        }

        [HttpDelete]
        public string Delete(Imovel Imovel)
        {
            var existe = lista.Where(imov => imov.Id == Imovel.Id)
                              .FirstOrDefault();
            if (existe != null)
            {
                lista.Remove(existe);
                return "Exclusão realizada com sucesso!";
            }
            else
            {
                return "Erro! Imovel não encontrado!";
            }
        }

        [HttpDelete("{id}")]
        public string Delete2(string id)
        {
            var existe = lista.Where(imov => imov.Id.ToString() == id)
                              .FirstOrDefault();
            if (existe != null)
            {
                lista.Remove(existe);
                return "Exclusão realizada com sucesso!";
            }
            else
            {
                return "Erro! Imovel não encontrado!";
            }
        }

    }
}
