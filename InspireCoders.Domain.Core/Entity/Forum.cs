using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InspireCoders.Domain
{
    public class Forum
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Code { get; set; }

        public int Maximum { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public int CourseID { get; set; }

        public int FacilitatorID { get; set; }

        public List<Student> Students { get; set; }

        public string StudentIDs { get; set; }


    }
}
