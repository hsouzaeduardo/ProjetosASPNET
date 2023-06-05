using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo05.Helpers
{
    public class TelefoneTagHelper : TagHelper
    {
        public string DDI { get; set; } = "+55";
        public string DDD { get; set; } = "(11)";
        private string whatp = "https://api.whatsapp.com/send?phone=5511";
        //<telefone>991777337</telefone>
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            var conteudo = await output.GetChildContentAsync();
            var res = $"{DDI} {DDD} {conteudo.GetContent()}";
            output.Attributes.SetAttribute("href", $"{whatp}{conteudo.GetContent()}");
            output.Content.SetContent(res);
        }
    }
}
