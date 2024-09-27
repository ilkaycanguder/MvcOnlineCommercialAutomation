using MvcOnlineTicariOtomasyon.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class YapilacakController : Controller
    {
        // GET: Yapilacak
        Context c = new Context();
        public ActionResult Index()
        {
            var values = c.Carilers.Count().ToString();
            ViewBag.d1 = values;
            var values2 = c.Uruns.Count().ToString();
            ViewBag.d2 = values2;
            var values3 = c.Kategoris.Count().ToString();
            ViewBag.d3 = values3;
            var values4 = (from x in c.Carilers select x.CariSehir).Distinct().Count().ToString();
            ViewBag.d4 = values4;

            var yapilacaklar = c.Yapilacaks.ToList();
            return View(yapilacaklar);
        }
    }
}