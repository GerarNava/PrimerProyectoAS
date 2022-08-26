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
    public class EVENTOesController : Controller
    {
        private DBEventosEntities db = new DBEventosEntities();

        // GET: EVENTOes
        public ActionResult Index()
        {
            var eVENTO = db.EVENTO.Include(e => e.ENCARGADO).Include(e => e.TIPO_PRESENTACION).Include(e => e.PRECIOS_EVENTOS).Include(e => e.LUGAR);
            return View(eVENTO.ToList());
        }

        // GET: EVENTOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EVENTO eVENTO = db.EVENTO.Find(id);
            if (eVENTO == null)
            {
                return HttpNotFound();
            }
            return View(eVENTO);
        }

        // GET: EVENTOes/Create
        public ActionResult Create()
        {
            ViewBag.Id_Encargado = new SelectList(db.ENCARGADO, "Id_Encargado", "Nombre");
            ViewBag.Id_Arrendatario = new SelectList(db.TIPO_PRESENTACION, "Id_Presentacion", "Nombre_Presentacion");
            ViewBag.Id_Precio = new SelectList(db.PRECIOS_EVENTOS, "Id_Precio", "Id_Precio");
            ViewBag.Id_lugar = new SelectList(db.LUGAR, "Id_lugar", "Dirección");
            return View();
        }

        // POST: EVENTOes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Evento,Tipo_evento,FechaEvento,HoraRealización,Id_Arrendatario,Id_Encargado,Id_Precio,Comentarios,Id_lugar")] EVENTO eVENTO)
        {
            if (ModelState.IsValid)
            {
                db.EVENTO.Add(eVENTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Encargado = new SelectList(db.ENCARGADO, "Id_Encargado", "Nombre", eVENTO.Id_Encargado);
            ViewBag.Id_Arrendatario = new SelectList(db.TIPO_PRESENTACION, "Id_Presentacion", "Nombre_Presentacion", eVENTO.Id_Arrendatario);
            ViewBag.Id_Precio = new SelectList(db.PRECIOS_EVENTOS, "Id_Precio", "Id_Precio", eVENTO.Id_Precio);
            ViewBag.Id_lugar = new SelectList(db.LUGAR, "Id_lugar", "Dirección", eVENTO.Id_lugar);
            return View(eVENTO);
        }

        // GET: EVENTOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EVENTO eVENTO = db.EVENTO.Find(id);
            if (eVENTO == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Encargado = new SelectList(db.ENCARGADO, "Id_Encargado", "Nombre", eVENTO.Id_Encargado);
            ViewBag.Id_Arrendatario = new SelectList(db.TIPO_PRESENTACION, "Id_Presentacion", "Nombre_Presentacion", eVENTO.Id_Arrendatario);
            ViewBag.Id_Precio = new SelectList(db.PRECIOS_EVENTOS, "Id_Precio", "Id_Precio", eVENTO.Id_Precio);
            ViewBag.Id_lugar = new SelectList(db.LUGAR, "Id_lugar", "Dirección", eVENTO.Id_lugar);
            return View(eVENTO);
        }

        // POST: EVENTOes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Evento,Tipo_evento,FechaEvento,HoraRealización,Id_Arrendatario,Id_Encargado,Id_Precio,Comentarios,Id_lugar")] EVENTO eVENTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eVENTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Encargado = new SelectList(db.ENCARGADO, "Id_Encargado", "Nombre", eVENTO.Id_Encargado);
            ViewBag.Id_Arrendatario = new SelectList(db.TIPO_PRESENTACION, "Id_Presentacion", "Nombre_Presentacion", eVENTO.Id_Arrendatario);
            ViewBag.Id_Precio = new SelectList(db.PRECIOS_EVENTOS, "Id_Precio", "Id_Precio", eVENTO.Id_Precio);
            ViewBag.Id_lugar = new SelectList(db.LUGAR, "Id_lugar", "Dirección", eVENTO.Id_lugar);
            return View(eVENTO);
        }

        // GET: EVENTOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EVENTO eVENTO = db.EVENTO.Find(id);
            if (eVENTO == null)
            {
                return HttpNotFound();
            }
            return View(eVENTO);
        }

        // POST: EVENTOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EVENTO eVENTO = db.EVENTO.Find(id);
            db.EVENTO.Remove(eVENTO);
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
