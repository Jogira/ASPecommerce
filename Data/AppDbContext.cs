using ASPecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPecommerce.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Define a compound/combination of primary keys. Actor_Movie will both be tied to a movie ID and Actor ID.
            modelBuilder.Entity<Actor_Movie>().HasKey(am => new
            {
                am.ActorId,
                am.MovieId
            });

            //This defines the Actor_Movie as the joining model/table on the C# side.
            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Movie).WithMany(am => am.Actors_Movies).HasForeignKey(m => m.MovieId);
            //We can see one movie goes to Movie, which will have all of the attributes in the Actors_Movies class.
            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Actor).WithMany(am => am.Actors_Movies).HasForeignKey(m => m.ActorId);


            base.OnModelCreating(modelBuilder);
        }

        //Declaring the names for all the tables that will go in the DB, based off their respective classes.
        public DbSet<Actor> Actors { get; set; } //Passing in an object of the Actor class, naming the table Actors.
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor_Movie> Actors_Movies { get; set; } //Passing in the Actor_Movie class, naming the table Actors_Movies.
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Producer> Producers { get; set; }

    }
}
