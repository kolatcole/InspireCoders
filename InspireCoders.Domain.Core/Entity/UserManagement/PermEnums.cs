using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace InspireCoders.Domain
{
    public enum PermEnums
    {
        [Description("Create User")]
        CreateUser = 1,
        [Description("Read User")]
        ReadUser = 2,
        [Description("Update User")]
        UpdateUser = 3,
        [Description("Delete User")]
        DeleteUser = 4,

        

        #region Role

        [Description("Create Role")]
        CreateRole = 5,
        [Description("Read Role")]
        ReadRole = 6,
        [Description("Update Role")]
        UpdateRole = 7,
        [Description("Delete Role")]
        DeleteRole = 8,


        #region Course

        [Description("Create Course")]
        CreateCourse = 9,
        [Description("Read Course")]
        ReadCourse = 10,
        [Description("Update Course")]
        UpdateCourse = 11,
        [Description("Delete Course")]
        DeleteCourse = 12,


        #endregion

        #region Facilitator

        [Description("Create Facilitator")]
        CreateFacilitator = 13,
        [Description("Read Facilitator")]
        ReadFacilitator = 14,
        [Description("Update Facilitator")]
        UpdateFacilitator = 15,
        [Description("Delete Facilitator")]
        DeleteFacilitator = 16,


        #endregion


        #region Forum

        [Description("Create Forum")]
        CreateForum = 17,
        [Description("Read Forum")]
        ReadForum = 18,
        [Description("Update Forum")]
        UpdateForum = 19,
        [Description("Delete Forum")]
        DeleteForum = 20,


        #endregion

        #region Student

        [Description("Create Student")]
        CreateStudent = 21,
        [Description("Read Student")]
        ReadStudent = 22,
        [Description("Update Student")]
        UpdateStudent = 23,
        [Description("Delete Student")]
        DeleteStudent = 24,


        #endregion

        #region Applicant

        [Description("Read Applicant")]
        ReadApplicant = 25,

        #endregion










        //#endregion

        //#region Permission

        //[Description("Read Permission")]
        //ReadPermission = 10,

        //#endregion

        //#region Message

        //[Description("Send Message")]
        //SendMessage = 11,
        //[Description("Read Message")]
        //ReadMessage = 12,

        #endregion
    }
}
