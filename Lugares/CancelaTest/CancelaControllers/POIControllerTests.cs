using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cancela.Controllers;
using ClassLibrary.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity.Migrations;
using ClassLibrary.Model;
using System.Web.Http.Results;
using System.Net;
using ClassLibrary.DAL;
using CancelaTest.DbSet;

namespace CancelaTest.CancelaControllers
{
    [TestClass]
    public class POIControllerTests
    {
        [TestMethod]
        public void PostPoi_ShouldReturnSamePoi()
        {
            var controller = new POIsController(new TestCancelaContext());

            var item = GetDemoPOIDTOReceive();

            var result =
                controller.PostPOI(item) as CreatedAtRouteNegotiatedContentResult<POI>;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.RouteName, "DefaultApi");
            Assert.AreEqual(result.RouteValues["PoiID"], result.Content.PoiID);
            Assert.AreEqual(result.Content.Nome, item.Nome);
        }

        [TestMethod]
        public void PutPoi_ShouldReturnStatusCode()
        {
            var controller = new POIsController(new TestCancelaContext());

            var item = GetDemoPOIDTOReceive();

            var result = controller.PutPOI(item.PoiID, item) as StatusCodeResult;
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
        }

        [TestMethod]
        public void PutPoi_ShouldFail_WhenDifferentID()
        {
            var controller = new POIsController(new TestCancelaContext());

            var badresult = controller.PutPOI(999, GetDemoPOIDTOReceive());
            Assert.IsInstanceOfType(badresult, typeof(BadRequestResult));
        }

        [TestMethod]
        public void GetPoi_ShouldReturnProductWithSameID()
        {
            var context = new TestCancelaContext();
            context.POIs.Add(GetDemoPOI());

            var controller = new POIsController(context);
            var result = controller.GetPOI(1) as OkNegotiatedContentResult<POI>;

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Content.PoiID);
        }

        [TestMethod]
        public void GetPoi_ShouldReturnAllProducts()
        {
            var context = new TestCancelaContext();
            context.POIs.AddOrUpdate(i => i.PoiID,
                new POI { Nome = "Estádio do Dragão", LocalID = 1, CategoriaID = 1, duracaoVisita = 45 },
                new POI { Nome = "Casa da Música", LocalID = 2, CategoriaID = 5, duracaoVisita = 35 },
                new POI { Nome = "Torre dos Clérigos", LocalID = 7, CategoriaID = 4, duracaoVisita = 15 });

            var controller = new POIsController(context);
            var result = controller.GetPOIs() as TestPOIDbSet;

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Local.Count);
        }

        [TestMethod]
        public void DeletePoi_ShouldReturnOK()
        {
            var context = new TestCancelaContext();
            var item = GetDemoPOI();
            context.POIs.Add(item);

            var controller = new POIsController(context);
            var result = controller.DeletePOI(3) as OkNegotiatedContentResult<POI>;

            Assert.IsNotNull(result);
            Assert.AreEqual(item.PoiID, result.Content.PoiID);
        }

        POI GetDemoPOI()
        {
            return new POI() { PoiID = 1, Nome = "Estádio do Dragão", LocalID = 1, CategoriaID = 1, duracaoVisita = 45 };
        }

        POIDTOReceive GetDemoPOIDTOReceive()
        {
            return new POIDTOReceive() { PoiID = 1, Nome = "Estádio do Dragão", LocalID = 1, CategoriaID = 1, duracaoVisita = 45 };
        }

    }
}

