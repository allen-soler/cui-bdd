using Microsoft.EntityFrameworkCore;

namespace FilmApi.Models
{
    public class FilmContext : DbContext
    {
        public DbSet<Film> Films { get; set; }
        public DbSet<Realisateur> Realisateurs { get; set; }
        public DbSet<Acteur> Acteurs { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<FilmActeur> FilmActeurs { get; set; }
        public DbSet<FilmGenre> FilmGenres { get; set; }
        public DbSet<FilmRealisateur> FilmRealisateurs { get; set; }

        public FilmContext(DbContextOptions<FilmContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FilmActeur>()
                .HasKey(fa => new { fa.FilmId, fa.CastActorId });

            modelBuilder.Entity<FilmGenre>()
                .HasKey(fg => new { fg.FilmId, fg.GenreId });

            modelBuilder.Entity<FilmRealisateur>()
                .HasKey(fr => new { fr.FilmId, fr.RealisateurId });

            // Additional configurations or constraints can be added here
        }
    }
}
