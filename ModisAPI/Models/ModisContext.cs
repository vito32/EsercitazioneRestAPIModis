using Microsoft.EntityFrameworkCore;
using ModisAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModisAPI.Models
{
    public class ModisContext : DbContext

    {

        public DbSet<Studente> Studenti { get; set; }

        public DbSet<Corso> Corsi { get; set; }

        public DbSet<StudenteCorso> StudenteCorsi { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {

            modelBuilder.Entity<StudenteCorso>()
                .HasKey(sc => new { sc.StudenteId, sc.CorsoId });

            modelBuilder.Entity<StudenteCorso>()
                .HasOne(bc => bc.Studente)
                .WithMany(b => b.StudenteCorsi)
                .HasForeignKey(bc => bc.StudenteId);

            modelBuilder.Entity<StudenteCorso>()
                .HasOne(bc => bc.Corso)
                .WithMany(c => c.StudenteCorsi)
                .HasForeignKey(bc => bc.CorsoId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {

            var connection = @"Server=(localdb)\mssqllocaldb;Database=ModisDB2;" +
                             "Trusted_Connection=True;ConnectRetryCount=0";
            var conn =       @"Server=tcp:vitoserver.database.windows.net,1433;Initial Catalog=vitoDB;Persist Security Info=False;User ID=vito32;Password=@@VitoDB@@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            optionsBuilder.UseSqlServer(connection);

        }

    }

}
