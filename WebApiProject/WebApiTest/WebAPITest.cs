using DatabaseAccess.Model;
using Moq;
using NUnit.Framework;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Hosting;
using System.Web.Http.Routing;
using WebApiProject.Controllers;
using WebApiProject.DatabaseAccess.Model;
using WebApiProject.Models;

namespace WebApiTest
{
    public class WebAPITest
    {

        [Test]
        public void APIController_SupplierData_Should_Retrun_Data_AS_Expected()
        {            
            // Arrange            
            var allSupplier = new[] {
                new supplier { SUPLNO="S100", SUPLADDR="Tomato Soup", SUPLNAME="test1" },
                  new supplier { SUPLNO="S100", SUPLADDR="Tomato Soup", SUPLNAME="test1" },
            };
            Mock<IPORepository> repository = new Mock<IPORepository>();
            repository.Setup(x => x.GetPOsupplier()).Returns(allSupplier);
            var StubPODataController = new PODataController(repository.Object);
            
            // Act
            var result = StubPODataController.Getsupplier();

            // Assert
            Assert.AreSame(allSupplier, result);
        }
        [Test]
        public void APIController_ItemsData_Should_Retrun_Data_AS_Expected()
        {

            // Arrange            
            var allItems = new[] {
                new items { ITCODE="S100", ITDESC="Tomato Soup", ITRATE=10 },
                  new items { ITCODE="S101", ITDESC="Tomato Soup", ITRATE=10 },
            };
            Mock<IPORepository> repository = new Mock<IPORepository>();
            repository.Setup(x => x.GetPOitems()).Returns(allItems);
            var StubPODataController = new PODataController(repository.Object);

            // Act
            var result = StubPODataController.Getitems();

            // Assert
            Assert.AreSame(allItems, result);
        }

        [Test]
        public void APIController_AllPoData_Should_Retrun_Data_AS_Expected()
        {
            // Arrange            
            var allPodataItems = new[] {
                new Podata { PONO="S100", ITCODE="S100", SUPLNO="Tomato Soup", ITrate=10 },
                  new Podata { PONO="S101", ITCODE="S100", SUPLNO="Tomato Soup", ITrate=10 },
            };
            Mock<IPORepository> repository = new Mock<IPORepository>();
            repository.Setup(x => x.GetAllPoData()).Returns(allPodataItems);
            var StubPODataController = new PODataController(repository.Object);

            // Act
            var result = StubPODataController.GetAllData();

            // Assert
            Assert.AreSame(allPodataItems, result);
        }
        [Test]
        public void APIController_SendPoData_Should_Retrun_Data_AS_Expected()
        {
            // Arrange           
            var podata = new Podata { Action ="A", ITCODE = "S100", SUPLNO = "S001", QTY = 10 };
          
            Mock<IPORepository> repository = new Mock<IPORepository>();
            repository.Setup(x => x.sendPOdata(podata)).Returns(podata);
            var StubPODataController = new PODataController(repository.Object);

            var config = new HttpConfiguration();
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost/api/senddata");
            var route = config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}");
            var routeData = new HttpRouteData(route, new HttpRouteValueDictionary { { "controller", "POData" } });

            StubPODataController.ControllerContext = new HttpControllerContext(config, routeData, request);
            StubPODataController.Request = request;
            StubPODataController.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;

            // Act
            var result = StubPODataController.senddata(podata);

            // Assert
            Assert.AreEqual(HttpStatusCode.Created, result.StatusCode);
        }

    }
}
