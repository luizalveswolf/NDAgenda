using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NDAgenda.Models;
using NDAgenda.Models.Entidades;
using NDAgenda.Models.Repository;

namespace NDAgenda.Controllers
{
    public class ContatosController : Controller
    {
        
        private readonly IContatoRepository _contatoRepository;

        public ContatosController(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        public ActionResult Index()
        {
            //return View(db.Contatos.ToList());
            return View(_contatoRepository.All().ToList());
        }

       
        public ActionResult Details(int id)
        {

            // Contatos contatos = db.Contatos.Find(id);
            Contatos contatos = _contatoRepository.Find(id);
            if (contatos == null)
            {
                return HttpNotFound();
            }
            return View(contatos);
        }

        // GET: Contatos/Create
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TipoContato,Telefone,Email,Site,TipoTelefone, Pessoa")] Contatos contatos)
        {
            if (ModelState.IsValid)
            {

                //db.Contatos.Add(contatos);
                //db.SaveChanges();
                _contatoRepository.Add(contatos);
                return RedirectToAction("Index");
            }

            return View(contatos);
        }

        // GET: Contatos/Edit/5
        public ActionResult Edit(int id)
        {

            //Contatos contatos = db.Contatos.Find(id);
            Contatos contatos = _contatoRepository.Find(id);
            if (contatos == null)
            {
                return HttpNotFound();
            }
            return View(contatos);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TipoContato,Telefone,Email,Site,TipoTelefone, Pessoa")] Contatos contatos)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(contatos).State = EntityState.Modified;
                //db.SaveChanges();
                _contatoRepository.Update(contatos);
                return RedirectToAction("Index");
            }
            return View(contatos);
        }

        // GET: Contatos/Delete/5
        public ActionResult Delete(int id)
        {

            //Contatos contatos = db.Contatos.Find(id);
            Contatos contatos = _contatoRepository.Find(id);
            if (contatos == null)
            {
                return HttpNotFound();
            }
            return View(contatos);
        }

        // POST: Contatos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Contatos contatos = db.Contatos.Find(id);
            //db.Contatos.Remove(contatos);
            //db.SaveChanges();
            _contatoRepository.Remove(id);
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
