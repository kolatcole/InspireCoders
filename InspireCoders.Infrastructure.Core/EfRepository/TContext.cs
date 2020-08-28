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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //var assignedPermissions = new List<PermEnums>
            //{
            //    PermEnums.
            //};

            //var permissions = assignedPermissions.Select(c => ((int)c).ToString()).ToList();
            modelBuilder.Entity<Role>().HasData(
                
                new Role
                {
                    DateCreated=DateTime.Now,
                    Description="Basic",
                    Name="Basic Role",
                    Permissions="",
                    Id=Guid.NewGuid()
                }
                
            );
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Facilitator> Facilitators { get; set; }

        public DbSet<Applicant> Applicants { get; set; }

        public DbSet<Forum> Forums { get; set; }

        public DbSet<ForumInstructor> ForumInstructors { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<StudentForum> StudentForums { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<User> Users { get; set; }


    }
}
