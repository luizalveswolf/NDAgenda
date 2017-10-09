using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NDAgenda.Models.Entidades
{
    public class Pessoa
    {
        [Required]
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public int ID { get; set; }

        public virtual ICollection<Contatos> Contatos { get; set; }

    }
}