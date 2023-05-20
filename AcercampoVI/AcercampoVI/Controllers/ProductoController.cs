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
    public class ProductoController : Controller
    {
        private ACERCAMPOVIEntities db = new ACERCAMPOVIEntities();

        // GET: Producto
        public ActionResult Index()
        {
            var producto = db.Producto.Include(p => p.TipoProducto);
            return View(producto.ToList());
        }

        // GET: Producto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductoE productoE = db.Producto.Find(id);
            if (productoE == null)
            {
                return HttpNotFound();
            }
            return View(productoE);
        }

        // GET: Producto/Create
        public ActionResult Create()
        {
            ViewBag.IdTipoProducto = new SelectList(db.TipoProducto, "IdTipoProducto", "Nombre");
            return View();
        }

        // POST: Producto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdProducto,IdUsuario,IdTipoProducto,Nombre,Cantidad,FechaIngreso")] ProductoE productoE)
        {
            if (ModelState.IsValid)
            {
                db.Producto.Add(productoE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdTipoProducto = new SelectList(db.TipoProducto, "IdTipoProducto", "Nombre", productoE.IdTipoProducto);
            return View(productoE);
        }

        // GET: Producto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductoE productoE = db.Producto.Find(id);
            if (productoE == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdTipoProducto = new SelectList(db.TipoProducto, "IdTipoProducto", "Nombre", productoE.IdTipoProducto);
            return View(productoE);
        }

        // POST: Producto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdProducto,IdUsuario,IdTipoProducto,Nombre,Cantidad,FechaIngreso")] ProductoE productoE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productoE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdTipoProducto = new SelectList(db.TipoProducto, "IdTipoProducto", "Nombre", productoE.IdTipoProducto);
            return View(productoE);
        }

        // GET: Producto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductoE productoE = db.Producto.Find(id);
            if (productoE == null)
            {
                return HttpNotFound();
            }
            return View(productoE);
        }

        // POST: Producto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductoE productoE = db.Producto.Find(id);
            db.Producto.Remove(productoE);
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
