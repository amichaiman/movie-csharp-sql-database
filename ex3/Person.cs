using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex3
{
    public class Person
    {
        private int _yearBorn;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string FristName { get; set; }
        public string LastName { get; set; }
        public int YearBorn
        {
            get => _yearBorn;
            set
            {
                if (value < 1990 || value > 2018)
                {
                    throw new InvalidInputException("Invalid year");
                }
                _yearBorn = value;
            }
        }
    }
}
