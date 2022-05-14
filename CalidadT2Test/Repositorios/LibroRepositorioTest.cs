using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalidadT2.Models;
using CalidadT2.Repositorio;
using Moq;
using CalidadT2Test.Helpers;

namespace CalidadT2Test.Repositorios
{
    public class LibroRepositorioTest
    {
        private IQueryable<Libro> data;
        private Mock<AppBibliotecaContext> mockDB;

        [SetUp]
        public void SetUp()
        {
            data = new List<Libro>
            {
                new Libro(){Id = 1, AutorId = 1, Nombre = "Fusiles y Machetes", Puntaje = 5 },
                new Libro(){Id = 2, AutorId = 2, Nombre = "Paco Yunque", Puntaje = 5 },
            }.AsQueryable();

            var mockAppContextUsuario = new MockDbSet<Libro>(data);
            mockDB = new Mock<AppBibliotecaContext>();
            mockDB.Setup(o => o.Libros).Returns(mockAppContextUsuario.Object);
        }

        [Test]
        public void obtenerBiblioteca()
        {
            var repo = new LibroRepositorio(mockDB.Object);
            var result = repo.obtenerLibros();

            Assert.AreEqual(2, result.Count);
        }

        [Test]
        public void obtenerLibro()
        {
            var repo = new LibroRepositorio(mockDB.Object);
            var result = repo.libro(1);

            Assert.AreEqual("Fusiles y Machetes", result.Nombre);
        }
        [Test]
        public void agregarComentarioRepositorio()
        {
            var repo = new LibroRepositorio(mockDB.Object);
            var result = repo.agregarComentario(new Comentario()
            {
                Id = 3, Texto = "Hola Mundo", Puntaje = 4, LibroId = 1, UsuarioId = 1
            });

            Assert.AreEqual(1, result.Id);
        }
    }
}
