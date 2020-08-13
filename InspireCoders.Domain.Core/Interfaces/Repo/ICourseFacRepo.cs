using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InspireCoders.Domain
{
    public interface ICourseFacRepo
    {
        Task<int> SaveCourseFacilitator(CourseFacilitator data);

    }
}
