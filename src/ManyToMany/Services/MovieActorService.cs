using ManyToMany.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ManyToMany.Models.MoviesActors;

namespace ManyToMany.Services
{
    public class MovieActorService
    {
        private MovieActorRepository _maRepo;
        private MovieRepository _mRepo;
        private ActorRepository _aRepo;

        public MovieActorService(MovieActorRepository mr, MovieRepository mre, ActorRepository ar)
        {
            _maRepo = mr;
            _mRepo = mre;
            _aRepo = ar;
        }

        public void AddActorToMovie(int movieId, ActorDTO actor)
        {
                Actor dbActor = new Actor()
                {
                    Id = actor.Id,
                    FirstName = actor.FirstName,
                    LastName = actor.LastName
                };
                _aRepo.AddActor(dbActor);

                MovieActor dbMa = new MovieActor
                {
                    ActorId = dbActor.Id,
                    MovieId = movieId
                    //MovieId = _mRepo.GetMovieById(movieId).First().Id
                };


                _maRepo.AddNewMovieActor(dbMa);

            }
        }
    }

