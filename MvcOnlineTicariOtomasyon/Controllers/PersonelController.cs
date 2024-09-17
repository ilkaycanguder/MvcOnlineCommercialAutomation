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
    }
}