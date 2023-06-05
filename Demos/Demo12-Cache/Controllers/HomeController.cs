using Demo12_Cache.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Demo12_Cache.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMemoryCache _memoryCache;
        private IList<string> Nomes = new List<string>();
        public HomeController(ILogger<HomeController> logger, IMemoryCache memoryCache)
        {
            _logger = logger;
            _memoryCache = memoryCache;
        }

        public IActionResult Index()
        {
            for (int i = 0; i < 10; i++)
            {
                Nomes.Add($"Nome{i}");
            }

            DateTime cacheEnd;
            List<string> cacheList = null;
            if(!_memoryCache.TryGetValue("MinhaLista", out cacheList)){
                cacheEnd = DateTime.Now.AddMinutes(1);
                var cacheOpt = new MemoryCacheEntryOptions().SetAbsoluteExpiration(cacheEnd);
                _memoryCache.Set("MinhaLista", Nomes, cacheOpt);
            }


            return View();
        }

        public IActionResult Privacy()
        {
            List<string> cacheList = null;
            if (!_memoryCache.TryGetValue("MinhaLista", out cacheList))
            {
                return NotFound("Cache não encontrado");
            }
            ViewBag.Nomes = cacheList;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
