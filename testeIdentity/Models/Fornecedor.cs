using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace testeIdentity.Models
{
    [Table("Fornecedor")]
    public class Fornecedor
    {
        public Fornecedor()
        {
            //nao ocorrer o caso de tentar adicionar um produto para esse fornecedor e essa lista de produto ser um objeto nulo
            this.produtos = new List<Produto>();
        }

        [Key]
        public int id { get; set; }
        public string nome { get; set; }
        public string razaoSocial { get; set; }
        public string cidade { get; set; }
        public string endereco { get; set; }
        public string estado { get; set; }
        public Boolean status { get; set; }
        public virtual ICollection<Produto> produtos { get; set; }
    }
}