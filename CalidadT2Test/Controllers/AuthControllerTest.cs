using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalidadT2.Controllers;
using CalidadT2.Repositorio;
using NUnit.Framework;
using Moq;
using Microsoft.AspNetCore.Mvc;

namespace CalidadT2Test.Controllers
{
    public class AuthControllerTest
    {
        [Test]
        public void LoginGet()
        {
            var loginT = new AuthController(null, null);
            var view = loginT.Login() as ViewResult;

            Assert.IsNotNull(view);
            Assert.IsInstanceOf<ViewResult>(view);
        }

        [Test]
        public void LoginPost()
        {
            var loginT =  new AuthController(null, null);
            var view = loginT.Login("admin", "admin");

            Assert.IsNotNull(view);
        }
    }
}
