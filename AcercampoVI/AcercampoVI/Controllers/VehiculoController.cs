using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AcercampoVI.Models.BD;

namespace AcercampoVI.Controllers
{
    public class VehiculoController : Controller
    {
        private ACERCAMPOVIEntities db = new ACERCAMPOVIEntities();

        // GET: Vehiculo
        public ActionResult Index()
        {
            var vehiculo = db.Vehiculo.Include(v => v.TipoTransporte).Include(v => v.UsuarioXRol);
            return View(vehiculo.ToList());
        }

        // GET: Vehiculo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehiculoE vehiculoE = db.Vehiculo.Find(id);
            if (vehiculoE == null)
            {
                return HttpNotFound();
            }
            return View(vehiculoE);
        }

        // GET: Vehiculo/Create
        public ActionResult Create()
        {
            ViewBag.IdTIpoTransporte = new SelectList(db.TipoTransporte, "IdTipoTransporte", "Nombre");
            ViewBag.IdUsuarioXRol = new SelectList(db.UsuarioXRol, "IdUsuarioXRol", "IdUsuarioXRol");
            return View();
        }

        // POST: Vehiculo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdVehiculo,IdUsuarioXRol,IdTIpoTransporte,Placa,FechaSoat,FechaTecicomecanica,CapacidadVehiculo")] VehiculoE vehiculoE)
        {
            if (ModelState.IsValid)
            {
                db.Vehiculo.Add(vehiculoE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdTIpoTransporte = new SelectList(db.TipoTransporte, "IdTipoTransporte", "Nombre", vehiculoE.IdTIpoTransporte);
            ViewBag.IdUsuarioXRol = new SelectList(db.UsuarioXRol, "IdUsuarioXRol", "IdUsuarioXRol", vehiculoE.IdUsuarioXRol);
            return View(vehiculoE);
        }

        // GET: Vehiculo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehiculoE vehiculoE = db.Vehiculo.Find(id);
            if (vehiculoE == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdTIpoTransporte = new SelectList(db.TipoTransporte, "IdTipoTransporte", "Nombre", vehiculoE.IdTIpoTransporte);
            ViewBag.IdUsuarioXRol = new SelectList(db.UsuarioXRol, "IdUsuarioXRol", "IdUsuarioXRol", vehiculoE.IdUsuarioXRol);
            return View(vehiculoE);
        }

        // POST: Vehiculo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdVehiculo,IdUsuarioXRol,IdTIpoTransporte,Placa,FechaSoat,FechaTecicomecanica,CapacidadVehiculo")] VehiculoE vehiculoE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehiculoE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdTIpoTransporte = new SelectList(db.TipoTransporte, "IdTipoTransporte", "Nombre", vehiculoE.IdTIpoTransporte);
            ViewBag.IdUsuarioXRol = new SelectList(db.UsuarioXRol, "IdUsuarioXRol", "IdUsuarioXRol", vehiculoE.IdUsuarioXRol);
            return View(vehiculoE);
        }

        // GET: Vehiculo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehiculoE vehiculoE = db.Vehiculo.Find(id);
            if (vehiculoE == null)
            {
                return HttpNotFound();
            }
            return View(vehiculoE);
        }

        // POST: Vehiculo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VehiculoE vehiculoE = db.Vehiculo.Find(id);
            db.Vehiculo.Remove(vehiculoE);
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
