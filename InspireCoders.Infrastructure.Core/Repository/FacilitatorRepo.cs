
using InspireCoders.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InspireCoders.Infrastructure
{
    public class FacilitatorRepo : IRepo<Facilitator>
    {

        private readonly TContext _context;

        public FacilitatorRepo(TContext context)
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
                var facilitator = await _context.Facilitators.FindAsync(ID);
                _context.Facilitators.Remove(facilitator);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Facilitator>> getAllAsync()
        {
            try
            {

               return  await _context.Facilitators.ToListAsync();
               // return instructors;

            }

            catch 
            {
                return null;
            }
        }

        public Task<List<Facilitator>> getAllByIDAsync(int ID)
        {
            throw new NotImplementedException();
        }

        public async Task<Facilitator> getAsync(int ID)
        {
            try
            {

                return await _context.Facilitators.FindAsync(ID);
                // return instructors;

            }

            catch
            {
                return null;
            }
        }

        public async Task<Facilitator> getByCodeAsync(string code)
        {
            try
            {

                var facilitator = await _context.Facilitators.FirstOrDefaultAsync(x => x.Code == code);
                return facilitator;

            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Facilitator> getByNameAsync(string name)
        {
            try
            {

                var facilitator = await _context.Facilitators.FirstOrDefaultAsync(x => x.Nickname == name);
                return facilitator;

            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> insertAsync(Facilitator data)
        {
            try
            {
                var facilitator = new Facilitator
                {
                    Code = data.Code,
                    DateCreated = DateTime.Now,
                    Nickname = data.Nickname
                };

                await _context.Facilitators.AddAsync(facilitator);
                await _context.SaveChangesAsync();

                return facilitator.ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<bool> insertListAsync(List<Facilitator> data)
        {
            throw new NotImplementedException();
        }

        public async Task updateAsync(Facilitator data)
        {
            try
            {
                var facilitator = await _context.Facilitators.FindAsync(data.ID);
                if (facilitator != null)
                {
                    if (data.Code != null) facilitator.Code = data.Code;
                    if (data.Nickname != null) facilitator.Nickname = data.Nickname;
                    facilitator.DateModified = DateTime.Now;

                    _context.Facilitators.Update(facilitator);
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
