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

        // to show facilitators related to this particular course gottten with the facilitator IDs
        public List<Facilitator> Facilitators { get; set; }
        
        // all selected facilitatorID are stringified separated by comma from the client
        public string FacilitatorIDs { get; set; }
    }
} 