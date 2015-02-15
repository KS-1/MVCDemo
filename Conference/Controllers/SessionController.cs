using Conference.Models;
using Conference.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Conference.Controllers
{
	[HandleError(ExceptionType = typeof(SqlException), View = "_SqlException")]
	[HandleError(View = "_GenericException")]
	public class SessionController : Controller
	{
		ISessionRepository repository = null;

		public SessionController()
		{
			repository = new SessionRepository();
		}

		public SessionController(ISessionRepository repository)
		{
			this.repository = repository;
		}

		[ChildActionOnly()]
		public PartialViewResult _SpeakerSessions(Int32 speakerID)
		{
			return PartialView(repository.GetBySpeaker(speakerID));
		}

		public ActionResult Details(Int32 id)
		{
			Session session = repository.GetByID(id);
			if (session == null) {
				return HttpNotFound();
			} else {
				ViewBag.Title = session.Title;
				return View("Details", repository.GetByID(id));
			}
		}
	}
}
