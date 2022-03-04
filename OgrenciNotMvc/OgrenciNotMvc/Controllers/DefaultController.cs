using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models.EntityFramework;

namespace OgrenciNotMvc.Controllers
{
    public class DefaultController : Controller
    { //İşin arka plan
        // GET: Default
        DbMvcOkulEntities db = new DbMvcOkulEntities(); //Tablolara ulaşmak için kullanılan sistem.
        public ActionResult Index()
        {
            var dersler = db.TBLDERSLER.ToList();
            return View(dersler);
        }

        [HttpGet]
        public ActionResult YeniDers()
        {
            return View();
        }
         
       [HttpPost]
        public ActionResult YeniDers(TBLDERSLER d)
        {
            db.TBLDERSLER.Add(d);
            db.SaveChanges();

            return View();
        }

        public ActionResult Sil(int id)
        {
            var ders = db.TBLDERSLER.Find(id);
            db.TBLDERSLER.Remove(ders);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult DersGetir(int id)
        {
            var ders2 = db.TBLDERSLER.Find(id);
            return View("DersGetir",ders2);
        }

        public ActionResult Guncelle(TBLDERSLER d)
        {
            var ders = db.TBLDERSLER.Find(d.DERSID);
            ders.DERSAD = d.DERSAD;
            db.SaveChanges();
            return RedirectToAction("Index", "Default");

        }

    }
}