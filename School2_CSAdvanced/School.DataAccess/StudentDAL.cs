using System.Data.SqlClient;
using System.Data;
using School.Model;

namespace School.DataAccess
{
    public sealed class StudentDAL : DbSqlCommands
    {
        public DataTable Select()
        {
            return SelectDataTable("SelectStudents");
        }

        public bool CheckMobileExists(string mobile)
        {
            return SelectFunc<bool>("dbo.CheckExistsMobileNumber", new SqlParameter[]
            {
                new SqlParameter("@MobileNumber", mobile)
            });
        }


        public int Insert(StudentDto studentDto)
        {
            return ExcuteProc("InsertStudent", new SqlParameter[]
            {
                    new SqlParameter("@FirstName",studentDto.FirstName),
                    new SqlParameter("@LastName",studentDto.LastName),
                    new SqlParameter("@Mobile",studentDto.Mobile),
            });
        }

        public int Update()
        {
            return ExcuteProc("UpdateStudent");
        }

        public int Delete()
        {
            return ExcuteProc("DeleteStudent");
        }
    }
}
