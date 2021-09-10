using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Uygulama.Models.Models;

namespace Uygulama.Models.DataContext
{
    public class PiDataDBContext:DbContext

    {

        public PiDataDBContext(DbContextOptions options) : base(options)
        {
            //yorum
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Emlak> Emlaks { get; set; }
        public DbSet<Musteri> Musteris { get; set; }
        public DbSet<Sehirler> Sehirlers { get; set; }
        public DbSet<Ilceler> Ilcelers { get; set; }
        public DbSet<Mahalleler> Mahallelers { get; set; }
        public DbSet<Durum> Durums { get; set; }
        public DbSet<Tip> Tips { get; set; }
        public DbSet<IlanResim> IlanResims { get; set; }
        public DbSet<Portfoy> Portfoys { get; set; }
    }
}
