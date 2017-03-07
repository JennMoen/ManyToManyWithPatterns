using ManyToMany.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManyToMany.Services
{
    public class MovieService
    {
        private MovieRepository _mRepo;

        public MovieService(MovieRepository mr)
        {
            _mRepo = mr;
        }

        //grab a single movie by its id and also grab its list of actors
        public MovieDTO GetActorsPerMovie(int movieId)
        {
            return (from m in _mRepo.GetMovieById(movieId)
                    select new MovieDTO()
                    {   Id = m.Id,
                        Title = m.Title,
                        Director = m.Director,
                        AssociatedActors = (from a in m.MovieActors
                                            select new MovieActorDTO()
                                            {
                                                ActorFirstName = a.Actor.FirstName,
                                                ActorLastName = a.Actor.LastName
                                            }).ToList()

                    }).FirstOrDefault();
        }


        //return all movies and their associated actors
        public IEnumerable<MovieDTO> GetAllMovies()
        {
            return (from m in _mRepo.GetAllMovies()
                    select new MovieDTO()
                    {
                        Id = m.Id,
                        Director = m.Director,
                        Title = m.Title,
                        AssociatedActors = (from a in m.MovieActors
                                            select new MovieActorDTO()
                                            {
                                                ActorFirstName = a.Actor.FirstName,
                                                ActorLastName = a.Actor.LastName,
                                                ActorId = a.Actor.Id
                                            }).ToList()

                    }).ToList();
        }
    }
}
