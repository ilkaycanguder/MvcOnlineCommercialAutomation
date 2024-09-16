using MvcOnlineTicariOtomasyon.DAL;
using MvcOnlineTicariOtomasyon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CariController : Controller
    {
        // GET: Cari
        Context c = new Context();
        public ActionResult Index()
        {
            var values = c.Carilers.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult NewCari()
        {
            return View();  
        }

        [HttpPost]
        public ActionResult NewCari(Cariler p)
        {
            c.Carilers.Add(p);  
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}