using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Unigo.Data;

namespace Unigo.Models
{
    public class IndexViewModel
    {
        public AddCarViewModel AddCar { get; set; }
        public UpdatePersonViewModel PersonData { get; set; }
        public ChangePasswordViewModel ChangePass { get; set; }
        
    }

    public class ManageLoginsViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }
        public IList<AuthenticationDescription> OtherLogins { get; set; }
    }

    public class FactorViewModel
    {
        public string Purpose { get; set; }
    }

    public class SetPasswordViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class AddPhoneNumberViewModel
    { 
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string Number { get; set; }
    }

    public class AddCarViewModel {

        [Display(Name = "License plate")]
        /* [RegularExpression(@"^[A-Z]{1,3}-[A-Z]{1,2}-[0-9]{1,4}$",
                ErrorMessage = "Enter danish license plate.")] 
             DOES NOT WORK, can't find regex for danish Plates   
             */
        [Required]
        public string LicensePlate { get; set; }

        [Display(Name = "Color")]
        [Required]
        public string Color { get; set; }

        [Display(Name = "Type")]
        [Required]
        public string Type { get; set; }
        
        [Display(Name = "Brand")]
        [Required]
        public string Brand { get; set; }
        
        [Display(Name = "Description(Optional)")]
        public string Description { get; set; }

        [Display(Name = "Number of seats")]
        [Range(0, 6, ErrorMessage = "Maximum number of seats is 6.")]
        [Required]
        public int NumberOfSeats { get; set; }

        public List<Car> carList { get; set; }

    }

    public class UpdatePersonViewModel
    {
        public DateTime Eightteen = DateTime.Now.AddYears(-18);

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Phone number")]
        [RegularExpression(@"^((\(?\+45\)?)?)(\s?\d{2}\s?\d{2}\s?\d{2}\s?\d{2})$",
            ErrorMessage = "Only danish numbers allowed.\n Use one of +45 35 35 35 35 ||| 35 35 35 35 ||| 35353535 formats.")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Date of birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [GreaterThanDate()]
        public DateTime DateOfBirth { get; set; }
    }

    public class CreateRideViewModel
    {
        [Required]
        public int DestinationId { get; set; }

        [Required]
        public string StartPoint { get; set; }

        [Required]
        public DateTime LeavingTime { get; set; }

        [Required]
        public int NumberOfSeats { get; set; }
        [Required]
        public string StartLat { get; set; }
        [Required]
        public string StartLong { get; set; }

        public List<ListHelper> Destinations { get; set; }

        public Car ActiveCar { get; set; }



        // Think about stoppoints long and lats
        // New viewmodel ? or just bunch of field in this viewmodel
        // Dropdown with cars ? or only active car

    }

}