﻿using MvcOnlineTicariOtomasyon.DAL;
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
    }
}