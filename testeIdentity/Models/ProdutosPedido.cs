using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace testeIdentity.Models
{
    [Table("ProdutosPedido")]
    public class ProdutosPedido
    {
        [Key]
        public int Id { get; set; }

        //chaves estrangeira
        public int PedidoId { get; set; }
        public int ProdutosCardapioId { get; set; }

        //propriedades de navegacao
        [ForeignKey("ProdutosCardapioId ")]
        public ProdutosCardapio ProdutosCardapio { get; set; }

        [ForeignKey("PedidoId ")]
        public Pedido Pedido { get; set; }
    }
}