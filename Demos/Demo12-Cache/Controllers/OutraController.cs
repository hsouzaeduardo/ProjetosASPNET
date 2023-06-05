using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo12_Cache.Controllers
{
    public class OutraController : Controller
    {
        private readonly IMemoryCache _memoryCache;
        public OutraController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        public IActionResult Index()
        {
            List<string> cacheList = null;
            if (!_memoryCache.TryGetValue("MinhaLista", out cacheList))
            {
                return NotFound("Cache não encontrado");
            }
            ViewBag.Nomes = cacheList;
            return View();
        }
    }
}
