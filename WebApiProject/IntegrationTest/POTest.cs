using NUnit.Framework;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace WebApiTest
{
    public class Class1
    {
        //private HttpServer Server;
        //private string UrlBase = "http://some.server/";

       
        public void Setup()
        {
         
            //var config = new HttpConfiguration();
            //config.Routes.MapHttpRoute(name: "Default", routeTemplate: "api/{controller}/{action}/{id}", defaults: new { id = RouteParameter.Optional });
            //config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;

            //Server = new HttpServer(config);
        }

        
        public void SupplierAPI_Should_Retrun_Data_AS_Expected()
        {
            var client = new HttpClient();
            var request = createRequest("api/supplier", "application/json", HttpMethod.Get,"");

            using (HttpResponseMessage response = client.SendAsync(request).Result)
            {
                Assert.IsNotNull(response);
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                Assert.NotNull(response.Content);
            }
        }

       
        public void ItemsAPI_Should_Retrun_Data_AS_Expected()
        {
            var client = new HttpClient();
            var request = createRequest("api/items", "application/json", HttpMethod.Get,"");

            using (HttpResponseMessage response = client.SendAsync(request).Result)
            {
                Assert.IsNotNull(response);
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                Assert.NotNull(response.Content);
            }
        }

        
        public void AllDataAPI_Should_Retrun_Data_AS_Expected()
        {
            var client = new HttpClient();
            var request = createRequest("api/alldata", "application/json", HttpMethod.Get,"");

            using (HttpResponseMessage response = client.SendAsync(request).Result)
            {
                Assert.IsNotNull(response);
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                Assert.NotNull(response.Content);
            }
        }
        
        public void PostData_Should_Retrun_Data_AS_Expected()
        {
            var client = new HttpClient();
            var request = createRequest("api/senddata", "application/json", HttpMethod.Post,"");
           
            using (HttpResponseMessage response = client.SendAsync(request).Result)
            {
                Assert.IsNotNull(response);
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                Assert.NotNull(response.Content);
            }
        }

       

    private HttpRequestMessage createRequest(string url, string mthv, HttpMethod method,string content)
        {
            var request = new HttpRequestMessage();

            request.RequestUri = new Uri("http://localhost:51543/" + url);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(mthv));
            request.Method = method;           
            return request;
        }
        
    }
}
