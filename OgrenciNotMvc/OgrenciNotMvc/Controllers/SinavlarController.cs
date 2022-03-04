using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models.EntityFramework;
using OgrenciNotMvc.Models;
namespace OgrenciNotMvc.Controllers

{
    public class SinavlarController : Controller
    {
        // GET: Sinavlar
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        public ActionResult Index()
        {

            var sinavlar = db.TBLNOTLAR.ToList();
            return View(sinavlar);
        }
        [HttpGet]
        public ActionResult YeniSinav()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniSinav(TBLNOTLAR tbn)
        {
            db.TBLNOTLAR.Add(tbn);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult NotGetir(int id)
        {
            var not2 = db.TBLNOTLAR.Find(id);
            return View("NotGetir", not2);
        }
        [HttpPost]
        public ActionResult NotGetir(TBLNOTLAR n, int SINAV1, int SINAV2, int SINAV3, int PROJE,Class1 model)
        {
            if (model.islem == "HESAPLA")
            {
                //İşlem 1 yap
                int ORTALAMA = (SINAV1 + SINAV2 + SINAV3 + PROJE) / 4;
                ViewBag.ort = ORTALAMA;
                
            }
            if (model.islem == "NOTGUNCELLE")
            {
                //İşlem 2 yap
            }

            return View();          
        }
    }
}