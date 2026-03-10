using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WSImobControl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProprietarioController : ControllerBase
    {
        [HttpGet]
        public string GetDados()
        {
            return "Dados";
        }

        [HttpGet("BSN")]
        public string GetDadosBSN()
        {
            return "BSN";
        }
    }
}
