using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Conference.Controllers;
using Conference.Tests.MockRepositories;
using System.Web.Mvc;

namespace Conference.Tests
{
	[TestClass]
	public class SessionControllerTests
	{
		private MockSessionRepository repository;
		private SessionController controller;
		
		public SessionControllerTests()
		{
			repository = new MockSessionRepository();
			controller = new SessionController(repository);
		}

		[TestMethod]
		public void SessionController_GetByID_FoundSession()
		{
			// arrange

			// act
			ActionResult result = controller.Details(1);

			// assert
			Assert.IsInstanceOfType(result, typeof(ViewResult));
			ViewResult viewResult = (ViewResult) result;
			Assert.AreEqual("Details", viewResult.ViewName);
		}

		[TestMethod()]
		public void SessionController_GetByID_HttpNotFoundWhenSessionNotFound()
		{
			// arrange

			// act
			ActionResult result = controller.Details(-1);

			// assert
			// returned type is HttpNotFound
			Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult));
		}
	}
}
