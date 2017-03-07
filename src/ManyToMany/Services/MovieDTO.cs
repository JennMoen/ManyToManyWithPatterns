using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManyToMany.Services
{
    public class MovieDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Director { get; set; }

        public IList<MovieActorDTO> AssociatedActors { get; set; }


    }
}
