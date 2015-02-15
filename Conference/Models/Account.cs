using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Conference.Models
{
	public class LoginAccount
	{
		[Required()]
		[DisplayName("Username")]
		public String UserName { get; set; }

		[Required()]
		[DataType(DataType.Password)]
		public String Password { get; set; }

		[DisplayName("Remember me")]
		public Boolean Persist { get; set; }
	}

	public class CreateAccount
	{
		[Required()]
		[DisplayName("Username")]
		public String UserName { get; set; }

		[Required()]
		[DataType(DataType.Password)]
		public String Password { get; set; }

		[Required()]
		[DataType(DataType.Password)]
		[Compare("Password", ErrorMessage = "Passwords do not match")]
		public String ConfirmPassword { get; set; }

		[Required()]
		[DataType(DataType.EmailAddress)]
		public String Email { get; set; }
	}
}