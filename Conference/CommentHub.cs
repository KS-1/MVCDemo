using Conference.Models;
using Conference.Models.Repositories;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Conference
{
	public class CommentHub : Hub
	{
		CommentRepository repository = new CommentRepository();

		// This method will now be available to my clients via javascript
		public void PostComment(String content, String sessionID)
		{
			Comment comment = new Comment() { Content = content, SessionID = Int32.Parse(sessionID) };
			repository.Create(comment);

			// Send signal to people looking at the session page
			// The method that will be called on the client is named "update"
			Clients.Group(sessionID).update(content);
		}

		public void Register(String sessionID)
		{
			Groups.Add(Context.ConnectionId, sessionID);
		}
	}
}