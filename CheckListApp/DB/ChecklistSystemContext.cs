using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CheckListApp.DB
{
    public partial class ChecklistSystemContext : DbContext
    {
        public ChecklistSystemContext()
        {
        }

        public ChecklistSystemContext(DbContextOptions<ChecklistSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Checklist> Checklists { get; set; } = null!;
        public virtual DbSet<CompletedTask> CompletedTasks { get; set; } = null!;
        public virtual DbSet<Participant> Participants { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=ChecklistSystem;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Checklist>(entity =>
            {
                entity.Property(e => e.ChecklistId)
                    .ValueGeneratedNever()
                    .HasColumnName("ChecklistID");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<CompletedTask>(entity =>
            {
                entity.HasKey(e => e.TaskId)
                    .HasName("PK__Complete__7C6949D1E07DB4EF");

                entity.Property(e => e.TaskId)
                    .ValueGeneratedNever()
                    .HasColumnName("TaskID");

                entity.Property(e => e.ChecklistId).HasColumnName("ChecklistID");

                entity.Property(e => e.ParticipantId).HasColumnName("ParticipantID");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.TaskDate).HasColumnType("datetime");

                entity.HasOne(d => d.Checklist)
                    .WithMany(p => p.CompletedTasks)
                    .HasForeignKey(d => d.ChecklistId)
                    .HasConstraintName("FK__Completed__Check__286302EC");

                entity.HasOne(d => d.Participant)
                    .WithMany(p => p.CompletedTasks)
                    .HasForeignKey(d => d.ParticipantId)
                    .HasConstraintName("FK__Completed__Parti__29572725");
            });

            modelBuilder.Entity<Participant>(entity =>
            {
                entity.Property(e => e.ParticipantId)
                    .ValueGeneratedNever()
                    .HasColumnName("ParticipantID");

                entity.Property(e => e.ContactInfo).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Role).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
