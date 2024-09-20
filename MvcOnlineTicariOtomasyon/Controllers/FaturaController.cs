using MvcOnlineTicariOtomasyon.DAL;
using MvcOnlineTicariOtomasyon.Models;
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

        [HttpGet]
        public ActionResult AddFatura()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddFatura(Faturalar p)
        {
            c.Faturalars.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}