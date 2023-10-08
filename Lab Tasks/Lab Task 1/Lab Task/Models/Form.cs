using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text.RegularExpressions;
using System.Web;


namespace Lab_Task.Models
{
    public class MinimumAgeAttribute : ValidationAttribute
    {
        private readonly int _minimumAge;

        public MinimumAgeAttribute(int minimumAge)
        {
            _minimumAge = minimumAge;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime dateOfBirth)
            {
                var today = DateTime.Today;
                var age = today.Year - dateOfBirth.Year;

                // If the birthdate has not occurred this year, subtract one year from the age
                if (dateOfBirth > today.AddYears(-age))
                {
                    age--;
                }

                if (age < _minimumAge)
                {
                    return new ValidationResult($"You must be at least {_minimumAge} years old.");
                }
            }

            return ValidationResult.Success;
        }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public sealed class CustomPasswordValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false; // Password is required, so a null value is not valid
            }

            string password = value.ToString();

            // Password length validation
            if (password.Length < 8)
            {
                return false; // Password should be at least 8 characters long
            }

            // First 4 characters must be alphabets with at least 1 upper and 2 lower case letters
            if (!Regex.IsMatch(password.Substring(0, 4), @"^(?=.*[a-z]{2})(?=.*[A-Z]).+$"))
            {
                return false; // First 4 characters do not meet requirements
            }

            // Next 4 characters must be a combination of special characters and numbers
            if (!Regex.IsMatch(password.Substring(4, 4), @"^(?=.*\d)(?=.*[.@!#$%^&*]).+$"))
            {
                return false; // Next 4 characters do not meet requirements
            }

            return true; // Password meets all requirements
        }
    }


    public class Form
    {
        [Required(ErrorMessage = "Provide your name")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Length must be between 4 and 50 characters")]
        [RegularExpression(@"^[a-zA-Z .-]*$", ErrorMessage = "Only alphabets, space ( ), dot (.) and dash (-) are allowed")]

        public string Name { get; set; }


        [Required(ErrorMessage = "Provide your user ID")]
        [StringLength(12, MinimumLength = 4, ErrorMessage = "Length must be between 4 and 12 characters")]
        [RegularExpression(@"^[a-zA-Z0-9_-]*$", ErrorMessage = "Only alphabets, numbers, dash (-) and underscore (_) are allowed")]

        public string UserId { get; set; }


        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please enter password")]
        [CustomPasswordValidation(ErrorMessage = "Invalid Password")]
        public string Password { get; set; }


        [Required(ErrorMessage = "Provide your Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [MinimumAge(18, ErrorMessage = "You must be at least 18 years old.")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Provide your Student ID")]
        [RegularExpression(@"^\d{2}-\d{5}-[1-3]$", ErrorMessage = "ID must be in the format xx-xxxxx-x")]
        public string Id { get; set; }

        [Required(ErrorMessage = "Provide your Email")]
        [StringLength(30, ErrorMessage = "Length must be less than 30 characters")]
        [RegularExpression(@"^\d{2}-\d{5}-[1-3]@student\.aiub\.edu$", ErrorMessage = "Email must be in the format xx-xxxxx-x@student.aiub.edu")]
        [SameAs("Id", ErrorMessage = "Email must start with the Student ID")]
        public string Email { get; set; }
    }
    public class SameAsAttribute : ValidationAttribute
    {
        private readonly string comparisonProperty;

        public SameAsAttribute(string comparisonProperty)
        {
            this.comparisonProperty = comparisonProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Value cannot be null");
            }

            var currentValue = value as string;
            var property = validationContext.ObjectType.GetProperty(comparisonProperty);

            if (property == null)
            {
                throw new ArgumentException("Property with this name not found");
            }

            var comparisonValue = property.GetValue(validationContext.ObjectInstance) as string;

            if (comparisonValue == null)
            {
                return new ValidationResult("Comparison value cannot be null");
            }

            if (currentValue.Split('@')[0] != comparisonValue)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}

    
