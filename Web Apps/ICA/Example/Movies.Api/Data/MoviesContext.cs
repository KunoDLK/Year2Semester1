using Microsoft.EntityFrameworkCore;

namespace Movies.Api.Data
{
    public class MoviesContext : DbContext
    {
        public string DbPath { get; set; }
        public MoviesContext()
        {
            var folder = Environment.SpecialFolder.MyDocuments;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "movies.db");
        }

        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieActor> MovieActors { get; set; }
        public DbSet<Person> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Movie>()
                .HasOne(m => m.Director)
                .WithMany()
                .HasForeignKey(m => m.DirectorId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<MovieActor>()
                .HasKey(a => new { a.PersonId, a.MovieId });

            builder.Entity<MovieActor>()
                .HasOne(a => a.Movie)
                .WithMany(m => m.Actors)
                .HasForeignKey(a => a.MovieId);

            builder.Entity<MovieActor>()
                .HasOne(a => a.Person)
                .WithMany()
                .HasForeignKey(a => a.PersonId);

            // Provide seed data
            builder.Entity<Nationality>().HasData(
                    new Nationality { NationalityId = 1, Title = "British" },
                    new Nationality { NationalityId = 2, Title = "French" },
                    new Nationality { NationalityId = 3, Title = "American" }
                );

            builder.Entity<Person>().HasData(
                new Person { PersonId = 1, NationalityId = 1, Birthday = DateTime.Now, FirstName = "Larry", LastName = "Losser" },
                new Person { PersonId = 2, NationalityId = 1, Birthday = new DateTime(1970, 2, 14), FirstName = "Simon", LastName = "Pegg" },
                new Person { PersonId = 3, NationalityId = 1, Birthday = new DateTime(1976, 7, 19), FirstName = "Benedict", LastName = "Cumberbatch" },
                new Person { PersonId = 4, NationalityId = 2, Birthday = new DateTime(1948, 7, 30), FirstName = "Jean", LastName = "Reno" },
                new Person { PersonId = 5, NationalityId = 3, Birthday = new DateTime(1980, 8, 26), FirstName = "Chris", LastName = "Pine" },
                new Person { PersonId = 6, NationalityId = 3, Birthday = new DateTime(1966, 6, 27), FirstName = "JJ", LastName = "Abrams" },
                new Person { PersonId = 7, NationalityId = 3, Birthday = new DateTime(1971, 10, 11), FirstName = "Justin", LastName = "Lin" }
            );

            builder.Entity<Movie>().HasData(
                new Movie { MovieId = 1, Title = "Star Wars: The Force Awakens", ReleaseDate = new DateTime(2015, 12, 18), DirectorId = 6 },
                new Movie { MovieId = 2, Title = "Star Trek", ReleaseDate = new DateTime(2009, 5, 8), DirectorId = 6 },
                new Movie { MovieId = 3, Title = "Star Trek Beyond", ReleaseDate = new DateTime(2016, 1, 1), DirectorId = 7 },
                new Movie { MovieId = 4, Title = "Fast & Furious", ReleaseDate = new DateTime(2009, 1, 1), DirectorId = 7 },
                new Movie { MovieId = 5, Title = "Fast Five", ReleaseDate = new DateTime(2011, 1, 1), DirectorId = 7 },
                new Movie { MovieId = 6, Title = "Fast & Furious 6", ReleaseDate = new DateTime(2013, 1, 1), DirectorId = 7 },
                new Movie { MovieId = 7, Title = "Hollywood Adventures", ReleaseDate = new DateTime(2015, 1, 1), DirectorId = 7 },
                new Movie { MovieId = 8, Title = "Star Trek Into Darkness", ReleaseDate = new DateTime(2013, 1, 1), DirectorId = 6 },
                new Movie { MovieId = 9, Title = "Mission: Impossible III", ReleaseDate = new DateTime(2006, 1, 1), DirectorId = 6 }
                
            );

            builder.Entity<MovieActor>().HasData(
                new MovieActor { MovieId = 1, PersonId = 2 },
                new MovieActor { MovieId = 2, PersonId = 2 },
                new MovieActor { MovieId = 2, PersonId = 3 }
            );
        }
    }
}
