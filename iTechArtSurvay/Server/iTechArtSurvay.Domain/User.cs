using System.ComponentModel.DataAnnotations;

namespace iTechArtSurvay.Domain {
	public class User {
		public int Id { get; set; }

		[Required]
		[MinLength(3, ErrorMessage = "Name should be at least 3 characters")]
		public string Name { get; set; }

		[Required]
		[EmailAddress(ErrorMessage = "Invalid email")]
		public string Email { get; set; }

		[Required]
		[MinLength(8, ErrorMessage = "Password should be at least 8 characters")]
		public string Password { get; set; }
	}
}