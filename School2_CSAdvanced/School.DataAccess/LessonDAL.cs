using School.Model;
using System.Data.SqlClient;

namespace School.DataAccess
{
    public class LessonDAL : DbSqlCommands
    {
        public int Insert(LessonDto lessonDto)
        {
            return ExcuteProc("InsertLesson",
                new SqlParameter("Title", lessonDto.Title));
        }
    }
}
