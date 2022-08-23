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
                optionsBuilder.UseSqlServer("Server=.; Database=Intern; User Id=sa; Password=pass@word1;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Designation>(entity =>
            {
                entity.HasKey(e => e.DesignationName)
                    .HasName("PK__Designat__372CDC220D766B2C");

                entity.Property(e => e.DesignationName).HasMaxLength(50);

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<InternRecord>(entity =>
            {
                entity.HasKey(e => e.InternId)
                    .HasName("PK__InternRe__6910EDE2994E99BC");

                entity.Property(e => e.InternId).HasMaxLength(50);

                entity.Property(e => e.Designation).HasMaxLength(50);

                entity.Property(e => e.EmailId).HasMaxLength(50);

                entity.Property(e => e.InternName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.InternStatus).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber).HasMaxLength(10);

                entity.HasOne(d => d.DesignationNavigation)
                    .WithMany(p => p.InternRecord)
                    .HasForeignKey(d => d.Designation)
                    .HasConstraintName("FK__InternRec__Desig__398D8EEE");
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
                    .HasConstraintName("FK__Leave__InternId__4316F928");
            });

            modelBuilder.Entity<WorkingHour>(entity =>
            {
                entity.HasKey(e => e.Whid)
                    .HasName("PK__WorkingH__831244614E643708");

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
                    .HasConstraintName("FK__WorkingHo__Inter__403A8C7D");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
