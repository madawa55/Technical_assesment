using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace library_system_API.Models;

public partial class LibrarySystemContext : DbContext
{
    public LibrarySystemContext()
    {
    }

    public LibrarySystemContext(DbContextOptions<LibrarySystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AuthorDetail> AuthorDetails { get; set; }

    public virtual DbSet<CategoryDetail> CategoryDetails { get; set; }

    public virtual DbSet<MasterBookInformation> MasterBookInformations { get; set; }

    public virtual DbSet<SubCategory> SubCategories { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            IConfigurationRoot configuratoin = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("appsettings.json").Build();
            var cs = configuratoin.GetSection("SqlServer").GetSection("connectionstring").Value;
            optionsBuilder.UseSqlServer(cs);
        }
    }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AuthorDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__author_d__3213E83F26820D34");

            entity.ToTable("author_details");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AuthorName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("author_name");
            entity.Property(e => e.RegisterNumber).HasColumnName("register_number");
        });

        modelBuilder.Entity<CategoryDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__category__3213E83F0688C4DA");

            entity.ToTable("category_details");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("category_name");
        });

        modelBuilder.Entity<MasterBookInformation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__master_b__3213E83FB2E95E97");

            entity.ToTable("master_book_information");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.BookName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("book_name");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Isbn)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("isbn");
            entity.Property(e => e.PublishedYear)
                .HasColumnType("date")
                .HasColumnName("published_year");
            entity.Property(e => e.SubCategoryId).HasColumnName("sub_category_id");

            entity.HasOne(d => d.Author).WithMany(p => p.MasterBookInformations)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("FK_master_book_information_author_details");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.MasterBookInformation)
                .HasForeignKey<MasterBookInformation>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_master_book_information_category_details");

            entity.HasOne(d => d.SubCategory).WithMany(p => p.MasterBookInformations)
                .HasForeignKey(d => d.SubCategoryId)
                .HasConstraintName("FK__master_bo__sub_c__2A4B4B5E");
        });

        modelBuilder.Entity<SubCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__sub_cate__3213E83F5BBE9526");

            entity.ToTable("sub_category");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.MainCategoryId).HasColumnName("main_category_id");
            entity.Property(e => e.SubCategoryName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("sub_category_name");

            entity.HasOne(d => d.MainCategory).WithMany(p => p.SubCategories)
                .HasForeignKey(d => d.MainCategoryId)
                .HasConstraintName("FK__sub_categ__main___2D27B809");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
