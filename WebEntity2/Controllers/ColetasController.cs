using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebEntity2.Context;
using WebEntity2.Entidades;
using WebEntity2.Atributos;


namespace WebEntity2.Controllers
{
    [MinhaAutenticacao]
    public class ColetasController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: Coletas
        public ActionResult Index()
        {
            return View(db.Coletas.ToList());
        }

        // GET: Coletas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coleta coleta = db.Coletas.Find(id);
            if (coleta == null)
            {
                return HttpNotFound();
            }
            return View(coleta);
        }

        // GET: Coletas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Coletas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPedidoColeta,EndereRetirada,EnderecoEntrega")] Coleta coleta)
        {
            if (ModelState.IsValid)
            {
                db.Coletas.Add(coleta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(coleta);
        }

        // GET: Coletas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coleta coleta = db.Coletas.Find(id);
            if (coleta == null)
            {
                return HttpNotFound();
            }
            return View(coleta);
        }

        // POST: Coletas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPedidoColeta,EndereRetirada,EnderecoEntrega")] Coleta coleta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coleta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(coleta);
        }

        // GET: Coletas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coleta coleta = db.Coletas.Find(id);
            if (coleta == null)
            {
                return HttpNotFound();
            }
            return View(coleta);
        }

        // POST: Coletas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Coleta coleta = db.Coletas.Find(id);
            db.Coletas.Remove(coleta);
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
