
using InspireCoders.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InspireCoders.Infrastructure
{
    public class StudentRepo : IRepo<Student>
    {

        private readonly TContext _context;

       public StudentRepo(TContext context)
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

        public async Task<List<Student>> getAllAsync()
        {
            try
            {

                var students = await _context.Students.ToListAsync();
                return students;

            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<List<Student>> getAllByIDAsync(int ID)
        {
            throw new NotImplementedException();
        }

        public async Task<Student> getAsync(int ID)
        {
            try
            {

                return await _context.Students.FindAsync(ID);

            }

            catch
            {
                return null;
            }
        }

        public async Task<int> insertAsync(Student data)
        {
            try
            {
                var student = new Student
                {
                    Code=data.Code,
                    DateCreated=DateTime.Now,
                    Nickname=data.Nickname
                };

                await _context.Students.AddAsync(student);
                await _context.SaveChangesAsync();

                return student.ID;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public Task<bool> insertListAsync(List<Student> data)
        {
            throw new NotImplementedException();
        }

        public async Task updateAsync(Student data)
        {
            try
            {
                var student = await _context.Students.FindAsync(data.ID);
                if (student != null)
                {
                    if (data.Code != null) student.Code = data.Code;
                    if (data.Nickname != null) student.Nickname = data.Nickname;
                    student.DateModified = DateTime.Now;

                    _context.Students.Update(student);
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
