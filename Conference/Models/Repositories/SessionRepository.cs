using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Conference.Models.Repositories
{
	public class SessionRepository : Repository<Session>, ISessionRepository
	{
		public List<Session> GetBySpeaker(Int32 speakerID)
		{
			return Set.Where(s => s.SpeakerID == speakerID).ToList();
		}
	}
}