using DatabaseAccess;
using DatabaseAccess.Model;
using System;
using System.Collections.Generic;
using WebApiProject.DatabaseAccess.Model;

namespace WebApiProject.Models
{
    public class PORepository :  IPORepository
    {
        AccessLayer obj = new AccessLayer();
        public IEnumerable<Podata> GetAllPoData()
        {
            return obj.GetthePoDetails();           
        }

        public IEnumerable<items> GetPOitems()
        {
            return obj.Getitems(); 
        }

        public IEnumerable<supplier> GetPOsupplier()
        {
            return obj.Getsupplier(); 
        }
        public Podata sendPOdata(Podata model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("model");
            }
            var cnt = obj.PODetailsOprations(model); 
            return model;
        }
    }
}