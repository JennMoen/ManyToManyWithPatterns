using ManyToMany.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManyToMany.Services
{
    public class ActorService
    {
        private ActorRepository _aRepo;

        public ActorService(ActorRepository mr)
        {
            _aRepo = mr;
        }

        //get all actors--can also include a list of each of their movies
        public IEnumerable<ActorDTO> GetAllActors()
        {
            return (from a in _aRepo.GetActors()
                    select new ActorDTO()
                    {
                        Id = a.Id,
                        FirstName = a.FirstName,
                        LastName = a.LastName,
                        AssociatedMovies = (from ma in a.MovieActors
                                            select new MovieActorDTO()
                                            {
                                                ActorFirstName = ma.Actor.FirstName,
                                                ActorLastName = ma.Actor.LastName,
                                                ActorId = ma.Actor.Id,
                                                MovieId = ma.Movie.Id,
                                                MovieName = ma.Movie.Title
                                            }).ToList()
                    }).ToList();
        }


        //just getting an actor by id is fine--you can return a list of his/her movies in the DTO
        public ActorDTO GetMoviesForOneActor(int actorId)
        {
            return (from a in _aRepo.GetActorById(actorId)
                    select new ActorDTO()
                    {
                        Id = a.Id,
                        FirstName = a.FirstName,
                        LastName = a.LastName,
                        AssociatedMovies = (from ma in a.MovieActors
                                            select new MovieActorDTO()
                                            {
                                                ActorFirstName = ma.Actor.FirstName,
                                                ActorLastName = ma.Actor.LastName,
                                                ActorId = ma.Actor.Id,
                                                MovieId = ma.Movie.Id,
                                                MovieName = ma.Movie.Title
                                            }).ToList()
                    }).FirstOrDefault();
        }

    }
}
