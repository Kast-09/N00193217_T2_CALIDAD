using CalidadT2.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CalidadT2.Repositorio
{
    public interface IComentarioRepositorio
    {
        Comentario agregarComentario(Comentario comentario);
    }
    public class ComentarioRepositorio: IComentarioRepositorio
    {
        private readonly AppBibliotecaContext app;

        public ComentarioRepositorio(AppBibliotecaContext app)
        {
            this.app = app;
        }

        public Comentario agregarComentario(Comentario comentario)
        {
            app.Comentarios.Add(comentario);
            app.SaveChanges();
            return comentario;
        }
    }
}
