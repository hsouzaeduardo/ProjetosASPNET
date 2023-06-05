using Demo13_APIPath.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Newtonsoft.Json.JsonConvert.SerializeObject;

namespace Demo13_APIPath.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasController : ControllerBase
    {
        private Demo13_APIPath.Contexto.Contexto _contexto;
        private ILogger<PessoasController> _logger;
        public PessoasController(ILogger<PessoasController> logger, Demo13_APIPath.Contexto.Contexto contexto)
        {
            _contexto = contexto;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Pessoa pessoa)
        {
            _contexto.Pessoas.Add(pessoa);
            _contexto.SaveChanges();
            return Ok();
        }


          //      [
          //          {
          //      "op": "replace",
          //            "path": "nome",
          //            "value": "Luis Fernando Oliveira"
          //    },
          //    {
          //      "op": "replace",
          //      "path": "cep",
          //      "value": "06192001"
          //    }
          //]
   

        [HttpPatch]
        public IActionResult Post(int id, [FromBody] JsonPatchDocument<Pessoa> pessoa)
        {
            if(pessoa == null)
            {
                _logger.LogError("Objeto nullo");
                return BadRequest("Objeto nullo");
            }

            var registro = _contexto.Pessoas.Find(id);
            
            //_contexto.Pessoas.Update(registro);

            pessoa.ApplyTo(registro, ModelState);

            // _contexto.SaveChanges();

            _contexto.SaveChanges();

            return NoContent();
        }
    }
}
