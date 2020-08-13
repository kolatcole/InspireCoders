
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

        public Task<Forum> getAsync(int ID)
        {
            throw new NotImplementedException();
        }

        public async Task<int> insertAsync(Forum data)
        {
            try
            {
                var Forum = new Forum
                {
                    Code=data.Code,
                    Name=data.Name
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
                   // if (data.Title != null) forum.Title = data.Title;

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
