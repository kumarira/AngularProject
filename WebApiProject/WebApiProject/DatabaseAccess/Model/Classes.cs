using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiProject.DatabaseAccess.Model
{
    public class supplier
    {
        public string SUPLNO { get; set; }
        public string SUPLNAME { get; set; }
        public string SUPLADDR { get; set; }
    }

    public class items
    {
        public string ITCODE { get; set; }
        public string ITDESC { get; set; }
        public decimal? ITRATE { get; set; }
    }
}