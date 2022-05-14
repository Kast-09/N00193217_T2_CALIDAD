using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using CalidadT2.Repositorio;
using CalidadT2.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace CalidadT2Test.Controllers
{
    public class HomeControllerTest
    {
        [Test]
        public void IndexViewCase()
        {
            var mockLibroRepo = new Mock<ILibroRepositorio>();

            var IndexT = new HomeController(null, mockLibroRepo.Object);
            var view = (ViewResult)IndexT.Index();

            Assert.IsNotNull(view);
            Assert.IsInstanceOf<ViewResult>(view);
        }
    }
}
