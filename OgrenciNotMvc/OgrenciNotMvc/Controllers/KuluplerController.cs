using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models.EntityFramework;
namespace OgrenciNotMvc.Controllers

{
    public class KuluplerController : Controller
    {
        // GET: Kulupler
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        public ActionResult Index()
        {
            var kulupler = db.TBLKULUPLER.ToList();
            return View(kulupler);
        }

        [HttpGet]
        public ActionResult YeniKulup()
        {
            return View();
        }

        public ActionResult YeniKulup(TBLKULUPLER k)
        {
            db.TBLKULUPLER.Add(k);
            db.SaveChanges();
            return View();
        }

        public ActionResult Sil(int id)
        {
            ///Silinecek değeri bulmam lazm
            ///

            var kulup = db.TBLKULUPLER.Find(id);
            db.TBLKULUPLER.Remove(kulup);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult KulupGetir(int id)
        {
            var kulup2 = db.TBLKULUPLER.Find(id);
            return View("KulupGetir",kulup2);
        }

        public ActionResult Guncelle(TBLKULUPLER k)
        {
            var klp = db.TBLKULUPLER.Find(k.KULUPID);
            klp.KULUPAD = k.KULUPAD;
            db.SaveChanges();
            return RedirectToAction("Index", "Kulupler");
        }
    }
}