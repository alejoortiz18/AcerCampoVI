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
    public class TipoProductoController : Controller
    {
        private ACERCAMPOVIEntities db = new ACERCAMPOVIEntities();

        // GET: TipoProducto
        public ActionResult Index()
        {
            return View(db.TipoProducto.ToList());
        }

        // GET: TipoProducto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoProductoE tipoProductoE = db.TipoProducto.Find(id);
            if (tipoProductoE == null)
            {
                return HttpNotFound();
            }
            return View(tipoProductoE);
        }

        // GET: TipoProducto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoProducto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTipoProducto,Nombre")] TipoProductoE tipoProductoE)
        {
            if (ModelState.IsValid)
            {
                db.TipoProducto.Add(tipoProductoE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoProductoE);
        }

        // GET: TipoProducto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoProductoE tipoProductoE = db.TipoProducto.Find(id);
            if (tipoProductoE == null)
            {
                return HttpNotFound();
            }
            return View(tipoProductoE);
        }

        // POST: TipoProducto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTipoProducto,Nombre")] TipoProductoE tipoProductoE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoProductoE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoProductoE);
        }

        // GET: TipoProducto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoProductoE tipoProductoE = db.TipoProducto.Find(id);
            if (tipoProductoE == null)
            {
                return HttpNotFound();
            }
            return View(tipoProductoE);
        }

        // POST: TipoProducto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoProductoE tipoProductoE = db.TipoProducto.Find(id);
            db.TipoProducto.Remove(tipoProductoE);
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
