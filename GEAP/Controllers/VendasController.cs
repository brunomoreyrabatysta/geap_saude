using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GEAP.Models;

namespace GEAP.Controllers
{
    public class VendasController : Controller
    {
        private GEAPDBContext db = new GEAPDBContext();

        // GET: Vendas
        public ActionResult Index()
        {
            string cnnString = System.Configuration.ConfigurationManager.ConnectionStrings["GEAPDBContext"].ConnectionString;

            SqlConnection cnn = new SqlConnection(cnnString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "ListarComissoesVendedores";
            //add any parameters the stored procedure might require
            cnn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            List<Relatorio> lista = new List<Relatorio>();
            while (reader.Read())
            {
                Relatorio relatorio = new Relatorio();

                relatorio.IdeVendedor = Convert.ToInt32(reader["IdeVendedor"]);
                relatorio.NmeVendedor = Convert.ToString(reader["NmeVendedor"]);
                relatorio.QuantidadeVeiculos = Convert.ToInt32(reader["QUANTIDADE_VEICULOS"]);
                relatorio.QuantidadeValeCombustivel = Convert.ToInt32(reader["QUANTIDE_VALE"]);
                relatorio.TotalVenda = Convert.ToDecimal(reader["TOTAL_VENDA"]);
                relatorio.TotalComissao = Convert.ToDecimal(reader["TOTAL_COMISSAO"]);

                lista.Add(relatorio);
            }
            cnn.Close();

            //var vendas = db.Vendas.Include(v => v.ModeloVersao).Include(v => v.Vendedor);
            return View(lista.ToList());
        }

        // GET: Vendas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venda venda = db.Vendas.Find(id);
            if (venda == null)
            {
                return HttpNotFound();
            }
            return View(venda);
        }

        // GET: Vendas/Create
        public ActionResult Create()
        {
            ViewBag.IdeModeloVersao = new SelectList(db.ModelosVersao, "IdeModeloVersao", "IdeModeloVersao");
            ViewBag.IdeVendedor = new SelectList(db.Vendedoress, "IdeVendedor", "NmeVendedor");
            return View();
        }

        // POST: Vendas/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdeVenda,IdeVendedor,IdeModeloVersao,VlrPrecoVenda,StaValeCombustivel")] Venda venda)
        {
            if (ModelState.IsValid)
            {
                db.Vendas.Add(venda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdeModeloVersao = new SelectList(db.ModelosVersao, "IdeModeloVersao", "IdeModeloVersao", venda.IdeModeloVersao);
            ViewBag.IdeVendedor = new SelectList(db.Vendedoress, "IdeVendedor", "NmeVendedor", venda.IdeVendedor);
            return View(venda);
        }

        // GET: Vendas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venda venda = db.Vendas.Find(id);
            if (venda == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdeModeloVersao = new SelectList(db.ModelosVersao, "IdeModeloVersao", "IdeModeloVersao", venda.IdeModeloVersao);
            ViewBag.IdeVendedor = new SelectList(db.Vendedoress, "IdeVendedor", "NmeVendedor", venda.IdeVendedor);
            return View(venda);
        }

        // POST: Vendas/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdeVenda,IdeVendedor,IdeModeloVersao,VlrPrecoVenda,StaValeCombustivel")] Venda venda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(venda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdeModeloVersao = new SelectList(db.ModelosVersao, "IdeModeloVersao", "IdeModeloVersao", venda.IdeModeloVersao);
            ViewBag.IdeVendedor = new SelectList(db.Vendedoress, "IdeVendedor", "NmeVendedor", venda.IdeVendedor);
            return View(venda);
        }

        // GET: Vendas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venda venda = db.Vendas.Find(id);
            if (venda == null)
            {
                return HttpNotFound();
            }
            return View(venda);
        }

        // POST: Vendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Venda venda = db.Vendas.Find(id);
            db.Vendas.Remove(venda);
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
