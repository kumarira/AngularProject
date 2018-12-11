using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Model
{
    public class Podata
    {
        public string Action { get; set; }
        public string PONO { get; set; }
        public DateTime? PODATE { get; set; }
        public string SUPLNO { get; set; }
        public string SUPname { get; set; }
        public string ITCODE  { get; set; }
        public string ITname { get; set; }
        public int? QTY { get; set; }
        public decimal? ITrate { get; set; }

        public decimal? totacost { get; set; }
        
    }
}
