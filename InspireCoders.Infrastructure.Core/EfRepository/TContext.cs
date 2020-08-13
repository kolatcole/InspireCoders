using InspireCoders.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InspireCoders.Infrastructure
{
    public class TContext:DbContext
    {
        public TContext(DbContextOptions<TContext> options):base(options)
        {

        }
        public DbSet<Student> Students { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Facilitator> Facilitators { get; set; }

        public DbSet<Applicant> Applicants { get; set; }

        public DbSet<Forum> Forums { get; set; }

        public DbSet<ForumInstructor> ForumInstructors { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<CourseFacilitator> CourseFacilitators { get; set; }
    }
}
