using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NDAgenda.Models.Entidades
{
    public class Endereco
    {
        public int ID { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
        public TipoEndereco TipoEndereco { get; set; }

        //public virtual Pessoa Pessoa { get; set; }
        //public int PessoaID { get; set; }
    }

    public enum TipoEndereco
    {
        Residencia,
        Comercial,
    }
}