using System;
using System.Linq;
using CalidadT2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CalidadT2.Repositorio;
using System.Security.Claims;

namespace CalidadT2.Controllers
{
    public class LibroController : Controller
    {
        private readonly AppBibliotecaContext app;
        private readonly ILibroRepositorio libroRepositorio;
        private readonly IUsuarioRepositorio usuarioRepositorio;

        public LibroController(AppBibliotecaContext app, ILibroRepositorio libroRepositorio, IUsuarioRepositorio usuarioRepositorio)
        {
            this.app = app;
            this.libroRepositorio = libroRepositorio;
            this.usuarioRepositorio = usuarioRepositorio;
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = libroRepositorio.libro(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult AddComentario(Comentario comentario)
        {
            Usuario user = LoggedUser();
            comentario.UsuarioId = user.Id;
            comentario.Fecha = DateTime.Now;

            libroRepositorio.agregarComentario(comentario);

            return RedirectToAction("Details", new { id = comentario.LibroId });
        }

        private Usuario LoggedUser()
        {
            var claim = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name);
            var user = claim.Value;
            return usuarioRepositorio.obtenerUsuario(user);
        }
    }
}
