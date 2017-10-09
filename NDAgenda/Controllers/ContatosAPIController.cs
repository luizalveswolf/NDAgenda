using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using NDAgenda.Models;
using NDAgenda.Models.Entidades;
using NDAgenda.Models.Repository;

namespace NDAgenda.Controllers
{
    public class ContatosAPIController : ODataController
    {
        private ContatoContext db = new ContatoContext();
        //private readonly IContatoRepository _contatoRepository;
                 

        // GET: odata/ContatosAPI
        [EnableQuery]
        public IQueryable<Contatos> GetContatosAPI()
        {

            return db.Contatos;
        }

        // GET: odata/ContatosAPI(5)
        [EnableQuery]
        public SingleResult<Contatos> GetContatos([FromODataUri] int key)
        {
            return SingleResult.Create(db.Contatos.Where(contatos => contatos.ID == key));
        }

        // PUT: odata/ContatosAPI(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Contatos> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Contatos contatos = db.Contatos.Find(key);
            if (contatos == null)
            {
                return NotFound();
            }

            patch.Put(contatos);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContatosExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(contatos);
        }

        // POST: odata/ContatosAPI
        public IHttpActionResult Post(Contatos contatos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Contatos.Add(contatos);
            db.SaveChanges();

            return Created(contatos);
        }

        // PATCH: odata/ContatosAPI(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Contatos> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Contatos contatos = db.Contatos.Find(key);
            if (contatos == null)
            {
                return NotFound();
            }

            patch.Patch(contatos);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContatosExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(contatos);
        }

        // DELETE: odata/ContatosAPI(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Contatos contatos = db.Contatos.Find(key);
            if (contatos == null)
            {
                return NotFound();
            }

            db.Contatos.Remove(contatos);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/ContatosAPI(5)/Endereco
        [EnableQuery]
        public SingleResult<Endereco> GetEndereco([FromODataUri] int key)
        {
            return SingleResult.Create(db.Contatos.Where(m => m.ID == key).Select(m => m.Endereco));
        }

        // GET: odata/ContatosAPI(5)/Pessoa
        [EnableQuery]
        public SingleResult<Pessoa> GetPessoa([FromODataUri] int key)
        {
            return SingleResult.Create(db.Contatos.Where(m => m.ID == key).Select(m => m.Pessoa));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContatosExists(int key)
        {
            return db.Contatos.Count(e => e.ID == key) > 0;
        }
    }
}
