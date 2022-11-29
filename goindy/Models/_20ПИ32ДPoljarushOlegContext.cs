using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MyApplication.Models
{
    public partial class _20ПИ32ДPoljarushOlegContext : DbContext
    {
        public _20ПИ32ДPoljarushOlegContext()
        {
        }

        public _20ПИ32ДPoljarushOlegContext(DbContextOptions<_20ПИ32ДPoljarushOlegContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Answer> Answers { get; set; } = null!;
        public virtual DbSet<Author> Authors { get; set; } = null!;
        public virtual DbSet<Blog> Blogs { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<Profile> Profiles { get; set; } = null!;
        public virtual DbSet<Tag> Tags { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=lab116-p;Database=20ПИ3-2ДPoljarushOleg;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>(entity =>
            {
                entity.ToTable("Answer");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Comments).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Info).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.TagsId).HasColumnName("Tags_id");
            });

            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("Author");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.BlogId).HasColumnName("Blog_id");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Projects).HasMaxLength(200);

                entity.HasMany(d => d.Blogs)
                    .WithMany(p => p.Authors)
                    .UsingEntity<Dictionary<string, object>>(
                        "AuthorsOfBlog",
                        l => l.HasOne<Blog>().WithMany().HasForeignKey("BlogId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Authors of blogs_Blog"),
                        r => r.HasOne<Author>().WithMany().HasForeignKey("AuthorId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Authors of blogs_Author"),
                        j =>
                        {
                            j.HasKey("AuthorId", "BlogId");

                            j.ToTable("Authors of blogs");

                            j.IndexerProperty<int>("AuthorId").HasColumnName("Author_id");

                            j.IndexerProperty<int>("BlogId").HasColumnName("Blog_id");
                        });
            });

            modelBuilder.Entity<Blog>(entity =>
            {
                entity.ToTable("Blog");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Author).HasMaxLength(150);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.GameName).HasMaxLength(50);

                entity.Property(e => e.ImagePath)
                    .HasMaxLength(250)
                    .HasColumnName("imagePath");

                entity.Property(e => e.Tags).HasMaxLength(150);

                entity.HasMany(d => d.TagsNavigation)
                    .WithMany(p => p.Blogs)
                    .UsingEntity<Dictionary<string, object>>(
                        "TagsOfBlog",
                        l => l.HasOne<Tag>().WithMany().HasForeignKey("TagId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Tags of blog_Tags"),
                        r => r.HasOne<Blog>().WithMany().HasForeignKey("BlogId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Tags of blog_Blog"),
                        j =>
                        {
                            j.HasKey("BlogId", "TagId").HasName("PK_Tags of blog_1");

                            j.ToTable("Tags of blog");

                            j.IndexerProperty<int>("BlogId").HasColumnName("Blog_id");

                            j.IndexerProperty<int>("TagId").HasColumnName("Tag_id");
                        });
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.AnswerId).HasColumnName("Answer_id");

                entity.Property(e => e.Avatar).HasMaxLength(50);

                entity.Property(e => e.Data).HasColumnType("date");

                entity.Property(e => e.Nickname).HasMaxLength(50);

                entity.Property(e => e.Text).HasMaxLength(500);

                entity.HasOne(d => d.Answer)
                    .WithMany(p => p.CommentsNavigation)
                    .HasForeignKey(d => d.AnswerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comments_Answer");
            });

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.ToTable("Profile");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.About).HasMaxLength(500);

                entity.Property(e => e.AuthorId).HasColumnName("Author_id");

                entity.Property(e => e.Avatar).HasMaxLength(250);

                entity.Property(e => e.Nickname).HasMaxLength(50);

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Profiles)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Profile_Author");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.AnswerId).HasColumnName("Answer_id");

                entity.Property(e => e.BlogId).HasColumnName("Blog_id");

                entity.Property(e => e.ProjectsId).HasColumnName("Projects_id");

                entity.Property(e => e.Tag1)
                    .HasMaxLength(100)
                    .HasColumnName("Tag");

                entity.HasOne(d => d.Answer)
                    .WithMany(p => p.Tags)
                    .HasForeignKey(d => d.AnswerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tags_Answer");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
