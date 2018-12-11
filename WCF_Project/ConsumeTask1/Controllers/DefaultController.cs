using ConsumeTask1.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConsumeTask1.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            // calling service with TCP binding 
            Service1Client tcpproxy = new Service1Client("tcpendpoint");
            var result1 = tcpproxy.GetData(12);
            Console.WriteLine(result1);
            ViewBag.Tcpdata = result1;

            //calling service with HTTP binding 
            Service1Client httpproxy = new Service1Client("httpendpoint");
            var result2 = httpproxy.GetData(12);
            ViewBag.httpData = result2;

            return View();
        }
    }
}