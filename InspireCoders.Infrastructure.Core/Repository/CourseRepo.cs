
using InspireCoders.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspireCoders.Infrastructure
{
    public class CourseRepo : ICourseRepo
    {

        private readonly TContext _context;

        public CourseRepo(TContext context)
        {
            _context = context;
        }

        public async Task deleteAsync(int ID)
        {
            try
            {
                var course = await _context.Courses.FindAsync(ID);
                _context.Courses.Remove(course);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Course> getByNameAsync(string name)
        {
            try
            {

                var course = await _context.Courses.FirstOrDefaultAsync(x => x.Name == name);
                return course;

            }

            catch (Exception ex)
            {
                throw ex;
            }
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

        public async Task<Course> getCourseByCodeAsync(string code)
        {
            try
            {
                return await _context.Courses.FirstOrDefaultAsync(x => x.Code == code);
            }
            catch
            {
                return null;
            }
        }

        public async Task<Course> getCourseByIDAsync(int ID)
        {
            try
            {
                return await _context.Courses.FirstOrDefaultAsync(x => x.ID == ID);
            }
            catch
            {
                return null;
            }
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
                   Name=data.Name,
                   FacilitatorIDs=data.FacilitatorIDs
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
                    if (data.FacilitatorIDs != null) course.FacilitatorIDs = data.FacilitatorIDs;
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
