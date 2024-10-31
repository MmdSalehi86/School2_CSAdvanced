using System.ComponentModel.DataAnnotations;

namespace School.Model
{
    internal class MobileValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string mobile = value.ToString();

            if (string.IsNullOrEmpty(mobile))
            {
                ErrorMessage = "شماره موبایل اجباری است";
                return false;
            }
            if (mobile.Length != 11 || !mobile.StartsWith("09"))
            {
                ErrorMessage = "شماره موبایل نامعتبر است";
                return false;
            }
            return true;
        }
    }
}
