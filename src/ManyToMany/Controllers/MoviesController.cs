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
        private MovieActorService _maService;

        public MoviesController(ApplicationDbContext db, MovieService ms, MovieActorService ma)
        {
            this._db = db;
            this._mService = ms;
            this._maService = ma;
        }

        [HttpGet]
        public IEnumerable<MovieDTO> GetAllMovies()
        {
            return _mService.GetAllMovies();
        }

        [HttpGet("{movieId}")]
        public MovieDTO GetActorsForMovie(int movieId)
        {
            return _mService.GetActorsPerMovie(movieId);
        }

        [HttpPost("{movieId}")]
        public IActionResult SaveActorToMovie(int movieId, [FromBody]ActorDTO actor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           
            _maService.AddActorToMovie(movieId, actor);

            return Ok();
        }

        

       
    }
}
