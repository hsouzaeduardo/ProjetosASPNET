using Demo05.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo05.ViewComponents
{
    //Caso queira usar um outro nome para seu compomente sem notação de ViewComponente 
    //pode ser usado um attributo chamado ViewComponent
    [ViewComponent(Name = "grid")]
    public class GridViewComponent : ViewComponent 
    {
        
        public async Task<IViewComponentResult> InvokeAsync(List<Carros> lista)
        {
            return View(lista);
        }
    }
}
