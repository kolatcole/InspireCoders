using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InspireCoders.Domain
{
    public interface ICourseService
    {
        Task<SaveResponse> SaveCourseWithFacilitator(Course data);

        Task<Course> getCourseByCode(string code);

        Task<List<Course>> getAllCourses();

        Task<Course> getCourseByID(int ID);

        Task<Course> getCourseByName(string name);

        Task UpdateCourse(Course data);

        Task DeleteCourse(int ID);

    }
}
