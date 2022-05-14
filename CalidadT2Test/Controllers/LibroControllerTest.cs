using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalidadT2.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using CalidadT2.Repositorio;
using CalidadT2.Models;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace CalidadT2Test.Controllers
{
    public class LibroControllerTest
    {
        [Test]
        public void DetailsViewCase()
        {
            var mockDetails = new Mock<ILibroRepositorio>();

            var detailsT = new LibroController(null, mockDetails.Object, null);
            var view = (ViewResult)detailsT.Details(1);

            Assert.IsNotNull(view);
            Assert.IsInstanceOf<ViewResult>(view);
        }

        [Test]
        public void AddComentarioViewCase()
        {
            var mockClaimsPrincipal = new Mock<ClaimsPrincipal>();
            mockClaimsPrincipal.Setup(o => o.Claims).Returns(new List<Claim>() { 
                new Claim(ClaimTypes.Name, "admin")
            });

            var mockContext = new Mock<HttpContext>();
            mockContext.Setup(o => o.User).Returns(mockClaimsPrincipal.Object);

            var mockUserRepo = new Mock<IUsuarioRepositorio>();
            mockUserRepo.Setup(o => o.obtenerUsuario("admin")).Returns(new Usuario());

            var mockLibroRepo = new Mock<ILibroRepositorio>();

            var comentario = new LibroController(null, mockLibroRepo.Object, mockUserRepo.Object);
            comentario.ControllerContext = new ControllerContext()
            {
                HttpContext = mockContext.Object
            };
            var redirect = comentario.AddComentario(new Comentario() { LibroId = 1, Puntaje = 5});

            Assert.IsNotNull(redirect);
            Assert.IsInstanceOf<RedirectToActionResult>(redirect);
        }
    }
}
