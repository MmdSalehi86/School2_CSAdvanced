using System;
using System.Data.SqlClient;
using System.Data;

namespace School.DataAccess
{
    public sealed class TeacherDAL : DbSqlCommands
    {
        public DataTable Select()
        {
            try
            {
                return SelectDataTable("SelectTeachers");
            }
            catch (Exception ex)
            {
                ex.AddLog();
                throw;
            }
        }

        public int Insert(string firstName, string lastName, string mobile)
        {
            return ExcuteProc("InsertTeacher", new SqlParameter[]
            {
                new SqlParameter("@FirstName",firstName),
                new SqlParameter("@LastName",lastName),
                new SqlParameter("@Mobile",mobile),
            });
        }

        public int Update()
        {
            return ExcuteProc("UpdateTeacher");
        }

        public int Delete()
        {
            return ExcuteProc("DeleteTeacher");
        }

    }
}
