using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Empresas.Models;

namespace Empresas.Views
{
    public class EMPRESAsController : Controller
    {
        private EMPRESAEntities db = new EMPRESAEntities();

        // GET: EMPRESAs
        public ActionResult Index()
        {
            var eMPRESA = db.EMPRESA.Include(e => e.TRABAJADOR).Include(e => e.USUARIO);
            return View(eMPRESA.ToList());
        }

        // GET: EMPRESAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPRESA eMPRESA = db.EMPRESA.Find(id);
            if (eMPRESA == null)
            {
                return HttpNotFound();
            }
            return View(eMPRESA);
        }

        // GET: EMPRESAs/Create
        public ActionResult Create()
        {
            ViewBag.ID_TRABAJADOR = new SelectList(db.TRABAJADOR, "ID", "CURP");
            ViewBag.NOMBRE_USUARIO = new SelectList(db.USUARIO, "NOMBRE", "CONTRASEÑA");
            return View();
        }

        // POST: EMPRESAs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NOMBRE_USUARIO,ID_TRABAJADOR")] EMPRESA eMPRESA)
        {
            if (ModelState.IsValid)
            {
                db.EMPRESA.Add(eMPRESA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_TRABAJADOR = new SelectList(db.TRABAJADOR, "ID", "CURP", eMPRESA.ID_TRABAJADOR);
            ViewBag.NOMBRE_USUARIO = new SelectList(db.USUARIO, "NOMBRE", "CONTRASEÑA", eMPRESA.NOMBRE_USUARIO);
            return View(eMPRESA);
        }

        // GET: EMPRESAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPRESA eMPRESA = db.EMPRESA.Find(id);
            if (eMPRESA == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_TRABAJADOR = new SelectList(db.TRABAJADOR, "ID", "CURP", eMPRESA.ID_TRABAJADOR);
            ViewBag.NOMBRE_USUARIO = new SelectList(db.USUARIO, "NOMBRE", "CONTRASEÑA", eMPRESA.NOMBRE_USUARIO);
            return View(eMPRESA);
        }

        // POST: EMPRESAs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NOMBRE_USUARIO,ID_TRABAJADOR")] EMPRESA eMPRESA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eMPRESA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_TRABAJADOR = new SelectList(db.TRABAJADOR, "ID", "CURP", eMPRESA.ID_TRABAJADOR);
            ViewBag.NOMBRE_USUARIO = new SelectList(db.USUARIO, "NOMBRE", "CONTRASEÑA", eMPRESA.NOMBRE_USUARIO);
            return View(eMPRESA);
        }

        // GET: EMPRESAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPRESA eMPRESA = db.EMPRESA.Find(id);
            if (eMPRESA == null)
            {
                return HttpNotFound();
            }
            return View(eMPRESA);
        }

        // POST: EMPRESAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EMPRESA eMPRESA = db.EMPRESA.Find(id);
            db.EMPRESA.Remove(eMPRESA);
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
