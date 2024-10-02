using MvcOnlineTicariOtomasyon.DAL;
using MvcOnlineTicariOtomasyon.Models;
using PagedList;
using System.Linq;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        Context c = new Context();
        public ActionResult Index(int sayfa = 1)
        {
            var values = c.Kategoris.ToList().ToPagedList(sayfa, 4);
            return View(values);
        }

        [HttpGet]
        public ActionResult AddKategori()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddKategori(Kategori k)
        {
            c.Kategoris.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteKategori(int id)
        {
            var k = c.Kategoris.Find(id);
            c.Kategoris.Remove(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetKategori(int id)
        {
            var k = c.Kategoris.Find(id);
            return View("GetKategori", k);
        }

        public ActionResult UpdateKategori(Kategori k)
        {
            var ktg = c.Kategoris.Find(k.KategoriID);
            ktg.KategoriAd = k.KategoriAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}