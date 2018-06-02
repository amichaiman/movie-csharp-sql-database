using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ex3
{
    public class Prize
    {
        private int _year;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Year
        {
            get => _year;
            set
            {
                if (value < 1900 || value > 2018)
                {
                    throw new InvalidInputException("Invalid year");
                }
                _year = value;
            }
        }

        public int ActorId { get; set; }
        public int ActressId { get; set; }
        public int DirectorId { get; set; }
        public int MovieSerial { get; set; }
    }
}