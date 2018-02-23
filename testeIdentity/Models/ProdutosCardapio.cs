using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace testeIdentity.Models
{
    [Table("ProdutosCardapio")]
    public class ProdutosCardapio
    {
        [Key]
        public int Id { get; set; }

        //chaves estrangeira
        public int CardapioId { get; set; }
        public int ProdutoId { get; set; }

        //propriedades de navegacao
        [ForeignKey("CardapioId ")]
        public Cardapio Cardapio { get; set; }

        [ForeignKey("ProdutoId ")]
        public Produto Produto { get; set; }
    }
}