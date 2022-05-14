using CalidadT2.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CalidadT2.Repositorio
{
    public interface ILibroRepositorio
    {
        List<Libro> obtenerLibros();
        Libro libro(int id);
        Libro agregarComentario(Comentario comentario);
    }
    public class LibroRepositorio: ILibroRepositorio
    {
        private AppBibliotecaContext app;

        public LibroRepositorio(AppBibliotecaContext app)
        {
            this.app = app;
        }

        public List<Libro> obtenerLibros() {
            return app.Libros.Include(o => o.Autor).ToList();
        }

        public Libro libro(int id) { 
            return app.Libros
                .Include("Autor")
                .Include("Comentarios.Usuario")
                .Where(o => o.Id == id)
                .FirstOrDefault();
        }

        public Libro agregarComentario(Comentario comentario)
        {
            app.Comentarios.Add(comentario);

            var libro = app.Libros.Where(o => o.Id == comentario.LibroId).FirstOrDefault();
            libro.Puntaje = (libro.Puntaje + comentario.Puntaje) / 2;

            app.SaveChanges();

            return libro;
        }

    }
}
