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
    public class ENCARGADOesController : Controller
    {
        private DBEventosEntities db = new DBEventosEntities();

        // GET: ENCARGADOes
        public ActionResult Index()
        {
            return View(db.ENCARGADO.ToList());
        }

        // GET: ENCARGADOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ENCARGADO eNCARGADO = db.ENCARGADO.Find(id);
            if (eNCARGADO == null)
            {
                return HttpNotFound();
            }
            return View(eNCARGADO);
        }

        // GET: ENCARGADOes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ENCARGADOes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Encargado,Nombre")] ENCARGADO eNCARGADO)
        {
            if (ModelState.IsValid)
            {
                db.ENCARGADO.Add(eNCARGADO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eNCARGADO);
        }

        // GET: ENCARGADOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ENCARGADO eNCARGADO = db.ENCARGADO.Find(id);
            if (eNCARGADO == null)
            {
                return HttpNotFound();
            }
            return View(eNCARGADO);
        }

        // POST: ENCARGADOes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Encargado,Nombre")] ENCARGADO eNCARGADO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eNCARGADO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eNCARGADO);
        }

        // GET: ENCARGADOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ENCARGADO eNCARGADO = db.ENCARGADO.Find(id);
            if (eNCARGADO == null)
            {
                return HttpNotFound();
            }
            return View(eNCARGADO);
        }

        // POST: ENCARGADOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ENCARGADO eNCARGADO = db.ENCARGADO.Find(id);
            db.ENCARGADO.Remove(eNCARGADO);
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
