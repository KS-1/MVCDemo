using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Conference.Models.Repositories
{
	public class CommentRepository : Repository<Comment>
	{
		public List<Comment> GetForSession(Int32 sessionID)
		{
			return Set.Where(c => c.SessionID == sessionID).ToList();
		}
	}
}