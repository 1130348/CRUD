using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Lugares;
using Lugares.Controllers;
using ClassLibrary.Model;

namespace LugaresTest.LugaresControllers
{
    [TestClass]
    public class POIControllerTests
    {

        [TestMethod]
        public void Index()
        {
            POIController poiController = new POIController();

            var result = poiController.Index() as ViewResult;

            Assert.IsNotNull(result.ViewName);

        }

        [TestMethod]
        public void Details()
        {
            POIController poiController = new POIController();

            var result = poiController.Details(2) as ViewResult;

            Assert.IsNotNull(result.ViewName);
        }

        [TestMethod]
        public void Create()
        {
            POIController poiController = new POIController();

            var result = poiController.Create() as ViewResult;

            Assert.IsNotNull(result.ViewName);
        }

        [TestMethod]
        public void Edit()
        {
            POIController poiController = new POIController();

            var result = poiController.Index() as ViewResult;

            Assert.IsNotNull(result.ViewName);
        }

        [TestMethod]
        public void EditPost()
        {
            POIController poiController = new POIController();

            var result = poiController.Index() as ViewResult;

            Assert.IsNotNull(result.ViewName);
        }

        [TestMethod]
        public void Delete()
        {
            POIController poiController = new POIController();

            var result = poiController.Index() as ViewResult;

            Assert.IsNotNull(result.ViewName);
        }

    }
}
