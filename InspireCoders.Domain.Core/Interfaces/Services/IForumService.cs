using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InspireCoders.Domain
{
    public interface IForumService
    {
        Task<SaveResponse> CreateForum(Forum data);

        Task<SaveResponse> AddStudent(int ForumID, string studentIDs);

        Task<List<Forum>> GetForums();

        Task<Forum> getForumByID(int ID);

        Task<List<Forum>> getForumsByStudentID(int studentID);
    }
}
