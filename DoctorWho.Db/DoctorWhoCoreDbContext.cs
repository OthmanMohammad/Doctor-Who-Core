using DoctorWho.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace DoctorWho.Db
{
    public class DoctorWhoCoreDbContext : DbContext
    {
        // DbSet properties for each of the entities in the domain
        public DbSet<Author> Authors { get; set; }
        public DbSet<Companion> Companions { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Enemy> Enemies { get; set; }
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<EpisodeCompanion> EpisodeCompanions { get; set; }
        public DbSet<EpisodeEnemy> EpisodeEnemies { get; set; }
        public DbSet<EpisodeView> EpisodeViews { get; set; }
        public DbSet<ThreeMostFrequentlyAppearingCompanions> ThreeMostFrequentlyAppearingCompanions { get; set; }
        public DbSet<ThreeMostFrequentlyAppearingEnemies> ThreeMostFrequenlyAppearingEnemies { get; set; }

        // Override the OnConfiguring method to configure the database connection string
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Use the UseSqlServer method to configure the connection string to use SQL Server
            optionsBuilder.UseSqlServer("Data Source = LAPTOP-COT3PQTF\\SQLEXPRESS; Initial Catalog=DoctorWhoCore; Integrated Security=True")
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
                .EnableSensitiveDataLogging(true);
        }

        // Method to create the model for the database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define the key for the Author entity and set properties
            modelBuilder.Entity<Author>().HasKey(a => a.AuthorId);
            modelBuilder.Entity<Author>().Property(a => a.AuthorName).IsRequired();
            modelBuilder.Entity<Author>().Property(a => a.AuthorName).HasMaxLength(350);

            // Define the key for the Companion entity and set properties
            modelBuilder.Entity<Companion>().HasKey(c => c.CompanionId);
            modelBuilder.Entity<Companion>().Property(c => c.CompanionName).IsRequired();
            modelBuilder.Entity<Companion>().Property(c => c.CompanionName).HasMaxLength(350);
            modelBuilder.Entity<Companion>().Property(c => c.WhoPlayed).IsRequired();
            modelBuilder.Entity<Companion>().Property(c => c.WhoPlayed).HasMaxLength(350);

            // Define the key for the Doctor entity and set properties
            modelBuilder.Entity<Doctor>().HasKey(d => d.DoctorId);
            modelBuilder.Entity<Doctor>().Property(d => d.DoctorId).IsRequired();
            modelBuilder.Entity<Doctor>().Property(d => d.DoctorName).IsRequired();
            modelBuilder.Entity<Doctor>().Property(d => d.DoctorName).HasMaxLength(350);
            modelBuilder.Entity<Doctor>().Property(d => d.BirthDate).HasDefaultValueSql("NULL");
            modelBuilder.Entity<Doctor>().Property(d => d.FirstEpisodeDate).HasDefaultValueSql("NULL");
            modelBuilder.Entity<Doctor>().Property(d => d.LastEpisodeDate).HasDefaultValueSql("NULL");

            // Define the key for the Enemy entity and set properties
            modelBuilder.Entity<Enemy>().HasKey(e => e.EnemyId);
            modelBuilder.Entity<Enemy>().Property(e => e.EnemyName).IsRequired();
            modelBuilder.Entity<Enemy>().Property(e => e.EnemyName).HasMaxLength(350);
            modelBuilder.Entity<Enemy>().Property(e => e.Description).HasDefaultValueSql("NULL");

            // Define the key for the Episode entity and set properties
            modelBuilder.Entity<Episode>().HasKey(e => e.EpisodeId);
            modelBuilder.Entity<Episode>().Property(e => e.SeriesNumber).HasDefaultValueSql("0");
            modelBuilder.Entity<Episode>().Property(e => e.EpisodeNumber).HasDefaultValueSql("0");
            modelBuilder.Entity<Episode>().Property(e => e.EpisodeType).IsRequired();
            modelBuilder.Entity<Episode>().Property(e => e.EpisodeType).HasMaxLength(50);
            modelBuilder.Entity<Episode>().Property(e => e.Title).IsRequired();
            modelBuilder.Entity<Episode>().Property(e => e.EpisodeDate).HasDefaultValueSql("NULL");
            modelBuilder.Entity<Episode>().Property(e => e.Notes).HasDefaultValueSql("NULL");

            // Define "EpisodeCompanion" entity and set the primary key
            modelBuilder.Entity<EpisodeCompanion>().HasKey(ec => ec.EpisodeCompanionId);

            // Set up the relationship between "EpisodeCompanion" and "Companion" entities
            modelBuilder.Entity<EpisodeCompanion>()
                        .HasOne(ec => ec.Companion)
                        .WithMany(c => c.EpisodeCompanions)
                        .HasForeignKey(ec => ec.CompanionId);

            // Set up the relationship between "EpisodeCompanion" and "Episode" entities
            modelBuilder.Entity<EpisodeCompanion>()
                        .HasOne(ec => ec.Episode)
                        .WithMany(e => e.EpisodeCompanions)
                        .HasForeignKey(ec => ec.EpisodeId);

            // Define the EpisodeEnemy entity and set the primary key
            modelBuilder.Entity<EpisodeEnemy>().HasKey(ee => ee.EpisodeEnemyId);

            // Define the relationship between EpisodeEnemy and Enemy entities
            modelBuilder.Entity<EpisodeEnemy>()
                        .HasOne(ee => ee.Enemy)
                        .WithMany(e => e.EpisodeEnemies)
                        .HasForeignKey(ee => ee.EnemyId);

            // Define the relationship between EpisodeEnemy and Episode entities
            modelBuilder.Entity<EpisodeEnemy>()
                        .HasOne(ee => ee.Episode)
                        .WithMany(e => e.EpisodeEnemies)
                        .HasForeignKey(ee => ee.EpisodeId);

            // Define the EpisodeView entity as a database view with no key
            modelBuilder.Entity<EpisodeView>().HasNoKey().ToView("viewEpisodes");

            // Define the ThreeMostFrequentlyAppearingCompanions entity as an entity with no key
            modelBuilder.Entity<ThreeMostFrequentlyAppearingCompanions>().HasNoKey();

            // Define the ThreeMostFrequentlyAppearingEnemies entity as an entity with no key
            modelBuilder.Entity<ThreeMostFrequentlyAppearingEnemies>().HasNoKey();

        }
    }
}




