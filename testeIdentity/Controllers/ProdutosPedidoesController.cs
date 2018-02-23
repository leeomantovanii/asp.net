using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using testeIdentity.Models;

namespace testeIdentity.Controllers
{
    public class ProdutosPedidoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ProdutosPedidoes
        public ActionResult Index()
        {
            var produtosPedido = db.produtosPedido.Include(p => p.Pedido).Include(p => p.ProdutosCardapio);
            return View(produtosPedido.ToList());
        }

        // GET: ProdutosPedidoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdutosPedido produtosPedido = db.produtosPedido.Find(id);
            if (produtosPedido == null)
            {
                return HttpNotFound();
            }
            return View(produtosPedido);
        }

        // GET: ProdutosPedidoes/Create
        public ActionResult Create()
        {
            ViewBag.PedidoId = new SelectList(db.pedido, "Id", "Id");
            ViewBag.ProdutosCardapioId = new SelectList(db.produtosCardapio, "Id", "Id");
            return View();
        }

        // POST: ProdutosPedidoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PedidoId,ProdutosCardapioId")] ProdutosPedido produtosPedido)
        {
            if (ModelState.IsValid)
            {
                db.produtosPedido.Add(produtosPedido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PedidoId = new SelectList(db.pedido, "Id", "Id", produtosPedido.PedidoId);
            ViewBag.ProdutosCardapioId = new SelectList(db.produtosCardapio, "Id", "Id", produtosPedido.ProdutosCardapioId);
            return View(produtosPedido);
        }

        // GET: ProdutosPedidoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdutosPedido produtosPedido = db.produtosPedido.Find(id);
            if (produtosPedido == null)
            {
                return HttpNotFound();
            }
            ViewBag.PedidoId = new SelectList(db.pedido, "Id", "Id", produtosPedido.PedidoId);
            ViewBag.ProdutosCardapioId = new SelectList(db.produtosCardapio, "Id", "Id", produtosPedido.ProdutosCardapioId);
            return View(produtosPedido);
        }

        // POST: ProdutosPedidoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PedidoId,ProdutosCardapioId")] ProdutosPedido produtosPedido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produtosPedido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PedidoId = new SelectList(db.pedido, "Id", "Id", produtosPedido.PedidoId);
            ViewBag.ProdutosCardapioId = new SelectList(db.produtosCardapio, "Id", "Id", produtosPedido.ProdutosCardapioId);
            return View(produtosPedido);
        }

        // GET: ProdutosPedidoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdutosPedido produtosPedido = db.produtosPedido.Find(id);
            if (produtosPedido == null)
            {
                return HttpNotFound();
            }
            return View(produtosPedido);
        }

        // POST: ProdutosPedidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProdutosPedido produtosPedido = db.produtosPedido.Find(id);
            db.produtosPedido.Remove(produtosPedido);
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
