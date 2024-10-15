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

        public ActionResult GetFatura(int id)
        {
            var fatura = c.Faturalars.Find(id);
            return View("GetFatura", fatura);
        }

        public ActionResult UpdateFatura(Faturalar f)
        {
            var fat = c.Faturalars.Find(f.FaturaID);
            fat.FaturaSeriNo = f.FaturaSeriNo;
            fat.FaturaSiraNo = f.FaturaSiraNo;
            fat.Saat = f.Saat;
            fat.Tarih = f.Tarih;
            fat.TeslimAlan = f.TeslimAlan;
            fat.TeslimEden = f.TeslimEden;
            fat.VergiDairesi = f.VergiDairesi;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FaturaDetails(int id)
        {
            var values = c.FaturaKalems.Where(d => d.FaturaID == id).ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult NewKalem()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewKalem(FaturaKalem p)
        {
            c.FaturaKalems.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Dinamik()
        {
            Class4 cs = new Class4();
            cs.deger1 = c.Faturalars.ToList();
            cs.deger2 = c.FaturaKalems.ToList();
            return View(cs);
        }

        public ActionResult FaturaKaydet(string FaturaSeriNo, string FaturaSiraNo, DateTime Tarih,
            string VergiDairesi, string Saat, string TeslimEden, string TeslimAlan, string Toplam, FaturaKalem[] kalemler)
        {
            Faturalar f = new Faturalar();
            f.FaturaSeriNo = FaturaSeriNo;
            f.FaturaSiraNo = FaturaSiraNo;
            f.Tarih = Tarih;
            f.VergiDairesi = VergiDairesi;
            f.Saat = Saat;
            f.TeslimAlan = TeslimAlan;
            f.TeslimAlan = TeslimAlan;
            f.Toplam = decimal.Parse(Toplam);
            c.Faturalars.Add(f);
            foreach (var x in kalemler)
            {
                FaturaKalem fk = new FaturaKalem();
                fk.Aciklama = x.Aciklama; 
                fk.BirimFiyat = x.BirimFiyat;
                fk.FaturaID = x.FaturaID;
                fk.Miktar = x.Miktar;
                fk.Tutar = x.Tutar; 
                c.FaturaKalems.Add(fk); 
            }
            c.SaveChanges();
            return Json("İşlem Başarılı", JsonRequestBehavior.AllowGet);
        }
    }
}