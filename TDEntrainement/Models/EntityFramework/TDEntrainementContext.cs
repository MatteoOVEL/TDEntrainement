using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TDEntrainement.Models.EntityFramework
{
    public partial class TDEntrainementContext : DbContext
    {
        public TDEntrainementContext()
        {
        }

        public TDEntrainementContext(DbContextOptions<TDEntrainementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Chanteur> Chanteurs { get; set; } = null!;
        public virtual DbSet<Musique> Musiques { get; set; } = null!;

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseNpgsql("Server=localhost;port=5432;Database=TDEntrainement; uid=postgres; \npassword=postgres;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chanteur>(entity =>
            {
                entity.HasKey(e => e.Idchanteur)
                    .HasName("chanteur_pkey");
            });

            modelBuilder.Entity<Musique>(entity =>
            {
                entity.HasKey(e => e.Idmusique)
                    .HasName("musique_pkey");

                entity.HasOne(d => d.IdchanteurNavigation)
                    .WithMany(p => p.Musiques)
                    .HasForeignKey(d => d.Idchanteur)
                    .HasConstraintName("fk_chanteur");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
