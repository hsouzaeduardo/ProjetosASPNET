using Demo06.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo06.Controllers
{
    public class TesteController : Controller
    {
        [HttpPost]
        [Route("/teste")]
        public IActionResult Index([FromBody] Pessoa pessoa)
        {
            if (!ModelState.IsValid)
            {
                if (pessoa != null)
                {
                    return StatusCode(500, ModelState);
                }
                else
                {
                    var objResult = new { Mensagem = "Objeto Null"
                        , Data = "{'cpj:00000000', 'nome: 'TESTE''}" };

                    return StatusCode(500, objResult);
                }

            }

            return Ok("Pessoa recebida");
        }
        


    }
}
