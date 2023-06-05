using Lab07_Extra.Infra.Repostiorio;
using Lab07_Extra.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Lab07_Extra.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepo<Pessoa> _repop;
        private readonly IRepo<Curso> _repoc;
        public HomeController(ILogger<HomeController> logger, IRepo<Pessoa> repop, 
            IRepo<Curso> repoc)
        {
            _logger = logger;
            _repop = repop;
            _repoc = repoc;
        }

        public IActionResult Index()
        {
            _repop.Add(new Pessoa() { Idade = 22, Nome = "Henrique" });
            

            return View(_repop.Get());
        }

        public IActionResult Privacy()
        {
            _repoc.Add(new Curso() { Descricao = "20486" });

            return View(_repoc.Get());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
