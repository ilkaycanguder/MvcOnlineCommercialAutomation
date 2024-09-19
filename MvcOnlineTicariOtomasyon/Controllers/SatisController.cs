using MvcOnlineTicariOtomasyon.DAL;
using MvcOnlineTicariOtomasyon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        Context c = new Context();
        public ActionResult Index()
        {
            var values = c.SatisHarekets.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult YeniSatis()
        {
            List<SelectListItem> value = (from x in c.Uruns.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.UrunAd,
                                              Value = x.UrunID.ToString(),
                                          }).ToList();
            List<SelectListItem> value2 = (from x in c.Carilers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAd + " " + x.CariSoyad,
                                               Value = x.CariID.ToString(),
                                           }).ToList();
            List<SelectListItem> value3 = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.PersonelSoyad,
                                               Value = x.PersonelID.ToString(),
                                           }).ToList();
            ViewBag.dgr1 = value;
            ViewBag.dgr2 = value2;
            ViewBag.dgr3 = value3;

            return View();
        }

        [HttpPost]
        public ActionResult YeniSatis(SatisHareket s)
        {
            s.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SatisHarekets.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}