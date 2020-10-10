using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JarusTech.API.Model
{
	public class InsPersonModel
	{
		public int InsPersonId { get; set; }
		public string QuoteNumber { get; set; }
		public PersonModel Person { get; set; }
		public int Coverage { get; set; }
	}
}
