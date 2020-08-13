using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InspireCoders.Domain
{
    public class Contact
    {
    

        [Key]
        public int ID { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        public string Subject { get; set; }

        [Required]
        [MaxLength(250)]
        public string Message { get; set; }
    }
}
