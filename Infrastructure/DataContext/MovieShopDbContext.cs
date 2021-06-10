using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Entities;

namespace Infrastructure
{
    public class MovieShopDbContext : DbContext
    {
        public MovieShopDbContext(DbContextOptions<MovieShopDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Cast>(ConfigureCast);
            modelBuilder.Entity<MovieCast>(ConfigureMovieCast);
            modelBuilder.Entity<MovieCrew>(ConfigureMovieCrew);
            modelBuilder.Entity<MovieGenre>(ConfigureMovieGenre);
            modelBuilder.Entity<Genre>(ConfigureGenre);
            modelBuilder.Entity<Crew>(ConfigureCrew);
            modelBuilder.Entity<Movie>(ConfigureMovie);
            modelBuilder.Entity<Review>(ConfigureReview);
            modelBuilder.Entity<UserRole>(ConfigureUserRole);
            modelBuilder.Entity<User>(ConfigureUser);
        }

      
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Trailer> Trailer { get; set; }
        public DbSet<Cast> Cast { get; set; }
        public DbSet<Crew> Crew { get; set; }
        //Table name will come from DbSet Property name
        public DbSet<Role> Role { get; set; }

        //2. using Fluent API
        public DbSet<Movie> Movie { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<MovieCast> MovieCast { get; set; }
        public DbSet<MovieGenre> MovieGenre { get; set; }
        public DbSet<MovieCrew> MovieCrew { get; set; }

        private void ConfigureUserRole(EntityTypeBuilder<UserRole> modelBuilder)
        {
            modelBuilder.HasKey(ur => new { ur.UserId,ur.RoleId });

            modelBuilder.HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId);

            modelBuilder.HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId);
            
        }
        private void ConfigureMovieCrew(EntityTypeBuilder<MovieCrew> modelBuilder)
        {
            modelBuilder.HasKey(mc => new { mc.MovieId, mc.CrewId });

            modelBuilder.HasOne(mc => mc.Crew)
                .WithMany(c => c.MovieCrews)
                .HasForeignKey(mc => mc.CrewId);

            modelBuilder.HasOne(mc => mc.Movie)
                .WithMany(m => m.MovieCrews)
                .HasForeignKey(mc => mc.MovieId);

            modelBuilder.Property(mc => mc.Department).HasMaxLength(128);
            modelBuilder.Property(mc => mc.Job).HasMaxLength(128);
        }
        private void ConfigureMovieGenre(EntityTypeBuilder<MovieGenre> modelBuilder)
        {
            modelBuilder.HasKey(mc => new { mc.MovieId, mc.GenreId });

            modelBuilder.HasOne(mc => mc.Genre)
                .WithMany(c => c.MovieGenres)
                .HasForeignKey(mc => mc.GenreId);

            modelBuilder.HasOne(mc => mc.Movie)
                .WithMany(m => m.MovieGenres)
                .HasForeignKey(mc => mc.MovieId);
        }
        private void ConfigureMovieCast(EntityTypeBuilder<MovieCast> modelBuilder)
        {
            modelBuilder.HasKey(mc => new { mc.MovieId, mc.CastId});

            modelBuilder.HasOne(mc => mc.Cast)
                .WithMany(c => c.MovieCasts)
                .HasForeignKey(mc => mc.CastId);

            modelBuilder.HasOne(mc => mc.Movie)
                .WithMany(m => m.MovieCasts)
                .HasForeignKey(mc => mc.MovieId);

            modelBuilder.Property(mc => mc.Character).HasMaxLength(450);
        }
        private void ConfigureCast(EntityTypeBuilder<Cast> builder)
        {
            // specify your Fluent API rules.
            builder.ToTable("Cast");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).HasMaxLength(128);
            builder.Property(t => t.ProfilePath).HasMaxLength(2084);
            builder.Ignore(m => m.Character);
        }
        private void ConfigureGenre(EntityTypeBuilder<Genre> builder)
        {
            // specify your Fluent API rules.
            builder.ToTable("Genre");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).HasMaxLength(64);
        }
        private void ConfigureCrew(EntityTypeBuilder<Crew> builder)
        {
            // specify your Fluent API rules.
            builder.ToTable("Crew");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).HasMaxLength(128);
            builder.Property(t => t.ProfilePath).HasMaxLength(2084);
        }
        private void ConfigureMovie(EntityTypeBuilder<Movie> builder)
        {
            // specify your Fluent API rules.
            builder.ToTable("Movie");
            //using ValueGeneratedOnAdd check if not using it
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd();


            builder.Property(m => m.Title).HasMaxLength(256);
            builder.Property(m => m.Tagline).HasMaxLength(512);
            builder.Property(m => m.Budget).HasColumnType("decimal(18, 2)").HasDefaultValue(9.9m);
            builder.Property(m => m.Revenue).HasColumnType("decimal(18, 2)");
            builder.Property(m => m.Price).HasColumnType("decimal(5, 2)").HasDefaultValue(9.9m);
            builder.Property(m => m.ImdbUrl).HasMaxLength(2084);
            builder.Property(m => m.TmdbUrl).HasMaxLength(2084);
            builder.Property(m => m.PosterUrl).HasMaxLength(2084);
            builder.Property(m => m.BackdropUrl).HasMaxLength(2084);
            builder.Property(m => m.OriginalLanguage).HasMaxLength(64);
            builder.Property(m => m.ReleaseDate).HasColumnType("datetime2(7)");

            //define Foreign Values
            builder.HasMany(m => m.Trailers).WithOne(t => t.Movie);
            builder.HasMany(m => m.Purchases).WithOne(p => p.Movie);
            builder.HasMany(m => m.Favorites).WithOne(p => p.Movie);

            builder.Ignore(m => m.Rating);
          

        }
        private void ConfigureReview(EntityTypeBuilder<Review> modelBuilder)
        {
            // specify your Fluent API rules.
            modelBuilder.ToTable("Review");
            modelBuilder.HasKey(mc => new { mc.MovieId, mc.UserId });
            modelBuilder.Property(t => t.Rating).HasColumnType("decimal(3,2)").HasDefaultValue(3.0d);
            
        }

        private void ConfigureUser(EntityTypeBuilder<User> modelBuilder)
        {
            // specify your Fluent API rules.
            modelBuilder.ToTable("User");
            modelBuilder.HasKey(mc => mc.Id );
            modelBuilder.Property(t => t.FirstName).HasMaxLength(128);
            modelBuilder.Property(t => t.LastName).HasMaxLength(128);
            modelBuilder.Property(t => t.Email).HasMaxLength(256);
            modelBuilder.Property(t => t.HashedPassword).HasMaxLength(1024);
            modelBuilder.Property(t => t.Salt).HasMaxLength(1024);
            modelBuilder.Property(t => t.PhoneNumber).HasMaxLength(16);
            modelBuilder.HasMany(m => m.Reviews).WithOne(t => t.User);
            modelBuilder.HasMany(m => m.Purchases).WithOne(p => p.User);
            modelBuilder.HasMany(m => m.Favorites).WithOne(p => p.User);
            modelBuilder.HasMany(m => m.UserRoles).WithOne(p => p.User);
       
        }
    }
}
