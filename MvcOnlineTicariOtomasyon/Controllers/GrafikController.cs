using MvcOnlineTicariOtomasyon.DAL;
using MvcOnlineTicariOtomasyon.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class GrafikController : Controller
    {
        // GET: Grafik
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index2()
        {
            var drawGraphic = new Chart(600, 600);
            drawGraphic.AddTitle("Kategori - Ürün Stok Sayısı")
                .AddLegend("Stok")
                .AddSeries("Değerler", xValue: new[]{
                    "Mobilya","Ofis Eşyaları","Bilgisayar"
            }, yValues: new[] { 85, 66, 98 }).Write();
            return File(drawGraphic.ToWebImage().GetBytes(), "image/jpeg");
        }

        public ActionResult Index3()
        {
            ArrayList xValue = new ArrayList();
            ArrayList yValue = new ArrayList();
            var sonuclar = c.Uruns.ToList();
            sonuclar.ToList().ForEach(x => xValue.Add(x.UrunAd));
            sonuclar.ToList().ForEach(y => yValue.Add(y.Stok));
            var graphic = new Chart(800, 800)
                .AddTitle("Stoklar")
                .AddSeries(chartType: "Column", name: "Stok", xValue: xValue, yValues: yValue);
            return File(graphic.ToWebImage().GetBytes(), "image/jpeg");
        }

        public ActionResult Index4()
        {
            return View();
        }

        public ActionResult VisualizeUrunResult()
        {
            return Json(UrunListesi(), JsonRequestBehavior.AllowGet);
        }

        public List<sinif1> UrunListesi()
        {
            List<sinif1> list = new List<sinif1>();
            list.Add(new sinif1()
            {
                urunad = "Bilgisayar",
                stok = 120
            });
            list.Add(new sinif1()
            {
                urunad = "Beyaz Eşya",
                stok = 150
            });
            list.Add(new sinif1()
            {
                urunad = "Mobilya",
                stok = 70
            });
            list.Add(new sinif1()
            {
                urunad = "Küçük Ev Aletleri",
                stok = 180
            });
            list.Add(new sinif1()
            {
                urunad = "Mobil Cihazlar",
                stok = 90
            });
            return list;
        }

        public ActionResult Index5()
        {
            return View();
        }
        public ActionResult VisualizeUrunResult2()
        {
            return Json(UrunListesi2(), JsonRequestBehavior.AllowGet);
        }

        public List<sinif2> UrunListesi2()
        {
            List<sinif2> snf = new List<sinif2>();
            var sorgu = from x in c.Uruns
                        group x by x.UrunAd into g
                        select new sinif2
                        {
                            urn = g.Key,
                            stk = g.Count()
                        };
            return (sorgu.ToList());
        }

        public ActionResult Index6()
        {
            return View();
        }
        public ActionResult Index7()
        {
            return View();
        }
    }
}