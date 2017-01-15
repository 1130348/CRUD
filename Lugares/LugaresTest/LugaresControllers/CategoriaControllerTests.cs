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
    public class CategoriaControllerTests
    {
        [TestMethod]
        public void Index()
        {
            CategoriaController categoriaController = new CategoriaController();

            var result = categoriaController.Index() as ViewResult;

            Assert.IsNotNull(result.ViewName);

        }

        [TestMethod]
        public void Details()
        {
            CategoriaController categoriaController = new CategoriaController();

            var result = categoriaController.Details(2) as ViewResult;

            Assert.IsNotNull(result.ViewName);
        }

        [TestMethod]
        public void Create()
        {
            CategoriaController categoriaController = new CategoriaController();

            var result = categoriaController.Create() as ViewResult;

            Assert.IsNotNull(result.ViewName);
        }

        [TestMethod]
        public void Edit()
        {
            CategoriaController categoriaController = new CategoriaController();

            var result = categoriaController.Index() as ViewResult;

            Assert.IsNotNull(result.ViewName);
        }

        [TestMethod]
        public void EditPost()
        {
            CategoriaController categoriaController = new CategoriaController();

            var result = categoriaController.Index() as ViewResult;

            Assert.IsNotNull(result.ViewName);
        }

        [TestMethod]
        public void Delete()
        {
            CategoriaController categoriaController = new CategoriaController();

            var result = categoriaController.Index() as ViewResult;

            Assert.IsNotNull(result.ViewName);
        }
    }
}
