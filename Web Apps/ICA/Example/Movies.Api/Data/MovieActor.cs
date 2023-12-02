using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Api.Data
{
    public class MovieActor
    {
        public int PersonId { get; set; }

        public int MovieId { get; set; }

        public Movie Movie { get; set; }

        public Person Person { get; set; }
    }
}
