using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Conference.Models
{
	public class Session
	{
		public Int32 SessionID { get; set; }

		[Required()]
		[StringLength(maximumLength: 20, MinimumLength = 1)]
		public String Title { get; set; }

		[Required()]
		[StringLength(maximumLength: 2000, MinimumLength = 1)]
		[DataType(DataType.MultilineText)] // generates <textarea>
		[AllowHtml()]
		public String Abstract { get; set; }

		// Virtual is required to enable lazy loading
		public virtual Speaker Speaker { get; set; }

		// technically this is not required, but it does simplify things
		public Int32 SpeakerID { get; set; }

		public virtual List<Comment> Comments { get; set; }
	}
}