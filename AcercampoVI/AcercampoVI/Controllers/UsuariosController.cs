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
    public class UsuariosController : Controller
    {
        private ACERCAMPOVIEntities db = new ACERCAMPOVIEntities();

        // GET: Usuarios
        public ActionResult Index()
        {
            return View(db.Usuarios.ToList());
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuariosE usuariosE = db.Usuarios.Find(id);
            if (usuariosE == null)
            {
                return HttpNotFound();
            }
            return View(usuariosE);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdUsuario,Nombre,Apellidos,FechaNacimientos,Identificacion,Correo,Direccion,Telefono,Localidad,Nit,Rut,Contrasena")] UsuariosE usuariosE)
        {
            if (ModelState.IsValid)
            {
                db.Usuarios.Add(usuariosE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usuariosE);
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuariosE usuariosE = db.Usuarios.Find(id);
            if (usuariosE == null)
            {
                return HttpNotFound();
            }
            return View(usuariosE);
        }

        // POST: Usuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdUsuario,Nombre,Apellidos,FechaNacimientos,Identificacion,Correo,Direccion,Telefono,Localidad,Nit,Rut,Contrasena")] UsuariosE usuariosE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuariosE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuariosE);
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuariosE usuariosE = db.Usuarios.Find(id);
            if (usuariosE == null)
            {
                return HttpNotFound();
            }
            return View(usuariosE);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UsuariosE usuariosE = db.Usuarios.Find(id);
            db.Usuarios.Remove(usuariosE);
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
