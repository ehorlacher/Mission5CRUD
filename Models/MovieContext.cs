using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission5CRUD.Models
{
    public class MovieContext : DbContext
    {
        //Constructor
        public MovieContext (DbContextOptions<MovieContext> options) : base (options)
        {
            //Leave blank
        }

        public DbSet<MovieModel> Responses { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Action/Adventure" },
                new Category { CategoryId = 2, CategoryName = "Drama" },
                new Category { CategoryId = 3, CategoryName = "Family" },
                new Category { CategoryId = 4, CategoryName = "Horror/Suspense" },
                new Category { CategoryId = 5, CategoryName = "Miscellaneous" },
                new Category { CategoryId = 6, CategoryName = "Television" },
                new Category { CategoryId = 7, CategoryName = "VHS" }
            );

            mb.Entity<MovieModel>().HasData(

                new MovieModel
                {
                    MovieID = 1,
                    CategoryId = 1,
                    Title = "Avengers",
                    Year = 2021,
                    Director = "Joss Wheadon",
                    Rating = "PG-13",
                    Lent_To = "",
                    Notes = "Slam dunk movie."
                },
                new MovieModel
                {
                    MovieID = 2,
                    CategoryId = 1,
                    Title = "Star Wars",
                    Year = 1977,
                    Director = "George Lucas",
                    Rating = "PG",
                    Lent_To = "",
                    Notes = "The O.G."
                },
                new MovieModel
                {
                    MovieID = 3,
                    CategoryId = 2,
                    Title = "Remember the Titans",
                    Year = 2000,
                    Director = "Boaz Yakin",
                    Rating = "PG",
                    Lent_To = "",
                    Notes = "A real tear-jerker."
                }

            );
        }
    }
}
