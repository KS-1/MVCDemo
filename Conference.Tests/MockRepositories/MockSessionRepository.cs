using Conference.Models;
using Conference.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conference.Tests.MockRepositories
{
	public class MockSessionRepository : ISessionRepository
	{
		List<Session> sessions = null;

		public MockSessionRepository()
		{
			sessions = new List<Session>() {
				new Session() { SessionID = 1, Title = "Some Title", Abstract = "Description goes here.", SpeakerID = 1 },
				new Session() { SessionID = 2, Title = "Another Title", Abstract = "Another description goes here.", SpeakerID = 2 },
				new Session() { SessionID = 3, Title = "Yet Another Title", Abstract = "I'm not overly creative.", SpeakerID = 1 },
			};
		}

		public Models.Session GetByID(int id)
		{
			return sessions.SingleOrDefault(s => s.SessionID == id);
		}

		public List<Models.Session> GetBySpeaker(int speakerID)
		{
			throw new NotImplementedException();
		}

		public List<Models.Session> GetAll()
		{
			throw new NotImplementedException();
		}

		public void Create(Models.Session session)
		{
			throw new NotImplementedException();
		}

		public void Update(Models.Session session)
		{
			throw new NotImplementedException();
		}

		public void Delete(Models.Session session)
		{
			throw new NotImplementedException();
		}
	}
}
