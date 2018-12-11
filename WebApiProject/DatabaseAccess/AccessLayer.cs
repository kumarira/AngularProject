using DatabaseAccess.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess
{
    public class AccessLayer
    {
        PODbEntities objPODbEntities = new PODbEntities();
        public List<Podata> GetthePoDetails()
        {
            List<Podata> objlist = new List<Podata>();

            var fetchAll = (from t in objPODbEntities.POMASTERs
                            join d in objPODbEntities.PODETAILs on t.PONO equals d.PONO
                            join s in objPODbEntities.SUPPLIERs on t.SUPLNO equals s.SUPLNO
                            join i in objPODbEntities.ITEMs on d.ITCODE equals i.ITCODE
                            select new { t.PONO, t.PODATE, t.SUPLNO, s.SUPLNAME, d.ITCODE, i.ITDESC, d.QTY, i.ITRATE, totacost = d.QTY * i.ITRATE });

            foreach (var item in fetchAll)
            {
                Podata obj = new Podata()
                {
                    PONO = item.PONO,
                    PODATE = item.PODATE,
                    SUPLNO = item.SUPLNO,
                    SUPname = item.SUPLNAME,
                    ITCODE = item.ITCODE,
                    ITname = item.ITDESC,
                    QTY = item.QTY,
                    ITrate = item.ITRATE,
                    totacost = item.totacost
                };
                objlist.Add(obj);
            }

            return objlist;
        }
        public void PODetailsOprations(Podata objPodata)
        {
           


        }
    }
}
