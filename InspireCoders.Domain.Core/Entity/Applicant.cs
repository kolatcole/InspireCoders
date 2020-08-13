using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InspireCoders.Domain
{
    public class Applicant
    {
        [Key]
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string Gender { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateofBirth { get; set; }



    }
}
