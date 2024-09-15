using MvcOnlineTicariOtomasyon.DAL;
using MvcOnlineTicariOtomasyon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class DepartmanController : Controller
    {
        // GET: Departman
        Context c = new Context();
        public ActionResult Index()
        {
            var values = c.Departmans.ToList();
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
    }
}