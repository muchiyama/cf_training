using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Sample_SoundServiceApi.Models
{
    public partial class SoundServiceApiContext : DbContext
    {
        public SoundServiceApiContext()
        {
        }

        public SoundServiceApiContext(DbContextOptions<SoundServiceApiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MusicInfo> MusicInfo { get; set; }
        public virtual DbSet<MusicPath> MusicPath { get; set; }
        public virtual DbSet<Parameter> Parameter { get; set; }
        public virtual DbSet<PlayingExtensionConfiguration> PlayingExtensionConfiguration { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=W1003848N182\\SQLEXPRESS;Database=SoundServiceApi;persist security info=True;user id=sa;password=1234567;MultipleActiveResultSets=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MusicInfo>(entity =>
            {
                entity.Property(e => e.Album)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Artist)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Genre)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Year)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MusicPath>(entity =>
            {
                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Parameter>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.RootDir)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PlayingExtensionConfiguration>(entity =>
            {
                entity.HasNoKey();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
