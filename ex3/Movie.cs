using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex3
{
    public class Movie
    {
        private int _year;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MovieSerial { get; set; }

        public string MovieTitle { get; set; }
        public int Year
        {
            get => _year;
            set
            {
                if (value < 1900 || value > 2018)
                {
                    throw new InvalidInputException("Invalid movie year");
                }
                _year = value;
            }
        }
        public int DirectorId { get; set; }
        public string Country { get; set; }
        public int ImdbScore { get; set; }


        public virtual Oscar Oscar { get; set; }
        public virtual GoldenGlobe GoldenGlobe { get; set; }
        public Director Director { get; set; }
        public virtual ICollection<Actor> Actors { get; set; }
        public virtual ICollection<Actress> Actresses { get; set; }
    }
}
