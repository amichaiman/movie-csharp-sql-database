
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex3
{
    public class Director
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public virtual ICollection<GoldenGlobe> GoldenGlobes { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
        public virtual ICollection<Oscar> Oscars { get; set; }
    }
}
