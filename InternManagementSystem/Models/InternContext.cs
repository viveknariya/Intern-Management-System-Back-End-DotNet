using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace InternManagementSystem.Models
{
    public partial class InternContext : DbContext
    {
        public InternContext()
        {
        }

        public InternContext(DbContextOptions<InternContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Designation> Designation { get; set; }
        public virtual DbSet<InternRecord> InternRecord { get; set; }
        public virtual DbSet<Leave> Leave { get; set; }
        public virtual DbSet<WorkingHour> WorkingHour { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=C1JUN22; Database=Intern; User Id=sa; Password=pass@word1;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Designation>(entity =>
            {
                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DesignationName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<InternRecord>(entity =>
            {
                entity.HasKey(e => e.InternId)
                    .HasName("PK__InternRe__6910EDE29C18B6B4");

                entity.Property(e => e.InternId).HasMaxLength(50);

                entity.Property(e => e.EmailId).HasMaxLength(50);

                entity.Property(e => e.InternName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.InternPassword)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.InternStatus).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber).HasMaxLength(10);

                entity.HasOne(d => d.DesignationNavigation)
                    .WithMany(p => p.InternRecord)
                    .HasForeignKey(d => d.Designation)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__InternRec__Desig__02FC7413");
            });

            modelBuilder.Entity<Leave>(entity =>
            {
                entity.Property(e => e.InternId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LeaveDate).HasColumnType("date");

                entity.HasOne(d => d.Intern)
                    .WithMany(p => p.Leave)
                    .HasForeignKey(d => d.InternId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Leave__InternId__08B54D69");
            });

            modelBuilder.Entity<WorkingHour>(entity =>
            {
                entity.HasKey(e => e.Whid)
                    .HasName("PK__WorkingH__831244619C2E0EC5");

                entity.Property(e => e.Whid).HasColumnName("WHId");

                entity.Property(e => e.CompanyWorkingHour)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.InternId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.InternWorkingHour)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Monthly)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.HasOne(d => d.Intern)
                    .WithMany(p => p.WorkingHour)
                    .HasForeignKey(d => d.InternId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__WorkingHo__Inter__05D8E0BE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
