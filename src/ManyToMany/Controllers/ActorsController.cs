using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ManyToMany.Services;
using ManyToMany.Data;
using static ManyToMany.Models.MoviesActors;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ManyToMany.Controllers
{
    [Route("api/[controller]")]
    public class ActorsController : Controller
    {
        private ActorService _aService;
        private ApplicationDbContext _db;
        private MovieService _mService;
        private MovieActorService _maService;

        public ActorsController(ActorService asv, ApplicationDbContext db, MovieService ms, MovieActorService ma)
        {
            this._aService = asv;
            this._db = db;
            this._mService = ms;
            this._maService = ma;
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

        [HttpGet]
        public IEnumerable<ActorDTO> GetActors()
        {
            return _aService.GetAllActors();
        }

        [HttpGet("{actorId}")]
        public ActorDTO GetById(int actorId)
        {
            return _aService.GetMoviesForOneActor(actorId);
        }

    }
}
