using Conference.Models;
using Conference.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Conference.Controllers
{
    public class CommentController : Controller
    {
		CommentRepository repository = new CommentRepository();

		[ChildActionOnly()]
        public PartialViewResult _Index(Int32 sessionID)
        {
            ViewBag.SessionID = sessionID;
			return PartialView("_Index", repository.GetForSession(sessionID));
        }

		[ChildActionOnly()]
		public PartialViewResult _CreateForm(Int32 sessionID)
		{
			ViewBag.SessionID = sessionID;
			Comment comment = new Comment() { SessionID = sessionID };
			return PartialView("_CreateForm", comment);
		}

		// this needs a different name because of a quirk in the Ajax form
		[HttpPost()]
		public PartialViewResult _CreateSubmit(Comment comment)
		{
			ViewBag.SessionID = comment.SessionID;
			repository.Create(comment);
			return PartialView("_Index", repository.GetAll());
		}
    }
}
