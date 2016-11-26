using System.ComponentModel.DataAnnotations;

namespace LauraAndChad.Models
{
    public class Rsvp
    {
        [Key] 
        public int RsvpId { get; set; }

        [Required(ErrorMessage = "First Name Required")]
        [Display(Name = "* First Name")]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name Required")]
        [Display(Name = "* Last Name")]
        [StringLength(100)]
        public string LastName { get; set; }

        [Display(Name = "Guest First Name")]
        [StringLength(100)]
        public string GuestFirstName { get; set; }

        [Display(Name = "Guest Last Name")]
        [StringLength(100)]
        public string GuestLastName { get; set; }

        [Required(ErrorMessage = "Email Required")]
        [Display(Name = "* Email")]
        [EmailAddress]
        [StringLength(254)]
        public string Email { get; set; }

        [Display(Name = "Comments")]
        public string Comments { get; set; }
    }
}
