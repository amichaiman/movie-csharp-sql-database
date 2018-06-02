using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex3
{
    class MovieContext : DbContext
    {
        public MovieContext() { }
        public MovieContext(string DbName) : base(DbName) { }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Actress> Actresses { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<GoldenGlobe> GoldenGlobes { get; set; }
        public DbSet<Oscar> Oscars { get; set; }
    }

}
