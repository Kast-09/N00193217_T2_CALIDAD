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
    public class BibliotecaRepositorioTest
    {
        private IQueryable<Biblioteca> data;
        private Mock<AppBibliotecaContext> mockDB;

        [SetUp]
        public void SetUp()
        {
            data = new List<Biblioteca>
            {
                new Biblioteca(){Id = 1, UsuarioId = 1, LibroId = 1},
                new Biblioteca(){Id = 2, UsuarioId = 2, LibroId = 1}
            }.AsQueryable();

            var mockAppContextUsuario = new MockDbSet<Biblioteca>(data);
            mockDB = new Mock<AppBibliotecaContext>();
            mockDB.Setup(o => o.Bibliotecas).Returns(mockAppContextUsuario.Object);
        }

        [Test]
        public void ObtenerBibliotecaCase01()
        {
            var obtener = new BibliotecaRepositorio(mockDB.Object);
            var resultado = obtener.obtenerDatosBiblioteca(1);

            Assert.AreEqual(1, resultado.Count);
        }

        [Test]
        public void agregarBibliotecaCase01()
        {
            var agregar = new BibliotecaRepositorio(mockDB.Object);
            var resultado = agregar.agregarDatosBiblioteca(new Biblioteca() { 
                Id = 3, UsuarioId = 2, LibroId = 1
            });

            Assert.AreEqual(3, resultado.Id);
        }

        [Test]
        public void actualizarLeyendoCase01()
        {
            var actualizar = new BibliotecaRepositorio(mockDB.Object);
            var resultado = actualizar.actualizarEstadoLeyendo(1, 1);

            Assert.AreEqual(2, resultado.Estado);
        }

        [Test]
        public void actualizarTerminadoCase01()
        {
            var actualizar = new BibliotecaRepositorio(mockDB.Object);
            var resultado = actualizar.actualizarEstadoTerminado(1, 1);

            Assert.AreEqual(3, resultado.Estado);
        }
    }
}
