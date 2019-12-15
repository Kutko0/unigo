using System;
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
        [Display(Name = "Your campus")]
        public int CampusId { get; set; }

        public List<ListHelper> Campuses { get; set; }

        [Display(Name = "City")]
        public Cities City { get; set; }
        [Display(Name = "Nationality")]
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
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string City { get; set; }
        public string Nationality { get; set; }
        public string Campus { get; set; }
        public string Joined { get; set; }
        public string UrlPhoto { get; set; }
        // Add rides

        public List<InfoPastRide> pastRides { get; set; }
        public List<InfoActiveRide> activeRides { get; set; }
        public List<InfoActiveJoinedRide> joinedActiveRides { get; set; }
    }

    public class InfoPastRide
    {
        public string riderName { get; set; }
        public string Destination { get; set; }
        public DateTime Time { get; set; }
        public int Id { get; internal set; }
    }

    public class InfoActiveRide
    {
        public int RideId { get; set; }
        public string Destination { get; set; }
        public DateTime Time { get; set; }

        public int NumberOfPeople { get; set; }
    } 
    
    public class InfoActiveJoinedRide
    {
        public int PersonRideId { get; set; }
        public string Destination { get; set; }
        public DateTime Time { get; set; }
        public string CarPlate{ get; set; }
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
    
   
}
