using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class PersonController : ControllerBase
	{
		private readonly IPersonService _personService;
		private readonly IConfiguration _configuration;

		public PersonController(IPersonService personService, IConfiguration configuration)
		{
			_personService = personService;
			_configuration = configuration;
		}

		[HttpPost]
		public Person CreatePersons()
		{
			return _personService.CreatePersons();
		}

		[HttpGet]
		public Person GetPersons()
		{
			return _personService.GetFirstPerson();
		}

		[HttpPut]
		public KeyValuePair<string, string>[] Config()
		{
			return _configuration.AsEnumerable().ToArray();
		}
	}
}
