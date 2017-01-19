using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;
using ManyToMany.Models;
using static ManyToMany.Models.MoviesActors;

namespace ManyToMany.Data
{
    public class SampleData
    {
        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            var db = serviceProvider.GetService<ApplicationDbContext>();
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            // Ensure db
            db.Database.EnsureCreated();

            // Ensure Stephen (IsAdmin)
            var stephen = await userManager.FindByNameAsync("Stephen.Walther@CoderCamps.com");
            if (stephen == null)
            {
                // create user
                stephen = new ApplicationUser
                {
                    UserName = "Stephen.Walther@CoderCamps.com",
                    Email = "Stephen.Walther@CoderCamps.com"
                };
                await userManager.CreateAsync(stephen, "Secret123!");

                // add claims
                await userManager.AddClaimAsync(stephen, new Claim("IsAdmin", "true"));
            }

            // Ensure Mike (not IsAdmin)
            var mike = await userManager.FindByNameAsync("Mike@CoderCamps.com");
            if (mike == null)
            {
                // create user
                mike = new ApplicationUser
                {
                    UserName = "Mike@CoderCamps.com",
                    Email = "Mike@CoderCamps.com"
                };
                await userManager.CreateAsync(mike, "Secret123!");
            }

            if (!db.Movies.Any())
            {
                // create movies
                db.Movies.AddRange(
                    new Movie { Title = "Star Wars" },
                    new Movie { Title = "Blade Runner" }
                );
                db.SaveChanges();

                // create actors
                db.Actors.AddRange(
                    new Actor { FirstName = "Harrison", LastName = "Ford" },
                    new Actor { FirstName = "Carrie", LastName = "Fisher" }
                );
                db.SaveChanges();

                // add many-to-many
                db.MovieActors.AddRange(
                    new MovieActor
                    {
                        MovieId = db.Movies.FirstOrDefault(m => m.Title == "Star Wars").Id,
                        ActorId = db.Actors.FirstOrDefault(a => a.LastName == "Ford").Id
                    },
                    new MovieActor
                    {
                        MovieId = db.Movies.FirstOrDefault(m => m.Title == "Star Wars").Id,
                        ActorId = db.Actors.FirstOrDefault(a => a.LastName == "Fisher").Id
                    },
                    new MovieActor
                    {
                        MovieId = db.Movies.FirstOrDefault(m => m.Title == "Blade Runner").Id,
                        ActorId = db.Actors.FirstOrDefault(a => a.LastName == "Ford").Id
                    }
                );
                db.SaveChanges();
            }
        }
    }
}
