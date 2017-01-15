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
    public class LocalControllerTests
    {
        [TestMethod]
        public void Index()
        {
            LocalController localController = new LocalController();

            var result = localController.Index() as ViewResult;

            Assert.IsNotNull(result.ViewName);

        }

        [TestMethod]
        public void Details()
        {
            LocalController localController = new LocalController();

            var result = localController.Details(2) as ViewResult;

            Assert.IsNotNull(result.ViewName);
        }

        [TestMethod]
        public void Create()
        {
            LocalController localController = new LocalController();

            var result = localController.Create() as ViewResult;

            Assert.IsNotNull(result.ViewName);
        }

        [TestMethod]
        public void Edit()
        {
            LocalController localController = new LocalController();

            var result = localController.Index() as ViewResult;

            Assert.IsNotNull(result.ViewName);
        }

        [TestMethod]
        public void EditPost()
        {
            LocalController localController = new LocalController();

            var result = localController.Index() as ViewResult;

            Assert.IsNotNull(result.ViewName);
        }

        [TestMethod]
        public void Delete()
        {
            LocalController localController = new LocalController();

            var result = localController.Index() as ViewResult;

            Assert.IsNotNull(result.ViewName);
        }
    }
}
