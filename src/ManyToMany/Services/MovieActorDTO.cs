using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManyToMany.Services
{
    public class MovieActorDTO
    {
        public int ActorId { get; set; }
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string ActorFirstName { get; set; }
        public string ActorLastName { get; set; }
        //public ActorDTO Actors { get; set; }
        //public MovieDTO Movies { get; set; }

        //public IList<MovieActorDTO> MovieActors { get; set; }



    }
}
