using Conference.Models;
using Conference.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Conference.Controllers
{
	public class SpeakerApiController : ApiController
	{
		SpeakerRepository repository = new SpeakerRepository();

		// GET api/<controller>
		public IEnumerable<Speaker> Get()
		{
			return repository.GetAll();
		}

		// GET api/<controller>/5
		public Speaker Get(int id)
		{
			return repository.GetByID(id);
		}
	}
}