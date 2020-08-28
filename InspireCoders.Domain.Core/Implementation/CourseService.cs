using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InspireCoders.Domain
{
    public class CourseService : ICourseService
    {

        private readonly ICourseRepo _cRepo;
        private readonly IRepo<Facilitator> _fRepo;
       // private readonly IRepo<StudentForum> _cfRepo;

        public CourseService(ICourseRepo cRepo, IRepo<Facilitator> fRepo /*IRepo<StudentForum> cfRepo*/)
        {
            _fRepo = fRepo;
            _cRepo = cRepo;
           // _cfRepo = cfRepo;
        }


        public async Task<SaveResponse> SaveCourseWithFacilitator(Course data)
        {
            var CID = await _cRepo.insertAsync(data);

            return new SaveResponse { ID = CID, status = true, Result = "Course was created" };
        }

        public async Task<List<Course>> getAllCourses()
        {
            var courses = await _cRepo.getAllAsync();

            if (courses != null)
            {
                foreach(var course in courses)
                {
                    if (!String.IsNullOrEmpty(course.FacilitatorIDs))
                    {

                        var facilitators = new List<Facilitator>();
                        foreach (var facID in course.FacilitatorIDs.Split(','))
                        {
                            int ID = int.Parse(facID);
                            var facilitator = await _fRepo.getAsync(ID);
                            facilitators.Add(facilitator);
                        }

                        course.Facilitators = facilitators;
                    }

                }
            }

            return courses;

        }

        public async Task<Course> getCourseByCode(string code)
        {
            var course= await _cRepo.getCourseByCodeAsync(code);

            if(!String.IsNullOrEmpty(course.FacilitatorIDs))
            {

                var facilitators = new List<Facilitator>();
                foreach (var facID in course.FacilitatorIDs.Split(','))
                {
                    int ID = int.Parse(facID);
                    var facilitator = await _fRepo.getAsync(ID);
                    facilitators.Add(facilitator);
                }

                course.Facilitators = facilitators;
            }

            return course;

        }

        public async Task<Course> getCourseByID(int ID)
        {
            var course = await _cRepo.getCourseByIDAsync(ID);

            if (!String.IsNullOrEmpty(course.FacilitatorIDs))
            {

                var facilitators = new List<Facilitator>();
                foreach (var facID in course.FacilitatorIDs.Split(','))
                {
                    int SingleID = int.Parse(facID);
                    var facilitator = await _fRepo.getAsync(SingleID);
                    facilitators.Add(facilitator);
                }

                course.Facilitators = facilitators;
            }

            return course;
        }

        public async Task<Course> getCourseByName(string name)
        {
            var course = await _cRepo.getByNameAsync(name);

            if (!String.IsNullOrEmpty(course.FacilitatorIDs))
            {

                var facilitators = new List<Facilitator>();
                foreach (var facID in course.FacilitatorIDs.Split(','))
                {
                    int ID = int.Parse(facID);
                    var facilitator = await _fRepo.getAsync(ID);
                    facilitators.Add(facilitator);
                }

                course.Facilitators = facilitators;
            }

            return course;

        }

        public async Task UpdateCourse(Course data)
        {
            await _cRepo.updateAsync(data);
        }

        public async Task DeleteCourse(int ID)
        {
            await _cRepo.deleteAsync(ID);
        }

    }
}
