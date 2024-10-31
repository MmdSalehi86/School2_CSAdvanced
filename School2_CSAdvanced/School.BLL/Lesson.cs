using School.DataAccess;
using School.Model;

namespace School.BLL
{
    public class Lesson
    {

        public OperationResult Insert(LessonDto lessonDto)
        {
            if (!lessonDto.IsValid)
            {
                return new OperationResult
                {
                    Message = lessonDto.ErrorMessage,
                    Success = false
                };
            }

            return new OperationResult
            {
                Success = true,
                Message = "عملیات ثبت موفقیت آمیز بود"
            };
        }
    }
}
