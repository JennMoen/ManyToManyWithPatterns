using ManyToMany.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ManyToMany.Models.MoviesActors;

namespace ManyToMany.Infrastructure
{
    public class ActorRepository
    {
        private ApplicationDbContext _db;

        public ActorRepository(ApplicationDbContext db)
        {
            _db = db;
        }


        public IQueryable<Actor> GetActors()
        {
            return from a in _db.Actors
                   select a;
        }


        public IQueryable<Actor> GetActorById(int id)
        {
            return from a in _db.Actors
                   where a.Id == id
                   select a;
        }

        public void AddActor(Actor actor) 
        {
            _db.Actors.Add(actor);
            _db.SaveChanges();
        }
    }
}
