using Conference.Models;
using Conference.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Conference.Controllers
{
	[Authorize()]
    public class SpeakerController : Controller
    {
		private SpeakerRepository repository = new SpeakerRepository();

        //
        // GET: /Speaker/
		[AllowAnonymous()]
        public ActionResult Index()
        {
            ViewBag.Title = "All Speakers";
			return View("Index", repository.GetAll());
        }

		[OutputCache(Duration = 3600)]
		[AllowAnonymous()]
		public ActionResult Details(Int32 id)
		{
			Speaker speaker = repository.GetByID(id);

			if(speaker == null) {
				return HttpNotFound();
			} else {
				ViewBag.Title = speaker.ToString();
				return View("Details", speaker);
			}
		}
		
		// Display form
		public ActionResult Create()
		{
			ViewBag.Title = "Add Speaker";
			return View("SpeakerEditor", new Speaker());
		}

		// Accept the new speaker
		[HttpPost()]
		public ActionResult Create(Speaker speaker)
		{
			return CreateOrEdit(speaker);
		}

		// Display form with current speaker
		public ActionResult Edit(Int32 id)
		{
			Speaker speaker = repository.GetByID(id);

			if(speaker == null) {
				return HttpNotFound();
			} else {
				ViewBag.Title = speaker.ToString();
				return View("SpeakerEditor", speaker);
			}
		}

		// Accept changes to existing speaker
		[HttpPost()]
		public ActionResult Edit(Speaker speaker)
		{
			return CreateOrEdit(speaker);
		}

		private ActionResult CreateOrEdit(Speaker speaker)
		{
			// 1. Confirm the data is valid
			if (!ModelState.IsValid) {
				return View("SpeakerEditor", speaker);
			}

			// 2. Pass the data to the model
			try {
				if(speaker.SpeakerID == 0) repository.Create(speaker);
				else repository.Update(speaker);
			} catch (Exception ex) {
				ModelState.AddModelError("", ex);
				return View("SpeakerEditor", speaker);
			}

			// 3. Display a result
			TempData["Message"] = "Updated " + speaker.ToString();
			return RedirectToAction("Details", new { id = speaker.SpeakerID });
		}
    }
}
