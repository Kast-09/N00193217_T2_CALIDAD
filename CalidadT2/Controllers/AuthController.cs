using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CalidadT2.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using CalidadT2.Repositorio;

namespace CalidadT2.Controllers
{
    public class AuthController : Controller
    {
        private readonly AppBibliotecaContext app;
        private readonly IUsuarioRepositorio usuarioRepositorio;

        public AuthController(AppBibliotecaContext app, IUsuarioRepositorio usuarioRepositorio)
        {
            this.app = app;
            this.usuarioRepositorio = usuarioRepositorio;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var usuario = usuarioRepositorio.VerificarUsuarioContraseña(username, password);
            if (usuario != null)
            {
                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, username)
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);


                HttpContext.SignInAsync(claimsPrincipal);
                
                return RedirectToAction("Index", "Home");
            }
            
            ViewBag.Validation = "Usuario y/o contraseña incorrecta";
            return View();
        }


        public ActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
