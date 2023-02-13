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

		protected override void OnModelCreating(ModelBuilder mb)
		{
			mb.Entity<ApplicationResponse>().HasData(

				new ApplicationResponse
				{
					ApplicationID = 1,
					Category = "Comedy/Drama",
					Title = "The Farewell",
					Year = 2019,
					Director = "Lulu Wang",
					Rating = "PG",
					Edited = true,
					LentTo = "",
					Notes = ""
				},
                new ApplicationResponse
                {
                    ApplicationID = 2,
                    Category = "Romance",
                    Title = "While You Were Sleeping",
                    Year = 1995,
                    Director = "Jon Turteltaub",
                    Rating = "PG",
                    Edited = true,
                    LentTo = "",
                    Notes = ""
                },
                new ApplicationResponse
                {
                    ApplicationID = 3,
                    Category = "Drama/Romance",
                    Title = "Good Will Hunting",
                    Year = 1997,
                    Director = "Gus Van Sant",
                    Rating = "R",
                    Edited = true,
                    LentTo = "",
                    Notes = ""
                }


            );
		}
	}
}

