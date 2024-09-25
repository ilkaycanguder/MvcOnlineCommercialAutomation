using MvcOnlineTicariOtomasyon.DAL;
using MvcOnlineTicariOtomasyon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        Context c = new Context();
        public ActionResult Index()
        {
            var values = c.Personels.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddPersonel()
        {
            List<SelectListItem> value = (from x in c.Departmans.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.DepartmanAd,
                                              Value = x.DepartmanID.ToString()
                                          }).ToList();
            ViewBag.dgr = value;
            return View();
        }

        [HttpPost]
        public ActionResult AddPersonel(Personel p)
        {
            c.Personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetPersonel(int id)
        {
            List<SelectListItem> value = (from x in c.Departmans.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.DepartmanAd,
                                              Value = x.DepartmanID.ToString()
                                          }).ToList();
            ViewBag.dgr = value;
            var prs = c.Personels.Find(id);
            return View("GetPersonel", prs);
        }

        public ActionResult UpdatePersonel(Personel p)
        {
            var prsn = c.Personels.Find(p.PersonelID);
            prsn.PersonelAd = p.PersonelAd;
            prsn.PersonelSoyad = p.PersonelSoyad;
            prsn.PersonelGorsel = p.PersonelGorsel;
            prsn.DepartmanID = p.DepartmanID;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelListe()
        {
            return View();
        }
    }
}