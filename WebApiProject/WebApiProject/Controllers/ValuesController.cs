using DatabaseAccess;
using DatabaseAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http; 

namespace WebApiProject.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<Podata> Get()
        {
            AccessLayer obj = new AccessLayer();
            var t1=  obj.GetthePoDetails();

            return t1;
            //return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
