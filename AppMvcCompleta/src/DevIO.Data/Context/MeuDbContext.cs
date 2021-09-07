using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevIO.Data.Context
{
    public class MeuDbContext : DbContext
    {
        public MeuDbContext(DbContextOptions options): base(options) { }

        public DbSet<AppMvcBasica.Models.Produto> Produto { get; set; }
        public DbSet<AppMvcBasica.Models.Endereco> Endereco { get; set; }
        public DbSet<AppMvcBasica.Models.Fornecedor> Fornecedor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            //Evitar nvarchar(max) de campos sem mapeamento
            foreach(var property in modelBuilder.Model.GetEntityTypes()
                                                      .SelectMany(e => e.GetProperties().Where(p => p.ClrType == typeof(string)))) 
            {
                //property.Relational().ColumnType = "varchar(100)"; //No custo esta com o EF 2.2 assim, ajustei para funcionar com o EF 3.0
                property.SetColumnType("varchar(100)");
            }
            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MeuDbContext).Assembly);

            //Desabilita cascade
            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                                                           .SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.ClientNoAction;
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
