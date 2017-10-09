using NDAgenda.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NDAgenda.Models.Repository
{
    public class ContatoWebServiceRepository : IContatoRepository
    {

        public ContatoWebServiceRepository(Dependencia dependecia)
        {
            _dependencia = dependecia;
        }

        public IEnumerable<Contatos> All()
        {
            return Contatos;
        }

        public Contatos Find(int id)
        {
            return Contatos.FirstOrDefault(t => t.ID == id);
        }

        public Contatos Add(Contatos novoContato)
        {
            novoContato.ID = 1;
            if (Contatos.Any())
                novoContato.ID = Contatos.Max(t => t.ID) + 1;
            Contatos.Add(novoContato);
            return novoContato;
        }

        public void Update(Contatos contato)
        {
            var contatoIndex = Contatos.FindIndex(t => t.ID == contato.ID);
            Contatos.RemoveAt(contatoIndex);
            Contatos.Insert(contatoIndex, contato);
        }

        public void Remove(int id)
        {
            var contatoUpdate = Contatos.Find(t => t.ID == id);
            Contatos.Remove(contatoUpdate);
        }

        private static readonly List<Contatos> Contatos = new List<Contatos> { new Contatos
            {
            Site = "WS"
            },
            new Contatos
            {
                Site = "WS Servidor"
            } };

        private readonly IDependencia _dependencia;
    }

    public interface IDependencia
    {
    }

    public class Dependencia : IDependencia
    {
    }
    
}