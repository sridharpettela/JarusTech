using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JarusTech.API.Data;
using JarusTech.API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace JarusTech.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class PersonController : ControllerBase
	{
		private readonly ILogger<PersonController> _logger;

		public PersonController(ILogger<PersonController> logger)
		{
			_logger = logger;
		}
		[HttpGet("{firstName?}/{lastName?}")]
		public IEnumerable<PersonModel> FindPeople(string firstName = "", string lastName = "")
		{
			return StoredData.personModels.Where(x => (!string.IsNullOrEmpty(firstName) && x.FirstName.ToLower().Contains(firstName.ToLower()))
			|| (!string.IsNullOrEmpty(lastName) && x.LastName.ToLower().Contains(lastName.ToLower())));
		}
	}
}
