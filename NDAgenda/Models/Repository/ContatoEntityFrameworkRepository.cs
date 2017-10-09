using NDAgenda.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NDAgenda.Models.Repository
{
    public class ContatoEntityFrameworkRepository : IContatoRepository
    {
        private readonly ContatoContext _db;

        public ContatoEntityFrameworkRepository(ContatoContext dbContext)
        {
            _db = dbContext;
        }

        public Contatos Add(Contatos novoContato)
        {
            _db.Contatos.Add(novoContato);
            _db.SaveChanges();
            return novoContato;
        }

        public IEnumerable<Contatos> All()
        {
            return _db.Contatos;
        } 

        public Contatos Find(int id)
        {
            return _db.Contatos.Find(id);
        }

        public void Remove(int id)
        {
            var contato = Find(id);
            _db.Contatos.Remove(contato);
            _db.SaveChanges();
        }

        public void Update(Contatos contato)
        {
            _db.Entry(contato).State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}