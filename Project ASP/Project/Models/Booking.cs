using System;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
	public class Booking
	{
		[Required]
        [Key]
        public int Bid { get; set; }

		[Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name should be at least 3 characters")]
		public string Name { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Email must follow specified format")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required]
        public string DSType { get; set; }

        [Required]
        public string TherapyType { get; set; }

        [Required]
        public string Doctor { get; set; }

        [StringLength(500, MinimumLength = 0, ErrorMessage = "Max Description length should be 500 char")]
        public string Desc { get; set; }

    }
}

