using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Conference.Models.Repositories
{
	public interface ISessionRepository
	{
		Session GetByID(Int32 id);
		List<Session> GetBySpeaker(Int32 speakerID);
		List<Session> GetAll();
		void Create(Session session);
		void Update(Session session);
		void Delete(Session session);
	}
}