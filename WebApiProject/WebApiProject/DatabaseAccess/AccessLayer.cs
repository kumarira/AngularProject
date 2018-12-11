using DatabaseAccess.Model;
using System.Collections.Generic;
using System.Linq;
using WebApiProject.DatabaseAccess;
using WebApiProject.DatabaseAccess.Model;

namespace DatabaseAccess{
    public class AccessLayer
    {
        PODbEntities1 objPODbEntities = new PODbEntities1();

        public int PODetailsOprations(Podata objPodata)
        {            
            var fetchAll = objPODbEntities.usp_addupdate_PO(objPodata.Action, objPodata.PONO, objPodata.SUPLNO, objPodata.ITCODE, objPodata.QTY);
            return fetchAll;
        }
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

        public List<supplier> Getsupplier()
        {
            List<supplier> objlist = new List<supplier>();

            var fetchAll = from t in objPODbEntities.SUPPLIERs 
                            select new { t };

            foreach (var item in fetchAll)
            {
                supplier obj = new supplier()
                {
                    
                    SUPLNO = item.t.SUPLNO,
                    SUPLNAME = item.t.SUPLNAME,
                    SUPLADDR = item.t.SUPLADDR 
                };
                objlist.Add(obj);
            }

            return objlist;  
        }
        public List<items> Getitems()
        {
            List<items> objlist = new List<items>();

            var fetchAll = from t in objPODbEntities.ITEMs
                           select new { t };

            foreach (var item in fetchAll)
            {
                items obj = new items()
                {

                    ITCODE = item.t.ITCODE,
                    ITDESC = item.t.ITDESC, 
                    ITRATE = item.t.ITRATE,
                };
                objlist.Add(obj);
            }

            return objlist;
        }
       
   
    }
}
