using Demo04.Filter;
using Demo04.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Demo04.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [FiltroCerveja("Brahma")]
        public IActionResult Index(int codigo = 0)
        {
            ViewBag.Controller = RouteData.Values["Controller"];
            ViewBag.Action = RouteData.Values["Action"];

            ViewBag.Id = codigo;
            ViewBag.Data = DateTime.Now;
            ViewData["Aluno"] = new Aluno { Nome = "Claudio", Idade = 15 };
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="cep">00000-000</param>
        /// <returns></returns>
        [Route("app/teste/{nome}/{cep:regex(^\\d{{5}}-\\d{{3}})}")]
        public IActionResult JsonTeste(string nome, string cep )
        {
            var obj = new { Nome = nome, Clube = cep };

            return StatusCode(500, obj);
        }
        [ResponseCache(Duration =100, Location = ResponseCacheLocation.None, NoStore = true)]
       // [FiltroCerveja("Heineken")]
        public IActionResult MeuTime()
        {
            return Content("SANTOS F.C.");
        }

        public IActionResult Teste2()
        {
            ViewBag.Controller = RouteData.Values["Controller"];
            ViewBag.Action = RouteData.Values["Action"];

            //if (DateTime.Now.Second % 2 == 0)
            //{
            //    return RedirectToAction("Index", new { codigo = 200 });
            //}

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
