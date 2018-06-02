using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex3
{
    public class Actress : Person
    {
        
        public virtual ICollection<GoldenGlobe> GoldenGlobes { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
        public virtual ICollection<Oscar> Oscars { get; set; }
    }
}
