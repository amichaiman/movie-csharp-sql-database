using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex3
{
    public class GoldenGlobe : Prize
    {
        
        
        [Required]
        public virtual Actor BestActor { get; set; }
        [Required]
        public virtual Actress BestActress { get; set; }
        [Required]
        public virtual Director BestDirector { get; set; }
        [Required]
        public virtual Movie BestFilm { get; set; }
    }
}
