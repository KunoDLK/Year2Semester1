﻿using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Events.Models
{
    public class Venue
    {
        [Key, MaxLength(5)]
        public string Code { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int Capacity { get; set; }
    }
}
