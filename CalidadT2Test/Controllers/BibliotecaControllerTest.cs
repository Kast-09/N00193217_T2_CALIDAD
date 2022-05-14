using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalidadT2.Controllers;
using CalidadT2.Models;
using CalidadT2.Repositorio;
using NUnit.Framework;
using Moq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CalidadT2Test.Controllers
{
    public class BibliotecaControllerTest
    {
        [Test]
        public void IndexViewCase()
        {
            var mockClaimsPrincipal = new Mock<ClaimsPrincipal>();
            mockClaimsPrincipal.Setup(o => o.Claims).Returns(new List<Claim>() {
                new Claim(ClaimTypes.Name, "admin")
            });

            var mockContext = new Mock<HttpContext>();
            mockContext.Setup(o => o.User).Returns(mockClaimsPrincipal.Object);

            var mockUserRepo = new Mock<IUsuarioRepositorio>();
            mockUserRepo.Setup(o => o.obtenerUsuario("admin")).Returns(new Usuario());

            var indexT = new BibliotecaController(null, mockUserRepo.Object, null);
            indexT.ControllerContext = new ControllerContext()
            {
                HttpContext = mockContext.Object
            };
            var redirect = indexT.Index;

            Assert.IsNotNull(redirect);
        }

        [Test]
        public void AddViewCase()
        {
            var mockClaimsPrincipal = new Mock<ClaimsPrincipal>();
            mockClaimsPrincipal.Setup(o => o.Claims).Returns(new List<Claim>() {
                new Claim(ClaimTypes.Name, "admin")
            });

            var mockContext = new Mock<HttpContext>();
            mockContext.Setup(o => o.User).Returns(mockClaimsPrincipal.Object);

            var mockUserRepo = new Mock<IUsuarioRepositorio>();
            mockUserRepo.Setup(o => o.obtenerUsuario("admin")).Returns(new Usuario());

            var mockBiblioteca = new Mock<IBibliotecaRepositorio>();

            var AddT = new BibliotecaController(null, mockUserRepo.Object, mockBiblioteca.Object);
            AddT.ControllerContext = new ControllerContext()
            {
                HttpContext = mockContext.Object
            };
            var redirect = AddT.Add(1);

            Assert.IsNotNull(redirect);
        }

        [Test]
        public void MarcarLeyendoViewCase()
        {
            var mockClaimsPrincipal = new Mock<ClaimsPrincipal>();
            mockClaimsPrincipal.Setup(o => o.Claims).Returns(new List<Claim>() {
                new Claim(ClaimTypes.Name, "admin")
            });

            var mockContext = new Mock<HttpContext>();
            mockContext.Setup(o => o.User).Returns(mockClaimsPrincipal.Object);

            var mockUserRepo = new Mock<IUsuarioRepositorio>();
            mockUserRepo.Setup(o => o.obtenerUsuario("admin")).Returns(new Usuario());

            var mockBiblioteca = new Mock<IBibliotecaRepositorio>();

            var marcarT = new BibliotecaController(null, mockUserRepo.Object, mockBiblioteca.Object);
            marcarT.ControllerContext = new ControllerContext()
            {
                HttpContext = mockContext.Object
            };
            var redirect = marcarT.MarcarComoLeyendo(1);

            Assert.IsNotNull(redirect);
        }

        [Test]
        public void MarcarTerminadoViewCase()
        {
            var mockClaimsPrincipal = new Mock<ClaimsPrincipal>();
            mockClaimsPrincipal.Setup(o => o.Claims).Returns(new List<Claim>() {
                new Claim(ClaimTypes.Name, "admin")
            });

            var mockContext = new Mock<HttpContext>();
            mockContext.Setup(o => o.User).Returns(mockClaimsPrincipal.Object);

            var mockUserRepo = new Mock<IUsuarioRepositorio>();
            mockUserRepo.Setup(o => o.obtenerUsuario("admin")).Returns(new Usuario());

            var mockBiblioteca = new Mock<IBibliotecaRepositorio>();

            var marcarT = new BibliotecaController(null, mockUserRepo.Object, mockBiblioteca.Object);
            marcarT.ControllerContext = new ControllerContext()
            {
                HttpContext = mockContext.Object
            };
            var redirect = marcarT.MarcarComoTerminado(1);

            Assert.IsNotNull(redirect);
        }
    }
}
