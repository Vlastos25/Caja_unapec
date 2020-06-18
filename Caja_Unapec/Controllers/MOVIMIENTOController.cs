﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Caja_Unapec;

namespace Caja_Unapec.Controllers
{
    public class MOVIMIENTOController : Controller
    {
        private Caja_UnapecEntities db = new Caja_UnapecEntities();

        // GET: MOVIMIENTO
        public ActionResult Index()
        {
            var mOVIMIENTO = db.MOVIMIENTO.Include(m => m.CLIENTE).Include(m => m.DOCUMENTO).Include(m => m.EMPLEADO).Include(m => m.FORMA_PAGO).Include(m => m.SERVICIO);
            return View(mOVIMIENTO.ToList());
        }

        // GET: MOVIMIENTO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MOVIMIENTO mOVIMIENTO = db.MOVIMIENTO.Find(id);
            if (mOVIMIENTO == null)
            {
                return HttpNotFound();
            }
            return View(mOVIMIENTO);
        }

        // GET: MOVIMIENTO/Create
        public ActionResult Create()
        {
            ViewBag.IdCliente = new SelectList(db.CLIENTE, "IdCliente", "Nombre");
            ViewBag.IdDocumento = new SelectList(db.DOCUMENTO, "IdDocumento", "Descripcion");
            ViewBag.IdEmpleado = new SelectList(db.EMPLEADO, "IdEmpleado", "Nombre");
            ViewBag.IdFormaPago = new SelectList(db.FORMA_PAGO, "IdFormaPago", "Descripcion");
            ViewBag.IdServicio = new SelectList(db.SERVICIO, "IdServicio", "Descripcion");
            return View();
        }

        // POST: MOVIMIENTO/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdMovimiento,Fecha,Monto,Estado,IdCliente,IdServicio,IdDocumento,IdEmpleado,IdFormaPago")] MOVIMIENTO mOVIMIENTO)
        {
            if (ModelState.IsValid)
            {
                db.MOVIMIENTO.Add(mOVIMIENTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCliente = new SelectList(db.CLIENTE, "IdCliente", "Nombre", mOVIMIENTO.IdCliente);
            ViewBag.IdDocumento = new SelectList(db.DOCUMENTO, "IdDocumento", "Descripcion", mOVIMIENTO.IdDocumento);
            ViewBag.IdEmpleado = new SelectList(db.EMPLEADO, "IdEmpleado", "Nombre", mOVIMIENTO.IdEmpleado);
            ViewBag.IdFormaPago = new SelectList(db.FORMA_PAGO, "IdFormaPago", "Descripcion", mOVIMIENTO.IdFormaPago);
            ViewBag.IdServicio = new SelectList(db.SERVICIO, "IdServicio", "Descripcion", mOVIMIENTO.IdServicio);
            return View(mOVIMIENTO);
        }

        // GET: MOVIMIENTO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MOVIMIENTO mOVIMIENTO = db.MOVIMIENTO.Find(id);
            if (mOVIMIENTO == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCliente = new SelectList(db.CLIENTE, "IdCliente", "Nombre", mOVIMIENTO.IdCliente);
            ViewBag.IdDocumento = new SelectList(db.DOCUMENTO, "IdDocumento", "Descripcion", mOVIMIENTO.IdDocumento);
            ViewBag.IdEmpleado = new SelectList(db.EMPLEADO, "IdEmpleado", "Nombre", mOVIMIENTO.IdEmpleado);
            ViewBag.IdFormaPago = new SelectList(db.FORMA_PAGO, "IdFormaPago", "Descripcion", mOVIMIENTO.IdFormaPago);
            ViewBag.IdServicio = new SelectList(db.SERVICIO, "IdServicio", "Descripcion", mOVIMIENTO.IdServicio);
            return View(mOVIMIENTO);
        }

        // POST: MOVIMIENTO/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdMovimiento,Fecha,Monto,Estado,IdCliente,IdServicio,IdDocumento,IdEmpleado,IdFormaPago")] MOVIMIENTO mOVIMIENTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mOVIMIENTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCliente = new SelectList(db.CLIENTE, "IdCliente", "Nombre", mOVIMIENTO.IdCliente);
            ViewBag.IdDocumento = new SelectList(db.DOCUMENTO, "IdDocumento", "Descripcion", mOVIMIENTO.IdDocumento);
            ViewBag.IdEmpleado = new SelectList(db.EMPLEADO, "IdEmpleado", "Nombre", mOVIMIENTO.IdEmpleado);
            ViewBag.IdFormaPago = new SelectList(db.FORMA_PAGO, "IdFormaPago", "Descripcion", mOVIMIENTO.IdFormaPago);
            ViewBag.IdServicio = new SelectList(db.SERVICIO, "IdServicio", "Descripcion", mOVIMIENTO.IdServicio);
            return View(mOVIMIENTO);
        }

        // GET: MOVIMIENTO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MOVIMIENTO mOVIMIENTO = db.MOVIMIENTO.Find(id);
            if (mOVIMIENTO == null)
            {
                return HttpNotFound();
            }
            return View(mOVIMIENTO);
        }

        // POST: MOVIMIENTO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MOVIMIENTO mOVIMIENTO = db.MOVIMIENTO.Find(id);
            db.MOVIMIENTO.Remove(mOVIMIENTO);
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
