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
    public class TIPO_PRESENTACIONController : Controller
    {
        private DBEventosEntities db = new DBEventosEntities();

        // GET: TIPO_PRESENTACION
        public ActionResult Index()
        {
            var tIPO_PRESENTACION = db.TIPO_PRESENTACION.Include(t => t.GRUPO_ARTISTA);
            return View(tIPO_PRESENTACION.ToList());
        }

        // GET: TIPO_PRESENTACION/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_PRESENTACION tIPO_PRESENTACION = db.TIPO_PRESENTACION.Find(id);
            if (tIPO_PRESENTACION == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_PRESENTACION);
        }

        // GET: TIPO_PRESENTACION/Create
        public ActionResult Create()
        {
            ViewBag.Id_grupoArtista = new SelectList(db.GRUPO_ARTISTA, "Id_grupoArtista", "Nombre");
            return View();
        }

        // POST: TIPO_PRESENTACION/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Presentacion,Nombre_Presentacion,Telefono,Personas_Evento,Id_grupoArtista")] TIPO_PRESENTACION tIPO_PRESENTACION)
        {
            if (ModelState.IsValid)
            {
                db.TIPO_PRESENTACION.Add(tIPO_PRESENTACION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_grupoArtista = new SelectList(db.GRUPO_ARTISTA, "Id_grupoArtista", "Nombre", tIPO_PRESENTACION.Id_grupoArtista);
            return View(tIPO_PRESENTACION);
        }

        // GET: TIPO_PRESENTACION/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_PRESENTACION tIPO_PRESENTACION = db.TIPO_PRESENTACION.Find(id);
            if (tIPO_PRESENTACION == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_grupoArtista = new SelectList(db.GRUPO_ARTISTA, "Id_grupoArtista", "Nombre", tIPO_PRESENTACION.Id_grupoArtista);
            return View(tIPO_PRESENTACION);
        }

        // POST: TIPO_PRESENTACION/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Presentacion,Nombre_Presentacion,Telefono,Personas_Evento,Id_grupoArtista")] TIPO_PRESENTACION tIPO_PRESENTACION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tIPO_PRESENTACION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_grupoArtista = new SelectList(db.GRUPO_ARTISTA, "Id_grupoArtista", "Nombre", tIPO_PRESENTACION.Id_grupoArtista);
            return View(tIPO_PRESENTACION);
        }

        // GET: TIPO_PRESENTACION/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_PRESENTACION tIPO_PRESENTACION = db.TIPO_PRESENTACION.Find(id);
            if (tIPO_PRESENTACION == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_PRESENTACION);
        }

        // POST: TIPO_PRESENTACION/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TIPO_PRESENTACION tIPO_PRESENTACION = db.TIPO_PRESENTACION.Find(id);
            db.TIPO_PRESENTACION.Remove(tIPO_PRESENTACION);
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
