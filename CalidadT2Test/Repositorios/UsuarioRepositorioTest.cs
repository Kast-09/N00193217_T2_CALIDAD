using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalidadT2.Models;
using CalidadT2.Repositorio;
using Moq;
using CalidadT2Test.Helpers;
using System.Linq;

namespace CalidadT2Test.Repositorios
{
    public class UsuarioRepositorioTest
    {
        private IQueryable<Usuario> data;
        private Mock<AppBibliotecaContext> mockDB;

        [SetUp]
        public void SetUp()
        {
            data = new List<Usuario>
            {
                new Usuario(){Id = 1, Username = "admin", Password="123456", Nombres="Carlos"},
                new Usuario(){Id = 2, Username = "user1", Password="123456", Nombres="Juan"}
            }.AsQueryable();

            var mockAppContextUsuario = new MockDbSet<Usuario>(data);
            mockDB = new Mock<AppBibliotecaContext>();
            mockDB.Setup(o => o.Usuarios).Returns(mockAppContextUsuario.Object);
        }

        [Test]
        public void obtenerUsuarioCase01()
        {
            var repo = new UsuarioRepositorio(mockDB.Object);
            var result = repo.obtenerUsuario("admin");

            Assert.AreEqual("admin", result.Username);
        }
    }
}
