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
    public class RolController : Controller
    {
        private ACERCAMPOVIEntities db = new ACERCAMPOVIEntities();

        // GET: Rol
        public ActionResult Index()
        {
            return View(db.Rol.ToList());
        }

        // GET: Rol/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RolE rolE = db.Rol.Find(id);
            if (rolE == null)
            {
                return HttpNotFound();
            }
            return View(rolE);
        }

        // GET: Rol/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rol/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdRol,Nombre")] RolE rolE)
        {
            if (ModelState.IsValid)
            {
                db.Rol.Add(rolE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rolE);
        }

        // GET: Rol/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RolE rolE = db.Rol.Find(id);
            if (rolE == null)
            {
                return HttpNotFound();
            }
            return View(rolE);
        }

        // POST: Rol/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdRol,Nombre")] RolE rolE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rolE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rolE);
        }

        // GET: Rol/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RolE rolE = db.Rol.Find(id);
            if (rolE == null)
            {
                return HttpNotFound();
            }
            return View(rolE);
        }

        // POST: Rol/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RolE rolE = db.Rol.Find(id);
            db.Rol.Remove(rolE);
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
