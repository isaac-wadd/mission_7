
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moviesApp.Models {

    public class MovieCtxt : DbContext {
        public MovieCtxt(DbContextOptions<MovieCtxt> options) : base(options) { }
        public DbSet<Movie> movies { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Rating> ratings { get; set; }

        protected override void OnModelCreating(ModelBuilder mb) {
            mb.Entity<Category>().HasData(
                new Category { categoryID = 1, name = "Action/Adventure" },
                new Category { categoryID = 2, name = "Comedy" },
                new Category { categoryID = 3, name = "Drama" },
                new Category { categoryID = 4, name = "Family" },
                new Category { categoryID = 5, name = "Horror/Suspense" },
                new Category { categoryID = 6, name = "Miscellaneous" },
                new Category { categoryID = 7, name = "Television" },
                new Category { categoryID = 8, name = "VHS" }
            );
            mb.Entity<Rating>().HasData(
                new Rating { ratingID = 1, term = "G" },
                new Rating { ratingID = 2, term = "PG" },
                new Rating { ratingID = 3, term = "PG-13" },
                new Rating { ratingID = 4, term = "R" },
                new Rating { ratingID = 5, term = "NR" },
                new Rating { ratingID = 6, term = "UR" },
                new Rating { ratingID = 7, term = "TV-Y7" },
                new Rating { ratingID = 8, term = "TV-PG" },
                new Rating { ratingID = 9, term = "TV-14" },
                new Rating { ratingID = 10, term = "TV-MA" }
            );
        }
    }
}
