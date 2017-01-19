using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ManyToMany.Data;
using static ManyToMany.Models.MoviesActors;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ManyToMany.Controllers
{
    [Route("api/[controller]")]
    public class MoviesController : Controller
    {
        private ApplicationDbContext _db;

        public MoviesController(ApplicationDbContext db)
        {
            this._db = db;
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

    }
}
