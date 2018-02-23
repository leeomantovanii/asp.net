using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace testeIdentity.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

        public virtual ICollection<Pedido> pedidos { get; set; }

        public ApplicationUser()
        {
            this.pedidos = new List<Pedido>();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Fornecedor> fornecedores { get; set; }
        public DbSet<Produto> produtos { get; set; }
        public DbSet<Cardapio> cardapios { get; set; }
        public DbSet<ProdutosCardapio> produtosCardapio { get; set; }
        public DbSet<ProdutosPedido> produtosPedido { get; set; }
        public DbSet<Pedido> pedido { get; set; }


        //fluente API
        //mostrar que tenho chave composta na classe produtosCardapio
        /*  protected override void OnModelCreating(DbModelBuilder mb)
        {
            base.OnModelCreating(mb);
            // mb.Entity<ProdutosCardapio>().HasKey(pc => new { pc.cardapioId, pc.produtoId });
            //mb.Entity<ProdutosCardapio>().HasRequired(t => t.produto).WithMany(t => t.produtosCardapio).HasForeignKey(k => k.produtoId);
            mb.Entity<ProdutosCardapio>().HasRequired(t => t.cardapio).WithMany(t => t.produtosCardapio).HasForeignKey(k => k.cardapioId);




        }*/


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

     
    }
}