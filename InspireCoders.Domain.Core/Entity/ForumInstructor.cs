using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InspireCoders.Domain
{
    public class ForumInstructor
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Forum")]
        public int ForumID { get; set; }

        [ForeignKey("Instructor")]
        public int InstructorID { get; set; }

    }
}
