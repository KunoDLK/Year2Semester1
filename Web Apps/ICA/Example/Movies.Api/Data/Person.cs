using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Movies.Api.Data
{
	public class Person
	{
		public int PersonId { get; set; }

		[Required]
		public string FirstName { get; set; }

		[Required]
		public string LastName { get; set; }

		public DateTime Birthday { get; set; }

		public int NationalityId { get; set; }

		[Required]
		public Nationality Nationality { get; set; }
	}
}
