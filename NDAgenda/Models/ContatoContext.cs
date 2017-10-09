using NDAgenda.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NDAgenda.Models
{
    public class ContatoContext : DbContext
    {

        public ContatoContext () : base("name=ContatoContext")
        {
        }

        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Contatos> Contatos { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
    }
}