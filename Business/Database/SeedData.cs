using Business.DataBase;
using Dal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Dal.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new MainDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<MainDbContext>>());

            if (context == null || context.Movie == null)
            {
                throw new NullReferenceException(
                    "Null ApplicationDbContext or Movie DbSet");
            }

            if (context.Movie.Any())
            {
                return;
            }

            context.Movie.AddRange(
                new Movie
                {
                    Title = "Mad Max",
                    ReleaseDate = new DateOnly(1979, 4, 12),
                    Genre = "Sci-fi (Cyberpunk)",
                    Price = 2.51M,
                    Rating = "R",
                    Origine = ""
                },
                new Movie
                {
                    Title = "The Road Warrior",
                    ReleaseDate = new DateOnly(1981, 12, 24),
                    Genre = "Sci-fi (Cyberpunk)",
                    Price = 2.78M,
                    Rating = "R",
                    Origine = ""
                },
                new Movie
                {
                    Title = "Mad Max: Beyond Thunderdome",
                    ReleaseDate = new DateOnly(1985, 7, 10),
                    Genre = "Sci-fi (Cyberpunk)",
                    Price = 3.55M,
                    Rating = "R",
                    Origine = ""
                },
                new Movie
                {
                    Title = "Mad Max: Fury Road",
                    ReleaseDate = new DateOnly(2015, 5, 15),
                    Genre = "Sci-fi (Cyberpunk)",
                    Price = 8.43M,
                    Rating = "R",
                    Origine = ""
                },
                new Movie
                {
                    Title = "Furiosa: A Mad Max Saga",
                    ReleaseDate = new DateOnly(2024, 5, 24),
                    Genre = "Sci-fi (Cyberpunk)",
                    Price = 13.49M,
                    Rating = "R",
                    Origine = ""
                });

            context.SaveChanges();
        }
    }
}
