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
    public class PRECIOS_EVENTOSController : Controller
    {
        private DBEventosEntities db = new DBEventosEntities();

        // GET: PRECIOS_EVENTOS
        public ActionResult Index()
        {
            return View(db.PRECIOS_EVENTOS.ToList());
        }

        // GET: PRECIOS_EVENTOS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRECIOS_EVENTOS pRECIOS_EVENTOS = db.PRECIOS_EVENTOS.Find(id);
            if (pRECIOS_EVENTOS == null)
            {
                return HttpNotFound();
            }
            return View(pRECIOS_EVENTOS);
        }

        // GET: PRECIOS_EVENTOS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PRECIOS_EVENTOS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Precio,precioEvento")] PRECIOS_EVENTOS pRECIOS_EVENTOS)
        {
            if (ModelState.IsValid)
            {
                db.PRECIOS_EVENTOS.Add(pRECIOS_EVENTOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pRECIOS_EVENTOS);
        }

        // GET: PRECIOS_EVENTOS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRECIOS_EVENTOS pRECIOS_EVENTOS = db.PRECIOS_EVENTOS.Find(id);
            if (pRECIOS_EVENTOS == null)
            {
                return HttpNotFound();
            }
            return View(pRECIOS_EVENTOS);
        }

        // POST: PRECIOS_EVENTOS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Precio,precioEvento")] PRECIOS_EVENTOS pRECIOS_EVENTOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRECIOS_EVENTOS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pRECIOS_EVENTOS);
        }

        // GET: PRECIOS_EVENTOS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRECIOS_EVENTOS pRECIOS_EVENTOS = db.PRECIOS_EVENTOS.Find(id);
            if (pRECIOS_EVENTOS == null)
            {
                return HttpNotFound();
            }
            return View(pRECIOS_EVENTOS);
        }

        // POST: PRECIOS_EVENTOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRECIOS_EVENTOS pRECIOS_EVENTOS = db.PRECIOS_EVENTOS.Find(id);
            db.PRECIOS_EVENTOS.Remove(pRECIOS_EVENTOS);
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
