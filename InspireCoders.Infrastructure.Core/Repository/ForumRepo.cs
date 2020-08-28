
using InspireCoders.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InspireCoders.Infrastructure
{
    public class ForumRepo : IRepo<Forum>
    {

        private readonly TContext _context;

        public ForumRepo(TContext context)
        {
            _context = context;
        }


        public Task deleteAllByIDAsync(int ID)
        {
            throw new NotImplementedException();
        }

        public async Task deleteAsync(int ID)
        {
            try
            {
                var forum = await _context.Forums.FindAsync(ID);
                _context.Forums.Remove(forum);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Forum> getByCodeAsync(string code)
        {
            try
            {

                var forum = await _context.Forums.FirstOrDefaultAsync(x => x.Code == code);
                return forum;

            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Forum> getByNameAsync(string name)
        {
            try
            {

                var forum = await _context.Forums.FirstOrDefaultAsync(x => x.Name == name);
                return forum;

            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Forum>> getAllAsync()
        {
            try
            {

                return await _context.Forums.ToListAsync();
               

            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<List<Forum>> getAllByIDAsync(int ID)
        {
            throw new NotImplementedException();
        }

        public async Task<Forum> getAsync(int ID)
        {
            try
            {

                return await _context.Forums.FindAsync(ID);

            }

            catch
            {
                return null;
            }
        }

        public async Task<int> insertAsync(Forum data)
        {
            try
            {
                var Forum = new Forum
                {
                    Code=data.Code,
                    Name=data.Name,
                    DateCreated=DateTime.Now,
                    Description=data.Description,
                    Maximum=data.Maximum,
                    CourseID=data.CourseID,
                    FacilitatorID=data.FacilitatorID
                };

                await _context.Forums.AddAsync(Forum);
                await _context.SaveChangesAsync();

                return Forum.ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<bool> insertListAsync(List<Forum> data)
        {
            throw new NotImplementedException();
        }

        public async Task updateAsync(Forum data)
        {
            try
            {
                var forum = await _context.Forums.FindAsync(data.ID);
                if(forum!=null)
                {
                    if (data.Code != null) forum.Code = data.Code;
                    if (data.Name != null) forum.Name = data.Name;
                    if (data.StudentIDs != null) forum.StudentIDs = data.StudentIDs;
                    if (data.Maximum > 0) forum.Maximum = data.Maximum;
                    if (data.CourseID > 0) forum.CourseID = data.CourseID;
                    if (data.FacilitatorID > 0) forum.FacilitatorID = data.FacilitatorID;
                    forum.DateModified = DateTime.Now;
                    if (data.Description != null) forum.Description = data.Description;

                    _context.Forums.Update(forum);
                    await _context.SaveChangesAsync();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
