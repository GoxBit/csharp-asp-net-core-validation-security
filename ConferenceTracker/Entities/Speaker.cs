using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConferenceTracker.Entities
{
    public class Speaker : IValidatableObject
    {
        [Required]
        public int Id { get; set; }

        [StringLength(100, MinimumLength = 2)]
        [DataType(DataType.Text)]
        [Display(Name = "First name")]
        [Required]
        public string FirstName { get; set; }

        [StringLength(100, MinimumLength = 2)]
        [DataType(DataType.Text)]
        [Display(Name = "Last name")]
        [Required]
        public string LastName { get; set; }

        [StringLength(500, MinimumLength = 10)]
        [DataType(DataType.MultilineText)]
        [Required]
        public string Description { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        public bool IsStaff { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var result = new List<ValidationResult>();
            if(EmailAddress != null && EmailAddress.EndsWith("TechnologyLiveConference.com", StringComparison.InvariantCultureIgnoreCase))
            {
                ValidationResult rejectEmailAddress = new ValidationResult("Technology Live Conference staff should not use their conference email addresses.");
                result.Add(rejectEmailAddress);
            }
            return result;
        }
    }
}
