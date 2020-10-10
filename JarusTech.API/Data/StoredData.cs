using JarusTech.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JarusTech.API.Data
{
	public sealed class StoredData
	{

		private StoredData()
		{
		}
		private static StoredData instance = null;
		public static StoredData Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new StoredData();
				}
				return instance;
			}
		}


		public static List<QuoteModel> quotes = new List<QuoteModel>()
		{
			new QuoteModel(){
			QuoteNumber="Q92348",
			QuoteStatus="",
			Applicant ="James Feather LLC",
			QuoteDate= Convert.ToDateTime("2020-07-14"),
			QuoteEffDate=  Convert.ToDateTime("2020-07-20"),
			},
			new QuoteModel(){
			QuoteNumber="Q92349",
			QuoteStatus="",
			Applicant ="James Feather LLC",
			QuoteDate= Convert.ToDateTime("2020-07-15"),
			QuoteEffDate=  Convert.ToDateTime("2020-07-21"),
			}
		};


		public static List<PersonModel> personModels = new List<PersonModel>()
		{
			new PersonModel()
			{
				PersonId=1,
				Title="Mr.",
				FirstName="James",
				LastName="Feather",
				DOB=Convert.ToDateTime("1980-03-01"),
			},
			new PersonModel()
			{
				PersonId=2,
				Title="Mr.",
				FirstName="John",
				LastName="Krakow",
				DOB=Convert.ToDateTime("1983-02-10"),
			},
			new PersonModel()
			{
				PersonId=3,
				Title="Mr.",
				FirstName="Red",
				LastName="Hemmington",
				DOB=Convert.ToDateTime("1984-05-17"),
			}
		};

		public static List<InsPersonModel> insPersonModels = new List<InsPersonModel>()
		{
			new InsPersonModel(){
			InsPersonId=1,
			Person= new PersonModel(){ PersonId=1 },
			QuoteNumber="Q92349",
			Coverage=35
			}
		};

	}
}
