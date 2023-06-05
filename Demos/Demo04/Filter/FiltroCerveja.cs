using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo04.Filter
{
    public class FiltroCerveja : ActionFilterAttribute
    {
        public string Nome { get; set; }

        public FiltroCerveja(string nome)
        {
            Nome = nome;
        }


        public override void OnActionExecuting(ActionExecutingContext context)
        {
            context.Result = new ContentResult()
            {
                Content = "Sua cerveja Ozias, " + Nome
            };
        }
    }
}
