﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Quiron.LojaVirtual.Web.Models;
using Quiron.LojaVirtual.Web.HTMLHelpers;

namespace Quiron.LojaVirtual.UnitTest
{
    [TestClass]
    public class UnitTestQuiron
    {
         [TestMethod]
        public void TestarSeAPaginacaoEstaSendoGeradaCorretamente()
        {
            //Arrange
            HtmlHelper htmlHelper = null;
            Paginacao paginacao = new Paginacao
            {
                PaginaAtual = 2,
                ItensTotal = 28,
                ItensPorPagina = 10
            };

            Func<int, string> paginaUrl = i => "Pagina" + i;

            //Act
            MvcHtmlString resultado = htmlHelper.PageLinks(paginacao, paginaUrl);


            //Assert           
            Assert.AreEqual(
                   @"<a class=""btn btn-default"" href=""Pagina1"">1</a>"
                 + @"<a class=""btn btn-default btn-primary Selected"" href=""Pagina2"">2</a>"
                 + @"<a class=""btn btn-default"" href=""Pagina3"">3</a>", resultado.ToString()
                 );

        }

    }


}
