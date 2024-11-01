using School.DataAccess;
using School.Model;

namespace School.BLL
{
    public class LessonBLL
    {
        LessonDAL dataAccess;

        public LessonBLL()
        {
            dataAccess = new LessonDAL();
        }

        public OperationResult<bool> Insert(LessonDto lessonDto)
        {
            OperationResult<bool> result = new OperationResult<bool>();

            if (!lessonDto.IsValid)
            {
                result.Message = lessonDto.ErrorMessage;
                return result;
            }
            try
            {
                dataAccess.Insert(lessonDto);
                result.Success = true;
                result.Message = "عملیات ثبت موفقیت آمیز بود";
                return result;
            }
            catch
            {
                result.Message = "عملیات با خطا مواجه شد";
            }
        }
    }
}
