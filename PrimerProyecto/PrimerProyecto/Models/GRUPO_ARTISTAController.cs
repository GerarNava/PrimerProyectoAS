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
    public class GRUPO_ARTISTAController : Controller
    {
        private DBEventosEntities db = new DBEventosEntities();

        // GET: GRUPO_ARTISTA
        public ActionResult Index()
        {
            return View(db.GRUPO_ARTISTA.ToList());
        }

        // GET: GRUPO_ARTISTA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GRUPO_ARTISTA gRUPO_ARTISTA = db.GRUPO_ARTISTA.Find(id);
            if (gRUPO_ARTISTA == null)
            {
                return HttpNotFound();
            }
            return View(gRUPO_ARTISTA);
        }

        // GET: GRUPO_ARTISTA/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GRUPO_ARTISTA/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_grupoArtista,Nombre,Nacionalidad,COMENTARIOS")] GRUPO_ARTISTA gRUPO_ARTISTA)
        {
            if (ModelState.IsValid)
            {
                db.GRUPO_ARTISTA.Add(gRUPO_ARTISTA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gRUPO_ARTISTA);
        }

        // GET: GRUPO_ARTISTA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GRUPO_ARTISTA gRUPO_ARTISTA = db.GRUPO_ARTISTA.Find(id);
            if (gRUPO_ARTISTA == null)
            {
                return HttpNotFound();
            }
            return View(gRUPO_ARTISTA);
        }

        // POST: GRUPO_ARTISTA/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_grupoArtista,Nombre,Nacionalidad,COMENTARIOS")] GRUPO_ARTISTA gRUPO_ARTISTA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gRUPO_ARTISTA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gRUPO_ARTISTA);
        }

        // GET: GRUPO_ARTISTA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GRUPO_ARTISTA gRUPO_ARTISTA = db.GRUPO_ARTISTA.Find(id);
            if (gRUPO_ARTISTA == null)
            {
                return HttpNotFound();
            }
            return View(gRUPO_ARTISTA);
        }

        // POST: GRUPO_ARTISTA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GRUPO_ARTISTA gRUPO_ARTISTA = db.GRUPO_ARTISTA.Find(id);
            db.GRUPO_ARTISTA.Remove(gRUPO_ARTISTA);
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
