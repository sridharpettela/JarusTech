using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JarusTech.API.Data;
using JarusTech.API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace JarusTech.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class QuoteController : ControllerBase
	{


		private readonly ILogger<QuoteController> _logger;

		public QuoteController(ILogger<QuoteController> logger)
		{
			_logger = logger;
		}

		[HttpGet("{quoteNo}")]
		public QuoteModel Get(string quoteNo)
		{
			return StoredData.quotes.FirstOrDefault(x => x.QuoteNumber == quoteNo);
		}
		[HttpGet()]
		public List<QuoteModel> GetAll()
		{
			return StoredData.quotes;
		}

	}

}
