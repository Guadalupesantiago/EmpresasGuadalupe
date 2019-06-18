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
    public class TRABAJADORsController : Controller
    {
        private EMPRESAEntities db = new EMPRESAEntities();

        // GET: TRABAJADORs
        public ActionResult Index()
        {
            return View(db.TRABAJADOR.ToList());
        }

        // GET: TRABAJADORs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRABAJADOR tRABAJADOR = db.TRABAJADOR.Find(id);
            if (tRABAJADOR == null)
            {
                return HttpNotFound();
            }
            return View(tRABAJADOR);
        }

        // GET: TRABAJADORs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TRABAJADORs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CURP,NSS,SUELDO,DEPARTAMENTO,DOMICILIO,OBSERVACION,EDAD,FECHA")] TRABAJADOR tRABAJADOR)
        {
            if (ModelState.IsValid)
            {
                db.TRABAJADOR.Add(tRABAJADOR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tRABAJADOR);
        }

        // GET: TRABAJADORs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRABAJADOR tRABAJADOR = db.TRABAJADOR.Find(id);
            if (tRABAJADOR == null)
            {
                return HttpNotFound();
            }
            return View(tRABAJADOR);
        }

        // POST: TRABAJADORs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CURP,NSS,SUELDO,DEPARTAMENTO,DOMICILIO,OBSERVACION,EDAD,FECHA")] TRABAJADOR tRABAJADOR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tRABAJADOR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tRABAJADOR);
        }

        // GET: TRABAJADORs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRABAJADOR tRABAJADOR = db.TRABAJADOR.Find(id);
            if (tRABAJADOR == null)
            {
                return HttpNotFound();
            }
            return View(tRABAJADOR);
        }

        // POST: TRABAJADORs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TRABAJADOR tRABAJADOR = db.TRABAJADOR.Find(id);
            db.TRABAJADOR.Remove(tRABAJADOR);
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
