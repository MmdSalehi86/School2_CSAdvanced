using School.DataAccess;
using School.Model;
using System;
using System.Security.Cryptography;

namespace School.BLL
{
    public class StudentBLL
    {
        StudentDAL student;
        public StudentBLL()
        {
            student = new StudentDAL();
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
                existsMobile = student.CheckMobileExists(studentDto.Mobile);
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
                if (student.Insert(studentDto) >= 1)
                {
                    result.Success = true;
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
    }
}
