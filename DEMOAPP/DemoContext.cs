using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DEMOAPP
{
    public partial class DemoContext : DbContext
    {
        public DemoContext()
        {
        }

        public DemoContext(DbContextOptions<DemoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
               optionsBuilder.UseSqlServer("Server=CHETUIWK1966\\SQL2017;Database=Demo;User id=sa;Password=Chetu@123;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DeptId)
                    .HasName("PK__Departme__512A59AC48CF87A7");

                entity.ToTable("Department");

                entity.Property(e => e.DeptId).HasColumnName("DEPT_ID");

                entity.Property(e => e.DeptName)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("DEPT_NAME");

                entity.Property(e => e.Remark)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DeptId)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Dept_Id");

                entity.Property(e => e.EmpAddress)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.EmpEmailId)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.EmpName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.LocId).HasColumnName("Loc_Id");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasKey(e => e.LocId)
                    .HasName("PK__Location__F67DD86347AEC895");

                entity.Property(e => e.LocId).HasColumnName("LOC_ID");

                entity.Property(e => e.LocName)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("LOC_NAME");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DeptId)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Dept_Id");

                entity.Property(e => e.EmpAddress)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.EmpEmailId)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.EmpName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.LocId).HasColumnName("Loc_Id");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.HasKey(e => e.SubId)
                    .HasName("PK__Subject__2AC154A41BD5AB0D");

                entity.ToTable("Subject");

                entity.Property(e => e.SubId).HasColumnName("SUB_ID");

                entity.Property(e => e.Remark)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.SubName)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("SUB_NAME");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
