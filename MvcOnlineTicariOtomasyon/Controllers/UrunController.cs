using MvcOnlineTicariOtomasyon.DAL;
using MvcOnlineTicariOtomasyon.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        Context c = new Context();
        public ActionResult Index(string p)
        {
            var values = from x in c.Uruns select x;
            if (!string.IsNullOrEmpty(p))
            {
                values = values.Where(y => y.UrunAd.Contains(p));
            }
            return View(values.ToList());
        }

        [HttpGet]
        public ActionResult NewUrun()
        {
            List<SelectListItem> value = (from x in c.Kategoris.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.KategoriAd,
                                              Value = x.KategoriID.ToString()
                                          }).ToList();
            ViewBag.dgr = value;
            return View();
        }

        [HttpPost]
        public ActionResult NewUrun(Urun p)
        {
            c.Uruns.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteUrun(int id)
        {
            var value = c.Uruns.Find(id);
            value.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetUrun(int id)
        {
            List<SelectListItem> value = (from x in c.Kategoris.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.KategoriAd,
                                              Value = x.KategoriID.ToString()
                                          }).ToList();
            ViewBag.dgr = value;
            var urunvalue = c.Uruns.Find(id);
            return View("GetUrun", urunvalue);
        }

        public ActionResult UpdateUrun(Urun p)
        {
            var urn = c.Uruns.Find(p.UrunID);
            urn.AlisFiyat = p.AlisFiyat;
            urn.Durum = p.Durum;
            urn.KategoriID = p.KategoriID;
            urn.Marka = p.Marka;
            urn.SatisFiyat = urn.SatisFiyat;
            urn.Stok = p.Stok;
            urn.UrunAd = p.UrunAd;
            urn.UrunGorsel = p.UrunGorsel;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunListesi()
        {
            var values = c.Uruns.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult SatisYap(int id)
        {
            List<SelectListItem> value = (from x in c.Personels.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.PersonelAd + " " + x.PersonelSoyad,
                                              Value = x.PersonelID.ToString(),
                                          }).ToList();
            ViewBag.dgr1 = value;
            var urunvalue = c.Uruns.Find(id);
            ViewBag.dgr2 = urunvalue.UrunID;
            ViewBag.dgr3 = urunvalue.SatisFiyat;
            return View();
        }

        [HttpPost]
        public ActionResult SatisYap(SatisHareket p)
        {
            p.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SatisHarekets.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index", "Satis");
        }
    }
}