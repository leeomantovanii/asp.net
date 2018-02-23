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
    public class ProdutosCardapiosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ProdutosCardapios
        public ActionResult Index()
        {
            var produtosCardapio = db.produtosCardapio.Include(p => p.Cardapio).Include(p => p.Produto);
            return View(produtosCardapio.ToList());
        }

        // GET: ProdutosCardapios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdutosCardapio produtosCardapio = db.produtosCardapio.Find(id);
            if (produtosCardapio == null)
            {
                return HttpNotFound();
            }
            return View(produtosCardapio);
        }

        // GET: ProdutosCardapios/Create
        public ActionResult Create()
        {
            ViewBag.CardapioId = new SelectList(db.cardapios, "Id", "Descricao");
            ViewBag.ProdutoId = new SelectList(db.produtos, "Id", "Nome");
            return View();
        }

        // POST: ProdutosCardapios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CardapioId,ProdutoId")] ProdutosCardapio produtosCardapio)
        {
            if (ModelState.IsValid)
            {
                db.produtosCardapio.Add(produtosCardapio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CardapioId = new SelectList(db.cardapios, "Id", "Descricao", produtosCardapio.CardapioId);
            ViewBag.ProdutoId = new SelectList(db.produtos, "Id", "Nome", produtosCardapio.ProdutoId);
            return View(produtosCardapio);
        }

        // GET: ProdutosCardapios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdutosCardapio produtosCardapio = db.produtosCardapio.Find(id);
            if (produtosCardapio == null)
            {
                return HttpNotFound();
            }
            ViewBag.CardapioId = new SelectList(db.cardapios, "Id", "Descricao", produtosCardapio.CardapioId);
            ViewBag.ProdutoId = new SelectList(db.produtos, "Id", "Nome", produtosCardapio.ProdutoId);
            return View(produtosCardapio);
        }

        // POST: ProdutosCardapios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CardapioId,ProdutoId")] ProdutosCardapio produtosCardapio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produtosCardapio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CardapioId = new SelectList(db.cardapios, "Id", "Descricao", produtosCardapio.CardapioId);
            ViewBag.ProdutoId = new SelectList(db.produtos, "Id", "Nome", produtosCardapio.ProdutoId);
            return View(produtosCardapio);
        }

        // GET: ProdutosCardapios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdutosCardapio produtosCardapio = db.produtosCardapio.Find(id);
            if (produtosCardapio == null)
            {
                return HttpNotFound();
            }
            return View(produtosCardapio);
        }

        // POST: ProdutosCardapios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProdutosCardapio produtosCardapio = db.produtosCardapio.Find(id);
            db.produtosCardapio.Remove(produtosCardapio);
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
