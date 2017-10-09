using NDAgenda.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDAgenda.Models.Repository
{
    public interface IContatoRepository
    {
        IEnumerable<Contatos> All();
        Contatos Find(int id);
        Contatos Add(Contatos novoContato);
        void Update(Contatos contato);
        void Remove(int id);
    }
}
