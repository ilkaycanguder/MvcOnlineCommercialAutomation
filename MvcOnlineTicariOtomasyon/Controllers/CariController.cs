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
            var values = c.Carilers.Where(x => x.Durum == true).ToList();
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
            p.Durum = true;
            c.Carilers.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCari(int id)
        {
            var cr = c.Carilers.Find(id);
            cr.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetCari(int id)
        {
            var cari = c.Carilers.Find(id);
            return View("GetCari", cari);
        }

        public ActionResult UpdateCari(Cariler p)
        {
            if (!ModelState.IsValid)
            {
                return View("GetCari");
            }
            var cari = c.Carilers.Find(p.CariID);
            cari.CariAd = p.CariAd;
            cari.CariSoyad = p.CariSoyad;
            cari.CariSehir = p.CariSehir;
            cari.CariMail = p.CariMail;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriSatis(int id)
        {
            var values = c.SatisHarekets.Where(x => x.CariID == id).ToList();
            var cr = c.Carilers.Where(x => x.CariID == id).Select(y => y.CariAd + " " + y.CariSoyad).FirstOrDefault();
            ViewBag.cari = cr;
            return View(values);
        }
    }
}