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
    public class DISTRITOesController : Controller
    {
        private DBEventosEntities db = new DBEventosEntities();

        // GET: DISTRITOes
        public ActionResult Index()
        {
            var dISTRITO = db.DISTRITO.Include(d => d.PAIS);
            return View(dISTRITO.ToList());
        }

        // GET: DISTRITOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DISTRITO dISTRITO = db.DISTRITO.Find(id);
            if (dISTRITO == null)
            {
                return HttpNotFound();
            }
            return View(dISTRITO);
        }

        // GET: DISTRITOes/Create
        public ActionResult Create()
        {
            ViewBag.Id_Pais = new SelectList(db.PAIS, "Id_Pais", "NomPais");
            return View();
        }

        // POST: DISTRITOes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_distrito,Nom_Distrito,Id_Pais")] DISTRITO dISTRITO)
        {
            if (ModelState.IsValid)
            {
                db.DISTRITO.Add(dISTRITO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Pais = new SelectList(db.PAIS, "Id_Pais", "NomPais", dISTRITO.Id_Pais);
            return View(dISTRITO);
        }

        // GET: DISTRITOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DISTRITO dISTRITO = db.DISTRITO.Find(id);
            if (dISTRITO == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Pais = new SelectList(db.PAIS, "Id_Pais", "NomPais", dISTRITO.Id_Pais);
            return View(dISTRITO);
        }

        // POST: DISTRITOes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_distrito,Nom_Distrito,Id_Pais")] DISTRITO dISTRITO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dISTRITO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Pais = new SelectList(db.PAIS, "Id_Pais", "NomPais", dISTRITO.Id_Pais);
            return View(dISTRITO);
        }

        // GET: DISTRITOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DISTRITO dISTRITO = db.DISTRITO.Find(id);
            if (dISTRITO == null)
            {
                return HttpNotFound();
            }
            return View(dISTRITO);
        }

        // POST: DISTRITOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DISTRITO dISTRITO = db.DISTRITO.Find(id);
            db.DISTRITO.Remove(dISTRITO);
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
