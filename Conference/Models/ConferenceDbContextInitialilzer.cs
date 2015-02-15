using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace Conference.Models
{
	public class ConferenceDbContextInitialilzer : DropCreateDatabaseAlways<ConferenceDbContext>
	{
		protected override void Seed(ConferenceDbContext context)
		{
			Speaker christopher = context.Speakers.Add(new Speaker()
				{ FirstName = "Christopher", LastName = "Harrison", Email = "charrison@geektrainer.com" });
			context.Sessions.Add(new Session()
				{ Title = "MVC and You", Abstract = "An amazing session about MVC", Speaker = christopher });
			context.Sessions.Add(new Session() 
				{ Title = "Apps and SharePoint", Abstract = "The future is here. The time to stop doing farm solutions is now.", Speaker = christopher });

			Speaker susan = context.Speakers.Add(new Speaker() 
				{ FirstName = "Susan", LastName = "Ibach", Email = "sibach@geektrainer.com" });
			context.Sessions.Add(new Session()
				{ Title = "Windows 8", Abstract = "Why you should care about Windows 8 App Development", Speaker = susan });

			try {
				context.SaveChanges();
			} catch (DbEntityValidationException ex) {
				ex.ToString();
			}
		}
	}
}