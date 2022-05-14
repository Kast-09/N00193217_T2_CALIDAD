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
    public class ComentarioRepositorioTest
    {
        private IQueryable<Comentario> data;
        private Mock<AppBibliotecaContext> mockDB;

        [SetUp]
        public void SetUp()
        {
            data = new List<Comentario>
            {
                new Comentario(){Id = 1, Texto = "Muy buen Libro", LibroId = 1, Puntaje = 4, UsuarioId = 2},
                new Comentario(){Id = 2, Texto = "Me encanto el libro, recomendado", LibroId = 1, Puntaje = 5, UsuarioId = 1 }
            }.AsQueryable();

            var mockAppContextUsuario = new MockDbSet<Comentario>(data);
            mockDB = new Mock<AppBibliotecaContext>();
            mockDB.Setup(o => o.Comentarios).Returns(mockAppContextUsuario.Object);
        }

        [Test]
        public void agregarComentarioCase01()
        {
            var comentario = new ComentarioRepositorio(mockDB.Object);
            var resultado = comentario.agregarComentario(new Comentario()
            {
                Id = 3, Texto = "Hola Mundo", Puntaje=4, LibroId=1, UsuarioId=1
            });

            Assert.AreEqual("Hola Mundo", resultado.Texto);
        }
    }
}
