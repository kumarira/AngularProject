using DatabaseAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApiProject.DatabaseAccess.Model;

namespace WebApiProject.Models
{
    public interface IPORepository
    {
        IEnumerable<Podata> GetAllPoData();
        IEnumerable<supplier> GetPOsupplier();
        IEnumerable<items> GetPOitems();
        Podata sendPOdata(Podata model);
    }
}
