using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DBFirstAssignment.Models
{
    public partial class DBFirstContext : DbContext
    {
        public DBFirstContext()
        {
        }

        public DBFirstContext(DbContextOptions<DBFirstContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TrainMaster> TrainMasters { get; set; } = null!;
        public virtual DbSet<TrainRunDay> TrainRunDays { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Data Source=RADHIKA;Initial Catalog=DBFirst;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TrainMaster>(entity =>
            {
                entity.HasKey(e => e.TrainNo);

                entity.ToTable("TrainMaster");

                entity.HasIndex(e => e.TrainNo, "UX_Table_1")
                    .IsUnique();

                entity.Property(e => e.TrainNo).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.FromStation)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ToStation)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TrainName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TrainRunDay>(entity =>
            {
                entity.HasKey(e => e.TrainId);

                entity.Property(e => e.TrainId).HasColumnName("Train_Id");

                entity.Property(e => e.RunDays)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Run_Days");

                entity.Property(e => e.TrainNo)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Train_No");

                entity.HasOne(d => d.TrainNoNavigation)
                    .WithMany(p => p.TrainRunDays)
                    .HasForeignKey(d => d.TrainNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TrainRunDays_TrainMaster");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
