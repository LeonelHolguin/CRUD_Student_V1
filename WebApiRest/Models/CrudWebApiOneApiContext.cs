using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApiRest.Models;

public partial class CrudWebApiOneApiContext : DbContext
{
    public CrudWebApiOneApiContext()
    {
    }

    public CrudWebApiOneApiContext(DbContextOptions<CrudWebApiOneApiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Studient> Studients { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Studient>(entity =>
        {
            entity.HasKey(e => e.IdStudent).HasName("PK__Studient__61B35104EFC9FB54");

            entity.ToTable("Studient");

            entity.Property(e => e.AdmissionDate).HasColumnType("date");
            entity.Property(e => e.Career)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.RegisterDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
