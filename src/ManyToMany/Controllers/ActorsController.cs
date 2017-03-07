using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ManyToMany.Services;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ManyToMany.Controllers
{
    [Route("api/[controller]")]
    public class ActorsController : Controller
    {
        private ActorService _aService;

        public ActorsController(ActorService asv)
        {
            this._aService = asv;
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
