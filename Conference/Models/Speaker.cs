using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Conference.Models
{
	[DataContract()]
	public class Speaker
	{
		[DataMember()]
		public Int32 SpeakerID { get; set; }

		[DisplayName("First Name")]
		[Required()]
		[StringLength(maximumLength: 20, MinimumLength = 1)]
		[DataMember()]
		public String FirstName { get; set; }

		[DisplayName("Last Name")]
		[Required()]
		[StringLength(maximumLength: 20, MinimumLength = 1)]
		[DataMember()]
		public String LastName { get; set; }

		[Required()]
		[DataType(DataType.EmailAddress)] // generates <input type="email">
		[DataMember()]
		public String Email { get; set; }

		public virtual List<Session> Sessions { get; set; }

		public override string ToString()
		{
			return FirstName + " " + LastName;
		}
	}
}