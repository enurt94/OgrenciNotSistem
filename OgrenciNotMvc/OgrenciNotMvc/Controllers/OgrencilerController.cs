using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models.EntityFramework;

namespace OgrenciNotMvc.Controllers
{
    public class OgrencilerController : Controller
    {
        // GET: Ogrenciler
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        public ActionResult Index()
        {
            var ogrenci = db.TBLOGRENCILER.ToList();
            return View(ogrenci);
        }
        [HttpGet]
        public ActionResult YeniOgrenci()
        {
            List<SelectListItem> degerler = (from i in db.TBLKULUPLER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KULUPAD,
                                                 Value = i.KULUPID.ToString()



                                             }).ToList();
            ViewBag.dgr = degerler;

            return View();
        }

        [HttpPost]
        public ActionResult YeniOgrenci(TBLOGRENCILER o)
        {
            var klp = db.TBLKULUPLER.Where(m => m.KULUPID == o.TBLKULUPLER.KULUPID).FirstOrDefault();
            o.TBLKULUPLER = klp;
            db.TBLOGRENCILER.Add(o);
            db.SaveChanges();
            return RedirectToAction("Index");



        }

        public ActionResult Sil(int id)
        {
            var ogrenci = db.TBLOGRENCILER.Find(id);
            db.TBLOGRENCILER.Remove(ogrenci);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult OgrenciGetir(int id)
        {
            var ogrenci2 = db.TBLOGRENCILER.Find(id);
            return View("OgrenciGetir", ogrenci2);
        }

        public ActionResult Guncelle(TBLOGRENCILER o)
        {
            var student = db.TBLOGRENCILER.Find(o.OGRENCIID);
            student.OGRAD = o.OGRAD;
            student.OGRSOYAD = o.OGRSOYAD;
            student.OGRFOTO = o.OGRFOTO;
            student.OGRKULUP = o.OGRKULUP;
            student.OGRCINSIYET = o.OGRCINSIYET;
            
            db.SaveChanges();
            return RedirectToAction("Index", "Ogrenciler");
        }


    }
}