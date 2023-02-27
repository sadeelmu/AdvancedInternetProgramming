using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class DoctorProfile
    {
        [Key]
        [Required]
        public int DoctorId { get; set; }

        [Required]
        public string Name { get; set; }


        [Required]
        public int Age { get; set; }

        [Required]
        public string Specialization { get; set; }


        public string DoctorImage { get; set; }


        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }


    }
}
