﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Events.Models
{
	public class Availability
	{
		[DataType(DataType.Date)]
		public DateTime Date { get; set; }

		[MinLength(5), MaxLength(5)]
		public string VenueCode { get; set; }

		[ForeignKey(nameof(VenueCode))]
		public Venue Venue { get; set; }

		[Range(0.0, Double.MaxValue)]
		public double CostPerHour { get; set; }

		public Reservation Reservation { get; set; }
	}
}
