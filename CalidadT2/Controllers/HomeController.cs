using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CalidadT2.Models;
using Microsoft.EntityFrameworkCore;
using CalidadT2.Repositorio;

namespace CalidadT2.Controllers
{
    public class HomeController : Controller
    {
        private AppBibliotecaContext app;
        private ILibroRepositorio libroRepositorio;
        public HomeController(AppBibliotecaContext app, ILibroRepositorio libroRepositorio)
        {
            this.app = app;
            this.libroRepositorio = libroRepositorio;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = libroRepositorio.obtenerLibros();
            return View(model);
        }
    }
}
