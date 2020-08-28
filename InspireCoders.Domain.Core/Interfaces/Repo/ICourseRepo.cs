using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InspireCoders.Domain
{
    public interface ICourseRepo
    {
        Task<Course> getCourseByIDAsync(int ID);

        Task<Course> getCourseByCodeAsync(string code);
        
        Task<List<Course>> getAllAsync();
        
        Task<int> insertAsync(Course data);
        
        Task updateAsync(Course data);

        Task deleteAsync(int ID);

        Task<Course> getByNameAsync(string name);
    }
}
