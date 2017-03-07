using ManyToMany.Data;
using ManyToMany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ManyToMany.Models.MoviesActors;

namespace ManyToMany.Infrastructure
{
    public class MovieRepository
    {
        private ApplicationDbContext _db;

            public MovieRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public IQueryable<Movie> GetMovieById(int id)
        {
            return from m in _db.Movies
                   where m.Id == id
                   select m;

        }

        

        public IQueryable<Movie> GetAllMovies()
        {
            return from m in _db.Movies
                   select m;
        }
    }
}
