using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ManyToMany.Data;
using static ManyToMany.Models.MoviesActors;
using ManyToMany.Services;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ManyToMany.Controllers
{
    [Route("api/[controller]")]
    public class MoviesController : Controller
    {
        private ApplicationDbContext _db;
        private MovieService _mService;

        public MoviesController(ApplicationDbContext db, MovieService ms)
        {
            this._db = db;
            this._mService = ms;
        }


        [HttpPost("{id}")]
        public IActionResult Post(int id, [FromBody]Actor actor)
        {
            // create actor
            _db.Actors.Add(actor);
            _db.SaveChanges();

            // add actor to existing movie
            _db.MovieActors.Add(new MovieActor
            {
                MovieId = id,
                ActorId = actor.Id
            });
            _db.SaveChanges();

            // success
            return Ok();
        }
        [HttpGet("{movieId}")]
        public MovieDTO GetActorsForMovie(int movieId)
        {
            return _mService.GetActorsPerMovie(movieId);
        }

        [HttpGet]
        public IEnumerable<MovieDTO> GetAllMovies()
        {
            return _mService.GetAllMovies();
        }

       
    }
}
