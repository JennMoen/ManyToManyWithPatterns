using ManyToMany.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ManyToMany.Models.MoviesActors;

namespace ManyToMany.Infrastructure
{
    public class MovieActorRepository
    {
        private ApplicationDbContext _db;

        public MovieActorRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        ////add actor to existing movie
        //public void AddActorToMovie ()
        //{
            
        //    _db.SaveChanges();
        //}

        //add totally new (actor and movie)--can work for totally new movie actor and/or adding a movie or actor to other existing one? see service level
        public void AddNewMovieActor(MovieActor dbMovieActor)
        {
            _db.MovieActors.Add(dbMovieActor);
            _db.SaveChanges();
        }

    }
}
