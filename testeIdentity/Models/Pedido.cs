using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace testeIdentity.Models
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }
        public DateTime Data =  DateTime.Now;
        public virtual ICollection<ProdutosPedido> ProdutosPedido { get; set; }

        

        public Pedido()
        {
            this.ProdutosPedido = new List<ProdutosPedido>();
        }
    }
}