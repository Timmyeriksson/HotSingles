using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dating.Models
{
    public class EditEmail
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

    }

    public class EditPassword
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }

    public class EditAbout
    {
        [StringLength(750, ErrorMessage = "rip 750 characters")]
        [Display(Name = "Tell us something about you")]
        public string About { get; set; }
    }

    public class EditAge
    {
        [Range(18, 99, ErrorMessage = "Age must be between 18 and 99")]
        [Display(Name = "Age")]
        public int Age { get; set; }
    }

    public class EditProfilePic
    {
        [Required]
        [Display(Name = "Profile Picture")]
        public string ProfileURL { get; set; }
    }

    public class EditSearchable
    {
        [Display(Name = "Searchable Profile")]
        public bool Searchable { get; set; }
    }

    //Eftersom vi har en knapp för varje edit så har vi en editwrapper där vi bryter ut varje edit
    public class editwrapper
    {
        public EditEmail mailen { get; set; }
        public EditPassword Password { get; set; }
        public EditAbout About { get; set; }
        public EditAge Age { get; set; }
        public EditProfilePic ProfileURL { get; set; }
        public EditSearchable Searchable { get; set; }
    }
}