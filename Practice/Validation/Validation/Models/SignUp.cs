using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text.RegularExpressions;
using System.Web;
using Validation.Models;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
public sealed class CustomEmailValidationAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        if (value == null)
        {
            return false; // Email is required, so a null value is not valid
        }

        string email = value.ToString();

        // Define a regular expression pattern for a valid email address
        string pattern = @"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$";

        return Regex.IsMatch(email, pattern);
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

        // Password complexity validation
        // Require a mix of uppercase and lowercase letters.
        // Require at least one numeric digit.
        // Require at least one special character(e.g., !, @, #, $, etc.).
        if (!Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[.@!#$%^&*])[A-Za-z\d.@!#$%^&*]+$"))
        {
            return false; // Password does not meet complexity requirements
        }


        return true; // Password meets all requirements
    }
 
}

namespace Validation.Models
{
    public class SignUp
    {
        [Required(ErrorMessage = "Provide your name")]
        [StringLength(5, ErrorMessage = "Length < 100")]

        public string Name { get; set; }


        [Required(ErrorMessage = "Email is required")]
      //  [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [CustomEmailValidation(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }



        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please enter password")]
        [CustomPasswordValidation(ErrorMessage = "Invalid Password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please enter password again")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password not matching")]
        public string ConfirmPassword { get; set; }


        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Please enter your phone number")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Invalid phone number. It should be a 11-digit number.")]
        public string Phone { get; set; }


        [Required]
        public string Gender { get; set; }
        [Required]
        public string Profession { get; set; }
        [Required]
        public List<string> Skills { get; set; }
    }
}
//                      123Akash@321