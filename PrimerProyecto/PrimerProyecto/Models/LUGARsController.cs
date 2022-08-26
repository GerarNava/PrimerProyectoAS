using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PrimerProyecto;

namespace PrimerProyecto.Models
{
    public class LUGARsController : Controller
    {
        private DBEventosEntities db = new DBEventosEntities();

        // GET: LUGARs
        public ActionResult Index()
        {
            var lUGAR = db.LUGAR.Include(l => l.DISTRITO);
            return View(lUGAR.ToList());
        }

        // GET: LUGARs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LUGAR lUGAR = db.LUGAR.Find(id);
            if (lUGAR == null)
            {
                return HttpNotFound();
            }
            return View(lUGAR);
        }

        // GET: LUGARs/Create
        public ActionResult Create()
        {
            ViewBag.Id_distrito = new SelectList(db.DISTRITO, "Id_distrito", "Nom_Distrito");
            return View();
        }

        // POST: LUGARs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_lugar,Dirección,Nom_Lugar,Id_distrito")] LUGAR lUGAR)
        {
            if (ModelState.IsValid)
            {
                db.LUGAR.Add(lUGAR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_distrito = new SelectList(db.DISTRITO, "Id_distrito", "Nom_Distrito", lUGAR.Id_distrito);
            return View(lUGAR);
        }

        // GET: LUGARs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LUGAR lUGAR = db.LUGAR.Find(id);
            if (lUGAR == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_distrito = new SelectList(db.DISTRITO, "Id_distrito", "Nom_Distrito", lUGAR.Id_distrito);
            return View(lUGAR);
        }

        // POST: LUGARs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_lugar,Dirección,Nom_Lugar,Id_distrito")] LUGAR lUGAR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lUGAR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_distrito = new SelectList(db.DISTRITO, "Id_distrito", "Nom_Distrito", lUGAR.Id_distrito);
            return View(lUGAR);
        }

        // GET: LUGARs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LUGAR lUGAR = db.LUGAR.Find(id);
            if (lUGAR == null)
            {
                return HttpNotFound();
            }
            return View(lUGAR);
        }

        // POST: LUGARs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LUGAR lUGAR = db.LUGAR.Find(id);
            db.LUGAR.Remove(lUGAR);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
