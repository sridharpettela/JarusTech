using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JarusTech.API.Model
{
	public class PersonModel
	{
		public int PersonId { get; set; }
		public string Title { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime DOB { get; set; }
	}
}
