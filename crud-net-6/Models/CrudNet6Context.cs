using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace crud_net_6.Models;

public partial class CrudNet6Context : DbContext
{
    private readonly IConfiguration _configuration;
    private IDbConnection DbConnection { get; }

    public CrudNet6Context()
    {
    }

    public CrudNet6Context(DbContextOptions<CrudNet6Context> options)
        : base(options)
    {
    }

    public CrudNet6Context(DbContextOptions<CrudNet6Context> options, IConfiguration configuration) : base(options)
    {
        this._configuration = configuration;
        DbConnection = new SqlConnection(this._configuration.GetConnectionString("CrudNet6Context"));
    }

    public virtual DbSet<TblStudent> TblStudents { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(DbConnection.ToString());
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblStudent>(entity =>
        {
            entity.ToTable("tblStudent");

            entity.Property(e => e.Dob)
                .HasColumnType("date")
                .HasColumnName("DOB");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.StudentAddress).HasMaxLength(500);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
