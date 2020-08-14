using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace InspireCoders.Domain
{
    public class ForumService : IForumService
    {
        private readonly IRepo<Forum> _fRepo;
        private readonly IRepo<Student> _sRepo;
        private readonly IRepo<StudentForum> _sfRepo;

        public ForumService(IRepo<Forum> fRepo, IRepo<Student> sRepo, IRepo<StudentForum> sfRepo)
        {
            _fRepo = fRepo;
            _sRepo = sRepo;
            _sfRepo = sfRepo;

        }


        public async Task<SaveResponse> CreateForum(Forum data)
        {
            var FID = await _fRepo.insertAsync(data);

            return new SaveResponse { ID = FID, Result = "Forum was created", status = true };
        }
         
        public async Task<SaveResponse> AddStudent(int ForumID,string studentIDs)
        {
            var forum = await _fRepo.getAsync(ForumID);

            if(forum!=null)
            {

                //string studentID = "";
                //for (int i=0;i<studentIDs.Count;i++)
                //{


                //    // Do not add comma if it''s the first id
                //    if (i==0)
                //        studentID += studentIDs[i].ToString();

                //    studentID = ",";
                //    studentID += studentIDs[i].ToString();

                //}

                // save the stringified studentIDs to the forum

                // save the rows for the connecing tables between forum and students

                var studForum = new List<StudentForum>();

                foreach(var ID in studentIDs.Split(",") )
                {
                    int SID = int.Parse(ID);

                    var sForum = new StudentForum
                    {
                        ForumID = ForumID,
                        StudentID = SID
                    };

                    studForum.Add(sForum);

                }

                // Save all studentForum Objects all at once

                await _sfRepo.insertListAsync(studForum);

                forum.StudentIDs = studentIDs;

            }

            // update forum with the new students

            await _fRepo.updateAsync(forum);

            return new SaveResponse { ID = ForumID, status = true, Result = "Student was added to this forum" };
        }

        public async Task<List<Forum>> GetForums()
        {
            var forums =await _fRepo.getAllAsync();

            if (forums != null)
            {
                foreach (var forum in forums)
                {
                    if (!String.IsNullOrEmpty(forum.StudentIDs))
                    {

                        var students = new List<Student>();
                        foreach (var studID in forum.StudentIDs.Split(','))
                        {
                            
                            int ID = int.Parse(studID);
                            var student = await _sRepo.getAsync(ID);
                            students.Add(student);
                        }

                        forum.Students = students;
                    }

                }
            }

            return forums;

        }

        public async Task<Forum> getForumByID(int ID)
        {
            var forum = await _fRepo.getAsync(ID);

            if (!String.IsNullOrEmpty(forum.StudentIDs))
            {

                var students = new List<Student>();
                foreach (var studID in forum.StudentIDs.Split(','))
                {
                    int SingleID = int.Parse(studID);
                    var student = await _sRepo.getAsync(SingleID);
                    students.Add(student);
                }

                forum.Students = students;
            }

            return forum;

        }

        public async Task<List<Forum>> getForumsByStudentID(int studentID)
        {
            try
            {
                // get all connecting rows of this studentID and forum
                var studentForum = await _sfRepo.getAllByIDAsync(studentID);

                var forums = new List<Forum>();

                // loop through all returned rows and use the forumID to get forums
                foreach (var sforum in studentForum)
                {
                    var forum = await _fRepo.getAsync(sforum.ForumID);
                    forums.Add(forum);

                }

                return forums;
            }
            catch
            {
                return null;
            }

        }
    }
}
