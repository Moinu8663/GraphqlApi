using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GraphQLApiDemo.Model;

public partial class MoinuContext : DbContext
{
    //DB first approche command
    //dotnet ef dbcontext scaffold "Server=ARJDU-D-0292\SQLEXPRESS;Database=Moinu;Trusted_Connection=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o Model -t UserDetails

    public MoinuContext(DbContextOptions<MoinuContext> options)
        : base(options)
    {
    }

    public virtual DbSet<UserDetail> UserDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserDetail>(entity =>
        {
            entity.HasKey(e => e.EmpCode).HasName("PK__UserDeta__7DA847CB8CE14CF5");

            entity.Property(e => e.EmpCode).HasMaxLength(50);
            entity.Property(e => e.Address).HasMaxLength(250);
            entity.Property(e => e.Company).HasMaxLength(50);
            entity.Property(e => e.CompanyAddress).HasMaxLength(250);
            entity.Property(e => e.CompanyImage).HasMaxLength(255);
            entity.Property(e => e.Department).HasMaxLength(50);
            entity.Property(e => e.Dob).HasColumnName("DOB");
            entity.Property(e => e.EmailId).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.Grade).HasMaxLength(255);
            entity.Property(e => e.JobTitle).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.MobileNo).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
