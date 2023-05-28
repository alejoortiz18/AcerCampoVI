using AcercampoVI.Models.BD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AcercampoVI.Controllers
{
    public class UsuarioXRolController : Controller
    {
        private ACERCAMPOVIEntities db = new ACERCAMPOVIEntities();

        // GET: UsuarioXRol
        public ActionResult Index()
        {
            var usuarioXRol = db.UsuarioXRol.Include(u => u.Rol).Include(u => u.Usuarios);
            return View(usuarioXRol.ToList());
        }

        // GET: UsuarioXRol/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioXRolE usuarioXRolE = db.UsuarioXRol.Find(id);
            if (usuarioXRolE == null)
            {
                return HttpNotFound();
            }
            return View(usuarioXRolE);
        }

        // GET: UsuarioXRol/Create
        public ActionResult Create()
        {
            ViewBag.IdRol = new SelectList(db.Rol, "IdRol", "Nombre");
            ViewBag.IdUsuario = new SelectList(db.Usuarios, "IdUsuario", "Nombre");
            return View();
        }

        // POST: UsuarioXRol/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdUsuarioXRol,IdRol,IdUsuario")] UsuarioXRolE usuarioXRolE)
        {
            if (ModelState.IsValid)
            {
                db.UsuarioXRol.Add(usuarioXRolE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdRol = new SelectList(db.Rol, "IdRol", "Nombre", usuarioXRolE.IdRol);
            ViewBag.IdUsuario = new SelectList(db.Usuarios, "IdUsuario", "Nombre", usuarioXRolE.IdUsuario);
            return View(usuarioXRolE);
        }

        // GET: UsuarioXRol/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioXRolE usuarioXRolE = db.UsuarioXRol.Find(id);
            if (usuarioXRolE == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdRol = new SelectList(db.Rol, "IdRol", "Nombre", usuarioXRolE.IdRol);
            ViewBag.IdUsuario = new SelectList(db.Usuarios, "IdUsuario", "Nombre", usuarioXRolE.IdUsuario);
            return View(usuarioXRolE);
        }

        // POST: UsuarioXRol/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdUsuarioXRol,IdRol,IdUsuario")] UsuarioXRolE usuarioXRolE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuarioXRolE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdRol = new SelectList(db.Rol, "IdRol", "Nombre", usuarioXRolE.IdRol);
            ViewBag.IdUsuario = new SelectList(db.Usuarios, "IdUsuario", "Nombre", usuarioXRolE.IdUsuario);
            return View(usuarioXRolE);
        }

        // GET: UsuarioXRol/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioXRolE usuarioXRolE = db.UsuarioXRol.Find(id);
            if (usuarioXRolE == null)
            {
                return HttpNotFound();
            }
            return View(usuarioXRolE);
        }

        // POST: UsuarioXRol/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UsuarioXRolE usuarioXRolE = db.UsuarioXRol.Find(id);
            db.UsuarioXRol.Remove(usuarioXRolE);
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
