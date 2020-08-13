using InspireCoders.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InspireCoders.Infrastructure
{
    public class CourseFacRepo : IRepo<CourseFacilitator>
    {
        private readonly TContext _context;
        public CourseFacRepo(TContext context)
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

        public Task<List<CourseFacilitator>> getAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<CourseFacilitator>> getAllByIDAsync(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<CourseFacilitator> getAsync(int ID)
        {
            throw new NotImplementedException();
        }

        public async Task<int> insertAsync(CourseFacilitator data)
        {
            try
            {
                var courseFac = new CourseFacilitator
                {
                    CourseID = data.CourseID,
                    FacilitatorID = data.FacilitatorID
                };

                await _context.CourseFacilitators.AddAsync(courseFac);
                await _context.SaveChangesAsync();
                return courseFac.ID;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> insertListAsync(List<CourseFacilitator> data)
        {
            try
            {

               _context.CourseFacilitators.AddRange(data);
                await _context.SaveChangesAsync();
                return true;

            }
            catch 
            {
                return false;
            }
        }


        public Task updateAsync(CourseFacilitator data)
        {
            throw new NotImplementedException();
        }
    }
}
