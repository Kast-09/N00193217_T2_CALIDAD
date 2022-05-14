using CalidadT2.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using CalidadT2.Constantes;

namespace CalidadT2.Repositorio
{
    public interface IBibliotecaRepositorio
    {
        List<Biblioteca> obtenerDatosBiblioteca(int UserId);
        Biblioteca agregarDatosBiblioteca(Biblioteca biblioteca);
        Biblioteca actualizarEstadoLeyendo(int lId, int uId);
        Biblioteca actualizarEstadoTerminado(int lId, int uId);
    }
    public class BibliotecaRepositorio: IBibliotecaRepositorio
    {
        private AppBibliotecaContext app;

        public BibliotecaRepositorio(AppBibliotecaContext app)
        {
            this.app = app;
        }

        public List<Biblioteca> obtenerDatosBiblioteca(int UserId)
        {
            return app.Bibliotecas
                .Include(o => o.Libro.Autor)
                .Include(o => o.Usuario)
                .Where(o => o.UsuarioId == UserId)
                .ToList();
        }

        public Biblioteca agregarDatosBiblioteca(Biblioteca biblioteca)
        {
            app.Bibliotecas.Add(biblioteca);
            app.SaveChanges();
            return biblioteca;
        }

        public Biblioteca actualizarEstadoLeyendo(int lId, int uId)
        {
            var libro = app.Bibliotecas
                .Where(o => o.LibroId == lId && o.UsuarioId == uId)
                .FirstOrDefault();

            libro.Estado = ESTADO.LEYENDO;
            app.SaveChanges();

            return libro;
        }

        public Biblioteca actualizarEstadoTerminado(int lId, int uId)
        {
            var libro = app.Bibliotecas
                .Where(o => o.LibroId == lId && o.UsuarioId == uId)
                .FirstOrDefault();

            libro.Estado = ESTADO.TERMINADO;
            app.SaveChanges();

            return libro;
        }
    }
}
