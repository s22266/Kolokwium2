using System;
using Kol2_example.Models;
using Microsoft.EntityFrameworkCore;

namespace Kol2_example.DataAccess
{
    public class MainDbContext : DbContext
    {
        protected MainDbContext()
        {
        }

        public MainDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Musician> Musicians { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<MusicLabel> MusicLabels { get; set; }
        public DbSet<Musician_Track> Musician_Tracks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Musician>(p =>
            {
                p.HasKey(e => e.IdMusician);
                p.Property(e => e.FirstName).IsRequired().HasMaxLength(30);
                p.Property(e => e.LastName).IsRequired().HasMaxLength(50);
                p.Property(e => e.Nickname).HasMaxLength(20);

                p.HasData(
                    new Musician { IdMusician = 1, FirstName = "Andrzej", LastName = "Nowak", Nickname = "ana" },
                    new Musician { IdMusician = 2, FirstName = "Ewa", LastName = "Wysoka", Nickname = "wysoka" },
                    new Musician { IdMusician = 3, FirstName = "Robert", LastName = "Lewandowski", Nickname = "r7" }
                    );
            });

            modelBuilder.Entity<Track>(d =>
            {
                d.HasKey(e => e.IdTrack);
                d.Property(e => e.TrackName).IsRequired().HasMaxLength(20);
                d.Property(e => e.Duration).IsRequired();

                d.HasOne(e => e.Album).WithMany(e => e.Tracks).HasForeignKey(e => e.idMusicAlbum);

                d.HasData(
                    new Track { IdTrack = 1, TrackName = "Track1", Duration = 5.4f},
                    new Track { IdTrack = 2, TrackName = "Track2", Duration = 3.3f}
                    );
            });

            modelBuilder.Entity<Album>(p =>
            {
                p.HasKey(e => e.IdAlbum);
                p.Property(e => e.AlbumName).IsRequired().HasMaxLength(30);
                p.Property(e => e.PublishDate).IsRequired();

                p.HasOne(e => e.MusicLabel).WithMany(e => e.Albums).HasForeignKey(e => e.IdMusicLabel);
                
                p.HasData(
                    new Album { IdAlbum = 1, AlbumName = "Album1", PublishDate = DateTime.Parse("2022-01-01")},
                    new Album { IdAlbum = 2, AlbumName = "Album2", PublishDate = DateTime.Parse("2022-01-01") }
                    );
            });

            modelBuilder.Entity<MusicLabel>(m =>
            {
                m.HasKey(e => e.IdMusicLabel);
                m.Property(e => e.Name).IsRequired().HasMaxLength(50);

                m.HasData(
                    new MusicLabel { IdMusicLabel = 1, Name = "Label1" },
                    new MusicLabel { IdMusicLabel = 2, Name = "Label2"}
                    );

            });

            modelBuilder.Entity<Musician_Track>(m =>
            {
                m.HasKey(e => new { e.IdTrack, e.IdMusician });

                m.HasOne(e => e.Track).WithMany(e => e.Musician_Tracks).HasForeignKey(e => e.IdTrack);
                m.HasOne(e => e.Musician).WithMany(e => e.Musician_Tracks).HasForeignKey(e => e.IdMusician);

                m.HasData(
                    new Musician_Track { IdTrack = 1, IdMusician = 1 },
                    new Musician_Track { IdTrack = 2, IdMusician = 2 }
                    );
            });
        }
    }
}
