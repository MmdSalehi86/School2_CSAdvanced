using School.DataAccess;
using School.Model;
using System;
using System.Data;

namespace School.BLL
{
    public sealed class StudentBLL
    {
        StudentDAL dataAccess;

        public StudentBLL()
        {
            dataAccess = new StudentDAL();
        }

        public OperationResult Insert(StudentDto studentDto)
        {
            OperationResult result = new OperationResult();

            if (!studentDto.IsValid)
            {
                result.Message = studentDto.ErrorMessage;
                return result;
            }
            bool existsMobile;
            try
            {
                existsMobile = dataAccess.CheckMobileExists(studentDto.Mobile);
            }
            catch (Exception ex)
            {
                ex.AddLog();
                result.Message = "عملیات با خطا مواجه شد";
                return result;
            }

            if (existsMobile)
            {
                result.Message = "شماره موبایل تکراری است";
                return result;
            }
            try
            { 
                if (dataAccess.Insert(studentDto) >= 1)
                {
                    result.Success = true;
                    result.Message = "عملیات ثبت موفقیت آمیز بود";
                    return result;
                }
                else
                {
                    result.Message = "تغییرات اعمال نشد";
                    return result;
                }
            }
            catch (Exception ex)
            {
                ex.AddLog();
                result.Message = "برنامه با خطا مواجه شد";
                return result;
            }
        }

        public OperationResult<DataTable> Select()
        {
            OperationResult<DataTable> result = new OperationResult<DataTable>();
            try
            {
                result.Data = dataAccess.Select();
                result.Success = true;
                return result;
            }
            catch
            {
                result.Message = "خطا در خواندن اطلاعات";
                return result;
            }
        }
    }
}
