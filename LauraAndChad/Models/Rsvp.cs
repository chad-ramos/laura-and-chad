using System.ComponentModel.DataAnnotations;

namespace LauraAndChad.Models
{
    public class Rsvp
    {
        [Required]
        [Display(Name = "* First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "* Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Guest First Name")]
        public string GuestFirstName { get; set; }

        [Display(Name = "Guest Last Name")]
        public string GuestLastName { get; set; }

        [Required]
        [Display(Name = "* Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Comments")]
        public string Comments { get; set; }
    }
}
