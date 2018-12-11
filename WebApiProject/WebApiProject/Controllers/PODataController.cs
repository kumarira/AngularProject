using DatabaseAccess.Model;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApiProject.DatabaseAccess.Model;
using WebApiProject.Models;

namespace WebApiProject.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PODataController : ApiController
    {
        readonly IPORepository repository;

        public PODataController()
        {
            this.repository = new PORepository();
        }

        public PODataController(IPORepository repository)
        {
            this.repository = repository;
        }

        // GET api/values
        [HttpGet]
        [Route("api/alldata")]
        public IEnumerable<Podata> GetAllData()
        { 
            return repository.GetAllPoData(); 
        }
        [HttpGet]
        [Route("api/supplier")]
        public IEnumerable<supplier> Getsupplier()
        {
            return repository.GetPOsupplier();
        }

        [HttpGet]
        [Route("api/items")]
        public IEnumerable<items> Getitems()
        {
            return repository.GetPOitems();
        }

        [HttpPost]
        [Route("api/senddata")]
        public HttpResponseMessage senddata(Podata model)
        {
            var data= repository.sendPOdata(model);

            var response = Request.CreateResponse(HttpStatusCode.Created, model);

            return response;
        }
    }
}
