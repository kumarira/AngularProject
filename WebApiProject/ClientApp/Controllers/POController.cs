using ClientApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ClientApp.Controllers
{
    public class POController : Controller
    {
        HttpClient client = new HttpClient(); 
        // GET: PO

        public ActionResult Index()
        { 
            return View();
        }
        public ActionResult Create()
        {
            Podata objdata = new Podata();
            objdata.suppliers = new SelectList(GetSupplier(), "SUPLNO", "SUPLNAME");
            objdata.items = new SelectList(GetItems(), "ITCODE", "ITDESC");
            return View("Create", objdata);
        }
        [HttpPost]
        public async Task<ActionResult> Create(Podata model)
        {
            model.Action = "A";
            model.SUPLNO= Request.Form["DropDownListSuplier"].ToString();
            model.ITCODE = Request.Form["DropDownListitems"].ToString();
           
            client.BaseAddress = new Uri("http://localhost:51543/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Accept.Clear();

            HttpResponseMessage response = await client.PostAsJsonAsync("api/senddata", model);

            if (response.IsSuccessStatusCode == true)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index"); 
        }

        public List<supplier> GetSupplier()
        { 
           
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response;
            response = client.GetAsync("http://localhost:51543/api/supplier").Result;
            response.EnsureSuccessStatusCode();
            List<supplier> SupplierList = response.Content.ReadAsAsync<List<supplier>>().Result;
            if (!object.Equals(SupplierList, null))
            {
                var Suppliers = SupplierList.ToList();
                return Suppliers;
            }
            else
            {
                return null;
            }
        }
        public List<items> GetItems()
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response;
            response = client.GetAsync("http://localhost:51543/api/items").Result;
            response.EnsureSuccessStatusCode();
            List<items> ItemsList = response.Content.ReadAsAsync<List<items>>().Result;
            if (!object.Equals(ItemsList, null))
            {
                var Items = ItemsList.ToList();
                return Items;
            }
            else
            {
                return null;
            }
        } 
    }

  
}