using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NDAgenda.Models.Entidades
{
    public class Contatos
    {
        public int ID { get; set; }
        public TipoContato TipoContato { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Site { get; set; }

        public virtual Pessoa Pessoa { get; set; }
        //public int PessoaID { get; set; }

        public TipoTelefone TipoTelefone { get; set; }

        public virtual Endereco Endereco { get; set; }
       // public int? EnderecoID { get; set; }
    }

    public enum TipoContato
    {
        Amigo,
        Trabalho,
        Faculdade,
        Familia
    }

    public enum TipoTelefone
    {
        Residencial,
        Celular,
        Comercial,
    }
}
