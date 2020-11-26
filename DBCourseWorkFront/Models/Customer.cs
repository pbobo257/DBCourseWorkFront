using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DBCourseWorkFront.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [CustomValidation(typeof(Customer), nameof(ValidatePhone))]
        public string PhoneNumber { get; set; }
        public string BonusCardNumber { get; set; }
        [Required]
        public int Bonuses { get; set; }

        public static ValidationResult ValidatePhone(string phoneNumber, ValidationContext vc)
        {
            Regex regex = new Regex(@"^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$");
            return regex.IsMatch(phoneNumber) ? ValidationResult.Success : new ValidationResult("Wrong phone number", new[] { vc.MemberName });
        }
    }
}
