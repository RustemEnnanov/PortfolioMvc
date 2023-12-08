
using System.ComponentModel.DataAnnotations;


namespace RazorPagesMovie.Models
{
    public class BirthDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if(value is DateTime birthDate)
            {
                if(birthDate > DateTime.Now)
                {
                    return true;
                }
                else {
                    ErrorMessage = "Дата рождения некоректна";
                }
            }
            return false;
        }
    }
}