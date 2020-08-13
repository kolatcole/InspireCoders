
using InspireCoders.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InspireCoders.Infrastructure
{
    public class ApplicantRepo : IRepo<Applicant>
    {

        private readonly TContext _context;

        public ApplicantRepo(TContext context)
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

            
                var applicant = await _context.Applicants.FindAsync(ID);
                _context.Applicants.Remove(applicant);
                await _context.SaveChangesAsync();
             }
            catch(Exception ex)
            {
                throw ex;
            }
}

        public async Task<List<Applicant>> getAllAsync()
        {
            try
            {

                var Applicants = await _context.Applicants.ToListAsync();
                return Applicants;

            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<List<Applicant>> getAllByIDAsync(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<Applicant> getAsync(int ID)
        {
            throw new NotImplementedException();
        }

        public async Task<int> insertAsync(Applicant data)
        {
            try
            {
                var Applicant = new Applicant
                {
                    Email = data.Email,
                    FirstName=data.FirstName,
                    LastName=data.LastName,
                    DateofBirth=data.DateofBirth,
                    Gender=data.Gender
                };

                await _context.Applicants.AddAsync(Applicant);
                await _context.SaveChangesAsync();

                return Applicant.ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<bool> insertListAsync(List<Applicant> data)
        {
            throw new NotImplementedException();
        }

        public Task updateAsync(Applicant data)
        {
            throw new NotImplementedException();
        }
    }
}
