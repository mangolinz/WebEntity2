using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.Extensions.Options;
using System.Data.Entity.ModelConfiguration.Conventions;
using WebEntity2.Entidades;

namespace WebEntity2.Context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("PucLogistica_AWS")  // "PucLogistica_AZURE"
        {
        }

        public DbSet<Coleta> Coletas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<WebEntity2.Entidades.PedidoColeta> PedidoColetas { get; set; }
    }


}