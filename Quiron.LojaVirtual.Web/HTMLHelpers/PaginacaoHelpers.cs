using Quiron.LojaVirtual.Web.Models;
using System;
using System.Text;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.Web.HTMLHelpers
{
    public static class PaginacaoHelpers
    {
        //abaixo um delegate
        public static MvcHtmlString PageLinks(this HtmlHelper html, Paginacao paginacao, Func<int,string> paginaurl)
        {
            StringBuilder resultado = new StringBuilder();
            for (int i = 1; i < paginacao.TotalPagina; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", paginaurl(i));
                tag.InnerHtml = i.ToString();
                //abaixo para saber a cor quando seleciona uma pagina
                if (i == paginacao.PaginaAtual)
                {
                    tag.AddCssClass("Selected");
                    tag.AddCssClass("btn-primary");
                }
                tag.AddCssClass("btn btn-default");
                resultado.Append(tag);
            }
            return MvcHtmlString.Create(resultado.ToString());
        } 
    }
}