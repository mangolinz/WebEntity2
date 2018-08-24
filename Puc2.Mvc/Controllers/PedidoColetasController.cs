using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Puc2.Mvc.Context;
using Puc2.Mvc.Entidades;
using Puc2.Mvc.Atributos;

namespace Puc2.Mvc.Controllers
{
    [MinhaAutenticacao]
    public class PedidoColetasController : Controller
    {
        private MyDbContext db = new MyDbContext();
        //private readonly Puc2.AcessoADados.Entidades.PedidoColeta pedidoColeta;

        // GET: PedidoColetas
        public ActionResult Index()
        {
            //return View(db.PedidoColetas.ToList());
            return View(db.PedidoColetas.ToList());
        }

        // GET: PedidoColetas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PedidoColeta pedidoColeta = db.PedidoColetas.Find(id);
            if (pedidoColeta == null)
            {
                return HttpNotFound();
            }
            return View(pedidoColeta);
        }

        // GET: PedidoColetas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PedidoColetas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPedidoColeta,NomeCliente,EnderecoCliente,TelefoneCliente,LarguraEncomenda,AlturaEncomenda,ProfEncomenda,PesoEncomenda,EndereRetirada,EnderecoEntrega")] PedidoColeta pedidoColeta)
        {
            if (ModelState.IsValid)
            {
                db.PedidoColetas.Add(pedidoColeta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pedidoColeta);
        }

        // GET: PedidoColetas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PedidoColeta pedidoColeta = db.PedidoColetas.Find(id);
            if (pedidoColeta == null)
            {
                return HttpNotFound();
            }
            return View(pedidoColeta);
        }

        // POST: PedidoColetas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPedidoColeta,NomeCliente,EnderecoCliente,TelefoneCliente,LarguraEncomenda,AlturaEncomenda,ProfEncomenda,PesoEncomenda,EndereRetirada,EnderecoEntrega")] PedidoColeta pedidoColeta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pedidoColeta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pedidoColeta);
        }

        // GET: PedidoColetas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PedidoColeta pedidoColeta = db.PedidoColetas.Find(id);
            if (pedidoColeta == null)
            {
                return HttpNotFound();
            }
            return View(pedidoColeta);
        }

        // POST: PedidoColetas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PedidoColeta pedidoColeta = db.PedidoColetas.Find(id);
            db.PedidoColetas.Remove(pedidoColeta);
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
