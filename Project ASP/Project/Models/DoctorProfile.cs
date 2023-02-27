using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class DoctorProfile
    {
        [Required]
        [Key]
        public int DoctorId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name should be at least 3 characters")]
        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "Use letters only please")]
        public string Name { get; set; }


        [Required]
        [Range(18, 100)]
        public int Age { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "Use letters only please")]
        public string Specialization { get; set; }


        [DataType(DataType.ImageUrl)]
        [Display(Name = "Image Link")]
        public string DoctorImage { get; set; }


        [Required]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Not a valid email")]
        public string Email { get; set; }

    }
}
