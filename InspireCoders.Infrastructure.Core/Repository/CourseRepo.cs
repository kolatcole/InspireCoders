
using InspireCoders.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InspireCoders.Infrastructure
{
    public class CourseRepo : IRepo<Course>
    {

        private readonly TContext _context;

        public CourseRepo(TContext context)
        {
            _context = context;
        }


        public Task deleteAllByIDAsync(int ID)
        {
            throw new NotImplementedException();
        }

        public Task deleteAsync(int ID)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Course>> getAllAsync()
        {
            try
            {

                return  await _context.Courses.ToListAsync();
               

            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<List<Course>> getAllByIDAsync(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<Course> getAsync(int ID)
        {
            throw new NotImplementedException();
        }

        public async Task<int> insertAsync(Course data)
        {
            try
            {
                var course = new Course
                {
                   DateCreated=DateTime.Now,
                   Description=data.Description,
                   Code=data.Code,
                   Name=data.Name
                };

                await _context.Courses.AddAsync(course);
                await _context.SaveChangesAsync();

                return course.ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<bool> insertListAsync(List<Course> data)
        {
            throw new NotImplementedException();
        }

        public async Task updateAsync(Course data)
        {
            try
            {
                var course = await _context.Courses.FindAsync(data.ID);
                if (course != null)
                {
                    if (data.Code != null) course.Code = data.Code;
                    if (data.Description !=null) course.Description = data.Description;
                    if (data.Name != null) course.Name = data.Name;
                    course.DateModified = DateTime.Now;

                    _context.Courses.Update(course);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
