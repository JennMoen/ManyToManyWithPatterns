using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManyToMany.Models
{
    public class MoviesActors
    {
        public class Movie
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Director { get; set; }

            public ICollection<MovieActor> MovieActors { get; set; }
        }


        public class Actor
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }

            public ICollection<MovieActor> MovieActors { get; set; }
        }


        public class MovieActor
        {
            public Movie Movie { get; set; }
            public int MovieId { get; set; }
            public Actor Actor { get; set; }
            public int ActorId { get; set; }
        }
    }
}
