using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iTechArtSurvay.Data.Entities {
	public class User {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		//[DataType(DataType.Text, ErrorMessage = "Wrong data type")]
		//[MinLength(3, ErrorMessage = "Name should be at least 3 characters")]
		public string Name { get; set; }

		[Required]
		//[DataType(DataType.EmailAddress, ErrorMessage = "Wrong data type")]
		//[EmailAddress(ErrorMessage = "Invalid email")]
		public string Email { get; set; }

		[Required]
		//[DataType(DataType.Password, ErrorMessage = "Wrong data type")]
		//[MinLength(8, ErrorMessage = "Password should be at least 8 characters")]
		public string Password { get; set; }

		//[Required]
		//[DataType(DataType.Password, ErrorMessage = "Wrong data type")]
		//[MinLength(8, ErrorMessage = "Password should be at least 8 characters")]
		//[Compare("Password", ErrorMessage = "Repeated password should be the same as password")]
		public string RepeatPassword { get; set; }
	}
}