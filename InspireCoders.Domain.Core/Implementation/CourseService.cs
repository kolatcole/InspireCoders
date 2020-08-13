using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InspireCoders.Domain
{
    public class CourseService : ICourseService
    {

        private readonly IRepo<Course> _cRepo;
        private readonly IRepo<Facilitator> _fRepo;
        private readonly IRepo<CourseFacilitator> _cfRepo;

        public CourseService(IRepo<Course> cRepo, IRepo<Facilitator> fRepo, IRepo<CourseFacilitator> cfRepo)
        {
            _fRepo = fRepo;
            _cRepo = cRepo;
            _cfRepo = cfRepo;
        }


        public async Task<SaveResponse> SaveCourseWithFacilitator(Course data)
        {
            var CID = await _cRepo.insertAsync(data);

            var facilitators = new List<CourseFacilitator>();
            foreach (var fac in data.Facilitators)
            {
                var facilitator = new CourseFacilitator
                {
                    CourseID = CID,
                    FacilitatorID = fac.ID
                };

                facilitators.Add(facilitator);

            }

            // assign all selected facilitators to course

            await _cfRepo.insertListAsync(facilitators);

            return new SaveResponse { ID = CID, status = true, Result = "Course was created" };
        }


    }
}
