using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace Unigo.Models
{
    public class IndexViewModel
    {
        public bool HasPassword { get; set; }
        public IList<UserLoginInfo> Logins { get; set; }
        public string PhoneNumber { get; set; }
        public bool BrowserRemembered { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
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

    public class ChangeFirstLastNameViewModel
    {
        [StringLength(100, ErrorMessage = "First name length between 2 and 100."), MinLength(2)]
        [Display(Name = "New first name")]
        [Required]
        public string NFirst { get; set; }

        [StringLength(100, ErrorMessage = "Last name length between 2 and 100."), MinLength(2)]
        [Display(Name = "New last name")]
        [Required]
        public string NLast { get; set; }
    }

    public class AddCarViewModel {

        [Display(Name = "License plate")]
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
        [Required]
        public int NumberOfSeats { get; set; }

    }

    
}