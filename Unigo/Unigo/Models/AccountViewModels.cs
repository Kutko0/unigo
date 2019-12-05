﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Unigo.Data;

namespace Unigo.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }


    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        public DateTime Eightteen = DateTime.Now.AddYears(-18);

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Agree with Termss")]
        public bool AgreeWithTerms { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Phone number")]
        [RegularExpression(@"^((\(?\+45\)?)?)(\s?\d{2}\s?\d{2}\s?\d{2}\s?\d{2})$",
            ErrorMessage = "Only danish numbers allowed.\n Use +45 35 35 35 35 ||| 35 35 35 35 ||| 35353535 format.")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Date of birth")]
        [DataType(DataType.Date)]
        [GreaterThanDate()]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        public int CampusId { get; set; }

        public List<ListHelper> Campuses { get; set; }


        public Cities City { get; set; }

        public Nationalities Nationality { get; set; }

    }

    public class ListHelper
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class UserProfileViewModel
    {
        public string FirstName;
        public string Lastname;
        public string City;
        public string Nationality;
        public string Campus;
        public string Joined;
        public string UrlPhoto;
        // Add rides

    }


    // Custom attribute
    public class GreaterThanDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime dt = (DateTime)value;

            long Eightteen = DateTime.Now.AddYears(-18).Ticks;

            if (dt.Ticks <= Eightteen)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(ErrorMessage ?? "Must be 18 y.o.");
        }

    }
    
    public class GreaterThanToday : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime dt = (DateTime)value;

            long now = DateTime.Now.AddMinutes(15).Ticks;

            if (dt.Ticks > now)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(ErrorMessage ?? "You have to create ride min. 15 before it starts.");
        }

    }
}
