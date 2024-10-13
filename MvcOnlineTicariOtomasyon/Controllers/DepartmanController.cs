using MvcOnlineTicariOtomasyon.DAL;
using MvcOnlineTicariOtomasyon.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [Authorize]
    public class DepartmanController : Controller
    {
        // GET: Departman
        Context c = new Context();
        public ActionResult Index()
        {
            var values = c.Departmans.Where(x => x.Durum == true).ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddDepartman()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddDepartman(Departman d)
        {
            c.Departmans.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteDepartman(int id)
        {
            var dep = c.Departmans.Find(id);
            dep.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetDepartman(int id)
        {
            var dpt = c.Departmans.Find(id);
            return View("GetDepartman", dpt);
        }

        public ActionResult UpdateDepartman(Departman p)
        {
            var dept = c.Departmans.Find(p.DepartmanID);
            dept.DepartmanAd = p.DepartmanAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanDetails(int id)
        {
            var values = c.Personels.Where(d => d.DepartmanID == id).ToList();
            var dpt = c.Departmans.Where(x => x.DepartmanID == id).Select(y => y.DepartmanAd).FirstOrDefault();
            ViewBag.d = dpt;
            return View(values);
        }

        public ActionResult DepartmanPersonelSatis(int id)
        {
            var values = c.SatisHarekets.Where(x => x.PersonelID == id).ToList();
            var per = c.Personels.Where(x => x.PersonelID == id).Select(y => y.PersonelAd + " " + y.PersonelSoyad).FirstOrDefault();
            ViewBag.dpers = per;
            return View(values);
        }
    }
}