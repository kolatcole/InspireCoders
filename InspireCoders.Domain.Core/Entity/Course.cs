using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InspireCoders.Domain
{
    public class Course
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Code { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        // client will only get a list of facilitator IDs, it's better to just stringify the  list of seleccted IDs
        public List<Facilitator> Facilitators { get; set; }
    }
} 