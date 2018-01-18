using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Angularzysko.Models
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z]{1,20}$")]
        [Required]
        public String Name { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z]{1,20}$")]
        [Required]
        public String Surname { get; set; }

        [RegularExpression(@"^[0-9\+]{1,}[0-9\-]{3,15}$")]
        [Required]
        public String Telephone { get; set; }


        [Required]
        public String Address { get; set; }
    }
}
