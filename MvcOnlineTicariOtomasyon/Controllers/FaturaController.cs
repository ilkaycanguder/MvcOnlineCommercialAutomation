using MvcOnlineTicariOtomasyon.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class FaturaController : Controller
    {
        // GET: Fatura
        Context c = new Context();  
        public ActionResult Index()
        {
            var values = c.Faturalars.ToList();
            return View(values);
        }
    }
}