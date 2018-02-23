using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace testeIdentity.Models
{
    [Table("Cardapio")]
    public class Cardapio
    {
        [Key]
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        public virtual ICollection<ProdutosCardapio> ProdutosCardapio { get; set; }
        

        public Cardapio()
        {
            this.ProdutosCardapio = new List<ProdutosCardapio>();
        }
    }

    
}