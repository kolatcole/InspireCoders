using InspireCoders.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspireCoders.Infrastructure
{
    public class StudentForumRepo : IRepo<StudentForum>
    {
        private readonly TContext _context;
        public StudentForumRepo(TContext context)
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

        public Task<List<StudentForum>> getAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<StudentForum>> getAllByIDAsync(int ID)
        {
            try
            {
                return await _context.StudentForums.Where(x=>x.StudentID==ID).ToListAsync();
            }
            catch
            {
                return null;
            }
        }

        public Task<StudentForum> getAsync(int ID)
        {
            throw new NotImplementedException();
        }

        public async Task<int> insertAsync(StudentForum data)
        {
            try
            {
                var forum = new StudentForum
                {
                    StudentID = data.StudentID,
                    ForumID = data.ForumID
                };

                await _context.StudentForums.AddAsync(forum);
                await _context.SaveChangesAsync();
                return forum.ID;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> insertListAsync(List<StudentForum> data)
        {
            try
            {

                _context.StudentForums.AddRange(data);
                await _context.SaveChangesAsync();
                return true;

            }
            catch
            {
                return false;
            }
        }


        public Task updateAsync(StudentForum data)
        {
            throw new NotImplementedException();
        }
    }
}
