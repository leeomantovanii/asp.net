using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace testeIdentity.Models
{
    [Table("Produto")]
    public class Produto
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        
  
        [ForeignKey("Fornecedor")]
        public int IdFornecedor { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }


        public virtual ICollection<ProdutosCardapio> ProdutosCardapio { get; set; }
        public virtual ICollection<ProdutosPedido> ProdutosPedido { get; set; }

        public Produto()
        {
            this.ProdutosCardapio = new List<ProdutosCardapio>();
            this.ProdutosPedido = new List<ProdutosPedido>();
        }

    }
}