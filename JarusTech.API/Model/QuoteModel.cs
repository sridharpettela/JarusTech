using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JarusTech.API.Model
{
	public class QuoteModel
	{
		public string QuoteNumber { get; set; }
		public string QuoteStatus { get; set; }
		public string Applicant { get; set; }
		public DateTime QuoteDate { get; set; }
		public DateTime QuoteEffDate { get; set; }
		public string PremiumOptions { get; set; }
	}
}
