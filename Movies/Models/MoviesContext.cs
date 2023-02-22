using System;
using Microsoft.EntityFrameworkCore;

namespace Movies.Models
{
	public class MoviesContext : DbContext
	{

		public MoviesContext (DbContextOptions<MoviesContext> options) : base (options)
		{

		}

		public DbSet<ApplicationResponse> responses { get; set; }
        public DbSet<Category> categories { get; set; }


        //seed data
        protected override void OnModelCreating(ModelBuilder mb)
		{
            mb.Entity<Category>().HasData(
                new Category { CategoryID=1, CategoryName= "Action/Adventure" },
                new Category { CategoryID =2, CategoryName = "Comdey" },
                new Category { CategoryID =3, CategoryName = "Drama" },
                new Category { CategoryID =4, CategoryName = "Family" },
                new Category { CategoryID =5, CategoryName = "Horror/Suspense" },
                new Category { CategoryID =6, CategoryName = "Miscellaneous" },
                new Category { CategoryID =7, CategoryName = "Television" },
                new Category { CategoryID =8, CategoryName = "VHS" },
                new Category { CategoryID =9, CategoryName = "Romance" },
                new Category { CategoryID =10, CategoryName = "Musicals" },
                new Category { CategoryID = 11, CategoryName = "Sci-Fi" },
                new Category { CategoryID = 12, CategoryName = "Mystery" },
                new Category { CategoryID = 13, CategoryName = "Sports" },
                new Category { CategoryID = 14, CategoryName = "Comdey/Drama" }

            );
			mb.Entity<ApplicationResponse>().HasData(

				new ApplicationResponse
				{
					ApplicationID = 1,
					CategoryID = 14,
					Title = "The Farewell",
					Year = 2019,
					Director = "Lulu Wang",
					Rating = "PG",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                },
                new ApplicationResponse
                {
                    ApplicationID = 2,
                    CategoryID = 9,
                    Title = "While You Were Sleeping",
                    Year = 1995,
                    Director = "Jon Turteltaub",
                    Rating = "PG",
                    Edited = false,
                    LentTo = "",
                    Notes = ""

                },
                new ApplicationResponse
                {
                    ApplicationID = 3,
                    CategoryID = 3,
                    Title = "Good Will Hunting",
                    Year = 1997,
                    Director = "Gus Van Sant",
                    Rating = "R",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                }


            );
		}
	}
}

