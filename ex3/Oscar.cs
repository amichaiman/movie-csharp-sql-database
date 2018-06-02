using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex3
{
    public class Oscar : Prize
    {
        
        [Required]
        public Actor BestActor { get; set; }
        [Required]
        public  Actress BestActress { get; set; }
        [Required]
        public Director BestDirector { get; set; }
        [Required]
        public Movie BestMotionPicture { get; set; }
    }
}
