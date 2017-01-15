using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lugares.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;

namespace LugaresTest.LugaresControllers
{
    [TestClass]
    public class PercursoControllerTests
    {
        [TestMethod]
        public void Index()
        {
            PercursoController percursoController = new PercursoController();

            var result = percursoController.Index() as ViewResult;

            Assert.IsNotNull(result.ViewName);

        }

        [TestMethod]
        public void Details()
        {
            PercursoController percursoController = new PercursoController();

            var result = percursoController.Details(2) as ViewResult;

            Assert.IsNotNull(result.ViewName);
        }

        [TestMethod]
        public void Create()
        {
            PercursoController percursoController = new PercursoController();

            var result = percursoController.Create() as ViewResult;

            Assert.IsNotNull(result.ViewName);
        }

        [TestMethod]
        public void Edit()
        {
            PercursoController percursoController = new PercursoController();

            var result = percursoController.Index() as ViewResult;

            Assert.IsNotNull(result.ViewName);
        }

        [TestMethod]
        public void EditPost()
        {
            PercursoController percursoController = new PercursoController();

            var result = percursoController.Index() as ViewResult;

            Assert.IsNotNull(result.ViewName);
        }

        [TestMethod]
        public void Delete()
        {
            PercursoController percursoController = new PercursoController();

            var result = percursoController.Index() as ViewResult;

            Assert.IsNotNull(result.ViewName);
        }

    }
}
