using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InspireCoders.Domain
{
    public interface ICourseService
    {
        Task<SaveResponse> SaveCourseWithFacilitator(Course data); 

        Task<>
    }
}
