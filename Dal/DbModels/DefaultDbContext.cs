using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dal.DbModels;

public partial class DefaultDbContext : DbContext
{
    public DefaultDbContext()
    {
    }

    public DefaultDbContext(DbContextOptions<DefaultDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Animal> Animals { get; set; }

    public virtual DbSet<Breed> Breeds { get; set; }

    public virtual DbSet<Typee> Typees { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-8QQKPTB;Initial Catalog=PetStore;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Animal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Animal__3213E83F74194D47");

            entity.ToTable("Animal");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nickname)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnName("nickname");

            entity.HasOne(d => d.Breed).WithMany(p => p.AnimalBreeds)
                .HasForeignKey(d => d.BreedId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Animal__BreedId__3B75D760");

            entity.HasOne(d => d.Type).WithMany(p => p.AnimalTypes)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Animal__TypeId__3C69FB99");
        });

        modelBuilder.Entity<Breed>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Breed__3213E83F7C46BCC5");

            entity.ToTable("Breed");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Typee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Typee__3213E83FD728FD3A");

            entity.ToTable("Typee");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3213E83F7852D400");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Login)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .IsRequired()
                .HasColumnName("password");
            entity.Property(e => e.RegistrationDate).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
