using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EvolentApp.ViewModels
{
    /// <summary>
    /// Business layer model
    /// </summary>
    public class ContactViewModel
    {
        [Display(Name = "Contact ID")]
        public int ContactId { get; set; }

        [Display(Name = "First Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide first name")]
        [RegularExpression(@"[\p{L} ]+$", ErrorMessage = "Invalid first name. Only alphabets and spaces are allowed.")]
        [StringLength(100, ErrorMessage = "First name must be 100 characters or less.")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide last name")]
        [RegularExpression(@"[\p{L} ]+$", ErrorMessage = "Invalid last name. Only alphabets and spaces are allowed.")]
        [StringLength(100, ErrorMessage = "Last name must be 100 characters or less.")]
        public string LastName { get; set; }

        [Display(Name = "E-Mail Address")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide email")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Please enter a valid email ID")]
        public string Email { get; set; }

        [Display(Name = "Phone Number")]
        public long? PhoneNumber { get; set; }

        [Display(Name = "Is Active?")]
        public bool ContactStatus { get; set; }
    }
}