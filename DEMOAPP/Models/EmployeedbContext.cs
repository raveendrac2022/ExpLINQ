using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEMOAPP.Models
{
    public class EmployeedbContext: DbContext
    {
        public EmployeedbContext()
        { }
        public EmployeedbContext(DbContextOptions<EmployeedbContext> options) : base(options)
        { }
        public DbSet<Employee> InsertEmployee { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employee { get; set; }

        public DbSet<EmployeeDetails> EmployeeInfo { get; set; }

    
        public DbSet<FillData> FillData { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer(@"Data Source=CHETUIWK782\\SQL2017;Initial Catalog=Demo;User ID=sa; Password=Chetu@123");
                optionsBuilder.UseSqlServer(Common.ConnectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeDetails>(entity =>
            {
                entity.Property(e => e.id).HasColumnName("id");
                entity.Property(e => e.EmpName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmpAddress)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmpEmailId)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.DEPT_NAME)
                   .IsRequired()
                   .HasMaxLength(100)
                   .IsUnicode(false);

            });
        }
    }

   
}

