using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JarusTech.API.Data;
using JarusTech.API.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace JarusTech.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class InsPersonController : ControllerBase
	{
		private readonly ILogger<InsPersonController> _logger;
		private readonly Random _random = new Random();

		public InsPersonController(ILogger<InsPersonController> logger)
		{
			_logger = logger;
		}

		[HttpGet("{quoteNo}")]
		public IEnumerable<InsPersonModel> GetAdditionalInsuredsForQuote(string quoteNo)
		{
			return from insPModel in StoredData.insPersonModels
				   join pModel in StoredData.personModels
						on insPModel.Person.PersonId equals pModel.PersonId
				   where insPModel.QuoteNumber == quoteNo
				   select new InsPersonModel()
				   {
					   InsPersonId = insPModel.InsPersonId,
					   Person = pModel,
					   QuoteNumber = insPModel.QuoteNumber,
					   Coverage = insPModel.Coverage
				   };
		}


		[HttpPost()]
		public void AddAdditionalInsured(ReqModel model)
		{
			StoredData.insPersonModels.Add(new InsPersonModel()
			{
				InsPersonId = StoredData.insPersonModels.Count + 1,
				Person = new PersonModel()
				{
					PersonId = model.personId
				},
				QuoteNumber = model.quoteNo,
				Coverage = _random.Next(10, 100)
			});
		}
		[HttpDelete("{insPerId}")]
		public void Delete(int insPerId)
		{
			StoredData.insPersonModels.Remove(StoredData.insPersonModels.FirstOrDefault(x => x.InsPersonId == insPerId));
		}

	}
}
