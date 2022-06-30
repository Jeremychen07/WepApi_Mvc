using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebApi.Models
{
    public partial class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext()
        {
        }

        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TEmployee> TEmployees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\a2726\\OneDrive\\Desktop\\PUSH GITHUB\\WepApi_Mvc\\WebApi\\WebApi\\App_Data\\dbEmp.mdf;Integrated Security=True;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TEmployee>(entity =>
            {
                entity.HasKey(e => e.FEmpId)
                    .HasName("PK__tmp_ms_x__C4A26E9C2BDE77EA");

                entity.ToTable("tEmployee");

                entity.Property(e => e.FEmpId)
                    .HasMaxLength(50)
                    .HasColumnName("fEmpId");

                entity.Property(e => e.FGender)
                    .HasMaxLength(50)
                    .HasColumnName("fGender");

                entity.Property(e => e.FMail)
                    .HasMaxLength(50)
                    .HasColumnName("fMail");

                entity.Property(e => e.FName)
                    .HasMaxLength(50)
                    .HasColumnName("fName");

                entity.Property(e => e.FSalary).HasColumnName("fSalary");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
